using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class Transaction
    {
        public string AccountNumber { get; }
        public double Amount { get; }
        public double EndBalance { get; }
        public Person Origniator { get; }
        public DateTime Date { get; }
        public Transaction(string accountnumber,double amount, double endBalance, Person person,DateTime time)
        {
            AccountNumber = accountnumber;
            Amount = amount;
            EndBalance = endBalance;
            Origniator = person;
            Date = time;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber} | Name: {Origniator.Name} | Amount: {Amount} | ";
        }
    }
}
