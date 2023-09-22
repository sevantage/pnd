using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disposal
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ReadFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static void ReadFile()
        {
            using (var dfr = new DataFileReader())
            {
                int? number;
                while ((number = dfr.GetNextNumber()) != null)
                    Console.WriteLine(number);
            }
        }
    }
}
