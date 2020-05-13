using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    public interface ILogger
    {
        void WriteToLog(string msg);
    }
}
