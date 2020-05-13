using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoLib.Tests
{
    public class TestMultiplicator
    {

        [Fact]
        public void DuplicateAll_ThrowsArgumentNullException_IfValuesIsNull()
        {
            var mult = new Multiplicator(null);
            Assert.Throws<ArgumentNullException>(() =>
            {
                mult.DuplicateAll(null);
            });
        }

        [Fact]
        public void DuplicateAll_DuplicatesAllValues()
        {
            var mockCalc = new Mock<Calculator>(MockBehavior.Strict);
            var values = new int[] { 1, 2, 3 };
            var expected = new int[] { -1, -2, -3 };
            mockCalc.Setup(x => x.Add(1, 1)).Returns(-1);
            mockCalc.Setup(x => x.Add(2, 2)).Returns(-2);
            mockCalc.Setup(x => x.Add(3, 3)).Returns(-3);

            var mult = new Multiplicator(mockCalc.Object);
            var result = mult.DuplicateAll(values);

            Assert.Equal(expected, result);

            mockCalc.VerifyAll();
        }

        [Fact]
        public void TriplicateAll_TriplicatesAllValues()
        {
            var values = new int[] { 1, 2, 3 };
            var expected = new int[] { -3, -6, -9 };
            var mockCalc = new Mock<Calculator>(MockBehavior.Strict);
            for (int i = 0; i < values.Length; i++)
                mockCalc.Setup(x => x.Add(values[i], values[i], values[i])).Returns(expected[i]);
            var mult = new Multiplicator(mockCalc.Object);
            var result = mult.TriplicateAll(values);

            Assert.Equal(expected, result);

            mockCalc.VerifyAll();                        
        }
    }
}
