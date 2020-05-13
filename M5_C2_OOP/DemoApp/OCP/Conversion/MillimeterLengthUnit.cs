using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Conversion
{
    public class MillimeterLengthUnit : LengthUnit
    {
        public override string Name => "mm";

        #region OCP implementation
        public override decimal MillimeterConversionFactor => 1m;
        #endregion
    }
}
