using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Conversion
{
    public abstract class LengthUnit
    {
        public abstract string Name { get; }

        #region OCP implementation
        public abstract decimal MillimeterConversionFactor { get; }
        #endregion
    }
}
