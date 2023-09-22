using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticTypes
{
    class GrossPrice
    {
        private readonly decimal value;

        public GrossPrice(decimal value)
        {
            this.value = value;
        }

        public decimal Value { get { return value; } }
    }
}
