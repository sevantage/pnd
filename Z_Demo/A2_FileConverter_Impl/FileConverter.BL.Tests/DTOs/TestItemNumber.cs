using FileConverter.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileConverter.BL.Tests.DTOs
{
    public class TestItemNumber
    {
        [Fact]
        public void Parse_InitializesObject()
        {
            var x = ItemNumber.Parse("A1234");
            Assert.Equal("A1234", x.Number);
        }

        [Fact]
        public void Parse_ThrowsArgumentException_IfInputIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => ItemNumber.Parse(null));
            Assert.Throws<ArgumentException>(() => ItemNumber.Parse(string.Empty));
            Assert.Throws<ArgumentException>(() => ItemNumber.Parse(" "));
        }

        [Fact]
        public void Parse_ThrowsArgumentException_IfInputIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => ItemNumber.Parse("123A"));
            Assert.Throws<ArgumentException>(() => ItemNumber.Parse("a1234"));
            Assert.Throws<ArgumentException>(() => ItemNumber.Parse("a12"));
        }
    }
}
