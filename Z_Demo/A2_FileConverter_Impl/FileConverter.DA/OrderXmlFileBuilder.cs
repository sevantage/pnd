using System;
using System.IO;
using System.Xml.Linq;
using FileConverter.BL;
using FileConverter.BL.DTOs;

namespace FileConverter.DA
{
    public class OrderXmlFileBuilder : IOrderBuilder
    {
        private readonly XDocument doc;

        public OrderXmlFileBuilder()
        {
            doc = new XDocument(new XElement("orders"));
        }

        public void AddOrder(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            var orderEl = new XElement("order",
                new XAttribute("custno", order.CustNo.Number),
                new XAttribute("date", order.Date.ToString("yyyy-MM-dd")));
            foreach(var orderLine in order.Lines)
            {
                    orderEl.Add(new XElement("pos",
                        new XAttribute("itemno", orderLine.ItemNo.Number),
                        new XAttribute("quantity", orderLine.Quantity.ToString()),
                        new XAttribute("price", orderLine.Price.ToString())));
            }
            doc.Root.Add(orderEl);
        }

        public void Write(Stream dest)
        {
            doc.Save(dest);
        }
    }
}