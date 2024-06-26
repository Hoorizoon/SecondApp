using System.ComponentModel;

namespace ConsoleApp1
{
    internal class Program
    {
        private static List<Account> Accounts = new List<Account>();
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
            Accounts.Add(account);
        }


        static void LogIn()
        {
            bool w = true;
            while (w)
            {
                Console.Write("Podaj login: ");
                var login = Console.ReadLine();
                Console.Write("Podaj haslo: ");
                var Haslo = Console.ReadLine();
                var acc = Accounts.Where(x => x.Login == login && x.Password == Haslo).FirstOrDefault();
                if (acc != null)
                {
                    w = false;
                    Console.WriteLine("AAAAAAAA");

                }
                else {
                    Console.Clear();
                    Console.WriteLine("Błędne hasło lub login!");

                }
            }

            //bool IsUser = false;    
            //foreach (var account in Accounts) {
            //    if (account.Login == login && account.Password == Haslo)
            //    {
            //        Console.WriteLine("Pomyślnie zalogowano!:)");
            //        IsUser = true;
            //        break;
            //    }
            //}
        }
    }
}
