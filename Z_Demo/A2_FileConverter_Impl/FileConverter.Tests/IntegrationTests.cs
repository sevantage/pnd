using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileConverter.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void Main_ConvertsFile_IfCultureIsDE()
        {
            const string inputFile = "Data.DE.txt";
            const string outputFile = "Output.DE.xml";
            const string expectedHash = "91C5DA3AE9F943C5165715E04EAF884F7DDC9940600D5E0794E01367BFF05539";
            RunConversion(inputFile, outputFile, expectedHash);
        }

        [Fact]
        public void Main_ConvertsFile_IfCultureIsEN()
        {
            const string inputFile = "Data.EN.txt";
            const string outputFile = "Output.EN.xml";
            const string expectedHash = "BA68095E2264540388A90E992F071DDA9942671425912A44026877982153A293";
            RunConversion(inputFile, outputFile, expectedHash);
        }

        private void RunConversion(string inputFile, string outputFile, string expectedHash)
        {
            var args = new string[]
            {
                inputFile,
                outputFile,
            };
            Program.Main(args);
            Assert.True(File.Exists(outputFile));
            string actualHash = GetFileHash(outputFile);
            Assert.Equal(expectedHash, actualHash);
        }

        private string GetFileHash(string outputFile)
        {
            var sha256 = SHA256.Create();
            byte[] hash;
            using (var fs = File.OpenRead(outputFile))
                hash = sha256.ComputeHash(fs);
            return string.Concat(hash.Select(x => x.ToString("X2")));
        }

        [Fact]
        public void Main_DoesNotThrowAnException_IfNoInputPathIsProvided()
        {
            var args = new string[]
            {
                " ",
                "Output.DE.xml",
            };
            Program.Main(args);
        }

        [Fact]
        public void Main_DoesNotThrowAnException_IfNoOutputPathIsProvided()
        {
            var args = new string[]
            {
                "Input.DE.txt ",
                " ",
            };
            Program.Main(args);
        }

        [Fact]
        public void Main_DoesNotThrowAnException_IfWrongNumberOfArgsIsProvided()
        {
            var args = new string[]
            {
                " ",
                "Output.DE.xml",
                " ",
            };
            Program.Main(args);
        }

        [Fact]
        public void Main_DoesNotThrowAnException_IfNoArgsAreProvided()
        {
            Program.Main(null);
        }
    }
}
