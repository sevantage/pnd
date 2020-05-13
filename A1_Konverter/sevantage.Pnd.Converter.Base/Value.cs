using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sevantage.Pnd.Converter.Base
{
    /// <summary>
    /// Values that are quantified by a unit.
    /// </summary>
    public class Value
    {
        private readonly sevantage.Pnd.Converter.Base.Unit unit;
        private readonly decimal amount;

        public Value(sevantage.Pnd.Converter.Base.Unit unit, decimal amount)
        {
            this.unit = unit;
            this.amount = amount;
        }

        /// <summary>
        /// Unit of value.
        /// </summary>
        public virtual Unit Unit => unit;

        /// <summary>
        /// Amount of value.
        /// </summary>
        public virtual decimal Amount => amount;
    }
}
