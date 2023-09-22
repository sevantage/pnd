using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.StateSample
{
    /// <summary>
    /// Account is the context of the state pattern.
    /// </summary>
    class Account
    {
        public Account()
        {
            this.Balance = 0m;
            this.CurrentState = new AccountPositiveState();
        }

        public override string ToString()
        {
            return string.Format("Balance = {0}, State = {1}", Balance, CurrentState.GetType().Name);
        }

        public decimal Balance { get; private set; }
        private State CurrentState { get; set; }

        public void Withdraw(decimal amount)
        {
            CurrentState.Withdraw(this, amount);
        }

        public void Deposit(decimal amount)
        {
            CurrentState.Deposit(this, amount);
        }

        #region State implementation

        /// <summary>
        /// Abstract state.
        /// </summary>
        private abstract class State
        {
            public abstract void Withdraw(Account acct, decimal amount);
            public abstract void Deposit(Account acct, decimal amount);
        }

        /// <summary>
        /// Concrete state for an account with a positive balance.
        /// </summary>
        private class AccountPositiveState : State
        {
            public override void Deposit(Account acct, decimal amount)
            {
                acct.Balance += amount;
            }

            public override void Withdraw(Account acct, decimal amount)
            {
                if (amount > 1000m)
                    throw new InvalidOperationException("Cannot withdraw more than 1000 XYZ at once.");
                acct.Balance -= amount;
                if (acct.Balance < 0)
                    acct.CurrentState = new AccountOverdrawnState();
            }
        }

        /// <summary>
        /// Concrete state for an overdrawn account.
        /// </summary>
        private class AccountOverdrawnState : State
        {
            public override void Deposit(Account acct, decimal amount)
            {
                acct.Balance += amount;
                if (acct.Balance >= 0)
                    acct.CurrentState = new AccountPositiveState();
            }

            public override void Withdraw(Account acct, decimal amount)
            {
                throw new InvalidOperationException("Cannot withdraw from an overdrawn account.");
            }
        }

        #endregion
    }
}
