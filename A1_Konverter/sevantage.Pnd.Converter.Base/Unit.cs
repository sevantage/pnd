using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sevantage.Pnd.Converter.Base
{
    /// <summary>
    /// Defines a unit.
    /// </summary>
    public abstract class Unit : IEquatable<Unit>, IComparable<Unit>
    {
        /// <summary>
        /// Returns name of unit.
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Compares the unit to another unit.
        /// </summary>
        public abstract int CompareTo(Unit other);
        /// <summary>
        /// Checks whether this unit and another are considered to be equal.
        /// </summary>
        public abstract bool Equals(Unit other);
    }
}
