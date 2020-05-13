using System;

namespace FileConverter
{
    class ConsoleLogger : ILogger
    {
        public void WriteToLog(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

