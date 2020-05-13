using DemoApp.BuilderSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var acct = new StateSample.Account();
            Console.WriteLine("Init: {0}", acct);
            acct.Deposit(1000);
            Console.WriteLine("+1000: {0}", acct);
            acct.Withdraw(500);
            Console.WriteLine("-500: {0}", acct);
            acct.Withdraw(750);
            Console.WriteLine("-750: {0}", acct);
            acct.Deposit(1000);
            Console.WriteLine("+1000: {0}", acct);

            Console.ReadLine();
        }
    }
}
