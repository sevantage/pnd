using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.BL.DTOs
{
    public class CustomerNumber
    {
        private readonly string custNo;

        private CustomerNumber(string custNo)
        {
            if (string.IsNullOrWhiteSpace(custNo))
            {
                throw new ArgumentException("Customer number cannot be empty", nameof(custNo));
            }

            this.custNo = custNo;
        }

        public string Number { get => custNo; }

        public static CustomerNumber Parse(string s)
        {
            return new CustomerNumber(s?.ToUpper(CultureInfo.InvariantCulture));
        }
    }
}
