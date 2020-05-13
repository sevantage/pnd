using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disposal
{
    class DataFileReader : IDisposable
    {
        private readonly StreamReader rdr;
        private readonly CultureInfo fileCulture;

        public DataFileReader()
        {
            rdr = new StreamReader("Data.txt");
            fileCulture = new CultureInfo("en-US");
        }

        ~DataFileReader()
        {
            Console.WriteLine("Finalizer");
        }

        public int? GetNextNumber()
        {
            var line = rdr.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
                return null;
            return int.Parse(line, fileCulture);
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
            rdr.Dispose();
        }
    }
}
