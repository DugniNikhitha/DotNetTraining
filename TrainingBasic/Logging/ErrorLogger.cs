using System.Text;

namespace Helpers.Logging
{
    public class ErrorLogger : Logger
    {
        Logs log = ErrorMessage;
        static StringBuilder Error = new StringBuilder(LoggerLevel.ERROR.ToString());

        public override string LogMessage(string message)
        {
            return log(message);
        }

        public static string ErrorMessage(string message)
        {
            return Error.Append(message).ToString();
        }
    }
}
