using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Decorator
{
    class ConsoleLogger : ILogger
    {
        public virtual void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
