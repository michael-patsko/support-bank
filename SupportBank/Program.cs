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
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var columns = values[0].Split(',');

                    listA.Add(values[0]);
                }
                listA.ForEach(item => Console.Write($"{item}\n"));
            }
        }
    }
}
