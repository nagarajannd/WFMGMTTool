namespace WorkflowManagementTool
{
    partial class FormWorkFlowProperties
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
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileVersionID = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPurpose = new System.Windows.Forms.TabPage();
            this.tabTargetAudience = new System.Windows.Forms.TabPage();
            this.tabReferences = new System.Windows.Forms.TabPage();
            this.tabOtherInformation = new System.Windows.Forms.TabPage();
            this.tabSystemCriteria = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFileID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(92, 41);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(290, 25);
            this.txtFileName.TabIndex = 0;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlTitle.Controls.Add(this.labelTitle);
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(757, 39);
            this.pnlTitle.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFileVersionID);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.tabControlMain);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtFileID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 362);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(183, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "File Version ID :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileVersionID
            // 
            this.txtFileVersionID.Enabled = false;
            this.txtFileVersionID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileVersionID.Location = new System.Drawing.Point(297, 14);
            this.txtFileVersionID.Name = "txtFileVersionID";
            this.txtFileVersionID.Size = new System.Drawing.Size(85, 25);
            this.txtFileVersionID.TabIndex = 16;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(650, 323);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 30);
            this.btnSubmit.TabIndex = 15;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPurpose);
            this.tabControlMain.Controls.Add(this.tabTargetAudience);
            this.tabControlMain.Controls.Add(this.tabReferences);
            this.tabControlMain.Controls.Add(this.tabOtherInformation);
            this.tabControlMain.Controls.Add(this.tabSystemCriteria);
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(6, 72);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(722, 245);
            this.tabControlMain.TabIndex = 14;
            // 
            // tabPurpose
            // 
            this.tabPurpose.Location = new System.Drawing.Point(4, 26);
            this.tabPurpose.Name = "tabPurpose";
            this.tabPurpose.Padding = new System.Windows.Forms.Padding(3);
            this.tabPurpose.Size = new System.Drawing.Size(714, 215);
            this.tabPurpose.TabIndex = 0;
            this.tabPurpose.Text = "Purpose";
            this.tabPurpose.UseVisualStyleBackColor = true;
            // 
            // tabTargetAudience
            // 
            this.tabTargetAudience.Location = new System.Drawing.Point(4, 26);
            this.tabTargetAudience.Name = "tabTargetAudience";
            this.tabTargetAudience.Padding = new System.Windows.Forms.Padding(3);
            this.tabTargetAudience.Size = new System.Drawing.Size(714, 215);
            this.tabTargetAudience.TabIndex = 1;
            this.tabTargetAudience.Text = "Target Audience";
            this.tabTargetAudience.UseVisualStyleBackColor = true;
            // 
            // tabReferences
            // 
            this.tabReferences.Location = new System.Drawing.Point(4, 26);
            this.tabReferences.Name = "tabReferences";
            this.tabReferences.Size = new System.Drawing.Size(714, 215);
            this.tabReferences.TabIndex = 2;
            this.tabReferences.Text = "References";
            this.tabReferences.UseVisualStyleBackColor = true;
            // 
            // tabOtherInformation
            // 
            this.tabOtherInformation.Location = new System.Drawing.Point(4, 26);
            this.tabOtherInformation.Name = "tabOtherInformation";
            this.tabOtherInformation.Size = new System.Drawing.Size(714, 215);
            this.tabOtherInformation.TabIndex = 3;
            this.tabOtherInformation.Text = "Other Information";
            this.tabOtherInformation.UseVisualStyleBackColor = true;
            // 
            // tabSystemCriteria
            // 
            this.tabSystemCriteria.Location = new System.Drawing.Point(4, 26);
            this.tabSystemCriteria.Name = "tabSystemCriteria";
            this.tabSystemCriteria.Size = new System.Drawing.Size(714, 215);
            this.tabSystemCriteria.TabIndex = 4;
            this.tabSystemCriteria.Text = "System Criteria";
            this.tabSystemCriteria.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Enabled = false;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "File ID :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileID
            // 
            this.txtFileID.Enabled = false;
            this.txtFileID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileID.Location = new System.Drawing.Point(92, 14);
            this.txtFileID.Name = "txtFileID";
            this.txtFileID.Size = new System.Drawing.Size(85, 25);
            this.txtFileID.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(9, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(100, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "label3";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormWorkFlowProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 419);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWorkFlowProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit WorkFlow Properties";
            this.Load += new System.EventHandler(this.FormWorkFlowProperties_Load);
            this.pnlTitle.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtFileID;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPurpose;
        private System.Windows.Forms.TabPage tabTargetAudience;
        private System.Windows.Forms.TabPage tabReferences;
        private System.Windows.Forms.TabPage tabOtherInformation;
        private System.Windows.Forms.TabPage tabSystemCriteria;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtFileVersionID;
        private System.Windows.Forms.Label labelTitle;

    }
}