using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib
{
    public class Calculator
    {
        public virtual int Add(params int[] operands)
        {
            return operands.Sum();
        }
    }
}
