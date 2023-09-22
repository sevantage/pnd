using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FileConverter.BL.DTOs
{
    public class ItemNumber
    {
        private static readonly Regex itemNoRegex = new Regex("^[ABC][0-9]{4}$");
        private readonly string itemNo;

        private ItemNumber(string itemNo)
        {
            if (!itemNoRegex.IsMatch(itemNo))
                throw new ArgumentException(string.Format("Artikelnummer {0} ist ungültig.", itemNo));

            this.itemNo = itemNo;
        }

        public string Number { get => itemNo; }

        public static ItemNumber Parse(string s)
        {
            return new ItemNumber(s);
        }
    }
}