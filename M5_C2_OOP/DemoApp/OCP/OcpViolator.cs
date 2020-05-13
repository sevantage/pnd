using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Violator
{
    enum Severity
    {
        Verbose, 
        Info, 
        Warning, 
        Error,
    }

    class LogMessage
    {
        public Severity Severity { get; set; }
        public string Text { get; set; }
    }

    class OcpViolator
    {
        public void PrintMessage(LogMessage msg)
        {
            string severityText = GetSeverityText(msg.Severity);
            Console.WriteLine("{0}: {1}", severityText, msg.Text);
        }

        private string GetSeverityText(Severity severity)
        {
            switch(severity)
            {
                case Severity.Verbose:
                    return "Verbose";
                case Severity.Info:
                    return "Info";
                case Severity.Warning:
                    return "Warning";
                case Severity.Error:
                    return "Error";
            }
            return "Unknown severity";
        }
    }
}
