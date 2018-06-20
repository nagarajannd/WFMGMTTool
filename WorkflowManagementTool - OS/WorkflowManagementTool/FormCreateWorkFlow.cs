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
    public partial class FormCreateWorkFlow : Form
    {
        TreeNode node, clipboardnode;
        LibDatabaseHandler db = new LibDatabaseHandler();
        Dictionary<string, Image> treeRefImages = new Dictionary<string, Image>();
        Dictionary<string, string> settings = LibGlobalSettings.getGlobalSetting();
        List<string> downloadimages = new List<string>();
        ImageList imgList = new ImageList();
        string filename = string.Empty; int fileindex = 0, versionindex = 0; bool isdatasaved = true;

        public FormCreateWorkFlow()
        {
            InitializeComponent();
            tmrMain.Start();
        }
        private void frmCreateWorkflow_Load(object sender, EventArgs e)
        {
            imgList.Images.Add("noimg", global::WorkflowManagementTool.Properties.Resources.no_image_dots);
            imgList.Images.Add("icon", global::WorkflowManagementTool.Properties.Resources.Open_Image);
            treeViewMain.ImageList = imgList;
            resetcurrentform();
        }
        private void FormCreateWorkFlow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isdatasaved && treeViewMain.Nodes.Count > 0)
            {
                switch (MessageBox.Show("Do you want to save the workflow ?", "Close Workflow", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        saveToolStripMenuItem_Click(null, null);
                        frmCreateWorkflow_Load(null, null);
                        this.Close();
                        foreach (string path in downloadimages)
                        {
                            try
                            {
                                if (File.Exists(path))
                                    File.Delete(path);
                            }
                            catch { }
                        }
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        isdatasaved = true;
                        this.Close();
                        foreach (string path in downloadimages)
                        {
                            try
                            {
                                if (File.Exists(path))
                                    File.Delete(path);
                            }
                            catch { }
                        }
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            picBox.Visible = false;
            TreeView tree = (TreeView)sender;
            node = tree.SelectedNode;
            toolStripTextBoxNodeIndex.Text = toolStripLabelNodeType.Text = string.Empty;
            toolStripNodeItems.Enabled = (node != null);
            if (node != null)
            {
                btndelnode.Enabled = btnEditNode.Enabled = btnAttachImage.Enabled = true;
                deleteSelectedNodeToolStripMenuItem.Enabled = editSelectedNodeToolStripMenuItem.Enabled = attachImageToolStripMenuItem.Enabled = true;
                toolStripButtonDeleteSelectedNode.Enabled = toolStripButtonEditSelectedNode.Enabled = toolStripButtonAttachImage.Enabled = true;
                toolStripButtonCut.Enabled = toolStripButtonCopy.Enabled = cutToolStripMenuItem.Enabled = copyToolStripMenuItem.Enabled = true;
                toolStripTextBoxNodeIndex.Text = node.ToolTipText;
                toolStripLabelNodeType.Text = node.Tag.ToString();
                if (treeRefImages.ContainsKey(node.ToolTipText.ToString()))
                {
                    displayImageBox(treeRefImages[node.ToolTipText.ToString()], node);
                }
            }
        }
        private void treeViewMain_DoubleClick(object sender, EventArgs e)
        {
            if (sender is TreeView)
            {
                TreeView tv = (TreeView)sender;
                if (tv.SelectedNode != null)
                {
                    TreeNode tn = tv.SelectedNode;
                    btnEditNode_Click(null, null);
                }
            }
        }

        private void btnaddstment_Click(object sender, EventArgs e)
        {
            string nodevalue = getInputfromForm(FormInputDialogBox.FormDisplayStyle.enMultiLineInput, "Enter Node Value :", "");
            if (nodevalue.Length > 0)
            {
                TreeNode tr = new TreeNode(nodevalue);
                tr.Tag = "[Node]";
                node.Nodes.Add(tr);
                addTagstoTree();
                if (treeViewMain.SelectedNode != null)
                    treeViewMain.SelectedNode.Expand(); treeViewMain.SelectedNode = tr.Parent; treeViewMain.Focus();
            }
        }
        private void btnaddcondition_Click(object sender, EventArgs e)
        {
            string nodevalue = getInputfromForm(FormInputDialogBox.FormDisplayStyle.enMultiLineInput, "Enter Node Value :", "");
            if (nodevalue.Length > 0)
            {
                TreeNode Questn = new TreeNode();
                TreeNode YesNode = new TreeNode();
                TreeNode NoNode = new TreeNode();
                Questn.Text = nodevalue;
                Questn.Tag = "[Question]";
                YesNode.Text = "If condition is true..";
                YesNode.Tag = "[AnswerYes]";
                NoNode.Text = "If condition is false..";
                NoNode.Tag = "[AnswerNo]";
                Questn.Nodes.AddRange(new TreeNode[] { YesNode, NoNode });
                node.Nodes.Add(Questn);
                Questn.Expand();
                addTagstoTree();
                if (treeViewMain.SelectedNode != null)
                    treeViewMain.SelectedNode.Expand(); treeViewMain.SelectedNode = Questn; treeViewMain.Focus();
            }
        }
        private void btndelnode_Click(object sender, EventArgs e)
        {
            if (node != null)
            {
                if (treeViewMain.SelectedNode == treeViewMain.Nodes[0])
                    MessageBox.Show("Root node cannot be deleted!");
                else
                {
                    node = treeViewMain.SelectedNode.Parent;
                    treeViewMain.Nodes.Remove(treeViewMain.SelectedNode);
                    addTagstoTree();
                    if (node != null)
                        node.Expand(); treeViewMain.SelectedNode = node; treeViewMain.Focus();
                }
            }
        }
        private void btnEditNode_Click(object sender, EventArgs e)
        {
            if (node != null)
            {
                if (treeViewMain.SelectedNode == treeViewMain.Nodes[0])
                    MessageBox.Show("Root node cannot be edited!");
                else
                {
                    string tmp = getInputfromForm(FormInputDialogBox.FormDisplayStyle.enMultiLineInput, "Please input new value:", treeViewMain.SelectedNode.Text);
                    if (tmp.Length > 0)
                        treeViewMain.SelectedNode.Text = tmp;
                    addTagstoTree();
                    if (treeViewMain.SelectedNode != null && treeViewMain.SelectedNode.Parent != null)
                        treeViewMain.SelectedNode.Parent.Expand(); treeViewMain.Focus();
                }
            }
        }
        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            Image bmp, img;
            TreeNode tr = treeViewMain.SelectedNode;
            string ImageIndex = tr.ToolTipText.ToString();
            if (tr.Tag.ToString().Contains("[Image]"))
            {
                tr.Tag = tr.Tag.ToString().Replace("[Image]", "");
                img = treeRefImages.ContainsKey(ImageIndex) ? treeRefImages[ImageIndex] : null;
                bmp = FormUploadImage.GetImageFromScreenOrFile(img);
            }
            else
                bmp = FormUploadImage.GetImageFromScreenOrFile();
            if (bmp != null)
            {
                if (!treeRefImages.ContainsKey(ImageIndex))
                    treeRefImages.Add(ImageIndex, bmp);
                else
                    treeRefImages[ImageIndex] = bmp;
                tr.Tag += "[Image]";
                addTagstoTree();
            }
            else
            {
                if (treeRefImages.ContainsKey(ImageIndex))
                    treeRefImages.Remove(ImageIndex);
                addTagstoTree();
            }
            if (treeViewMain.Nodes.Count > 0)
                treeViewMain.Focus();
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = getInputfromForm(FormInputDialogBox.FormDisplayStyle.enOneLineInput, "Enter Workflow Name :", "");
            if (name.Length > 0)
            {
                filename = name;
                isdatasaved = false;
                treeViewMain.Nodes.Add(name);
                node = treeViewMain.TopNode;
                addTagstoTree();
                resetcurrentformafteropen();
                fileindex = createFileIteminDB(filename);
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isRunRequired = false;
            if (!isdatasaved)
            {
                switch (MessageBox.Show("Do you want to save the workflow ?", "Close Workflow", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        saveToolStripMenuItem_Click(null, null);
                        isRunRequired = true;
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        isRunRequired = true;
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                }
            }
            else
                isRunRequired = true;
            if (isRunRequired)
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
                    pullTreeDatafromDB(fileindex, versionindex);
                    resetcurrentformafteropen();
                    if (treeViewMain.Nodes.Count == 0)
                        treeViewMain.Nodes.Add(filename);
                    addTagstoTree();
                    treeViewMain.CollapseAll();
                }
            }
        }
        private void recentProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (recentProjectsToolStripMenuItem.DropDownItems.Count == 0)
                addRecentProjects();
            fileToolStripMenuItem.ShowDropDown();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (appendTreetoDB())
            {
                MessageBox.Show("Data saved successfully.!");
                isdatasaved = true;
                saveToolStripMenuItem.Enabled = toolStripButtonSave.Enabled = false;
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = getInputfromForm(FormInputDialogBox.FormDisplayStyle.enOneLineInput, "Enter Workflow Title :", "");
            if (name.Length > 0)
            {
                filename = name;
                fileindex = createFileIteminDB(filename);
                if (appendTreetoDB())
                {
                    MessageBox.Show("Data saved successfully.!");
                    isdatasaved = true;
                    saveToolStripMenuItem.Enabled = toolStripButtonSave.Enabled = false;
                }
            }
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.Nodes.Count > 0)
            {
                treeViewMain.Refresh();
                treeViewMain.CollapseAll();
                treeViewMain.ExpandAll();
                addTagstoTree();
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isRunRequired = false;
            if (!isdatasaved)
            {
                switch (MessageBox.Show("Do you want to save the workflow ?", "Close Workflow", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        saveToolStripMenuItem_Click(null, null);
                        isRunRequired = true;
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        isRunRequired = true;
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                }
            }
            else
                isRunRequired = true;
            if(isRunRequired)
                frmCreateWorkflow_Load(null, null);
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isdatasaved && treeViewMain.Nodes.Count > 0)
            {
                switch (MessageBox.Show("Do you want to save the workflow ?", "Close Workflow", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        saveToolStripMenuItem_Click(null, null);
                        frmCreateWorkflow_Load(null, null);
                        this.Close();
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        this.Close();
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                }
            }
            else
                this.Close();
        }       

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode != null)
            {
                clipboardnode = treeViewMain.SelectedNode;
                treeViewMain.SelectedNode.Remove();
                toolStripButtonPaste.Enabled = pasteToolStripMenuItem.Enabled = true;
            }
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode != null)
            {
                clipboardnode = treeViewMain.SelectedNode;
                toolStripButtonPaste.Enabled = pasteToolStripMenuItem.Enabled = true;
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode != null)
            {
                clipboardnode = (TreeNode)clipboardnode.Clone();
                treeViewMain.SelectedNode.Nodes.Add(clipboardnode);
                treeViewMain.ExpandAll();
            }
        }
        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode != null)
            {
                TreeNode tr = treeViewMain.SelectedNode;
                TreeNode parent = tr.Parent;
                TreeView view = tr.TreeView;
                if (parent != null)
                {
                    int index = parent.Nodes.IndexOf(tr);
                    if (index > 0)
                    {
                        parent.Nodes.RemoveAt(index);
                        parent.Nodes.Insert(index - 1, tr);
                    }
                }
                else if (node.TreeView.Nodes.Contains(tr)) //root node
                {
                    int index = view.Nodes.IndexOf(tr);
                    if (index > 0)
                    {
                        view.Nodes.RemoveAt(index);
                        view.Nodes.Insert(index - 1, tr);
                    }
                }
                treeViewMain.SelectedNode = tr;
            }
        }
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode != null)
            {
                TreeNode tr = treeViewMain.SelectedNode;
                TreeNode parent = tr.Parent;
                TreeView view = tr.TreeView;
                if (parent != null)
                {
                    int index = parent.Nodes.IndexOf(tr);
                    if (index < parent.Nodes.Count - 1)
                    {
                        parent.Nodes.RemoveAt(index);
                        parent.Nodes.Insert(index + 1, tr);
                    }
                }
                else if (view != null && view.Nodes.Contains(tr)) //root node
                {
                    int index = view.Nodes.IndexOf(tr);
                    if (index < view.Nodes.Count - 1)
                    {
                        view.Nodes.RemoveAt(index);
                        view.Nodes.Insert(index + 1, tr);
                    }
                }
                treeViewMain.SelectedNode = tr;
            }
        }
        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.Nodes.Count > 0)
                treeViewMain.ExpandAll();
        }
        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.Nodes.Count > 0)
                treeViewMain.CollapseAll();
        }
        private void expandSelectedNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode != null)
                if (treeViewMain.SelectedNode.Nodes.Count > 0)
                    treeViewMain.SelectedNode.Expand();
        }
        private void collapseSelectedNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode != null)
                if (treeViewMain.SelectedNode.Nodes.Count > 0)
                    treeViewMain.SelectedNode.Collapse();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowCredits.DisplayCredits();
        }

        private string getInputfromForm(FormInputDialogBox.FormDisplayStyle type, string caption, string text)
        {
            FormInputDialogBox frm = new FormInputDialogBox(type, caption, text);
            return frm.ShowDialog() == DialogResult.OK ? frm.textBox.Text : "";
        }
        private int createFileIteminDB(string filename)
        {
            int returncode = 0;
            string sqry = "insert into WorkFlowMGMTFileList(FileName, CreatedBy, LastModifiedBy, LastModifiedDate, CurrentVersion) values('" + 
                filename + "','" + Environment.UserName + "','" + Environment.UserName + "', getdate(), 1);select scope_identity(); ";
            if (db.DBConnect())
            {
                returncode = db.ExecuteScalar(sqry);
                db.DBDisconnect();
            }
            return returncode;
        }
        private bool appendTreetoDB()
        {
            int cnt = 0;
            bool isProcessed = false;
            DataTable dt = new DataTable();
            dt = treetotable(treeViewMain);

            string sqry = "update WorkFlowMGMTTreeData set DeleteFlag = 'N' where FileID = " + fileindex.ToString() + " and VersionID = " + versionindex.ToString() + "\n\n";
            versionindex++;

            foreach (DataRowView dr in dt.DefaultView)
            {
                if (cnt % 999 == 0)
                {
                    sqry = sqry.Substring(0, sqry.Length - 1) + ";\n\n";
                    sqry += "insert into WorkFlowMGMTTreeData (FileID, VersionID, TreeParentIndex, TreeNodeIndex, TreeNodeText, TreeNodeType, EnteredUser) values \n";
                }
                sqry += "(" + fileindex.ToString() + "," + versionindex.ToString() + "," + dr[0].ToString();
                sqry += "," + dr[1].ToString() + ",'" + dr[2].ToString() + "','" + dr[3].ToString() + "','" + Environment.UserName + "')\n,";
                cnt++;
            }
            sqry = sqry.Substring(0, sqry.Length - 1);
            try
            {
                if (db.DBConnect())
                    if (db.ExecuteQuery(sqry) > 0)
                        isProcessed = true;
            }
            catch (Exception ex) { }
            finally { db.DBDisconnect(); }
            sqry = "insert into WorkFlowMGMTImageList(FileID, VersionID, NodeIndex, BinaryImage) values ";
            appendImagestoDB(treeViewMain.Nodes[0], ref sqry);
            sqry = sqry.Substring(0, sqry.Length - 1);
            try
            {
                if (db.DBConnect())
                    if (db.ExecuteQuery(sqry) > 0)
                        isProcessed = true;
            }
            catch (Exception ex) { }
            finally { db.DBDisconnect(); }
            sqry = "update WorkFlowMGMTFileList set LastModifiedBy = '" + Environment.UserName+"', LastModifiedDate = getdate(), CurrentVersion = " + 
                versionindex.ToString() + " where FileID = " + fileindex.ToString();
            try
            {
                if (db.DBConnect())
                    db.ExecuteQuery(sqry);
            }
            catch (Exception ex) { }
            finally { db.DBDisconnect(); }

            return isProcessed;
        }
        private void appendImagestoDB(TreeNode tn, ref string sqry)
        {
            foreach (TreeNode node in tn.Nodes)
            {
                if (treeRefImages.ContainsKey(node.ToolTipText.ToString()))
                {
                    sqry += "(" + fileindex.ToString() + "," + versionindex.ToString() + "," + node.ToolTipText.ToString() + ",'" + 
                        imagetobase64Encoding(treeRefImages[node.ToolTipText.ToString()]) + "'),";
                }
                appendImagestoDB(node, ref sqry);
            }
        }
        private void pullTreeDatafromDB(int index, int version)
        {
            DataTable dt = new DataTable();
            string qry = "exec WorkFlowMGMTPullTreeNodes " + index.ToString() + ", " + version.ToString();
            if (db.DBConnect())
                dt = db.OpenRecordset(qry);
            db.DBDisconnect();
            treeViewMain.Nodes.Clear();
            treeViewMain.Nodes.AddRange(treefromtable(dt, "ParentID", "NodeID", "Name", "Tag"));
            pullImagesfromDB(index, version);
        }
        private void pullImagesfromDB(int index,int version)
        {
            DataTable dt = new DataTable();
            string qry = "exec WorkFlowMGMTPullTreeImages " + index.ToString() + ", " + version.ToString();
            if (db.DBConnect())
                dt = db.OpenRecordset(qry);
            db.DBDisconnect();
            treeRefImages.Clear();
            foreach (DataRowView dv in dt.DefaultView)
            {
                treeRefImages.Add(dv["NodeIndex"].ToString(), imagefrombase64Encoding(dv["BinaryImage"].ToString()));
            }
        }

        private DataTable treetotable(TreeView tv)
        {
            DataTable dt = new DataTable("TreeNodes");
            int id = 1;

            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("NodeID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Tag", typeof(string));

            foreach (TreeNode pn in tv.Nodes)
            {
                dt.Rows.Add(0, id, pn.Text, pn.Tag.ToString());
                GetAllNodes(ref dt, pn, id, ref id);
                id += 1;
            }
            return dt;
        }
        private void GetAllNodes(ref DataTable dt, TreeNode pn, int parentid, ref int id)
        {
            foreach (TreeNode cn in pn.Nodes)
            {
                id += 1;
                dt.Rows.Add(parentid, id, cn.Text, cn.Tag.ToString());
                GetAllNodes(ref dt, cn, id, ref id);
            }
        }
        private TreeNode[] treefromtable(DataTable dt, string parent, string node, string name, string tag)
        {
            List<TreeNode> tnodes = new List<TreeNode>();
            string[] columns = { parent, node, name, tag };

            if (dt.Columns.Contains(parent) && dt.Columns.Contains(node) && dt.Columns.Contains(name) && dt.Columns.Contains(tag))
            {
                dt.DefaultView.RowFilter = "[" + parent + "] = 0";
                foreach (DataRowView r in dt.DefaultView)
                {
                    tnodes.Add(ReadNodes(columns, r, dt));
                }
                return tnodes.ToArray();
            }
            else
                return tnodes.ToArray();
        }
        private TreeNode ReadNodes(string[] columns, DataRowView r, DataTable dt)
        {
            TreeNode cn = new TreeNode();
            cn.Name = cn.Text = r[columns[2].ToString()].ToString();
            cn.Tag = r[columns[3].ToString()].ToString();
            GetAllNodes(columns,ref cn, dt, int.Parse(r[columns[1].ToString()].ToString()));
            return cn;
        }
        private void GetAllNodes(string[] columns, ref TreeNode pn, DataTable dt, int nodeid)
        {
            dt.DefaultView.RowFilter = "[" + columns[0].ToString() + "] = " + nodeid.ToString();
            foreach(DataRowView r in dt.DefaultView)
            {
                TreeNode cn = new TreeNode();
                cn.Text = r[columns[2].ToString()].ToString();
                cn.Name = cn.Text;
                cn.Tag = r[columns[3].ToString()].ToString();
                pn.Nodes.Add(cn);
                GetAllNodes(columns, ref cn, dt, int.Parse(r[columns[1].ToString()].ToString()));
            }
        }
        
        private void resetcurrentform()
        {
            RemoveAllcontentsfromTree();
            filename = string.Empty; fileindex = 0; isdatasaved = true;
            picBox.Visible = false;
            pnlTreeView.Enabled = gBoxcontrols.Enabled = toolStripControls.Enabled = toolStripNodeItems.Enabled = false;
            insertNewStepToolStripMenuItem.Enabled = insertNewConditionToolStripMenuItem.Enabled = false;
            btndelnode.Enabled = btnEditNode.Enabled = btnAttachImage.Enabled = false;
            deleteSelectedNodeToolStripMenuItem.Enabled = editSelectedNodeToolStripMenuItem.Enabled = attachImageToolStripMenuItem.Enabled = false;
            toolStripButtonDeleteSelectedNode.Enabled = toolStripButtonEditSelectedNode.Enabled = toolStripButtonAttachImage.Enabled = false;
            saveToolStripMenuItem.Enabled = saveAsToolStripMenuItem.Enabled = closeToolStripMenuItem.Enabled = false;
            toolStripButtonSave.Enabled = toolStripButtonSaveAs.Enabled = toolStripButtonClose.Enabled = false;
            createNewToolStripMenuItem.Enabled = toolStripButtonCreateNew.Enabled = true;
            toolStripButtonPaste.Enabled = pasteToolStripMenuItem.Enabled = false;
            toolStripButtonCut.Enabled = toolStripButtonCopy.Enabled = cutToolStripMenuItem.Enabled = copyToolStripMenuItem.Enabled = false;
        }
        private void resetcurrentformafteropen()
        {
            pnlTreeView.Enabled = gBoxcontrols.Enabled = toolStripControls.Enabled = true;
            insertNewStepToolStripMenuItem.Enabled = insertNewConditionToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = saveAsToolStripMenuItem.Enabled = closeToolStripMenuItem.Enabled = true;
            toolStripButtonSave.Enabled = toolStripButtonSaveAs.Enabled = toolStripButtonClose.Enabled = true;
            createNewToolStripMenuItem.Enabled = toolStripButtonCreateNew.Enabled = false;
        }
        private void RemoveAllcontentsfromTree()
        {
            while (treeViewMain.Nodes.Count != 0)
                treeViewMain.Nodes.Remove(treeViewMain.Nodes[0]);
        }

        private void addTagstoTree()
        {
            int i = 1;
            TreeNode tn = new TreeNode();
            tn = treeViewMain.Nodes[0];
            tn.Tag = "[Root]";
            tn.ToolTipText = i.ToString();
            tn.NodeFont = new Font("Segoe UI", 10, FontStyle.Bold);
            tn.ForeColor = Color.DarkCyan;
            addTagsToTree(tn, ref i);
            isdatasaved = false;
        }
        private void addTagsToTree(TreeNode node, ref int i)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                i++;
                tn.ImageKey = "noimg";
                tn.SelectedImageKey = "noimg";
                if (tn.Tag.ToString().Contains("[Node]"))
                {
                }
                if (tn.Tag.ToString().Contains("[Question]"))
                {
                    tn.NodeFont = new Font("Segoe UI", 10, FontStyle.Regular);
                    tn.ForeColor = Color.DarkBlue;
                }
                if (tn.Tag.ToString().Contains("[AnswerYes]"))
                {
                    tn.NodeFont = new Font("Segoe UI", 10, FontStyle.Italic);
                    tn.ForeColor = Color.SeaGreen;
                }
                if (tn.Tag.ToString().Contains("[AnswerNo]"))
                {
                    tn.NodeFont = new Font("Segoe UI", 10, FontStyle.Italic);
                    tn.ForeColor = Color.OrangeRed;
                }
                if (tn.Tag.ToString().Contains("[Image]"))
                {
                    tn.ImageKey = "icon";
                    tn.SelectedImageKey = "icon";
                }
                tn.Text = tn.Text;
                tn.ToolTipText = i.ToString();
                addTagsToTree(tn, ref i);
            }
        }
        
        private void displayImageBox(Image bmp, TreeNode tn)
        {
            int x = 0, y = 0;
            if (tn.Bounds.Right > this.Width)
            {
                x = this.Width - picBox.Width - 40;
                y = tn.Bounds.Bottom + 5;
            }
            else if (tn.Bounds.Right < this.Width / 2)
            {
                x = tn.Bounds.Right + 20;
                y = tn.Bounds.Top;
            }
            else
            {
                x = tn.Bounds.Right - picBox.Width;
                y = tn.Bounds.Bottom + 5;
            }
            picBox.BackgroundImage = bmp;
            picBox.SetBounds(x, y, picBox.Width, picBox.Height);
            picBox.Visible = true;
            picBox.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void addRecentProjects()
        {
            DataTable dt = new DataTable();
            string sqry = "exec WorkFlowMGMTOpenFileListRecent";
            if (db.DBConnect())
                dt = db.OpenRecordset(sqry);
            db.DBDisconnect();
            foreach (DataRow dr in dt.Rows)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = dr[1].ToString();
                tsmi.Tag = dr[0].ToString() + "," + dr[6].ToString();
                tsmi.ShortcutKeyDisplayString = (" (Ctrl+" + (recentProjectsToolStripMenuItem.DropDownItems.Count + 1).ToString() + ")");
                tsmi.ShortcutKeys = (Keys)(Keys.Control | (Keys)(49 + recentProjectsToolStripMenuItem.DropDownItems.Count));
                tsmi.Click += (sender, e) => OpenRecentProjectwithIndex(sender, e);
                recentProjectsToolStripMenuItem.DropDownItems.Add(tsmi);
            }
        }
        private void OpenRecentProjectwithIndex(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            var list = item.Tag.ToString().Split(',');
            bool isRunRequired = false;
            if (!isdatasaved)
            {
                switch (MessageBox.Show("Do you want to save the workflow ?", "Close Workflow", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        saveToolStripMenuItem_Click(null, null);
                        isRunRequired = true;
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        isRunRequired = true;
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                }
            }
            else
                isRunRequired = true;
            if (isRunRequired)
            {
                pullTreeDatafromDB(int.Parse(list[0]), int.Parse(list[1]));
                resetcurrentformafteropen();
                if (treeViewMain.Nodes.Count == 0)
                    treeViewMain.Nodes.Add(filename);
                addTagstoTree();
                treeViewMain.CollapseAll();
            }
        }

        private string imagetobase64Encoding(Image bmp)
        {
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteimage = ms.ToArray();
            return Convert.ToBase64String(byteimage);
        }
        private Image imagefrombase64Encoding(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            using (MemoryStream ms = new MemoryStream(bytes))
                return Image.FromStream(ms);
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
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode != null)
                picBox.Visible = treeRefImages.ContainsKey(node.ToolTipText.ToString());
            else
                picBox.Visible = false;
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWorkFlowProperties frm = new FormWorkFlowProperties(fileindex, versionindex, filename);
            frm.ShowDialog();
        }
    }
}
