using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class Person
    {
        private string password;
        public readonly string SIN;
        
        public static bool IsAuthenticated { get; private set; }
        public string Name { get; }

        public Person(string name,string sin)
        {
            Name = name;
            SIN = sin;
            password = SIN.Substring(0, 3);
        }
        public void Login(string password)
        {
           if (this.password != password)
            {
                throw new AccountException(AccountException.PASSWORD_INCORRECT);
            }
            IsAuthenticated = true;
        }
        public void Logout()
        {
            IsAuthenticated = false;
        }
        public override string ToString()
        {
            return $"Name: {Name} | Authenticated: {IsAuthenticated}";
        }

    }
}
