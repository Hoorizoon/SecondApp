using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Account
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive {  get; set; }
        public DateTime BlockTime { get; set; }
        public Account(string login, string password) { 
            Login = login;
            Password = password;
            IsActive = true;
            IsAdmin = false;
        }
    }
}
