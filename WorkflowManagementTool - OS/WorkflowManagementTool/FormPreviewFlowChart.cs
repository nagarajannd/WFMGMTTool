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
    public partial class FormPreviewFlowChart : Form
    {
        LibDatabaseHandler db = new LibDatabaseHandler();
        DataTable mdt = new DataTable();
        int iHeight = 20, iWidth = 70, x = 0, y = 0;
        int h_btn = 30, w_btn = 30, d_space = 5;
        Button lastcontrol;

        public FormPreviewFlowChart()
        {
            InitializeComponent();
        }
        private void FormPreviewFlowChart_Load(object sender, EventArgs e)
        {
            loadworkflowdata(25, 5);
            calculateworkflowarea();
            drawflowchart();
        }

        private void loadworkflowdata(int fileid, int fileversion)
        {
            try
            {
                if (db.DBConnect())
                    mdt = db.OpenRecordset("exec WorkFlowMGMTPullTreeNodes " + fileid.ToString() + ", " + fileversion.ToString());
            }
            catch (Exception ex) { }
            finally { db.DBDisconnect(); }
        }
        private void calculateworkflowarea()
        {
            pnlMain.SetBounds(0, 0, 0, 0);
            foreach (DataRowView dv in mdt.DefaultView)
            {
                iHeight += (h_btn + d_space);
                if (dv[3].ToString().Contains("Question"))
                    iWidth += ((w_btn + d_space) * 2);
            }
            //iWidth += 1500;
            pnlMain.SetBounds(0, 0, iWidth, iHeight);
        }

        private void drawflowchart()
        {
            DataTable fstline = mdt.AsEnumerable().OrderBy(t => t.Field<int>("RowIndex")).Take(1).CopyToDataTable();
            foreach (DataRowView dv in fstline.DefaultView)
            {
                Button btn = new Button();
                btn.Text = dv[1].ToString(); btn.Tag = dv[3].ToString();
                btn.Width = w_btn; btn.Height = h_btn;
                btn.SetBounds(iWidth / 2 - w_btn / 2, 20, w_btn, h_btn);
                pnlMain.Controls.Add(btn);
                lastcontrol = btn;
                drawcontrols(int.Parse(btn.Text), btn);
            }
        }
        private void drawcontrols(int index, Button prevBtn)
        {
            var rows = mdt.AsEnumerable().OrderBy(t => t.Field<int>("RowIndex")).Where(t => t.Field<int>("ParentID") == index).ToArray();
            if (rows.Length > 0)
            {
                var dt = mdt.AsEnumerable().OrderBy(t => t.Field<int>("RowIndex")).Where(t => t.Field<int>("ParentID") == index).CopyToDataTable();
                foreach (DataRowView dv in dt.DefaultView)
                {
                    Button btn = new Button();
                    btn.Text = dv[1].ToString(); btn.Tag = dv[3].ToString();
                    btn.Width = w_btn; btn.Height = h_btn;

                    if (prevBtn.Tag.ToString().Contains("Question"))
                    {
                        if (dv[3].ToString().Contains("AnswerYes"))
                        {
                            int childs = countchildquestions(int.Parse(btn.Text));
                            btn.SetBounds(prevBtn.Bounds.Left - ((d_space + w_btn) * childs), prevBtn.Bounds.Bottom + d_space, w_btn, h_btn);
                        }
                        if (dv[3].ToString().Contains("AnswerNo"))
                        {
                            int childs = countchildquestions(int.Parse(btn.Text));
                            btn.SetBounds(prevBtn.Bounds.Right + ((d_space + w_btn) * childs) - w_btn, prevBtn.Bounds.Bottom + d_space, w_btn, h_btn);
                        }
                    }
                    else
                    {
                        btn.SetBounds(parentcontrol(int.Parse(btn.Text)).Bounds.Left, lastcontrol.Bounds.Bottom + d_space, w_btn, h_btn);
                    }
                    if (btn.Tag.ToString().Contains("Question"))
                        btn.BackColor = Color.Purple;
                    if (btn.Tag.ToString().Contains("AnswerYes"))
                        btn.BackColor = Color.LightGreen;
                    if (btn.Tag.ToString().Contains("AnswerNo"))
                        btn.BackColor = Color.OrangeRed;

                    pnlMain.Controls.Add(btn);
                    lastcontrol = btn;
                    drawcontrols(int.Parse(btn.Text), btn);
                }
            }
        }

        private int countchildquestions(int index)
        {
            int cnt = 1;
            //var parent = mdt.AsEnumerable().Where(t => t.Field<int>("NodeID") == index).Select(t => t.Field<int>("ParentID")).Take(1).ToArray();
            //var opindex = mdt.AsEnumerable().Where(t => t.Field<int>("ParentID") == parent[0] && t.Field<int>("NodeID") != index).Select(t => t.Field<int>("NodeID")).Take(1).ToArray();
            //if (opindex.Length > 0)
            //    countchildquestions(opindex[0], ref cnt);
            countchildquestions(index, ref cnt);
            return cnt;
        }
        private void countchildquestions(int index, ref int cnt)
        {
            var rows = mdt.AsEnumerable().Where(x => x.Field<int>("ParentID") == index);
            DataTable tmpdt = null;
            if (rows.ToArray().Length > 0)
            {
                tmpdt = mdt.AsEnumerable().Where(x => x.Field<int>("ParentID") == index).CopyToDataTable();
                foreach (DataRowView dv in tmpdt.DefaultView)
                {
                    if (dv["Tag"].ToString().ToLower().Contains("[question]"))
                        cnt++;
                    countchildquestions(int.Parse(dv["NodeID"].ToString()), ref cnt);
                }
            }
        }
        private Button parentcontrol(int index)
        {
            var parent = mdt.AsEnumerable().Where(t => t.Field<int>("NodeID") == index).Select(t => t.Field<int>("ParentID")).Take(1).ToArray();
            Button ret = null;
            foreach (Button btn in pnlMain.Controls)
            {
                if (btn.Text.Contains(parent[0].ToString()))
                    ret = btn;
            }
            return ret;
        }
    }
}
