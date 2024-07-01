using System.Security.Principal;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                int select;
                Console.WriteLine("1.Zaloguj");
                Console.WriteLine("2.Zarejestruj");
                select = Convert.ToInt32(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        LogIn();
                        
                        break;
                    case 2:
                        CreateUser();
                        break;
                }
            }
        }
        static void CreateUser()
        {
            string login = "", haslo = "", haslo2 = "";
            bool passwordcorrect = false;
            while (passwordcorrect == false)
            {
                Console.Write("Podaj login: ");
                login = Console.ReadLine();
                Console.Write("Podaj haslo: ");
                haslo = Console.ReadLine();
                Console.Write("Powtórz haslo: ");
                haslo2 = Console.ReadLine();
                if (haslo != haslo2)
                {

                    Console.WriteLine("Hasła nie są takie same!");
                }
                else
                {
                    passwordcorrect = true;
                }
            }
            var account = new Account(login, haslo);
            //Accounts.Add(account);
            SaveAcc(account);
            Console.Clear();
        }


        static bool LogIn()
        {   
            bool a = false;
            bool w = true;
            int iloscprob = 0;
            while (w)
            {
                Console.Write("Podaj login: ");
                var login = Console.ReadLine();
                Console.Write("Podaj haslo: ");
                var Haslo = Console.ReadLine();
                var acc = LoadAcc().Where(x => x.Login == login && x.Password == Haslo).FirstOrDefault();
                var possiblelogin = LoadAcc().Where(x => x.Login == login).FirstOrDefault();

                if (possiblelogin != null)
                {

                    if (acc != null)
                    {
                        w = false;
                        Console.Clear();
                        Console.WriteLine("Pomyślnie zalogowano!:)");
                        a = true;

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Błędne hasło lub login!");
                        a = false;
                        iloscprob++;
                        if (possiblelogin.BlockTime > DateTime.Now)
                        {
                            Console.WriteLine($"Twoje konto jest zablokowane do: {possiblelogin.BlockTime.ToString()}");
                        }
                        if (iloscprob == 3)
                        {
                            possiblelogin.BlockTime = DateTime.Now.AddMinutes(10);

                        }

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Błędny login lub hasło!");
                }
            }

            return a;
        }
        public static long MaxInt(List<Account> accounts)
        {
            long maxid = 0;
            foreach (var acc in accounts)
            {
                if (maxid < acc.Id)
                {
                    maxid = acc.Id;
                }

            }
            return maxid++;
        }
        public static void SaveAcc(Account account)
        {
            string filepath = "C:\\Users\\PC\\Desktop\\Programowanie\\ConsoleApp2\\ConsoleApp1\\Acc.txt";
            var sw = new StreamWriter(filepath);
            string konto = MaxInt(LoadAcc()) + "|" + account.Login + "|" + account.Password + "|" +
                account.IsAdmin + "|" + account.IsActive + "|" + account.BlockTime;
            sw.WriteLine(konto);
            sw.Close();
        }
        public static List<Account> LoadAcc() 
        {
            string filepath = "C:\\Users\\PC\\Desktop\\Programowanie\\ConsoleApp2\\ConsoleApp1\\Acc.txt";
            List<Account> acc = new List<Account>();
            using (var sr = new StreamReader(filepath))
            {
                
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    acc.Add(GetAccount(line));
                }
                
            }
            return acc;
        }
        public static Account GetAccount(string line)
        {
            var elements = line.Split('|');
            var Account = new Account();
            Account.Id = Convert.ToInt64(elements[0]);
            Account.Login = (elements[1]);
            Account.Password = (elements[2]);
            Account.IsAdmin = Convert.ToBoolean(elements[3]);
            Account.IsActive = Convert.ToBoolean(elements[4]);
            Account.BlockTime = Convert.ToDateTime(elements[5]);
            return Account;
        }
        
    }
}
