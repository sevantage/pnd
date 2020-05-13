using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib
{
    public class Multiplicator
    {
        private readonly Calculator calc;

        public Multiplicator(Calculator calc)
        {
            this.calc = calc;
        }

        public IEnumerable<int> DuplicateAll(IEnumerable<int> values)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            return values.Select(x => calc.Add(x, x));
        }

        public object TriplicateAll(IEnumerable<int> values)
        {
            return values.Select(x => calc.Add(x, x, x));
        }
    }
}
