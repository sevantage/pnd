using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSourceCodeAnalyzers
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static void ObsoleteMethod()
        {
        }
    }

    public class DataProcessor
    {
        private readonly System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

        public void ProcessSomeData(int iAmStillUsed, int iAmObsolete)
        {
            for (int i = 0; i < iAmStillUsed; i++)
                Console.Write(".");
        }
    }
}
