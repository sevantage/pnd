using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.OCP.Respecter
{
    abstract class Severity
    {
        public abstract string Text { get; }
    }

    #region Severity values

    class InfoSeverity : Severity
    {
        public override string Text
        {
            get
            {
                return "Info";
            }
        }
    }

    class WarningSeverity : Severity
    {
        public override string Text
        {
            get
            {
                return "Warning";
            }
        }
    }

    class ErrorSeverity : Severity
    {
        public override string Text
        {
            get
            {
                return "Error";
            }
        }
    }

    class VerboseSeverity : Severity
    {
        public override string Text
        {
            get
            {
                return "Verbose";
            }
        }
    }

    #endregion

    class LogMessage
    {
        public Severity Severity { get; set; }
        public string Text { get; set; }
    }

    class OcpRespecter
    {
        public void PrintMessage(LogMessage msg)
        {
            string severityText = msg.Severity.Text;
            Console.WriteLine("{0}: {1}", severityText, msg.Text);
        }
    }
}
