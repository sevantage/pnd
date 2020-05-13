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
            MyAbstractBaseClass cls = new MyDerivedClass();

            cls.AbstractMethod();
            //cls.VirtualMethod();
            //cls.NonVirtualMethod();

            Console.ReadLine();
        }
    }
}
