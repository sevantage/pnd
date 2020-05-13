using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Conversion
{
    public interface ILengthConverter
    {
        decimal Convert(decimal value, LengthUnit fromUnit, LengthUnit toUnit);
    }
}
