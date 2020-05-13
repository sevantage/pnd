using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.DI
{
    class Logger
    {
        public virtual void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
