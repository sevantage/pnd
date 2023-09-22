using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pnd.sev.Converter.LengthConv
{
    internal class MileUnit : LengthUnit
    {
        public MileUnit() : base("Meilen")
        {
        }

        public override decimal InMeters => 1609.344m;
    }
}
