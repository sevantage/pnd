namespace Pnd.sev.Converter.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblConv = new System.Windows.Forms.Label();
            this.cmbConv = new System.Windows.Forms.ComboBox();
            this.cmbFromUnit = new System.Windows.Forms.ComboBox();
            this.lblFromUnit = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbToUnit = new System.Windows.Forms.ComboBox();
            this.lblToUnit = new System.Windows.Forms.Label();
            this.lblResultTitle = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConv
            // 
            this.lblConv.AutoSize = true;
            this.lblConv.Location = new System.Drawing.Point(129, 16);
            this.lblConv.Name = "lblConv";
            this.lblConv.Size = new System.Drawing.Size(56, 13);
            this.lblConv.TabIndex = 0;
            this.lblConv.Text = "&Konverter:";
            // 
            // cmbConv
            // 
            this.cmbConv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConv.FormattingEnabled = true;
            this.cmbConv.Location = new System.Drawing.Point(200, 13);
            this.cmbConv.Name = "cmbConv";
            this.cmbConv.Size = new System.Drawing.Size(121, 21);
            this.cmbConv.TabIndex = 1;
            this.cmbConv.SelectedIndexChanged += new System.EventHandler(this.cmbConv_SelectedIndexChanged);
            // 
            // cmbFromUnit
            // 
            this.cmbFromUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromUnit.FormattingEnabled = true;
            this.cmbFromUnit.Location = new System.Drawing.Point(200, 40);
            this.cmbFromUnit.Name = "cmbFromUnit";
            this.cmbFromUnit.Size = new System.Drawing.Size(121, 21);
            this.cmbFromUnit.TabIndex = 3;
            this.cmbFromUnit.SelectedIndexChanged += new System.EventHandler(this.cmbFromUnit_SelectedIndexChanged);
            // 
            // lblFromUnit
            // 
            this.lblFromUnit.AutoSize = true;
            this.lblFromUnit.Location = new System.Drawing.Point(97, 43);
            this.lblFromUnit.Name = "lblFromUnit";
            this.lblFromUnit.Size = new System.Drawing.Size(88, 13);
            this.lblFromUnit.TabIndex = 2;
            this.lblFromUnit.Text = "&Ausgangseinheit:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(142, 71);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "&Menge:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(200, 68);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(121, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // cmbToUnit
            // 
            this.cmbToUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToUnit.FormattingEnabled = true;
            this.cmbToUnit.Location = new System.Drawing.Point(200, 94);
            this.cmbToUnit.Name = "cmbToUnit";
            this.cmbToUnit.Size = new System.Drawing.Size(121, 21);
            this.cmbToUnit.TabIndex = 7;
            this.cmbToUnit.SelectedIndexChanged += new System.EventHandler(this.cmbToUnit_SelectedIndexChanged);
            // 
            // lblToUnit
            // 
            this.lblToUnit.AutoSize = true;
            this.lblToUnit.Location = new System.Drawing.Point(127, 97);
            this.lblToUnit.Name = "lblToUnit";
            this.lblToUnit.Size = new System.Drawing.Size(58, 13);
            this.lblToUnit.TabIndex = 6;
            this.lblToUnit.Text = "&Zieleinheit:";
            // 
            // lblResultTitle
            // 
            this.lblResultTitle.AutoSize = true;
            this.lblResultTitle.Location = new System.Drawing.Point(127, 123);
            this.lblResultTitle.Name = "lblResultTitle";
            this.lblResultTitle.Size = new System.Drawing.Size(51, 13);
            this.lblResultTitle.TabIndex = 8;
            this.lblResultTitle.Text = "&Ergebnis:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(197, 123);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 9;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 154);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblResultTitle);
            this.Controls.Add(this.cmbToUnit);
            this.Controls.Add(this.lblToUnit);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.cmbFromUnit);
            this.Controls.Add(this.lblFromUnit);
            this.Controls.Add(this.cmbConv);
            this.Controls.Add(this.lblConv);
            this.Name = "frmMain";
            this.Text = "Konverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConv;
        private System.Windows.Forms.ComboBox cmbConv;
        private System.Windows.Forms.ComboBox cmbFromUnit;
        private System.Windows.Forms.Label lblFromUnit;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbToUnit;
        private System.Windows.Forms.Label lblToUnit;
        private System.Windows.Forms.Label lblResultTitle;
        private System.Windows.Forms.Label lblResult;
    }
}

