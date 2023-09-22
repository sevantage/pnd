using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.BuilderSample
{
    /// <summary>
    /// Abstract Builder
    /// </summary>
    abstract class OutputFormat
    {
        public abstract void StartDocument();
        public abstract void EndDocument();
        public abstract void WriteHeader(string header);
        public abstract void WriteContent(string text);
    }
}
