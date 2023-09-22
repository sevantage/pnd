using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.NullObject
{
    class Listener
    {
        public virtual void BeforeAction()
        {
            Console.WriteLine("Before action");
        }

        public virtual void AfterAction()
        {
            Console.WriteLine("After action");
        }
    }
}
