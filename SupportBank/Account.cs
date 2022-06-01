using System;
namespace SupportBank
{
    public class Account
    {
        public string Name { get; }
        public Account(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}