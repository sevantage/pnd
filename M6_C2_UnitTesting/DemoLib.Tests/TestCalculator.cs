using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoLib.Tests
{
    public class TestCalculator
    {
        [Fact]
        public void Add_AddsIntegers()
        {
            var calc = new Calculator();
            var result = calc.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(100, 2, 102)]
        [InlineData(1, -2, -1)]
        public void Add_AddsVariousIntegers(int a, int b, int expected)
        {
            var calc = new Calculator();
            var result = calc.Add(a, b);
            Assert.Equal(expected, result);
        }
    }
}
