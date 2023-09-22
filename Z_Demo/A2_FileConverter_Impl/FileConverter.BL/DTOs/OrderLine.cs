using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.BL.DTOs
{
    public class OrderLine
    {
        public ItemNumber ItemNo { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
