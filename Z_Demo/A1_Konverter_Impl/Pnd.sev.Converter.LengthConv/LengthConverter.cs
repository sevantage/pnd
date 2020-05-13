using sevantage.Pnd.Converter.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pnd.sev.Converter.LengthConv
{
    public class LengthConverter : IConverter
    {
        public string Name => "Länge";

        public IEnumerable<Unit> SupportedUnits => new Unit[]
        {
            new MeterUnit(), 
            new KilometerUnit(), 
            new MileUnit(), 
        };

        public Value Convert(Value fromValue, Unit toUnit)
        {
            if (!ValidateUnit(fromValue.Unit))
                throw new ArgumentException("Ausgangseinheit wird nicht unterstützt.");
            if (!ValidateUnit(toUnit))
                throw new ArgumentException("Zieleinheit wird nicht unterstützt.");
            var fromLengthUnit = (LengthUnit)fromValue.Unit;
            var toLengthUnit = (LengthUnit)toUnit;
            var fromInMeters = fromValue.Amount * fromLengthUnit.InMeters;
            var result = fromInMeters / toLengthUnit.InMeters;
            return new Value(toUnit, result);
        }

        private bool ValidateUnit(Unit unit)
        {
            return SupportedUnits.Any(x => x.Equals(unit));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
