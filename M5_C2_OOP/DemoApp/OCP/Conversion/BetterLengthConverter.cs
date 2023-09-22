using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Conversion
{
    public class BetterLengthConverter : ILengthConverter
    {
        private static Dictionary<ConvKey, decimal> factors = new Dictionary<ConvKey, decimal>();

        static BetterLengthConverter()
        {
            factors.Add(new ConvKey(typeof(MillimeterLengthUnit), typeof(MeterLengthUnit)), 1000);
            factors.Add(new ConvKey(typeof(MillimeterLengthUnit), typeof(KilometerLengthUnit)), 1000000);
            factors.Add(new ConvKey(typeof(MeterLengthUnit), typeof(KilometerLengthUnit)), 1000);
        }

        public decimal Convert(decimal value, LengthUnit fromUnit, LengthUnit toUnit)
        {
            var key = new ConvKey(fromUnit.GetType(), toUnit.GetType());
            decimal factor;
            if (!factors.TryGetValue(key, out factor))
            {
                // Check for conversion for swapped units
                key = new ConvKey(toUnit.GetType(), fromUnit.GetType());
                if (!factors.TryGetValue(key, out factor))
                    throw new ArgumentException("Invalid conversion");
                else
                    factor = 1 / factor;
            }
            return value / factor;
        }

        private class ConvKey : IEquatable<ConvKey>
        {
            public ConvKey(Type fromUnitType, Type toUnitType)
            {
                this.FromUnitType = fromUnitType;
                this.ToUnitType = toUnitType;
            }

            public Type FromUnitType { get; set; }
            public Type ToUnitType { get; set; }

            public bool Equals(ConvKey other)
            {
                return (this.FromUnitType == other.FromUnitType
                    && this.ToUnitType == other.ToUnitType);
            }

            public override bool Equals(object obj)
            {
                var other = obj as ConvKey;
                if (other == null)
                    return false;
                return Equals(other);
            }

            public override int GetHashCode()
            {
                return FromUnitType.GetHashCode() | ToUnitType.GetHashCode();
            }
        }
    }
}
