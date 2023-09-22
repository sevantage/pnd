using FileConverter.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.BL
{
    public interface IOrderReader : IDisposable
    {
        IEnumerable<OrderResult> Read();
    }

    public class OrderResult
    {
        public Order Order { get; set; }
        public string ErrorMessage { get; set; }
        public int LineNumber { get; set; }

        public bool IsValid { get => string.IsNullOrWhiteSpace(ErrorMessage); }
    }
}
