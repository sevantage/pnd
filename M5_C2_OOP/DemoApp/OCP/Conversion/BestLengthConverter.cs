using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Conversion
{
    public class BestLengthConverter : ILengthConverter
    {
        public decimal Convert(decimal value, LengthUnit fromUnit, LengthUnit toUnit)
        {
            return value 
                * fromUnit.MillimeterConversionFactor 
                / toUnit.MillimeterConversionFactor;
        }
    }
}
