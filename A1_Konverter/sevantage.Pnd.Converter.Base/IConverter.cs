using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sevantage.Pnd.Converter.Base
{
    /// <summary>
    /// Interface that all converters implement.
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Returns the name of the converter.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Returns the units that the converter can convert.
        /// </summary>
        IEnumerable<Unit> SupportedUnits { get; }
        /// <summary>
        /// Converts a value from one unit to another.
        /// </summary>
        /// <param name="fromValue">Value that is to be converted.</param>
        /// <param name="toUnit">Unit that the value should be converted to.</param>
        /// <returns>Value in unit that the value should be converted to.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown if conversion is not possible due to combination of units.</exception>
        /// <exception cref="System.ArgumentException">Thrown if fromValue is invalid.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if either fromValue or toUnit is null.</exception>
        Value Convert(Value fromValue, Unit toUnit);
    }
}
