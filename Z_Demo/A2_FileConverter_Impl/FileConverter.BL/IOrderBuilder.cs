using FileConverter.BL.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.BL
{
    public interface IOrderBuilder
    {
        void AddOrder(Order order);
    }
}
