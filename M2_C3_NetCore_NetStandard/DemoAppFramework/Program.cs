using DemoClassLibStd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World from {Environment.OSVersion}!");
            Console.WriteLine($"1 + 2 = {new Calculator().Add(1, 2)}");
        }
    }
}
