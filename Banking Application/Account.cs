using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    abstract class Account
    {
        private static int CURRENT_NUMBER = 100000;
        public List<Transaction> transactions = new List<Transaction>();
        public readonly List<Person> holders = new List<Person>();
        public readonly string Number;

        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }
        public Account(string type, double balance)
        {
            Balance = balance;
            LowestBalance = balance;
            Number = string.Concat(type, CURRENT_NUMBER);
            CURRENT_NUMBER++;
        }
        public void AddUser(Person person)
        {
            holders.Add(person);
        }
        public void Deposit(double amount, Person person)
        {
            Balance += amount;
            LowestBalance = Balance;
            Transaction transaction = new Transaction(Number, amount,Balance, person, DateTime.Now);
        }
        public bool IsHolder(string name)
        {
            foreach (var person in holders)
            {
                if (person.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public abstract void PrepareMonthlyReport();

        public override string ToString()
        {
            string display = $"Account: {Number}\n";
            display += "Users:\n";
            foreach (var user in holders)
            {
                display += $"--{user.Name}\n";
            }

            display += $"Balance: {Balance}";
            display += $"Transction:\n";
            foreach (var transaction in transactions)
            {
                display += $"--Amount{transaction.Amount}|--{transaction.Date}|--{transaction.EndBalance}";
            }

            return display;
        }
       

    }
}
