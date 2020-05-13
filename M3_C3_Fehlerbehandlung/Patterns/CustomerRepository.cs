using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class CustomerRepository
    {
        public void Insert(string no, string name)
        {
            throw new Exception("Database access exception with lots of technical details...");
        }
    }
}
