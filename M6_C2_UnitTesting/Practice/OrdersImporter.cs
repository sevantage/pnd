using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class OrdersImporter
    {
        private readonly IOrderLineParser parser;
        private readonly IOrderWriter writer;

        public OrdersImporter(IOrderLineParser parser, IOrderWriter writer)
        {
            this.parser = parser;
            this.writer = writer;
        }

        public void Import(IEnumerable<string> lines)
        {
            foreach(var line in lines.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                var order = parser.Parse(line);
                writer.Write(order);
            }
        }
    }
}
