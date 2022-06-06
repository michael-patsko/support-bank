using System;

namespace SupportBank
{
    public class Bank
    {
        public List<Account> UserAccounts{get ;}
        public Bank()
        {
            UserAccounts = new List<Account>();
        }
    }
}