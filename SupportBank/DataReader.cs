using System.IO;
namespace SupportBank

{
    public class DataReader
    {
        public static Bank ReadData()
        {
            using (var sr = new StreamReader(@"..\Transactions2014.csv"))
            {
                Bank bank = new Bank();

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(';');
                    var columns = values[0].Split(',');

                    Account fromAccount = new Account(columns[1]);
                    Account toAccount = new Account(columns[2]);
                    Payment newPayment = new Payment(fromAccount, toAccount, DateTime.Parse(columns[0]), decimal.Parse(columns[4]));
                    string newDescription = columns[3];

                    bool fromAccountExists = false;
                    bool toAccountExists = false;
                    foreach (Account bankAccount in bank.UserAccounts)
                    {

                        if (fromAccount == bankAccount)
                        {
                            bankAccount.Transactions.transactions.Add(newPayment, newDescription);
                            fromAccountExists = true;
                        }

                        if (toAccount == bankAccount)
                        {
                            bankAccount.Transactions.transactions.Add(newPayment, newDescription);
                            toAccountExists = true;
                        }
                    }
                    if (!fromAccountExists)
                    {
                        fromAccount.Transactions.transactions.Add(newPayment, newDescription);
                        bank.UserAccounts.Add(fromAccount);
                    }
                    if (!toAccountExists)
                    {
                        toAccount.Transactions.transactions.Add(newPayment, newDescription);
                        bank.UserAccounts.Add(toAccount);
                    }
                }

                return bank;
            }
        }
    }
}