using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Decorator
{
    class RedForegroundColorDecorator : ILogger
    {
        private readonly ConsoleLogger decoratedLogger;

        public RedForegroundColorDecorator(ConsoleLogger decoratedLogger)
        {
            this.decoratedLogger = decoratedLogger;
        }

        public void Log(string msg)
        {
            var savedColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            try
            {
                decoratedLogger.Log(msg);
            }
            finally
            {
                Console.ForegroundColor = savedColor;
            }
        }
    }
}
