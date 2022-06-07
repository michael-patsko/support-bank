using System;
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
            //string accountName = input.Substring(4, input.Length - 6);

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