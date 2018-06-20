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
    public partial class FormWorkFlowProperties : Form
    {
        LibDatabaseHandler db = new LibDatabaseHandler();

        public FormWorkFlowProperties()
        {
            InitializeComponent();
        }
        public FormWorkFlowProperties(int FileID, int VersionID, string FileName)
        {
            InitializeComponent();
            txtFileName.Text = FileName; txtFileID.Text = FileID.ToString(); txtFileVersionID.Text = VersionID.ToString();
            labelTitle.Text = FileName.Length > 0 ? "Properties - " + FileName : "Edit Properties Window";
            labelTitle.Bounds = pnlTitle.Bounds;
        }

        private void FormWorkFlowProperties_Load(object sender, EventArgs e)
        {
            drawTabPageControls();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int result = 0;
            Button btn = (Button)sender;
            TabPage tbpage = (TabPage)btn.Parent;
            TextBox txbox = (TextBox)tbpage.Controls.Find("txtFreeText", false).FirstOrDefault();

            string sqry = "insert into WorkFlowMGMTFileProperties (FileID, VersionID, Category, ContentText, EnteredBy) values (" +
                txtFileID.Text + "," + txtFileVersionID.Text + ",'" + tbpage.Text + "','" + txbox.Text + "','" + Environment.UserName + "')";
            try
            {
                if (db.DBConnect())
                    result = db.ExecuteQuery(sqry);
            }
            catch (Exception ex) { }
            finally { db.DBDisconnect(); }
            txbox.Text = "";
            updategridviewcontrols();
            if (result > 0)
                MessageBox.Show("Data Inserted Successfully..!", "Workflow Management Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int result = 0;
            Button btn = (Button)sender;
            TabPage tbpage = (TabPage)btn.Parent;
            TextBox txbox = (TextBox)tbpage.Controls.Find("txtFreeText", false).FirstOrDefault();
            DataGridView dgvMain = (DataGridView)tbpage.Controls.Find("dgvMain", false).FirstOrDefault();
            string sqry = "update WorkFlowMGMTFileProperties set DeleteFlag = 'Y' where PropID = " + dgvMain.Rows[dgvMain.CurrentRow.Index].Cells[2].Value.ToString();
            try
            {
                if (db.DBConnect())
                    result = db.ExecuteQuery(sqry);
            }
            catch (Exception ex) { }
            finally { db.DBDisconnect(); }
            txbox.Text = "";
            updategridviewcontrols();
            if (result > 0)
                MessageBox.Show("Data Deleted Successfully..!", "Workflow Management Tool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void dgvMain_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgvMain = (DataGridView)sender;
            FormInputDialogBox frm = new FormInputDialogBox(FormInputDialogBox.FormDisplayStyle.enMultiLineInput, "Value :", dgvMain.Rows[dgvMain.CurrentRow.Index].Cells[1].Value.ToString());
            frm.ShowDialog();
        }

        private void updategridviewcontrols()
        {
            if (db.DBConnect())
            {
                foreach (TabPage tbpage in tabControlMain.TabPages)
                {
                    string sqry = "exec WorkFlowMGMTOpenFileProperties '" + txtFileID.Text + "', '" + txtFileVersionID.Text + "', '" + tbpage.Text + "'";
                    DataGridView dgvMain = (DataGridView)tbpage.Controls.Find("dgvMain", false).FirstOrDefault();
                    DataTable dt = new DataTable();
                    dt = db.OpenRecordset(sqry);
                    dgvMain.DataSource = dt;
                }
            }
            db.DBDisconnect();
        }
        private void drawTabPageControls()
        {
            if (db.DBConnect())
            {
                foreach (TabPage tbpage in tabControlMain.TabPages)
                {
                    string sqry = "exec WorkFlowMGMTOpenFileProperties '" + txtFileID.Text + "', '" + txtFileVersionID.Text + "', '" + tbpage.Text + "'";
                    Button btnAdd = new Button();
                    Button btnDelete = new Button();
                    DataGridView dgvMain = new DataGridView();
                    Label labelFreeText = new Label();
                    TextBox txtFreeText = new TextBox();

                    btnDelete.Location = new Point(640, 39);
                    btnDelete.Name = "btnDelete";
                    btnDelete.Size = new Size(67, 27);
                    btnDelete.Text = "Delete";
                    btnDelete.UseVisualStyleBackColor = true;
                    btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

                    dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    dgvMain.Location = new Point(11, 72);
                    dgvMain.Name = "dgvMain";
                    dgvMain.Size = new Size(696, 137);
                    dgvMain.ReadOnly = true;
                    dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dgvMain.ScrollBars = ScrollBars.Both;
                    dgvMain.DoubleClick += (sender, e) => dgvMain_DoubleClick(sender, e);

                    btnAdd.Location = new Point(640, 6);
                    btnAdd.Name = "btnAdd";
                    btnAdd.Size = new Size(67, 27);
                    btnAdd.Text = "Add";
                    btnAdd.UseVisualStyleBackColor = true;
                    btnAdd.Click += new System.EventHandler(btnAdd_Click);

                    labelFreeText.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    labelFreeText.Location = new Point(8, 8);
                    labelFreeText.Name = "labelFreeText";
                    labelFreeText.Size = new Size(68, 40);
                    labelFreeText.Text = tbpage.Text;
                    labelFreeText.TextAlign = ContentAlignment.MiddleRight;

                    txtFreeText.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    txtFreeText.Location = new Point(82, 6);
                    txtFreeText.Multiline = true;
                    txtFreeText.Name = "txtFreeText";
                    txtFreeText.ScrollBars = ScrollBars.Vertical;
                    txtFreeText.Size = new Size(552, 60);

                    tbpage.Controls.Add(btnDelete);
                    tbpage.Controls.Add(dgvMain);
                    tbpage.Controls.Add(btnAdd);
                    tbpage.Controls.Add(labelFreeText);
                    tbpage.Controls.Add(txtFreeText);

                    DataTable dt = new DataTable();
                    dt = db.OpenRecordset(sqry);
                    dgvMain.DataSource = dt;

                    dgvMain.Columns[2].Visible = false;
                }
            }
            db.DBDisconnect();
        }
    }
}
