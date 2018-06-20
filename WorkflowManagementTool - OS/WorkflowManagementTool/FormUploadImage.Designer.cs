namespace WorkflowManagementTool
{
    partial class FormUploadImage
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
            this.cbActiveWindows = new System.Windows.Forms.ComboBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.ow_toopStrip = new System.Windows.Forms.ToolStrip();
            this.ow_toopStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.cropNewImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExistingImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripbuttonSubmit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.cropOpenWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.ow_toopStrip.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbActiveWindows
            // 
            this.cbActiveWindows.FormattingEnabled = true;
            this.cbActiveWindows.Location = new System.Drawing.Point(7, 3);
            this.cbActiveWindows.Name = "cbActiveWindows";
            this.cbActiveWindows.Size = new System.Drawing.Size(256, 21);
            this.cbActiveWindows.TabIndex = 0;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(94, 30);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(12, 92);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(270, 149);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 2;
            this.picBox.TabStop = false;
            this.picBox.DoubleClick += new System.EventHandler(this.picBox_DoubleClick);
            // 
            // ow_toopStrip
            // 
            this.ow_toopStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ow_toopStripSplitButton,
            this.toolStripSeparator1,
            this.toolStripbuttonSubmit,
            this.toolStripSeparator2,
            this.toolStripButtonClose});
            this.ow_toopStrip.Location = new System.Drawing.Point(0, 0);
            this.ow_toopStrip.Name = "ow_toopStrip";
            this.ow_toopStrip.Size = new System.Drawing.Size(294, 25);
            this.ow_toopStrip.TabIndex = 5;
            this.ow_toopStrip.Text = "ow_toopStrip";
            // 
            // ow_toopStripSplitButton
            // 
            this.ow_toopStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cropNewImageToolStripMenuItem,
            this.cropOpenWindowsToolStripMenuItem,
            this.toolStripSeparator3,
            this.openExistingImageToolStripMenuItem});
            this.ow_toopStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ow_toopStripSplitButton.Name = "ow_toopStripSplitButton";
            this.ow_toopStripSplitButton.Size = new System.Drawing.Size(99, 22);
            this.ow_toopStripSplitButton.Text = "New Image";
            this.ow_toopStripSplitButton.ButtonClick += new System.EventHandler(this.cropNewImageToolStripMenuItem_Click);
            // 
            // cropNewImageToolStripMenuItem
            // 
            this.cropNewImageToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.NewDiagramBtn;
            this.cropNewImageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cropNewImageToolStripMenuItem.Name = "cropNewImageToolStripMenuItem";
            this.cropNewImageToolStripMenuItem.ShortcutKeyDisplayString = "(Ctrl+N)";
            this.cropNewImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.cropNewImageToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.cropNewImageToolStripMenuItem.Text = "Crop From Screen";
            this.cropNewImageToolStripMenuItem.Click += new System.EventHandler(this.cropNewImageToolStripMenuItem_Click);
            // 
            // openExistingImageToolStripMenuItem
            // 
            this.openExistingImageToolStripMenuItem.Image = global::WorkflowManagementTool.Properties.Resources.OpenBtn;
            this.openExistingImageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openExistingImageToolStripMenuItem.Name = "openExistingImageToolStripMenuItem";
            this.openExistingImageToolStripMenuItem.ShortcutKeyDisplayString = "(Ctrl+O)";
            this.openExistingImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openExistingImageToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.openExistingImageToolStripMenuItem.Text = "Open Existing Image";
            this.openExistingImageToolStripMenuItem.Click += new System.EventHandler(this.openExistingImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripbuttonSubmit
            // 
            this.toolStripbuttonSubmit.Image = global::WorkflowManagementTool.Properties.Resources.Open_Image;
            this.toolStripbuttonSubmit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbuttonSubmit.Name = "toolStripbuttonSubmit";
            this.toolStripbuttonSubmit.Size = new System.Drawing.Size(65, 22);
            this.toolStripbuttonSubmit.Text = "Submit";
            this.toolStripbuttonSubmit.Click += new System.EventHandler(this.toolStripbuttonSubmit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Image = global::WorkflowManagementTool.Properties.Resources.DeleteBtn;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButtonClose.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonClose.Text = "Discard";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnCapture);
            this.pnlControls.Controls.Add(this.cbActiveWindows);
            this.pnlControls.Location = new System.Drawing.Point(12, 28);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(270, 58);
            this.pnlControls.TabIndex = 6;
            // 
            // cropOpenWindowsToolStripMenuItem
            // 
            this.cropOpenWindowsToolStripMenuItem.Name = "cropOpenWindowsToolStripMenuItem";
            this.cropOpenWindowsToolStripMenuItem.ShortcutKeyDisplayString = "(Ctrl+Shift+N)";
            this.cropOpenWindowsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.cropOpenWindowsToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.cropOpenWindowsToolStripMenuItem.Text = "Crop Open Windows";
            this.cropOpenWindowsToolStripMenuItem.Click += new System.EventHandler(this.cropOpenWindowsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(264, 6);
            // 
            // FormUploadImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 256);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.ow_toopStrip);
            this.Controls.Add(this.picBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUploadImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Screen Scraper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUploadImage_FormClosing);
            this.Load += new System.EventHandler(this.frmSelectOpenWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ow_toopStrip.ResumeLayout(false);
            this.ow_toopStrip.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbActiveWindows;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.ToolStrip ow_toopStrip;
        private System.Windows.Forms.ToolStripSplitButton ow_toopStripSplitButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cropNewImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openExistingImageToolStripMenuItem;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripbuttonSubmit;
        private System.Windows.Forms.ToolStripMenuItem cropOpenWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}