using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class FileImportService
    {
        public void ImportFiles(IEnumerable<string> filePaths)
        {
            var lst = new List<Exception>();
            foreach(var path in filePaths)
            {
                try
                {
                    ImportFile(path);
                    Console.WriteLine("Imported file {0}", path);
                }
                catch(Exception ex)
                {
                    lst.Add(new ApplicationException(string.Format("Error importing file {0}", path), ex));
                }
            }
            if (lst.Any())
                throw new AggregateException("At least one import failed.", lst.ToArray());
        }

        private void ImportFile(string path)
        {
            if (path.StartsWith("e", StringComparison.OrdinalIgnoreCase))
                throw new ApplicationException("Unable to access drive e");
        }
    }
}
