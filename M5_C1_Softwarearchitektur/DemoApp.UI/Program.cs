using DemoApp.BusinessLogic;
using DemoApp.Crosscut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            logger.Log("Starting program...");
            var svc = new CustomerService();
            foreach (var cust in svc.GetAll(logger))
                Console.WriteLine("{0} - {1}", cust.Id, cust.Name);
            Console.ReadLine();
            logger.Log("Terminating program.");
        }

        private class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
