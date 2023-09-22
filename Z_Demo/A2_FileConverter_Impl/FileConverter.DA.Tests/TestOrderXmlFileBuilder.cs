using FileConverter.BL.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileConverter.DA.Tests
{
    public class TestOrderXmlFileBuilder
    {
        [Fact]
        public void Builder_AddsOrderAndBuildsFile()
        {
            var order = new Order()
            {
                CustNo = CustomerNumber.Parse("KND1234"),
                Date = new DateTime(2019, 10, 30),
                Lines = Enumerable.Range(1, 2)
                    .Select(x => new OrderLine()
                    {
                        ItemNo = ItemNumber.Parse("A1234"),
                        Quantity = x,
                        Price = 12.34m,
                    }),
            };
            var bldr = new OrderXmlFileBuilder();
            bldr.AddOrder(order);
            using (var str = new MemoryStream())
            {
                bldr.Write(str);
                str.Flush();
                str.Seek(0, SeekOrigin.Begin);
                var sha256 = SHA256.Create();
                var hashBytes = sha256.ComputeHash(str);
                var actual = string.Concat(hashBytes.Select(x => x.ToString("X2")));
                Assert.Equal("AC845721244C41A6E7E25A8093FB597989614A2305FB83C3362CC417D445413E", actual);
            }
        }
    }
}
