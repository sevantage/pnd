using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Conversion
{
    public class KilometerLengthUnit : LengthUnit
    {
        public override string Name => "km";

        #region OCP implementation
        public override decimal MillimeterConversionFactor => 1000000m;
        #endregion
    }
}
