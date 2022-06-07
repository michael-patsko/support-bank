using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    public class Program
    {

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Training\Support-Bank\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            Logger.Info("Starting Program.cs");
            Services.UserPrompt();
        }
    }
}
