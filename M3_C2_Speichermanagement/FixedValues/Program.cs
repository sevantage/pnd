using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedValues
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var msg in GetLogMessages())
            {
                Console.ForegroundColor = msg.Level.Color;
                Console.WriteLine("{0} ({1})", msg.Text, msg.Level.Text);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }

        static IEnumerable<LogMessage> GetLogMessages()
        {
            return Enumerable.Range(1, 1000)
                .Select(x => new LogMessage() { Text = "Message " + x.ToString(), Level = GetLogLevel(x) })
                .ToArray();
        }

        private static LogLevel GetLogLevel(int x)
        {
            if (x % 2 == 0)
                return LogLevel.Default;
            return LogLevel.Important;
        }
    }

    class LogMessage
    {
        public string Text { get; set; }
        public LogLevel Level { get; set; }
    }

    class LogLevel
    {
        private static LogLevel defaultLogLevel = new LogLevel("Default", ConsoleColor.Gray);
        private static LogLevel importantLogLevel = new LogLevel("Important", ConsoleColor.Red);
        private readonly string text;
        private readonly ConsoleColor color;

        private LogLevel(string text, ConsoleColor color)
        {
            this.text = text;
            this.color = color;
        }

        public static LogLevel Default { get { return defaultLogLevel; } }
        public static LogLevel Important { get { return importantLogLevel; } }

        public string Text { get { return text; } }
        public ConsoleColor Color { get { return color; } }
    }
}
