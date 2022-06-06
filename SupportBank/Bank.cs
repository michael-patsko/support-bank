using System.Linq;

namespace SupportBank
{
    public class Bank
    {
        public List<Account> UserAccounts { get; }
        public Bank()
        {
            UserAccounts = new List<Account>();
        }
        public Account GetAccountByName(string name)
        {
            return UserAccounts
                .Where(account => account.Name == name)
                .Single();
        }
    }
}