using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeMetrics
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region Plain method

        static void MethodThatDoesEverything()
        {
            var data = Enumerable.Range(1, 100).ToArray();
            foreach (var item in data)
            {
                if (item % 2 == 0)
                    Console.WriteLine("{0} can be divided by 2.", item);
                if (item % 3 == 0)
                    Console.WriteLine("{0} can be divided by 3.", item);
                if (item % 4 == 0)
                    Console.WriteLine("{0} can be divided by 4.", item);
                if (item % 5 == 0)
                    Console.WriteLine("{0} can be divided by 5.", item);
                if (item % 6 == 0)
                    Console.WriteLine("{0} can be divided by 6.", item);
                if (item % 7 == 0)
                    Console.WriteLine("{0} can be divided by 7.", item);
                if (item % 8 == 0)
                    Console.WriteLine("{0} can be divided by 8.", item);
                if (item % 9 == 0)
                    Console.WriteLine("{0} can be divided by 9.", item);
                if (item % 10 == 0)
                    Console.WriteLine("{0} can be divided by 10.", item);
            }
        }

        #endregion

        #region Loop

        static void MethodThatDoesEverythingButUsesALoop()
        {
            var data = Enumerable.Range(1, 100).ToArray();
            foreach (var item in data)
            {
                for (int i = 2; i <= 10; i++)
                    if (item % i == 0)
                        Console.WriteLine("{0} can be divided by {1}.", item, i);
            }
        }

        #endregion

        #region Split into Submethods

        static void MethodThatCallsSubmethods()
        {
            var data = Enumerable.Range(1, 100).ToArray();
            foreach (var item in data)
                CheckDivisions(item);
        }

        private static void CheckDivisions(int item)
        {
            for (int i = 2; i <= 10; i++)
                CheckDivision(item, i);
        }

        private static void CheckDivision(int item, int i)
        {
            if (item % i == 0)
                Console.WriteLine("{0} can be divided by {1}.", item, i);
        }

        #endregion
    }
}
