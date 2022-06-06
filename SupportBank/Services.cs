using System;
namespace SupportBank
{
    public class Services
    {
        public static void UserPrompt()
        {
            Bank bank = DataReader.ReadData();

            Console.WriteLine("Please select a service: \n" +
            "(1) List All");
            string input = Console.ReadLine();

            if (input == "List All" || input == "1")
            {
                ListAll(bank);
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
    }
}