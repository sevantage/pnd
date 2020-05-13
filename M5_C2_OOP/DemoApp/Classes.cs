using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    abstract class MyAbstractBaseClass
    {
        public abstract void AbstractMethod();
    }

    class MyBaseClass : MyAbstractBaseClass
    {
        public override void AbstractMethod()
        {
            Console.WriteLine("MyBaseClass.AbstractMethod");
        }

        public virtual void VirtualMethod()
        {
            Console.WriteLine("MyBaseClass.VirtualMethod");
        }

        public void NonVirtualMethod()
        {
            Console.WriteLine("MyBaseClass.NonVirtualMethod");
        }
    }

    class MyDerivedClass : MyBaseClass
    {
        public override void AbstractMethod()
        {
            Console.WriteLine("MyDerivedClass.AbstractMethod");
        }

        public override void VirtualMethod()
        {
            Console.WriteLine("MyDerivedClass.VirtualMethod");
        }

        public new void NonVirtualMethod()
        {
            Console.WriteLine("MyDerivedClass.NonVirtualMethod");
        }
    }
}
