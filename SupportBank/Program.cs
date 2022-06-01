using System;
using System.IO;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Transactions transactionsList = DataReader.ReadData();
            foreach (var payment in transactionsList.transactions.Keys)
            {
                Console.WriteLine(payment);
            }
        }
    }
}
