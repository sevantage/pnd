using DemoApp.OCP.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoApp.Tests.OCP.Conversion
{
    public class TestLengthConverterBase
    {
        public void CheckConvert<TCONV, TFROMUNIT, TTOUNIT>(TCONV conv, TFROMUNIT fromUnit, TTOUNIT toUnit, decimal fromValue, decimal expectedResult)
            where TCONV : ILengthConverter
            where TFROMUNIT : LengthUnit
            where TTOUNIT : LengthUnit
        {
            var result = conv.Convert(fromValue, fromUnit, toUnit);
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> Conversions()
        {
            yield return CreateConversion<MeterLengthUnit, KilometerLengthUnit>(123m, 0.123m);
            yield return CreateConversion<KilometerLengthUnit, MeterLengthUnit>(0.123m, 123m);
            yield return CreateConversion<MillimeterLengthUnit, MeterLengthUnit>(123m, 0.123m);
            yield return CreateConversion<MeterLengthUnit, MillimeterLengthUnit>(0.123m, 123m);
            yield return CreateConversion<MillimeterLengthUnit, KilometerLengthUnit>(123m, 0.000123m);
            yield return CreateConversion<KilometerLengthUnit, MillimeterLengthUnit>(0.000123m, 123m);
        }

        private static object[] CreateConversion<TFROMUNIT, TTOUNIT>(decimal fromValue, decimal expectedResult)
            where TFROMUNIT : LengthUnit, new()
            where TTOUNIT : LengthUnit, new()
        {
            return new object[] { new TFROMUNIT(), new TTOUNIT(), fromValue, expectedResult };
        }
    }
}
