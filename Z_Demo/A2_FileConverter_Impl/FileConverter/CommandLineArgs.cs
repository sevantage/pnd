using System;
using System.Collections.Generic;
using System.Linq;

namespace FileConverter
{
    class CommandLineArgs
    {
        public static CommandLineArgs Create(IEnumerable<string> args)
        {
            if (args == null || args.Count() != 2)
                throw new ApplicationException("Bitte geben Sie den Eingabe- und Ausgabepfad an.");
            var result = new CommandLineArgs()
            {
                InputFilePath = args.ElementAt(0),
                OutputFilePath = args.ElementAt(1),
            };
            if (string.IsNullOrWhiteSpace(result.InputFilePath))
                throw new ApplicationException("Bitte geben Sie den Eingabepfad an.");
            if (string.IsNullOrWhiteSpace(result.OutputFilePath))
                throw new ApplicationException("Bitte geben Sie den Ausgabepfad an.");
            return result;
        }

        public string InputFilePath { get; private set; }
        public string OutputFilePath { get; private set; }
    }
}

