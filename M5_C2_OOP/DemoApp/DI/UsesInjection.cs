using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.DI
{
    class UsesInjection
    {
        private readonly Logger logger;

        public UsesInjection(Logger logger)
        {
            this.logger = logger;
        }

        public void DoSomething()
        {
            logger.Log("Some message");
        }
    }
}
