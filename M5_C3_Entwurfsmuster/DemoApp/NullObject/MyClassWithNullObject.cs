using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.NullObject
{
    class MyClassWithNullObject
    {
        private readonly Listener listener;

        public MyClassWithNullObject(Listener listener)
        {
            if (listener != null)
                this.listener = listener;
            else
                this.listener = new NullListener();
        }

        public void DoSomething()
        {
            listener.BeforeAction();
            // Do something
            listener.AfterAction();
        }

        private class NullListener : Listener
        {
            public override void BeforeAction()
            {
                // Do nothing
            }

            public override void AfterAction()
            {
                // Do nothing
            }
        }
    }
}
