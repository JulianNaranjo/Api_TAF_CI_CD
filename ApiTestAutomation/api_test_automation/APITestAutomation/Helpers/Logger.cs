using log4net;

namespace TestAutomationFramework.Helpers
{
    public class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        public static void LogInfo(string message) => log.Info(message);
        public static void LogWarn(string message) => log.Warn(message);
        public static void LogError(string message, Exception e) => log.Error(message, e);
    }
}
