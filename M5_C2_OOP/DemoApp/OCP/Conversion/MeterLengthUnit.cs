using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Conversion
{
    public class MeterLengthUnit : LengthUnit
    {
        public override string Name => "m";

        #region OCP implementation
        public override decimal MillimeterConversionFactor => 1000m;
        #endregion
    }
}
