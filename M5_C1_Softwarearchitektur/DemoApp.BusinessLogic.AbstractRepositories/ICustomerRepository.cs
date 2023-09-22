using DemoApp.Crosscut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.BusinessLogic.AbstractRepositories
{
    public class CustomerEntity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface ICustomerRepository
    {
        IEnumerable<CustomerEntity> GetAll(ILogger logger);
    }
}
