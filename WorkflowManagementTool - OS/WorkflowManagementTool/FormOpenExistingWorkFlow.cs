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
    public partial class FormOpenExistingWorkFlow : Form
    {
        LibDatabaseHandler db = new LibDatabaseHandler();
        public FormOpenExistingWorkFlow()
        {
            InitializeComponent();
        }
        private void frmOpenWorkflow_Load(object sender, EventArgs e)
        {
            dataGridView.Height += 2;
            dataGridView.Width += 2;
            dataGridView.Top = dataGridView.Left = -1;
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            db.DBConnect();
            DataTable dt = db.OpenRecordset("exec WorkFlowMGMTOpenFileList");
            db.DBDisconnect();
            dataGridView.DataSource = dt;
            dataGridView.Columns[0].Visible = dataGridView.Columns[6].Visible = false;
            dataGridView.Refresh();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DataGridView dv = dataGridView;
            lblOutput.Text = dv.Rows[dv.CurrentRow.Index].Cells[4].Value.ToString();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.DBConnect();
            db.ExecuteQuery("update WorkFlowMGMTFileList set DeleteFlag = 'Y' where FileID = " + dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString());
            MessageBox.Show("Delete successfull!");
            db.DBDisconnect();
            frmOpenWorkflow_Load(null, null);
        }
        private void btnChooseVersion_Click(object sender, EventArgs e)
        {
            DataGridView dv = dataGridView;
            FormOpenWorkFlowVersion frm = new FormOpenWorkFlowVersion(int.Parse(dv.Rows[dv.CurrentRow.Index].Cells[0].Value.ToString()));
            frm.Text = dv.Rows[dv.CurrentRow.Index].Cells[1].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblOutput.Text = frm.lblOutput.Text;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
