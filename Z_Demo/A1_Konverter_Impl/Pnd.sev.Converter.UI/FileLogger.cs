using Pnd.sev.Converter.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pnd.sev.Converter.UI
{
    internal class FileLogger : ILogger
    {
        private readonly string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public void Log(string message)
        {
            System.IO.File.AppendAllLines(filePath, new string[] { message });
        }
    }
}
