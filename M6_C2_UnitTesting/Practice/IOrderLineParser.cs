using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public interface IOrderLineParser
    {
        Order Parse(string line);
    }
}
