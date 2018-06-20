namespace WorkflowManagementTool
{
    partial class FormExecuteWorkFlow
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
            this.Icon = global::WorkflowManagementTool.Properties.Resources.workflow_px2_icon;
            this.fw_menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.recentProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeWorkflowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.pnlProperties = new System.Windows.Forms.Panel();
            this.pnlWorkFlow = new System.Windows.Forms.Panel();
            this.pnlCurrentStep = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClaimNo = new System.Windows.Forms.TextBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.btnPrevStep = new System.Windows.Forms.Button();
            this.rbtnoption2 = new System.Windows.Forms.RadioButton();
            this.rbtnoption1 = new System.Windows.Forms.RadioButton();
            this.txtStepNo = new System.Windows.Forms.TextBox();
            this.txtCurrentStep = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCreateNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.gBoxCurrentProcessStep = new System.Windows.Forms.GroupBox();
            this.gBoxProperties = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fw_menuStrip.SuspendLayout();
            this.pnlCurrentStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.gBoxCurrentProcessStep.SuspendLayout();
            this.gBoxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fw_menuStrip
            // 
            this.fw_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.fw_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.fw_menuStrip.Name = "fw_menuStrip";
            this.fw_menuStrip.Size = new System.Drawing.Size(1093, 24);
            this.fw_menuStrip.TabIndex = 0;
            this.fw_menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.recentProjectsToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeWorkflowToolStripMenuItem,
            this.toolStripSeparator6,
            this.resetToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.NewDiagramBtn;
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "(Ctrl+N)";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.OpenBtn;
            this.openToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeyDisplayString = "(Ctrl+O)";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // recentProjectsToolStripMenuItem
            // 
            this.recentProjectsToolStripMenuItem.Name = "recentProjectsToolStripMenuItem";
            this.recentProjectsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.recentProjectsToolStripMenuItem.Text = "Recent Projects";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.SaveBtn;
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "(Ctrl+S)";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.SaveAsBtn;
            this.saveAsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // closeWorkflowToolStripMenuItem
            // 
            this.closeWorkflowToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.DeleteDiagramBtn;
            this.closeWorkflowToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.closeWorkflowToolStripMenuItem.Name = "closeWorkflowToolStripMenuItem";
            this.closeWorkflowToolStripMenuItem.ShortcutKeyDisplayString = "(Ctrl+W)";
            this.closeWorkflowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeWorkflowToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.closeWorkflowToolStripMenuItem.Text = "Close Workflow";
            this.closeWorkflowToolStripMenuItem.Click += new System.EventHandler(this.closeWorkflowToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(207, 6);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.RefreshBtn;
            this.refreshToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeyDisplayString = "(F5)";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeyDisplayString = "(Alt+X)";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextStepToolStripMenuItem,
            this.previousStepToolStripMenuItem,
            this.toolStripSeparator7});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // nextStepToolStripMenuItem
            // 
            this.nextStepToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.ForwardBtn;
            this.nextStepToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextStepToolStripMenuItem.Name = "nextStepToolStripMenuItem";
            this.nextStepToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.nextStepToolStripMenuItem.Text = "Next Step";
            // 
            // previousStepToolStripMenuItem
            // 
            this.previousStepToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.BackBtn;
            this.previousStepToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousStepToolStripMenuItem.Name = "previousStepToolStripMenuItem";
            this.previousStepToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.previousStepToolStripMenuItem.Text = "Previous Step";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(142, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpDocumentToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpDocumentToolStripMenuItem
            // 
            this.helpDocumentToolStripMenuItem.Name = "helpDocumentToolStripMenuItem";
            this.helpDocumentToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.helpDocumentToolStripMenuItem.Text = "Help Document";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // btnNextStep
            // 
            this.btnNextStep.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNextStep.Location = new System.Drawing.Point(443, 9);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(75, 23);
            this.btnNextStep.TabIndex = 2;
            this.btnNextStep.Text = "Next >>";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // pnlProperties
            // 
            this.pnlProperties.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProperties.Location = new System.Drawing.Point(3, 16);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.Size = new System.Drawing.Size(521, 18);
            this.pnlProperties.TabIndex = 2;
            // 
            // pnlWorkFlow
            // 
            this.pnlWorkFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWorkFlow.AutoScroll = true;
            this.pnlWorkFlow.BackColor = System.Drawing.SystemColors.Window;
            this.pnlWorkFlow.Location = new System.Drawing.Point(545, 52);
            this.pnlWorkFlow.Name = "pnlWorkFlow";
            this.pnlWorkFlow.Size = new System.Drawing.Size(536, 481);
            this.pnlWorkFlow.TabIndex = 3;
            // 
            // pnlCurrentStep
            // 
            this.pnlCurrentStep.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCurrentStep.Controls.Add(this.label1);
            this.pnlCurrentStep.Controls.Add(this.txtClaimNo);
            this.pnlCurrentStep.Controls.Add(this.picBox);
            this.pnlCurrentStep.Controls.Add(this.btnPrevStep);
            this.pnlCurrentStep.Controls.Add(this.rbtnoption2);
            this.pnlCurrentStep.Controls.Add(this.rbtnoption1);
            this.pnlCurrentStep.Controls.Add(this.btnNextStep);
            this.pnlCurrentStep.Controls.Add(this.txtStepNo);
            this.pnlCurrentStep.Controls.Add(this.txtCurrentStep);
            this.pnlCurrentStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCurrentStep.Location = new System.Drawing.Point(3, 16);
            this.pnlCurrentStep.Name = "pnlCurrentStep";
            this.pnlCurrentStep.Size = new System.Drawing.Size(521, 419);
            this.pnlCurrentStep.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Claim #";
            // 
            // txtClaimNo
            // 
            this.txtClaimNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtClaimNo.Location = new System.Drawing.Point(148, 7);
            this.txtClaimNo.Multiline = true;
            this.txtClaimNo.Name = "txtClaimNo";
            this.txtClaimNo.Size = new System.Drawing.Size(181, 25);
            this.txtClaimNo.TabIndex = 8;
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(91, 195);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(328, 170);
            this.picBox.TabIndex = 7;
            this.picBox.TabStop = false;
            this.picBox.DoubleClick += new System.EventHandler(this.picBox_DoubleClick);
            // 
            // btnPrevStep
            // 
            this.btnPrevStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevStep.Location = new System.Drawing.Point(362, 9);
            this.btnPrevStep.Name = "btnPrevStep";
            this.btnPrevStep.Size = new System.Drawing.Size(75, 23);
            this.btnPrevStep.TabIndex = 6;
            this.btnPrevStep.Text = "<< Prev";
            this.btnPrevStep.UseVisualStyleBackColor = true;
            // 
            // rbtnoption2
            // 
            this.rbtnoption2.AutoSize = true;
            this.rbtnoption2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnoption2.Location = new System.Drawing.Point(12, 166);
            this.rbtnoption2.Name = "rbtnoption2";
            this.rbtnoption2.Size = new System.Drawing.Size(111, 23);
            this.rbtnoption2.TabIndex = 5;
            this.rbtnoption2.TabStop = true;
            this.rbtnoption2.Text = "radioButton2";
            this.rbtnoption2.UseVisualStyleBackColor = true;
            this.rbtnoption2.CheckedChanged += new System.EventHandler(this.rbtnoption1_CheckedChanged);
            // 
            // rbtnoption1
            // 
            this.rbtnoption1.AutoSize = true;
            this.rbtnoption1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnoption1.Location = new System.Drawing.Point(12, 143);
            this.rbtnoption1.Name = "rbtnoption1";
            this.rbtnoption1.Size = new System.Drawing.Size(111, 23);
            this.rbtnoption1.TabIndex = 4;
            this.rbtnoption1.TabStop = true;
            this.rbtnoption1.Text = "radioButton1";
            this.rbtnoption1.UseVisualStyleBackColor = true;
            this.rbtnoption1.CheckedChanged += new System.EventHandler(this.rbtnoption1_CheckedChanged);
            // 
            // txtStepNo
            // 
            this.txtStepNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtStepNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStepNo.Location = new System.Drawing.Point(5, 7);
            this.txtStepNo.Name = "txtStepNo";
            this.txtStepNo.Size = new System.Drawing.Size(79, 25);
            this.txtStepNo.TabIndex = 3;
            // 
            // txtCurrentStep
            // 
            this.txtCurrentStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentStep.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrentStep.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentStep.Location = new System.Drawing.Point(5, 38);
            this.txtCurrentStep.Multiline = true;
            this.txtCurrentStep.Name = "txtCurrentStep";
            this.txtCurrentStep.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCurrentStep.Size = new System.Drawing.Size(513, 99);
            this.txtCurrentStep.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCreateNew,
            this.toolStripButtonOpen,
            this.toolStripSeparator5,
            this.toolStripButtonSave,
            this.toolStripButtonSaveAs,
            this.toolStripButtonClose,
            this.toolStripSeparator4,
            this.toolStripButtonRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1093, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonCreateNew
            // 
            this.toolStripButtonCreateNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCreateNew.Image = global::WorkflowManagementTool.Properties.Resources.NewDiagramBtn;
            this.toolStripButtonCreateNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCreateNew.Name = "toolStripButtonCreateNew";
            this.toolStripButtonCreateNew.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCreateNew.Text = "Create New";
            this.toolStripButtonCreateNew.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::WorkflowManagementTool.Properties.Resources.OpenBtn;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::WorkflowManagementTool.Properties.Resources.SaveBtn;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save";
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveAs.Image = global::WorkflowManagementTool.Properties.Resources.SaveAsBtn;
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSaveAs.Text = "Save As";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = global::WorkflowManagementTool.Properties.Resources.DeleteDiagramBtn;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClose.Text = "Close Workflow";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::WorkflowManagementTool.Properties.Resources.RefreshBtn;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "Refresh Tree View";
            // 
            // gBoxCurrentProcessStep
            // 
            this.gBoxCurrentProcessStep.Controls.Add(this.pnlCurrentStep);
            this.gBoxCurrentProcessStep.Location = new System.Drawing.Point(12, 52);
            this.gBoxCurrentProcessStep.Name = "gBoxCurrentProcessStep";
            this.gBoxCurrentProcessStep.Size = new System.Drawing.Size(527, 438);
            this.gBoxCurrentProcessStep.TabIndex = 5;
            this.gBoxCurrentProcessStep.TabStop = false;
            this.gBoxCurrentProcessStep.Text = "Current Step";
            // 
            // gBoxProperties
            // 
            this.gBoxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gBoxProperties.Controls.Add(this.pnlProperties);
            this.gBoxProperties.Location = new System.Drawing.Point(12, 496);
            this.gBoxProperties.Name = "gBoxProperties";
            this.gBoxProperties.Size = new System.Drawing.Size(527, 37);
            this.gBoxProperties.TabIndex = 6;
            this.gBoxProperties.TabStop = false;
            this.gBoxProperties.Text = "Properties";
            this.gBoxProperties.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(994, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // FormExecuteWorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 545);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlWorkFlow);
            this.Controls.Add(this.gBoxProperties);
            this.Controls.Add(this.gBoxCurrentProcessStep);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.fw_menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.fw_menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormExecuteWorkFlow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workflow Management Tool - Execute Workflow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormExecuteWorkFlow_FormClosed);
            this.Load += new System.EventHandler(this.FormExecuteWorkFlow_Load);
            this.fw_menuStrip.ResumeLayout(false);
            this.fw_menuStrip.PerformLayout();
            this.pnlCurrentStep.ResumeLayout(false);
            this.pnlCurrentStep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gBoxCurrentProcessStep.ResumeLayout(false);
            this.gBoxProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip fw_menuStrip;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Panel pnlProperties;
        private System.Windows.Forms.Panel pnlWorkFlow;
        private System.Windows.Forms.Panel pnlCurrentStep;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox txtCurrentStep;
        private System.Windows.Forms.GroupBox gBoxCurrentProcessStep;
        private System.Windows.Forms.GroupBox gBoxProperties;
        private System.Windows.Forms.TextBox txtStepNo;
        private System.Windows.Forms.RadioButton rbtnoption2;
        private System.Windows.Forms.RadioButton rbtnoption1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveAs;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem closeWorkflowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.Button btnPrevStep;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClaimNo;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreateNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}