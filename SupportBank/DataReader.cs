using NLog;

namespace SupportBank
{
    public class DataReader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public static Bank ReadData()
        {
            using (var sr = new StreamReader(@"..\DodgyTransactions2015.csv"))
            {
                Bank bank = new Bank();

                sr.ReadLine();
                int counter = 2;
                Logger.Info("Reading data...");
                while (!sr.EndOfStream)
                {
                    Logger.Info($"Reading line {counter}.");
                    var line = sr.ReadLine();
                    var values = line.Split(';');
                    var columns = values[0].Split(',');

                    DateTime paymentDate = new DateTime();
                    try
                    {
                        paymentDate = DateTime.Parse(columns[0]);
                    }
                    catch (FormatException err)
                    {
                        Logger.Error($"Error on line {counter}. DateTime: {columns[0]}");
                        Console.WriteLine($"Invalid date format in CSV on line {counter}.");
                        throw err;
                    }
                    Account fromAccount = new Account(columns[1]);
                    Account toAccount = new Account(columns[2]);
                    string newDescription = columns[3];

                    decimal paymentAmount = new decimal();
                    try
                    {
                        paymentAmount = decimal.Parse(columns[4]);
                    }
                    catch (FormatException err)
                    {
                        Logger.Error($"Error on line {counter}. Amount: {columns[4]}");
                        Console.WriteLine($"Invalid decimal format in CSV on line {counter}.");
                        throw err;
                    }

                    Payment newPayment = new Payment(fromAccount, toAccount, paymentDate, paymentAmount);

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
                    counter += 1;
                }

                return bank;
            }
        }
    }
}