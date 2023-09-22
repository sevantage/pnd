using DemoClassLib;
using DemoConsoleApp.MyFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            var result = calc.Add(1, 2);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
