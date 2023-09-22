using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.BL
{
    public interface IFileConversionRunner
    {
        void Convert(IOrderReader rdr, IOrderBuilder bldr);
    }
}
