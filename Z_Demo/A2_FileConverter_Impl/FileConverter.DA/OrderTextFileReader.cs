using FileConverter.BL;
using FileConverter.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.DA
{
    public sealed class OrderTextFileReader : IOrderReader
    {
        private readonly Stream src;
        private readonly CultureInfo cult;

        public OrderTextFileReader(Stream src, CultureInfo cult)
        {
            this.src = src;
            this.cult = cult;
        }

        public void Dispose()
        {
            src.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<OrderResult> Read()
        {
            using (var rdr = new StreamReader(src))
            {
                string line;
                var lineNo = 1;
                while ((line = rdr.ReadLine()) != null)
                {
                    var orderResult = new OrderResult();
#pragma warning disable CA1031 // Do not catch general exception types
                    try
                    {
                        var parts = line.Split('\t');
                        if (parts.Length < 5 || (parts.Length - 2) % 3 != 0)
                            throw new ApplicationException("Die Zeile ist nicht richtig formatiert.");
                        var custNo = CustomerNumber.Parse(parts[0]);
                        var dt = DateTime.Parse(parts[1], cult.DateTimeFormat);
                        var orderLines = new List<OrderLine>();
                        for (int j = 2; j <= parts.Length - 1; j += 3)
                        {
                            var orderLine = new OrderLine()
                            {
                                ItemNo = ItemNumber.Parse(parts[j]),
                                Quantity = int.Parse(parts[j + 1]),
                                Price = int.Parse(parts[j + 2]),
                            };
                            orderLines.Add(orderLine);
                        }
                        orderResult.Order = new Order()
                        {
                            CustNo = custNo,
                            Date = dt,
                            Lines = orderLines,
                        };
                    }
                    catch (Exception ex)
                    {
                        orderResult.ErrorMessage = $"Zeile {lineNo}: {ex.Message}";
                        orderResult.LineNumber = lineNo;
                    }
#pragma warning restore CA1031 // Do not catch general exception types
                    lineNo++;
                    yield return orderResult;
                }
            }
        }
    }
}
