using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class AccountException : Exception
    {
        public const string ACCOUNT_DOES_NOT_EXIST = "There is no such account in our system.";
        public const string CREDIT_LIMIT_HAS_BEEN_EXCEEDED = "Your credit limit has been exceeded.";
        public const string NAME_NOT_ASSOCIATED_WITH_ACCOUNT = "The name is not assiciated with the account.";
        public const string NO_OVERDRAFT = "There is no overdraft in the account.";
        public const string PASSWORD_INCORRECT = "The password is not correct.";
        public const string USER_DOES_NOT_EXIST = "There is no such user in our system.";
        public const string USER_NOT_LOGGED_IN = "The user is not logged in.";

        public AccountException() { }
        public AccountException(string reason):base(reason)
        {
            
        }

    }
}
