using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking_Application
{
    class CheckingAccount : Account   
    {
        private static double COST_PER_TRANSACTION = 0.05;
        private static double INTEREST_RATE = 0.005;
        private bool hasOverdraft;
        public CheckingAccount(double balance = 0, bool hasOberdraft = false):base("CK-",balance)
        {
            this.hasOverdraft = hasOberdraft;
        }
        public new void Deposit (double amount, Person person)
        {
            foreach (var person1 in base.holders)
            {
                if ( person.Name == person1.Name)
                {
                    base.Deposit(amount,person1);
                }
            }
        }
        public void Withdraw(double amount, Person person)  
        {
            foreach(var person1 in base.holders)
            {
                if (person1.Name != person.Name)
                {
                    throw new AccountException(AccountException.USER_DOES_NOT_EXIST);
                }
                if (!Person.IsAuthenticated) 
                {
                    throw new AccountException(AccountException.USER_NOT_LOGGED_IN);
                }
                if (amount > base.Balance && !hasOverdraft)
                {
                    throw new AccountException(AccountException.NO_OVERDRAFT);
                }
                Deposit(-amount,person);
            }
        }
        public override void PrepareMonthlyReport()
        {
            double service_charge = transactions.Count * COST_PER_TRANSACTION;
            double interest = (Balance * INTEREST_RATE)/12;
            Balance += interest - service_charge;
            transactions.Clear();
        }
    }
}
