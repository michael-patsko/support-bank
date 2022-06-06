using System;
using System.IO;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bank bank = DataReader.ReadData();

            Console.WriteLine("Please select a service: \n" +
            "(1) List All");
            string input = Console.ReadLine();

            if (input == "List All" || input == "1")
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
}
