using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.DI
{
    class DoesNotUseInjection
    {
        private readonly Logger logger = new Logger();

        public void DoSomething()
        {
            logger.Log("Some message");
        }
    }
}
