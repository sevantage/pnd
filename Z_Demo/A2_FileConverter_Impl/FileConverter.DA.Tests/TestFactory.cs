using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileConverter.DA.Tests
{
    public class TestFactory
    {
        [Fact]
        public void CreateOrderReader_CreatesReader()
        {
            using (var rdr = new Factory().CreateOrderReader("Data.DE.txt"))
            {
                Assert.NotNull(rdr);
            }            
        }
    }
}
