using System;
namespace SupportBank
{
    public class Account
    {
        public string Name { get; }
        public decimal MoneyOut
        {
            get
            {
                decimal result = 0M;
                foreach (var payment in Transactions.transactions.Keys)
                {
                    if (payment.From == this)
                    {
                        result += payment.Amount;
                    }
                }
                return result;
            }
        }
        public decimal MoneyIn
        {
            get
            {
                decimal result = 0M;
                foreach (var payment in Transactions.transactions.Keys)
                {
                    if (payment.To == this)
                    {
                        result += payment.Amount;
                    }
                }
                return result;
            }
        }
        public Transactions Transactions;
        public Account(string name)
        {
            Name = name;
            Transactions = new Transactions();
        }

        public override bool Equals(object obj) => this.Equals(obj as Account);

        public bool Equals(Account account)
        {
            return string.Equals(Name, account.Name);
        }

        public override int GetHashCode() => (Name).GetHashCode();

        public static bool operator ==(Account lhs, Account rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Account lhs, Account rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Name}, MoneyIn: £{MoneyIn}, MoneyOut: £{MoneyOut}, Total balance: £{MoneyIn - MoneyOut}";
        }
    }
}