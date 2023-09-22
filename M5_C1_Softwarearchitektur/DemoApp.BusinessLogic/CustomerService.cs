using DemoApp.BusinessLogic.AbstractRepositories;
using DemoApp.Crosscut;
using DemoApp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.BusinessLogic
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CustomerService
    {
        private readonly ICustomerRepository repos = RepositoryFactory.GetCustomerRepository(false);
        public IEnumerable<Customer> GetAll(ILogger logger)
        {
            logger.Log("Getting all customers...");
            return from x in repos.GetAll(logger) select new Customer() { Id = x.Id, Name = x.Name };
        } 
    }
}
