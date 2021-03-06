using System.Text.RegularExpressions;
namespace SupportBank
{
    public class Services
    {
        public static void UserPrompt()
        {
            Bank bank = DataReader.ReadData();

            Console.WriteLine("Please select a service: \n" +
            "(1) List All \n" +
            "(2) List[Account]");
            string input = Console.ReadLine();
            string inputPattern = @"List\[.+\]";
            Regex inputRegex = new Regex(inputPattern);
            Match inputMatch = inputRegex.Match(input);

            string namePattern = @"(?<=\[).+(?=\])";
            Regex nameRegex = new Regex(namePattern);
            Match nameMatch = nameRegex.Match(input);

            if (input == "List All" || input == "1")
            {
                ListAll(bank);
            }
            if (input == "2")
            {
                Console.WriteLine("Please enter account name:");
                string accountName = Console.ReadLine();
                ListAccount(accountName, bank);
            }
            if (inputMatch.Success)
            {
                string accountName = nameMatch.Value;
                ListAccount(accountName, bank);
            }
        }
        public static void ListAll(Bank bank)
        {
            decimal TotalBalance = 0M;
            foreach (Account account in bank.UserAccounts)
            {
                Console.WriteLine(account);
                TotalBalance += account.MoneyIn;
                TotalBalance -= account.MoneyOut;
            }
            Console.WriteLine($"Total Balance: £{TotalBalance}");
        }
        public static void ListAccount(string accountName, Bank bank)
        {
            Account accountInfo = bank.GetAccountByName(accountName);
            Console.WriteLine($"Account name : {accountInfo.Name}");
            foreach (Payment payment in accountInfo.Transactions.transactions.Keys)
            {
                Console.WriteLine($"{payment} {accountInfo.Transactions.transactions[payment]}");
            }
        }
    }
}