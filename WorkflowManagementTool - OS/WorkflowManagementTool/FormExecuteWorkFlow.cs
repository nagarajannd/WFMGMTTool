using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using WMSupportLibrary;

namespace WorkflowManagementTool
{
    public partial class FormExecuteWorkFlow : Form
    {
        LibDatabaseHandler db = new LibDatabaseHandler();
        DataTable mdt = new DataTable();
        Dictionary<string, Image> treeRefImages = new Dictionary<string, Image>();
        List<string> downloadimages = new List<string>();
        int nodeindex = 0, axisY = 40, axisX = 40;
        int fileindex = 0, versionindex = 0; string filename;
        Button lastcontrol = null;
        bool isQuestionAnswered = false, isFlowCompleted = false;
        Color m_backcolor = Color.White;

        public FormExecuteWorkFlow()
        {
            InitializeComponent();
            resetcurrentform();
        }
        private void FormExecuteWorkFlow_Load(object sender, EventArgs e)
        {
            picBox.BackgroundImageLayout = ImageLayout.Stretch;
            picBox.BackgroundImage = null;
        }
        private void FormExecuteWorkFlow_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (string path in downloadimages)
            {
                try
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }
                catch { }
            }
        }

        private void flowBtnClickEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            displaycurrentsteptext(btn.Text, btn.Tag.ToString());
            displaycurrentsteppicture(btn.Tag.ToString());
        }
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (!isFlowCompleted)
            {
                bool isValid = false;
                if (isQuestionAnswered)
                {
                    String tag = string.Empty;
                    if (rbtnoption1.Checked)
                        tag = rbtnoption2.Tag.ToString();
                    if (rbtnoption2.Checked)
                        tag = rbtnoption1.Tag.ToString();
                    deletechilds(int.Parse(tag), ref mdt);
                    deletenode(int.Parse(tag), ref mdt);
                    isQuestionAnswered = rbtnoption1.Checked = rbtnoption2.Checked = rbtnoption1.Visible = rbtnoption2.Visible = false;
                }
                if (nodeindex == 0)
                {
                    var line = mdt.AsEnumerable().OrderBy(x => x.Field<int>("RowIndex")).Select(x => x.Field<int>("NodeID")).Take(1).ToArray();
                    if (line.Length > 0)
                        nodeindex = line[0];
                    else
                        isFlowCompleted = true;
                    isValid = line.Length > 0;
                }
                else
                {
                    var line = mdt.AsEnumerable().Where(x => x.Field<int>("NodeID") > nodeindex).OrderBy(x => x.Field<int>("RowIndex")).Select(x => x.Field<int>("NodeID")).Take(1).ToArray();
                    if (line.Length > 0)
                        nodeindex = line[0];
                    else
                        isFlowCompleted = true;
                    isValid = line.Length > 0;
                }

                if (isValid)
                {
                    var rdt = mdt.AsEnumerable().Where(t => t.Field<int>("NodeID") == nodeindex).CopyToDataTable();
                    if (rdt.Rows.Count > 0)
                    {
                        displaycurrentsteptext(rdt.DefaultView[0][2].ToString(), nodeindex.ToString());
                        drawshape(rdt);
                        displaycurrentsteppicture(nodeindex.ToString());
                        if (rdt.DefaultView[0][3].ToString().ToLower().Contains("[question]"))
                        {
                            rdt = mdt.AsEnumerable().Where(t => t.Field<int>("ParentID") == int.Parse(rdt.DefaultView[0][1].ToString())).CopyToDataTable();
                            var yesdt = rdt.AsEnumerable().Where(x => x.Field<string>("Tag").ToLower().Contains("[answeryes]")).CopyToDataTable();
                            var nodt = rdt.AsEnumerable().Where(x => x.Field<string>("Tag").ToLower().Contains("[answerno]")).CopyToDataTable();

                            if (yesdt != null)
                            {
                                rbtnoption1.Visible = true;
                                rbtnoption1.Tag = yesdt.DefaultView[0][1].ToString();
                                rbtnoption1.Text = yesdt.DefaultView[0][2].ToString();
                            }
                            if (nodt != null)
                            {
                                rbtnoption2.Visible = true;
                                rbtnoption2.Tag = nodt.DefaultView[0][1].ToString();
                                rbtnoption2.Text = nodt.DefaultView[0][2].ToString();
                            }
                            btnNextStep.Enabled = isQuestionAnswered = false;
                        }
                    }
                }
                else
                    drawstartendshape(false);
            }
            else
                MessageBox.Show("End of process");
        }
        private void rbtnoption1_CheckedChanged(object sender, EventArgs e)
        {
            isQuestionAnswered = true;
            btnNextStep.Enabled = true;
        }
        private void picBox_DoubleClick(object sender, EventArgs e)
        {
            Image bmp = picBox.BackgroundImage;
            if (bmp != null)
            {
                string path = Path.GetTempFileName().Replace(".tmp", "") + ".jpg";
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                downloadimages.Add(path);
                Process.Start(path);
            }
        }

        private void pulltreedatafromdb(int index, int version)
        {
            string qry = "exec WorkFlowMGMTPullTreeNodes " + index.ToString() + ", " + version.ToString();
            if (db.DBConnect())
                mdt = db.OpenRecordset(qry);
            db.DBDisconnect();
            pullImagesfromdb(index, version);
        }
        private void pullImagesfromdb(int index, int version)
        {
            DataTable dt = new DataTable();
            string qry = "exec WorkFlowMGMTPullTreeImages " + index.ToString() + ", " + version.ToString();
            if (db.DBConnect())
                dt = db.OpenRecordset(qry);
            db.DBDisconnect();
            treeRefImages.Clear();
            foreach (DataRowView dv in dt.DefaultView)
                treeRefImages.Add(dv["NodeIndex"].ToString(), imagefrombase64Encoding(dv["BinaryImage"].ToString()));
        }
        private void displaycurrentsteptext(string text, string index)
        {
            txtStepNo.Text = " " + index;
            txtCurrentStep.Text = text;
        }
        private void displaycurrentsteppicture(string index)
        {
            picBox.BackgroundImage = treeRefImages.ContainsKey(index) ? treeRefImages[index] : null;
        }
        private void drawshape(DataTable dt)
        {
            string nodetype; Color backcolor = m_backcolor, forecolor = Color.Black; Font font = new Font("Segoe UI", 9, FontStyle.Regular);
            Padding padding = new Padding(10);
            ContentAlignment textalign = ContentAlignment.MiddleLeft;

            //cnt++;
            //if (cnt % 3 == 0)
            //    backcolor = m_backcolor = Color.FromArgb(m_backcolor.R - 2, m_backcolor.G, m_backcolor.B);
            //else if (cnt % 2 == 0)
            //    backcolor = m_backcolor = Color.FromArgb(m_backcolor.R, m_backcolor.G - 2, m_backcolor.B);
            //else
            //    backcolor = m_backcolor = Color.FromArgb(m_backcolor.R, m_backcolor.G, m_backcolor.B - 2);

            nodetype = dt.DefaultView[0][3].ToString().ToLower();
            if(nodetype.Contains("[root]"))
            {
                backcolor = Color.DarkSlateGray;
                forecolor = Color.White;
                font = new Font("Segoe UI", 10, FontStyle.Bold);
                padding = new Padding(40, 10, 40, 10);
                textalign = ContentAlignment.MiddleCenter;
            }
            else if (nodetype.Contains("[image]"))
            {
                backcolor = Color.Plum;
                forecolor = Color.White;
                font = new Font("Segoe UI", 10, FontStyle.Regular);
                padding = new Padding(40, 10, 40, 10);
                textalign = ContentAlignment.MiddleCenter;
            }
            else if (nodetype.Contains("[question]"))
            {
                backcolor = Color.Peru;
                forecolor = Color.White;
                font = new Font("Segoe UI", 10, FontStyle.Bold | FontStyle.Italic);
                padding = new Padding(40, 10, 40, 10);
                textalign = ContentAlignment.MiddleCenter;
            }
            else if (nodetype.Contains("[answeryes]"))
            {
                backcolor = Color.ForestGreen;
                forecolor = Color.White;
                font = new Font("Segoe UI", 10, FontStyle.Bold);
                padding = new Padding(40, 10, 40, 10);
            }
            else if (nodetype.Contains("[answerno]"))
            {
                backcolor = Color.Coral;
                forecolor = Color.White;
                font = new Font("Segoe UI", 10, FontStyle.Bold);
                padding = new Padding(40, 10, 40, 10);
            }
            axisY = lastcontrol != null ? lastcontrol.Bottom + 20 : 40;
            axisX = lastcontrol != null ? lastcontrol.Left : 40;

            if (lastcontrol != null)
            {
                PictureBox picbox = new PictureBox();
                picbox.BackgroundImage = global::WorkflowManagementTool.Properties.Resources.arrowdown;
                picbox.BackgroundImageLayout = ImageLayout.Stretch;
                pnlWorkFlow.Controls.Add(picbox);
                picbox.SetBounds(pnlWorkFlow.Width / 2 - 10, lastcontrol.Bottom, 20, 20);
            }
            Button btn = new Button();
            btn.Text = dt.DefaultView[0][2].ToString();
            btn.Tag = dt.DefaultView[0][1].ToString();
            btn.BackColor = backcolor; btn.Font = font; btn.ForeColor = forecolor; btn.Padding = padding; btn.TextAlign = textalign;
            btn.AutoSize = true; btn.AutoSizeMode = AutoSizeMode.GrowOnly; btn.AutoEllipsis = false;
            pnlWorkFlow.Controls.Add(btn);

            axisX = pnlWorkFlow.Width / 2 - btn.Width / 2;
            btn.SetBounds(axisX, axisY, btn.Width, btn.Height);

            if (btn.Width > pnlWorkFlow.Width)
            {
                btn.AutoSize = false;
                Size textsize = TextRenderer.MeasureText(btn.Text, btn.Font);
                int rows = (int)Math.Round((((double)(textsize.Width) + 40) / (double)pnlWorkFlow.Width) + 0.49999);
                btn.SetBounds(20, axisY, pnlWorkFlow.Width - 40, (int)(((btn.Height) * rows)) - (15 * rows));
            }

            btn.Focus();
            btn.Click += (sender, e) => flowBtnClickEvent(sender, e);
            lastcontrol = btn;
        }
        private void drawstartendshape(bool isstartshape)
        {
            if (isstartshape)
            {
                Button btn = new Button();
                PictureBox picbox = new PictureBox();
                picbox.BackgroundImage = global::WorkflowManagementTool.Properties.Resources.FlowStart;
                picbox.BackgroundImageLayout = ImageLayout.Stretch;
                pnlWorkFlow.Controls.Add(picbox);
                picbox.SetBounds(pnlWorkFlow.Width / 2 - 60, 40, 120, 60);
                axisY += 60;
                btn.SetBounds(0, axisY, 0, 0);
                lastcontrol = btn;
            }
            else
            {
                PictureBox picbox;
                if (lastcontrol != null)
                {
                    picbox = new PictureBox();
                    picbox.BackgroundImage = global::WorkflowManagementTool.Properties.Resources.arrowdown;
                    picbox.BackgroundImageLayout = ImageLayout.Stretch;
                    pnlWorkFlow.Controls.Add(picbox);
                    picbox.SetBounds(pnlWorkFlow.Width / 2 - 10, lastcontrol.Bottom, 20, 20);
                }
                picbox = new PictureBox();
                picbox.BackgroundImage = global::WorkflowManagementTool.Properties.Resources.FlowEnd;
                picbox.BackgroundImageLayout = ImageLayout.Stretch;
                pnlWorkFlow.Controls.Add(picbox);
                axisY = lastcontrol.Bottom + 20;
                picbox.SetBounds(pnlWorkFlow.Width / 2 - 60, axisY, 120, 60);
                pnlWorkFlow.VerticalScroll.Value = pnlWorkFlow.VerticalScroll.Maximum;
            }
        }

        private void deletenode(int nodeid, ref DataTable mdt)
        {
            mdt = mdt.AsEnumerable().Where(x => x.Field<int>("NodeID") != nodeid).CopyToDataTable();
        }
        private void deletechilds(int nodeid, ref DataTable mdt)
        {
            var childs = mdt.AsEnumerable().Where(x => x.Field<int>("ParentID") == nodeid).Select(x => x.Field<int>("NodeID")).ToArray();
            if (childs.Length > 0)
            {
                foreach (var child in childs)
                {
                    mdt = mdt.AsEnumerable().Where(x => x.Field<int>("NodeID") != child).CopyToDataTable();
                    deletechilds(child, ref mdt);
                }
            }
        }
        private Image imagefrombase64Encoding(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            using (MemoryStream ms = new MemoryStream(bytes))
                return Image.FromStream(ms);
        }
        
        private void resetcurrentform()
        {
            axisY = axisX = 40;
            gBoxCurrentProcessStep.Enabled = gBoxProperties.Enabled = pnlWorkFlow.Enabled = false;
            foreach (Control ctrl in pnlWorkFlow.Controls)
            {
                pnlWorkFlow.Controls.Remove(ctrl); ctrl.Dispose();
            }
            pnlWorkFlow.Refresh();
            rbtnoption1.Visible = rbtnoption2.Visible = false;
            picBox.BackgroundImage = null;
            btnNextStep.Enabled = true;
        }
        private void resetcurrentformafteropen()
        {
            axisY = axisX = 40;
            gBoxCurrentProcessStep.Enabled = gBoxProperties.Enabled = pnlWorkFlow.Enabled = true;
            rbtnoption1.Visible = rbtnoption2.Visible = false;
            btnNextStep.Enabled = true;
            picBox.BackgroundImage = null;
            foreach (Control ctrl in pnlWorkFlow.Controls)
            {
                pnlWorkFlow.Controls.Remove(ctrl); ctrl.Dispose();
            }
            pnlWorkFlow.Refresh();
            pnlWorkFlow.Controls.Clear();
            lastcontrol = null;
            isQuestionAnswered = isFlowCompleted = false;
            nodeindex = 0;
            drawstartendshape(true);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = null;
            FormOpenExistingWorkFlow opnwrkflw = new FormOpenExistingWorkFlow();
            if (opnwrkflw.ShowDialog() == DialogResult.OK)
            {
                dr = opnwrkflw.dataGridView.SelectedRows[0];
            }
            if (dr != null)
            {
                fileindex = int.Parse(dr.Cells[0].Value.ToString());
                versionindex = int.Parse(dr.Cells[6].Value.ToString());
                filename = dr.Cells[1].Value.ToString();
                pulltreedatafromdb(fileindex, versionindex);
                resetcurrentformafteropen();
                string claim = string.Empty;
                while (claim == string.Empty)
                {
                    FormInputDialogBox frm = new FormInputDialogBox(FormInputDialogBox.FormDisplayStyle.enOneLineInput, "Please Input Claim Number :", "");
                    claim = txtClaimNo.Text = frm.ShowDialog() == DialogResult.OK ? frm.textBox.Text : "";
                }
                starttimerframe(true);
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetcurrentform();
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void closeWorkflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetcurrentform();
            mdt = null;
        }

        private void starttimerframe(bool start)
        {
            Form frm = new Form();
            Label lbl = new Label();
            Stopwatch sw = new Stopwatch();
            Timer tmr = new Timer();
            tmr.Interval = 1000;
            
            frm.Controls.Add(lbl);
            frm.TopMost = true;

            frm.Height = 50; frm.Width = 150;
            lbl.Height = 50; lbl.Width = 150;
            lbl.Location = new Point(0, 0);
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = "00:00:00";
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Opacity = 0.6D;
            Rectangle res = Screen.PrimaryScreen.WorkingArea;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(res.Width - frm.Width, res.Height - frm.Height);

            frm.Show();
            sw.Start(); tmr.Start();
            tmr.Tick += (sender, e) => {
                lbl.Text = sw.Elapsed.ToString("hh\\:mm\\:ss");
            };
        }
    }
}
