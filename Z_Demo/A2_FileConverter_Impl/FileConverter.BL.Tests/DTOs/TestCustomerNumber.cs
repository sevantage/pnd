using FileConverter.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileConverter.BL.Tests.DTOs
{
    public class TestCustomerNumber
    {
        [Fact]
        public void Parse_InitializesObject()
        {
            var x = CustomerNumber.Parse("knd1234");
            Assert.Equal("KND1234", x.Number);
        }

        [Fact]
        public void Parse_ThrowsArgumentException_IfInputIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => CustomerNumber.Parse(null));
            Assert.Throws<ArgumentException>(() => CustomerNumber.Parse(string.Empty));
            Assert.Throws<ArgumentException>(() => CustomerNumber.Parse(" "));
        }
    }
}
