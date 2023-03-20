using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class SavingAccount:Account
    {
        private static double COST_PER_TRANSACTION = 0.05;
        private static double INTEREST_RATE = 0.015;

        public SavingAccount(double balance = 0, bool hasOverDraft = false) : base("SV-", balance) { }
        public new void Deposit(double amount, Person person)
        {
            foreach (var person1 in base.holders)
            {
                if(person.Name == person1.Name)
                {
                    base.Deposit(amount, person);
                }
            }
        }
        public void Withdraw(double amount, Person person)
        {
            foreach (var person1 in base.holders)
            {
                if (person1.Name != person.Name)
                {
                    throw new AccountException(AccountException.USER_DOES_NOT_EXIST);
                }
                if (!Person.IsAuthenticated)
                {
                    throw new AccountException(AccountException.USER_NOT_LOGGED_IN);
                }
                if (amount > base.Balance)
                {
                    throw new AccountException(AccountException.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
                }
                Deposit(-amount, person);
            }
        }
        public override void PrepareMonthlyReport()
        {
            double service_charge = transactions.Count * COST_PER_TRANSACTION;
            double interest = LowestBalance * INTEREST_RATE / 12;
            Balance += interest - service_charge;
            transactions.Clear();
        }
    }
}
