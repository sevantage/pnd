using FileConverter.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileConverter.BL.Tests
{
    public class TestOrderValidator
    {
        [Fact]
        public void AssertIsValid_DoesNotThrowException_IfOrderIsValid()
        {
            var order = new Order()
            {
                Date = DateTime.Today.AddDays(-5),
            };
            new OrderValidator().AssertIsValid(order);
        }

        [Fact]
        public void AssertIsValid_ThrowsException_IfOrderIsInvalid()
        {
            var order = new Order()
            {
                Date = DateTime.Today.AddDays(5),
            };
            Assert.Throws<ApplicationException>(() => new OrderValidator().AssertIsValid(order));
        }
    }
}
