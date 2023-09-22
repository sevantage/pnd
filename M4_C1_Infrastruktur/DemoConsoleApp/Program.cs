using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfgValue = ConfigurationManager.AppSettings["MyAppSetting"];
            Console.WriteLine("Setting value = {0}", cfgValue);
            Console.ReadLine();
        }
    }
}
