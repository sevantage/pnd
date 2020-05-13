using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileConverter.BL
{
    internal class FileConversionRunner : IFileConversionRunner
    {
        private readonly ILogger logger;
        private readonly OrderValidator val;

        public FileConversionRunner(ILogger logger, OrderValidator val)
        {
            this.logger = logger;
            this.val = val;
        }

        public void Convert(IOrderReader rdr, IOrderBuilder bldr)
        {
            var orderResults = rdr.Read();
            var lineNo = 1;
            var successCnt = 0;
            foreach (var result in orderResults)
            {
                try
                {
                    if (!result.IsValid)
                        logger.WriteToLog(result.ErrorMessage);
                    else
                    {
                        val.AssertIsValid(result.Order);
                        bldr.AddOrder(result.Order);
                        successCnt++;
                    }
                }
// Suppressed because at this point, it is ok to catch a general exception type
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    logger.WriteToLog($"Zeile {lineNo}: {ex.Message}");
                }
                lineNo++;
            }
            logger.WriteToLog(string.Format("Es wurden {0} von {1} Aufträgen erfolgreich importiert.", successCnt, lineNo - 1));
        }
    }
}
