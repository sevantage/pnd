using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemoApp
{
    class Program
    {
        private static IKernel kernel = SetupKernel();

        static void Main(string[] args)
        {
            var cls = kernel.Get<SomeClass>();
            cls.DoSomething();
            Console.ReadLine();
        }

        private static IKernel SetupKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ILogger>().To<ConsoleLogger>().InSingletonScope();
            return kernel;
        }
    }

    interface ILogger
    {
        void Log(string msg);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    class SomeClass
    {
        private readonly ILogger logger;

        public SomeClass(ILogger logger)
        {
            this.logger = logger;
        }

        public void DoSomething()
        {
            logger.Log("Did something");
        }
    }
}
