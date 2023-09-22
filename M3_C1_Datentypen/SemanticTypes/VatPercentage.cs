using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticTypes
{
    class VatPercentage
    {
        private readonly decimal percentage;

        private VatPercentage(decimal percentage)
        {
            if (percentage < 0
                || percentage > 1.0m)
                throw new ArgumentException("Invalid VAT percentage. Valid values are between 0 and 1.", "percentage");
            this.percentage = percentage;
        }

        public decimal Percentage { get { return percentage; } }

        public static VatPercentage Default
        {
            get
            {
                return new VatPercentage(0.19m);
            }
        }

        public static VatPercentage Reduced
        {
            get
            {
                return new VatPercentage(0.07m);
            }
        }
    }
}
