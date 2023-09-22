using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FileConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Bitte geben Sie eine Datei an.");
                return;
            }
            var fileWithoutExt = Path.GetFileNameWithoutExtension(args[0]);
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
                Console.WriteLine("Bitte geben Sie eine Textdatei an, die als Englisch oder Deutsch gekennzeichnet ist.");
                return;
            }
            var doc = new XDocument(new XElement("orders"));
            var lineIndex = 1;
            var successCnt = 0;
            var lines = File.ReadLines(args[0]);
            foreach(var line in lines)
            {
                try
                {
                    var parts = line.Split('\t');
                    if (parts.Length < 5 || (parts.Length - 2) % 3 != 0)
                        throw new ApplicationException("Die Zeile ist nicht richtig formatiert.");
                    var dt = DateTime.Parse(parts[1], cult.DateTimeFormat);
                    if (dt >= DateTime.Today)
                        throw new ApplicationException("Das Belegdatum muss in der Vergangenheit liegen.");
                    var orderEl = new XElement("order",
                        new XAttribute("custno", parts[0]),
                        new XAttribute("date", dt.ToString("yyyy-MM-dd")));
                    for (int j = 2; j <= parts.Length - 1; j += 3)
                    {
                        var itemNoRegex = new Regex("^[ABC][0-9]{4}$");
                        if (!itemNoRegex.IsMatch(parts[j]))
                            throw new ApplicationException(string.Format("Artikelnummer {0} ist ungültig.", parts[j]));
                        else
                        {
                            orderEl.Add(new XElement("pos",
                                new XAttribute("itemno", parts[j]),
                                new XAttribute("quantity", int.Parse(parts[j + 1], cult.NumberFormat).ToString()),
                                new XAttribute("price", decimal.Parse(parts[j + 2], cult.NumberFormat).ToString())));
                        }
                    }
                    doc.Root.Add(orderEl);
                    successCnt += 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Fehler beim Import von Zeile {0}: {1}", lineIndex + 1, ex.Message));
                }
                lineIndex++;
            }
            doc.Save(args[1]);
            Console.WriteLine(string.Format("Es wurden {0} von {1} Aufträgen erfolgreich importiert.", successCnt, lineIndex - 1));
        }
    }
}
