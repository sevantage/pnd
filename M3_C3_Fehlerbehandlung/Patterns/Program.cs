using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var filePaths = new[]
                {
                    @"C:\Temp\Test.txt",
                    @"D:\Temp\Test.txt",
                    @"E:\Temp\Test.txt",
                    @"F:\Temp\Test.txt",
                };
                var fileImpSvc = new FileImportService();
                fileImpSvc.ImportFiles(filePaths);
            }
            catch (AggregateException aggrEx)
            {
                Console.WriteLine("Caught aggregate exception");
                foreach (var ex in aggrEx.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
