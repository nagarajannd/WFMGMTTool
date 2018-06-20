using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkflowManagementTool
{
    public partial class FormInputDialogBox : Form
    {
        public enum FormDisplayStyle : int
        {
            enOneLineInput = 0,
            enMultiLineInput = 1
        }
        public FormInputDialogBox(FormDisplayStyle style, string labeltext, string textboxtext)
        {
            InitializeComponent();
            label.Text = labeltext;
            textBox.Text = textboxtext;
            if (style == FormDisplayStyle.enOneLineInput)
            {
                this.Size = new Size(347, 147);
                this.label.Font = new Font("Calibri", 9.75F, FontStyle.Regular);
                this.label.Location = new Point(12, 9);
                this.label.Size = new Size(317, 41);

                this.textBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
                this.textBox.Location = new System.Drawing.Point(12, 53);
                this.textBox.Multiline = true;
                this.textBox.Size = new Size(317, 25);
                this.textBox.ScrollBars = ScrollBars.None;

                this.btnOK.Location = new Point(254, 84);
                this.btnOK.Size = new Size(75, 23);
                this.btnCancel.Location = new Point(173, 84);
                this.btnCancel.Size = new Size(75, 23);
            }
            if (style == FormDisplayStyle.enMultiLineInput)
            {
                this.label.Font = new Font("Calibri", 9.75F, FontStyle.Regular);
                this.label.Location = new Point(12, 9);
                this.label.Size = new Size(317, 41);

                this.textBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                this.textBox.Location = new Point(12, 53);
                this.textBox.Multiline = true;
                this.textBox.ScrollBars = ScrollBars.Vertical;
                this.textBox.Size = new Size(460, 188);

                this.btnOK.Location = new Point(397, 247);
                this.btnOK.Size = new Size(75, 23);
                this.btnCancel.Location = new Point(316, 247);
                this.btnCancel.Size = new Size(75, 23);
            }
        }
        public FormInputDialogBox(FormDisplayStyle style, string labeltext, string textboxtext, string titletext)
        {
        }
        private void frmInputDialog_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = textBox.Text.Length > 0;
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = textBox.TextLength > 0;
        }
    }
}
