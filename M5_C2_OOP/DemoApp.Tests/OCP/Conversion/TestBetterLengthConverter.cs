using DemoApp.OCP.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoApp.Tests.OCP.Conversion
{
    public class TestBetterLengthConverter : TestLengthConverterBase
    {
        [Theory]
        [MemberData(nameof(Conversions))]
        public void Convert_Works<TFROMUNIT, TTOUNIT>(TFROMUNIT fromUnit, TTOUNIT toUnit, decimal fromValue, decimal expectedResult)
            where TFROMUNIT : LengthUnit, new()
            where TTOUNIT : LengthUnit, new()
        {
            CheckConvert(new BetterLengthConverter(), fromUnit, toUnit, fromValue, expectedResult);
        }
    }
}
