using sevantage.Pnd.Converter.Base;
using Pnd.sev.Converter.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pnd.sev.Converter.UI
{
    public partial class frmMain : Form
    {
        private readonly ILogger logger;

        public frmMain()
        {
            var logFilePath = GetLogFilePath();
            DeleteLogFileIfPresent(logFilePath);
            logger = new FileLogger(logFilePath);
            InitializeComponent();
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var converters = new Loader().LoadFrom(path, logger);
            if (!converters.Any())
            {
                logger.Log($"Unable to load any converters from path {path}.");
                MessageBox.Show("Es konnten keine Konverter geladen werden.");
                return;
            }
            BindConverters(converters);
            BindToUnits();
        }

        private static string GetLogFilePath()
        {
            var tempPath = Path.GetTempPath();
            var fileName = "Pnd.sev.Converter.log";
            return Path.Combine(tempPath, fileName);
        }

        private static void DeleteLogFileIfPresent(string logFilePath)
        {
            if (File.Exists(logFilePath))
                File.Delete(logFilePath);
        }

        private void BindConverters(IEnumerable<IConverter> converters)
        {
            cmbConv.DataSource = converters;
            cmbConv.SelectedIndex = 0;
        }

        private IConverter GetCurrentConverter()
        {
            return (IConverter)cmbConv.SelectedItem;
        }

        private sevantage.Pnd.Converter.Base.Unit GetUnit(ComboBox cmb)
        {
            if (cmb.SelectedIndex < 0)
                return null;
            return (sevantage.Pnd.Converter.Base.Unit)cmb.SelectedItem;
        }

        private void BindToUnits()
        {
            var fromUnit = (sevantage.Pnd.Converter.Base.Unit)cmbFromUnit.SelectedItem;
            var toUnits = GetCurrentConverter().SupportedUnits.Where(x => !x.Equals(fromUnit)).ToArray();
            cmbToUnit.DataSource = toUnits.OrderBy(x => x).ToArray();
        }

        private void UpdateResult()
        {
            try
            {
                var conv = GetCurrentConverter();
                var fromUnit = GetUnit(cmbFromUnit);
                var toUnit = GetUnit(cmbToUnit);
                if (conv != null
                    && fromUnit != null
                    && toUnit != null
                    && !string.IsNullOrWhiteSpace(txtAmount.Text)
                    && decimal.TryParse(txtAmount.Text, out var amount))
                {
                    lblResult.Text = conv.Convert(new Value(fromUnit, amount), toUnit).Amount.ToString();
                }
                else
                    lblResult.Text = "---";
            }
            catch(Exception ex)
            {
                logger.Log($"Error during conversion: {ex.ToString()}");
                MessageBox.Show($"Fehler bei der Konvertierung: {ex.Message}", "Konverter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbConv_SelectedIndexChanged(object sender, EventArgs e)
        {
            IConverter conv = GetCurrentConverter();
            cmbFromUnit.DataSource = conv.SupportedUnits.OrderBy(x => x).ToArray();
            txtAmount.Text = "0";
            cmbToUnit.DataSource = null;
        }

        private void cmbFromUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindToUnits();
        }

        private void cmbToUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }
    }
}
