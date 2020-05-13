using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.BuilderSample
{
    /// <summary>
    /// Concrete Builder for the text format.
    /// </summary>
    class TextOutputFormat : OutputFormat
    {
        private readonly StringBuilder output = new StringBuilder();

        public override void StartDocument()
        {
        }

        public override void EndDocument()
        {
        }

        public override void WriteContent(string text)
        {
            output.AppendLine(text);
        }

        public override void WriteHeader(string header)
        {
            output.AppendLine();
            output.AppendLine(header);
            output.AppendLine(new string('-', header.Length));
        }

        public string GetOutput()
        {
            return output.ToString();
        }
    }
}
