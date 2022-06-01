using System.IO;
namespace SupportBank

{
    public class DataReader
    {
        public static Transactions ReadData()
        {
            using (var sr = new StreamReader(@"..\Transactions2014.csv"))
            {
                List<DateTime> dates = new List<DateTime>();
                List<Account> from = new List<Account>();
                List<Account> to = new List<Account>();
                List<decimal> amount = new List<decimal>();
                List<string> description = new List<string>();

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(';');
                    var columns = values[0].Split(',');
                    dates.Add(DateTime.Parse(columns[0]));

                    Account fromAccount = new Account(columns[1]);
                    from.Add(fromAccount);

                    Account toAccount = new Account(columns[2]);
                    to.Add(toAccount);

                    description.Add(columns[3]);
                    amount.Add(decimal.Parse(columns[4]));
                }

                int length = from.Count();
                Transactions transactions = new Transactions();

                for (int i = 0; i < length; i++)
                {
                    Payment payment = new Payment(from[i], to[i], dates[i], amount[i]);
                    transactions.transactions.Add(payment, description[i]);
                }
                return transactions;
            }
        }
    }
}