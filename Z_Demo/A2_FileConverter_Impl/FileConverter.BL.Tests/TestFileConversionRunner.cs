using FileConverter.BL.DTOs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileConverter.BL.Tests
{
    public class TestFileConversionRunner
    {
        [Fact]
        public void Convert_OrchestratesConversion()
        {
            var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
            mockLogger.Setup(x => x.WriteToLog(It.IsAny<string>()));
            var orders = GetTestOrders().ToArray();
            var mockRdr = new Mock<IOrderReader>(MockBehavior.Strict);
            mockRdr.Setup(x => x.Read()).Returns(orders);
            var mockVal = new Mock<OrderValidator>(MockBehavior.Strict);
            mockVal.Setup(x => x.AssertIsValid(orders.ElementAt(0).Order));
            mockVal.Setup(x => x.AssertIsValid(orders.ElementAt(1).Order))
                .Throws<ApplicationException>();
            var mockBldr = new Mock<IOrderBuilder>(MockBehavior.Strict);
            mockBldr.Setup(x => x.AddOrder(orders.ElementAt(0).Order));
            var runner = new FileConversionRunner(mockLogger.Object, 
                mockVal.Object);
            runner.Convert(mockRdr.Object, mockBldr.Object);
            mockLogger.VerifyAll();
            mockRdr.VerifyAll();
            mockVal.VerifyAll();
            mockBldr.VerifyAll();
        }

        private static IEnumerable<OrderResult> GetTestOrders()
        {
            yield return new OrderResult()
            {
                Order = new BL.DTOs.Order()
                {
                    CustNo = CustomerNumber.Parse("KND1234"),
                    Date = DateTime.Today,
                    Lines = new OrderLine[]
                    {
                        new OrderLine()
                        {
                            ItemNo = ItemNumber.Parse("A1234"),
                            Quantity = 5,
                            Price = 10,
                        }
                    }
                }
            };
            yield return new OrderResult()
            {
                Order = new BL.DTOs.Order()
                {
                    CustNo = CustomerNumber.Parse("KND1234"),
                    Date = DateTime.Today.AddDays(1),
                    Lines = new OrderLine[]
                    {
                        new OrderLine()
                        {
                            ItemNo = ItemNumber.Parse("A1234"),
                            Quantity = 5,
                            Price = 10,
                        }
                    }
                }
            };
            yield return new OrderResult()
            {
                ErrorMessage = "Error row",
                LineNumber = 3, 
            };
        }
    }
}
