using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var netPrice = new NetPrice(100m);
            var vatPct = VatPercentage.Default;
            var grossPrice = GetGrossPrice(netPrice, vatPct);
        }

        //static decimal GetGrossPrice(decimal netPrice, decimal vatPct)
        //{
        //    return netPrice * (1 + vatPct);
        //}

        static GrossPrice GetGrossPrice(NetPrice netPrice, VatPercentage vatPct)
        {
            return new GrossPrice(netPrice.Value * (1 + vatPct.Percentage));
        }
    }
}
