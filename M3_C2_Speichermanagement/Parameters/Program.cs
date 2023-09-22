using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;

            OutMethod(out x);
            Console.WriteLine("Value in Main-Method: x = {0}", x);

            ByValMethod(x);
            Console.WriteLine("Value in Main-Method: x = {0}", x);

            ByRefMethod(ref x);
            Console.WriteLine("Value in Main-Method: x = {0}", x);
            Console.ReadLine();
        }

        static void OutMethod(out int x)
        {
            x = 123;
            Console.WriteLine("Value in OutMethod: x = {0}", x);
        }

        static void ByValMethod(int x)
        {
            x *= 2;
            Console.WriteLine("Value in ByValMethod: x = {0}", x);
        }

        static void ByRefMethod(ref int x)
        {
            x *= 2;
            Console.WriteLine("Value in ByRefMethod: x = {0}", x);
        }
    }
}
