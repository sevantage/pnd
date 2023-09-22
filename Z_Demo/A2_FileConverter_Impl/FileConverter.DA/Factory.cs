using FileConverter.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.DA
{
    /// <summary>
    /// The construction of the order reader is complex, hence a factory class is used.
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// This method creates an order reader.
        /// </summary>
        /// <remarks>By marking it as virtual, it can be overridden later.</remarks>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public virtual IOrderReader CreateOrderReader(string filePath)
        {
            var cultProv = new CultureInfoProvider();
            var cult = cultProv.GetCultureFromFileName(filePath);
            var fs = File.OpenRead(filePath);
            return new OrderTextFileReader(fs, cult);
        }
    }
}
