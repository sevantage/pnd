using FileConverter.BL;
using FileConverter.DA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    class Orchestrator
    {
        private readonly DA.Factory daFactory;
        private readonly IFileConversionRunner runner;
        private readonly CommandLineArgs cmdLineArgs;

        public Orchestrator(DA.Factory daFactory, 
            IFileConversionRunner runner, 
            CommandLineArgs cmdLineArgs)
        {
            // The construction of the OrderTextFileReader is complex, 
            // hence it is delegated to a factory
            // that is provided by the IoCC
            this.daFactory = daFactory;
            this.runner = runner;
            this.cmdLineArgs = cmdLineArgs;
        }

        public void Run(IOrderBuilder bldr)
        {
            using (var rdr = daFactory.CreateOrderReader(cmdLineArgs.InputFilePath))
            {
                runner.Convert(rdr, bldr);
            }
        }
    }
}
