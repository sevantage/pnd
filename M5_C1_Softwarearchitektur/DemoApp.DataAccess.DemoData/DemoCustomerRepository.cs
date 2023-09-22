using DemoApp.BusinessLogic.AbstractRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Crosscut;

namespace DemoApp.DataAccess.DemoData
{
    public class DemoCustomerRepository : ICustomerRepository
    {
        public IEnumerable<CustomerEntity> GetAll(ILogger logger)
        {
            logger.Log("Reading customers from demo data repository...");
            return Enumerable.Range(101, 110)
                .Select(x => new CustomerEntity() { Id = x, Name = "Demo Customer " + x.ToString("0000") });
        }
    }
}
