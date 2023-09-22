using FileConverter.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.BL
{
    class OrderValidator
    {
        public virtual void AssertIsValid(Order order)
        {
            if (order.Date >= DateTime.Today)
                throw new ApplicationException("Das Belegdatum muss in der Vergangenheit liegen.");
        }
    }
}
