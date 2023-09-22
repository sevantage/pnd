using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = GetCustomers();
            foreach (var cust in customers)
                ProcessCustomer(cust);
            Console.ReadLine();
        }

        private static void ProcessCustomer(Customer cust)
        {
            if (cust.Id == 37)
            {
                try
                {
                    throw new Exception("Error processing customer 37");
                }
                catch
                { }
            }
            else if (cust.Name == "Customer 0098")
                Console.WriteLine("Processing customer 98 in a special way...");
            else
                Console.WriteLine("Processing customer {0}...", cust.Id);
        }

        static IEnumerable<Customer> GetCustomers()
        {
            return Enumerable.Range(1, 100)
                .Select(x => new DemoDebugging.Customer() { Id = x, Name = "Customer " + x.ToString("0000") })
                .ToArray();
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
