using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Decorator
{
    class MyClass
    {
        public MyClass(ILogger logger)
        {
            this.Logger = logger;
        }

        public ILogger Logger { get; set; }

        public void DoSomething()
        {
            Logger.Log("Doing something...");
            // Do something
            Logger.Log("Did something.");
        }
    }
}
