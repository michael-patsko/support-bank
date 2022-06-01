using System;
namespace SupportBank
{
    public class Payment
    {
        public Account From;
        public Account To;
        public DateTime DateTime;
        public decimal Amount;
        public Payment(Account from, Account to, DateTime dateTime, decimal amount)
        {
            From = from;
            To = to;
            DateTime = dateTime;
            Amount = amount;
        }
        public override string ToString()
        {
            return $"From: {From} To: {To} Date: {DateTime} Amount: {Amount}";
        }
    }
}
