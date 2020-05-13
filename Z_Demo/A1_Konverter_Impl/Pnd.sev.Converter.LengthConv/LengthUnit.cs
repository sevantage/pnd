using Pnd.sev.Converter.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pnd.sev.Converter.LengthConv
{
    internal abstract class LengthUnit : Unit
    {
        public LengthUnit(string name) : base(name)
        {
        }

        public abstract decimal InMeters { get; }
    }
}
