using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.BuilderSample
{
    /// <summary>
    /// Director for the builder sample.
    /// </summary>
    class DocumentWriter
    {
        public void WriteDocument(Document doc, OutputFormat outputFormat)
        {
            outputFormat.StartDocument();
            foreach (var section in doc.Sections)
            {
                outputFormat.WriteHeader(section.Header);
                outputFormat.WriteContent(section.Content);
            }
            outputFormat.EndDocument();
        }
    }
}
