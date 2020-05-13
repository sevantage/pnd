using DemoApp.BusinessLogic.AbstractRepositories;
using DemoApp.Crosscut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<CustomerEntity> GetAll(ILogger logger)
        {
            logger.Log("Reading customers from data store...");
            return Enumerable.Range(1, 10)
                .Select(x => new CustomerEntity() { Id = x, Name = "Customer " + x.ToString("0000") });
        }
    }
}
