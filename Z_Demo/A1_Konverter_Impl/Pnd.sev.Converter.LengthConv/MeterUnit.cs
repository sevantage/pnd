using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pnd.sev.Converter.LengthConv
{
    internal class MeterUnit : LengthUnit
    {
        public MeterUnit() : base("Meter")
        {
        }

        public override decimal InMeters => 1m;
    }
}
