using DemoApp.BusinessLogic.AbstractRepositories;
using DemoApp.DataAccess;
using DemoApp.DataAccess.DemoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Factories
{
    public static class RepositoryFactory
    {
        public static ICustomerRepository GetCustomerRepository(bool isDemo)
        {
            if (isDemo)
                return new DemoCustomerRepository();
            return new CustomerRepository();
        }
    }
}
