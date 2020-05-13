using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileConverter.DA.Tests
{
    public class TestOrderTextFileReader
    {
        [Fact]
        public void Read_ReadsOrders()
        {
            using (var s = File.OpenRead("Data.DE.txt"))
            {
                using (var rdr = new OrderTextFileReader(s, new CultureInfo("de-DE")))
                {
                    var result = rdr.Read().ToArray();
                    Assert.Equal(4, result.Count());
                    Assert.Equal(new bool[] { true, true, false, false }, result.Select(x => x.IsValid));
                    Assert.NotNull(result.ElementAt(0).Order);
                    Assert.Equal("KND1234", result.ElementAt(0).Order.CustNo.Number);
                    Assert.Equal(new DateTime(2013, 10, 1), result.ElementAt(0).Order.Date);
                    Assert.Equal("A1234", result.ElementAt(0).Order.Lines.ElementAt(0).ItemNo.Number);
                    Assert.Equal(5, result.ElementAt(0).Order.Lines.ElementAt(0).Quantity);
                    Assert.Equal(70, result.ElementAt(0).Order.Lines.ElementAt(0).Price);
                    Assert.NotNull(result.ElementAt(1).Order);
                    Assert.Equal(3, result.ElementAt(2).LineNumber);
                    Assert.Null(result.ElementAt(2).Order);
                    Assert.Equal(4, result.ElementAt(3).LineNumber);
                    Assert.Null(result.ElementAt(3).Order);
                }
            }
        }
    }
}
