using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.BuilderSample
{
    class Document
    {
        public IEnumerable<Section> Sections { get; set; }
    }

    class Section
    {
        public string Header { get; set; }
        public string Content { get; set; }
    }
}
