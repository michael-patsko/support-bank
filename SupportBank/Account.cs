using System;
namespace SupportBank
{
    public class Account
    {
        public string Name { get; }
        public decimal AmountOwed
        {
            get;
        }
        public decimal OwedTo { get; }
        public List<Transactions> Transactions;
        public Account(string name)
        {
            Name = name;
            AmountOwed = 0;
            OwedTo = 0;
            Transactions = new List<Transactions>();
        }
        public override bool Equals(object obj) => this.Equals(obj as Account);
        public bool Equals(Account account)
        {
            return string.Equals(Name, account.Name);
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}