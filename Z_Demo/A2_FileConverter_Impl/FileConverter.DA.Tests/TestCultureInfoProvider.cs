using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileConverter.DA.Tests
{
    public class TestCultureInfoProvider
    {
        [Theory]
        [MemberData(nameof(ValidCases))]
        public void GetCultureFromFileName_GetCorrectCulture(string filePath, string expected)
        {
            var cult = new CultureInfoProvider().GetCultureFromFileName(filePath);
            var actual = cult.Name;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(InvalidCases))]
        public void GetCultureFromFileName_ThrowsApplicationException_IfFileNameIsInvalid(string filePath)
        {
            Assert.Throws<ApplicationException>(() => new CultureInfoProvider().GetCultureFromFileName(filePath));
        }

        public static IEnumerable<object[]> ValidCases
        {
            get
            {
                yield return new object[] { "Data.DE.txt", "de-DE" };
                yield return new object[] { "Data.de.txt", "de-DE" };
                yield return new object[] { "Data.dE.txt", "de-DE" };
                yield return new object[] { "Data.De.txt", "de-DE" };
                yield return new object[] { "Data.EN.txt", "en-US" };
                yield return new object[] { "Data.en.txt", "en-US" };
                yield return new object[] { "Data.eN.txt", "en-US" };
                yield return new object[] { "Data.En.txt", "en-US" };
                yield return new object[] { "C:\\Temp\\Data.DE.txt", "de-DE" };
                yield return new object[] { "C:\\Temp\\Data.de.txt", "de-DE" };
                yield return new object[] { "C:\\Temp\\Data.dE.txt", "de-DE" };
                yield return new object[] { "C:\\Temp\\Data.De.txt", "de-DE" };
                yield return new object[] { "C:\\Temp\\Data.EN.txt", "en-US" };
                yield return new object[] { "C:\\Temp\\Data.en.txt", "en-US" };
                yield return new object[] { "C:\\Temp\\Data.eN.txt", "en-US" };
                yield return new object[] { "C:\\Temp\\Data.En.txt", "en-US" };
            }
        }

        public static IEnumerable<object[]> InvalidCases
        {
            get
            {
                yield return new object[] { "Data.ES.txt" };
                yield return new object[] { "Data.es.txt" };
                yield return new object[] { "Data.eS.txt" };
                yield return new object[] { "Data.Es.txt" };
                yield return new object[] { "Data.txt" };
                yield return new object[] { "Data.txt" };
                yield return new object[] { "Data.txt" };
                yield return new object[] { "Data.txt" };
                yield return new object[] { "C:\\Temp\\Data.ES.txt" };
                yield return new object[] { "C:\\Temp\\Data.es.txt" };
                yield return new object[] { "C:\\Temp\\Data.eS.txt" };
                yield return new object[] { "C:\\Temp\\Data.Es.txt" };
                yield return new object[] { "C:\\Temp\\Data.txt" };
                yield return new object[] { "C:\\Temp\\Data.txt" };
                yield return new object[] { "C:\\Temp\\Data.txt" };
                yield return new object[] { "C:\\Temp\\Data.txt" };
            }
        }
    }
}
