using DemoClassLibStd;
using System;

namespace DemoAppCore
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
