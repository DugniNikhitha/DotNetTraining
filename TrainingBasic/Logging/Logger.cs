namespace Helpers.Logging
{
    public abstract class Logger
    {
        public delegate string Logs(string message);

        public static void PrintLog(string message)
        {
            Console.WriteLine(message);
        }
        public abstract string LogMessage(string message);
    }
}
