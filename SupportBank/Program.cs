using System;
using System.IO;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Transaction transaction = new Transaction();
            using (var reader = new StreamReader(@"..\Transactions2014.csv"))
            {
                List<string> dates = new List<string>();
                List<string> from = new List<string>();
                List<string> to = new List<string>();
                List<string> amount = new List<string>();
                List<string> description = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var columns = values[0].Split(',');
                    dates.Add(columns[0]);
                    from.Add(columns[1]);
                    to.Add(columns[2]);
                    amount.Add(columns[3]);
                    description.Add(columns[4]);
                }
                // Console.WriteLine(dates);
                from.ForEach(item => Console.WriteLine(item));
            }
        }
    }
}
