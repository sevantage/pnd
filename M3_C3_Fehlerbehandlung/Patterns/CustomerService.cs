using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class CustomerService
    {
        private readonly CustomerRepository custRepos;

        public CustomerService(CustomerRepository custRepos)
        {
            this.custRepos = custRepos;
        }

        public void Create(string no, string name)
        {
            try
            {
                // Validate...
                custRepos.Insert(no, name);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating customer", ex);
            }
        }
    }
}
