using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.BL.DTOs
{
    public class Order
    {
        public CustomerNumber CustNo { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderLine> Lines { get; set; }
    }
}
