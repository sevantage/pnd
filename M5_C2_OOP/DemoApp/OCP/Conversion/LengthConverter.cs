using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Conversion
{
    public class LengthConverter : ILengthConverter
    {
        public decimal Convert(decimal value, LengthUnit fromUnit, LengthUnit toUnit)
        {
            if (fromUnit is MillimeterLengthUnit && toUnit is MeterLengthUnit)
                return value / 1000;
            else if (fromUnit is MillimeterLengthUnit && toUnit is KilometerLengthUnit)
                return value / 1000000;
            else if (fromUnit is MeterLengthUnit && toUnit is KilometerLengthUnit)
                return value / 1000;
            else if (fromUnit is KilometerLengthUnit && toUnit is MeterLengthUnit)
                return value * 1000;
            else if (fromUnit is KilometerLengthUnit && toUnit is MillimeterLengthUnit)
                return value * 1000000;
            else if (fromUnit is MeterLengthUnit && toUnit is MillimeterLengthUnit)
                return value * 1000;
            throw new ArgumentException("Invalid Conversion");
        }
    }
}
