using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.NullObject
{
    class MyClass
    {
        private readonly Listener listener;

        public MyClass(Listener listener)
        {
            this.listener = listener;
        }

        public void DoSomething()
        {
            if (listener != null)
                listener.BeforeAction();
            // Do something
            if (listener != null)
                listener.AfterAction();
        }
    }
}
