using FileConverter.BL;
using FileConverter.DA;
using FileConverter.IoC;
using Ninject;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FileConverter
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            try
            {
                var cmdLineArgs = CommandLineArgs.Create(args);
                using (var kernel = ConfigureIoC(logger, cmdLineArgs))
                {
                    // This UI uses an OrderXmlFileBuilder; 
                    // by requesting it from the kernel instead creating it, the concrete type can be changed later
                    var bldr = kernel.Get<OrderXmlFileBuilder>();
                    // The orchestrator is a mediator that connects the various classes
                    var orchestrator = kernel.Get<Orchestrator>();
                    orchestrator.Run(bldr);
                    // After the conversion has been run, the output file can be written
                    using (var fs = File.Create(cmdLineArgs.OutputFilePath))
                        bldr.Write(fs);
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                logger.WriteToLog(ex.ToString());
            }
        }

        /// <summary>
        /// This method sets up the Ninject kernel.
        /// </summary>
        /// <param name="logger">Logger that is created once per run</param>
        /// <param name="cmdLineArgs">CommandLineArgs that contain the settings for this run</param>
        /// <returns></returns>
        // Can be suppressed because object is disposed by caller
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private static StandardKernel ConfigureIoC(ConsoleLogger logger, CommandLineArgs cmdLineArgs)
        {
            var kernel = new StandardKernel();
            // Bind objects that are created manually
            kernel.Bind<ILogger>().ToConstant(logger);
            kernel.Bind<CommandLineArgs>().ToConstant(cmdLineArgs);
            // Load a module that contains the general IoC configuration
            kernel.Load<FileConverterModule>();
            return kernel;
        }
    }
}

