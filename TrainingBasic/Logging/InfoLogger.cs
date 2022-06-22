using System.Text;

namespace Helpers.Logging
{
    public class InfoLogger : Logger
    {
        Logs log = InfoMessage;
        static string Info = new String($"{LoggerLevel.INFO}: ");

        public override string LogMessage(string message)
        {
            return log(message);
        }

        public static string InfoMessage(string message)
        {
            return (Info + message);
        }
    }
}
