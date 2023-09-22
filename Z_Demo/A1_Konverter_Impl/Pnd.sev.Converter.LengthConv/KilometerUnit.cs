using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pnd.sev.Converter.LengthConv
{
    internal class KilometerUnit : LengthUnit
    {
        public KilometerUnit() : base("Kilometer")
        {
        }

        public override decimal InMeters => 1000m;
    }
}
