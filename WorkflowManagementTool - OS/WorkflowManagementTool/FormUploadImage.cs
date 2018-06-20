using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using WMSupportLibrary;

namespace WorkflowManagementTool
{
    public partial class FormUploadImage : Form
    {
        public static Image newbmp = null;
        private bool isCropWindow = false;
       
        public FormUploadImage()
        {
            InitializeComponent();
        }
        public static Image GetImageFromScreenOrFile()
        {
            FormUploadImage frm = new FormUploadImage();
            return frm.ShowDialog() == DialogResult.OK ? newbmp : null;
        }
        public static Image GetImageFromScreenOrFile(Image img)
        {
            FormUploadImage frm = new FormUploadImage();
            frm.picBox.Image = newbmp = img;
            frm.ShowDialog();
            return newbmp;
        }

        private void frmSelectOpenWindow_Load(object sender, EventArgs e)
        {
            btnCapture.Visible = cbActiveWindows.Visible = false;
            toolStripbuttonSubmit.Enabled = (picBox.Image != null);
        }
        private void FormUploadImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Image bmp = null;
            if (!isCropWindow)
                bmp = LibScreenScraperHelper.Snip((IntPtr)cbActiveWindows.SelectedValue);
            else
                bmp = LibScreenScraperHelper.SnipWindow((IntPtr)cbActiveWindows.SelectedValue);
            if (bmp != null) { newbmp = bmp; }
            picBox.Image = newbmp;
            toolStripbuttonSubmit.Enabled = (newbmp != null);
            this.Activate();
        }
        
        private void toolStripbuttonSubmit_Click(object sender, EventArgs e)
        {
            if (newbmp != null)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }
        private void cropNewImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCropWindow = false;
            BindActiveWindowList();
        }
        private void cropOpenWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCropWindow = true;
            BindActiveWindowList();
        }
        private void openExistingImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (dlg.ShowDialog() == DialogResult.OK)
                newbmp = Image.FromFile(dlg.FileName);
            if (newbmp != null)
            {
                picBox.Image = newbmp;
                toolStripbuttonSubmit.Enabled = true;
                picBox.Visible = true;
            }
        }
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            picBox.Image = newbmp = null;
            DialogResult = DialogResult.OK;
        }
        private void picBox_DoubleClick(object sender, EventArgs e)
        {
            Image bmp = picBox.Image;
            string path = Path.GetTempFileName() + ".jpg";
            bmp.Save(path,System.Drawing.Imaging.ImageFormat.Jpeg);
            Process.Start(path);
        }

        private void BindActiveWindowList()
        {
            btnCapture.Visible = cbActiveWindows.Visible = picBox.Visible = true;
            DataTable dt = new DataTable();
            dt.Columns.Add("Handle", typeof(IntPtr));
            dt.Columns.Add("Title", typeof(string));
            Process[] processes = Process.GetProcesses();
            foreach (Process prc in processes)
                if (prc.MainWindowHandle != IntPtr.Zero && prc.MainWindowTitle.Length > 0)
                    dt.Rows.Add(prc.MainWindowHandle, prc.MainWindowTitle);
            cbActiveWindows.DataSource = dt;
            cbActiveWindows.ValueMember = "Handle";
            cbActiveWindows.DisplayMember = "Title";
        }
    }
}
