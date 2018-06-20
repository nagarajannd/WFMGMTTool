using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMSupportLibrary;

namespace WorkflowManagementTool
{
    public partial class FormOpenWorkFlowVersion : Form
    {
        LibDatabaseHandler db = new LibDatabaseHandler();
        int FileID = 0;

        public FormOpenWorkFlowVersion(int File)
        {
            InitializeComponent();
            FileID = File;
            lblOutput.Text = "1";
        }
        private void FormOpenWorkFlowVersion_Load(object sender, EventArgs e)
        {
            dataGridView.Width += 2;
            dataGridView.Height += 2;
            dataGridView.Top = dataGridView.Left = -1;
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            db.DBConnect();
            DataTable dt = db.OpenRecordset("exec WorkFlowMGMTFileVersionList " + FileID.ToString());
            db.DBDisconnect();
            dataGridView.DataSource = dt;
            dataGridView.Refresh();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DataGridView dv = dataGridView;
            lblOutput.Text = dv.Rows[dv.CurrentRow.Index].Cells[1].Value.ToString();
        }
    }
}
