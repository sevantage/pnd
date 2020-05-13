using System;

namespace DemoApp.State
{
    public class Context
    {
        internal State currentState;

        public void Operation1()
        {
            currentState.Operation1(this);
        }

        public void Operation2()
        {
            currentState.Operation2(this);
        }
    }

    internal abstract class State
    {
        internal abstract void Operation1(Context context);

        internal abstract void Operation2(Context context);
    }

    internal class StateA : State
    {
        internal override void Operation1(Context context)
        {
            context.currentState = new StateB();
        }

        internal override void Operation2(Context context)
        {
            throw new InvalidOperationException();
        }
    }

    internal class StateB : State
    {
        internal override void Operation1(Context context)
        {
            throw new InvalidOperationException();
        }

        internal override void Operation2(Context context)
        {
            context.currentState = new StateA();
        }
    }
}