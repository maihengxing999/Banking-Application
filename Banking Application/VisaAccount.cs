using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class VisaAccount:Account
    {
        private static double INTEREST_RATE = 0.1995;
        private double creditLimit;
        public VisaAccount(double balance=0,double creditLimit = 1200): base("VS-",balance)
        {
            this.creditLimit = creditLimit;
        }
        public void DoPayment(double amount, Person person)
        {
            base.Deposit(amount, person);
        }
        public void DoPurchase(double amount,Person person)
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
                if (amount > creditLimit)
                {
                    throw new AccountException(AccountException.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
                }
                Deposit(-amount, person);
            }
        }
        public override void PrepareMonthlyReport()
        {
            double interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance -= interest;
            transactions.Clear();
        }
    }
}
