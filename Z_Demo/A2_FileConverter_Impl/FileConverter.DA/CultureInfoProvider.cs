using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.DA
{
    class CultureInfoProvider
    {
        public virtual CultureInfo GetCultureFromFileName(string filePath)
        {
            var fileWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            CultureInfo cult = default(CultureInfo);
            if (fileWithoutExt.EndsWith(".EN", StringComparison.InvariantCultureIgnoreCase))
            {
                cult = new CultureInfo("en-US");
            }
            else if (fileWithoutExt.EndsWith(".DE", StringComparison.InvariantCultureIgnoreCase))
            {
                cult = new CultureInfo("de-DE");
            }
            else
            {
                throw new ApplicationException("Bitte geben Sie eine Textdatei an, die als Englisch oder Deutsch gekennzeichnet ist.");
            }
            return cult;
        }
    }
}
