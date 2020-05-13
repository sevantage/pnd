using sevantage.Pnd.Converter.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pnd.sev.Converter.Base
{
    public class Loader
    {
        public IEnumerable<IConverter> LoadFrom(string path, ILogger logger)
        {
            var converters = new List<IConverter>();
            foreach (var filePath in Directory.GetFiles(path, "*conv.dll"))
            {
                try
                {
                    var a = Assembly.LoadFrom(filePath);
                    var convTypes = a.GetTypes()
                        .Where(x => typeof(IConverter).IsAssignableFrom(x));
                    foreach (var convType in convTypes)
                    {
                        var conv = CreateConverter(convType, logger);
                        if (conv != null)
                            converters.Add(conv);
                    }
                }
                catch (Exception ex)
                {
                    logger.Log($"Error loading converters from file {filePath}: {ex.ToString()}");
                }
            }
            return converters.ToArray();
        }

        private static IConverter CreateConverter(Type t, ILogger logger)
        {
            try
            {
                return (IConverter)Activator.CreateInstance(t);
            }
            catch (Exception ex)
            {
                logger.Log($"Error creating converter for type {t.AssemblyQualifiedName}: {ex.ToString()}");
                return null; 
            }
        }
    }
}
