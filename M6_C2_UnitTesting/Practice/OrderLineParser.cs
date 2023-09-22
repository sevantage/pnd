using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /// <summary>
    /// Parses a line that contains a tab-separated list of order data:
    /// orderno \t custno \t value
    /// </summary>
    public class OrderLineParser
    {
        public Order Parse(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentNullException("line");
            var parts = line.Split('\t');
            if (parts.Length != 3)
                throw new ArgumentException("Format is invalid.");
            var cult = CultureInfo.CreateSpecificCulture("en-US");
            if (!decimal.TryParse(parts[2], NumberStyles.Number, cult, out decimal value))
                throw new ArgumentException(string.Format("Unable to parse {0} as a decimal value.", parts[2]));
            return new Order()
            {
                OrderNo = parts[0],
                CustNo = parts[1],
                Value = value,
            };
        }
    }
}
