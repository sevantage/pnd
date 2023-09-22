using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DemoApp.BuilderSample
{
    /// <summary>
    /// Concrete Builder for outputting in HTML format.
    /// </summary>
    class HtmlOutputFormat : OutputFormat
    {
        private readonly StringWriter str;
        private readonly XmlWriter writer;

        public HtmlOutputFormat()
        {
            str = new StringWriter();
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            writer = XmlWriter.Create(str, settings);
        }

        public override void StartDocument()
        {
            writer.WriteStartElement("html");
            writer.WriteStartElement("body");
        }

        public override void EndDocument()
        {
            writer.WriteEndElement();   //body
            writer.WriteEndElement();   //html
        }

        public override void WriteContent(string text)
        {
            writer.WriteElementString("p", text);
        }

        public override void WriteHeader(string header)
        {
            writer.WriteElementString("h1", header);
        }

        public string GetOutput()
        {
            writer.Flush();
            str.Flush();
            return str.GetStringBuilder().ToString();
        }
    }
}
