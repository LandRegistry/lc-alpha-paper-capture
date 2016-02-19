namespace PaperCapture
{
    partial class ScanOptions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanOptions));
            this.scanButton = new System.Windows.Forms.Button();
            this.numPagesInput = new System.Windows.Forms.NumericUpDown();
            this.cbxTwoSides = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxOutput = new System.Windows.Forms.RichTextBox();
            this.grpbxFrmDtls = new System.Windows.Forms.GroupBox();
            this.lblRecievedBy = new System.Windows.Forms.Label();
            this.rdbPortalFallout = new System.Windows.Forms.RadioButton();
            this.rdbFax = new System.Windows.Forms.RadioButton();
            this.rdbPost = new System.Windows.Forms.RadioButton();
            this.cmbxFormType = new System.Windows.Forms.ComboBox();
            this.lblFormType = new System.Windows.Forms.Label();
            this.cmbxWorkList = new System.Windows.Forms.ComboBox();
            this.lblAppnType = new System.Windows.Forms.Label();
            this.lblFormsToScan = new System.Windows.Forms.Label();
            this.cbxScanAll = new System.Windows.Forms.CheckBox();
            this.numDocsInput = new System.Windows.Forms.NumericUpDown();
            this.cmbxSource = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPreview = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbxScanAndSend = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProg = new System.Windows.Forms.ToolStripProgressBar();
            this.tslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbpScanOptions = new System.Windows.Forms.GroupBox();
            this.pbxShowLog = new System.Windows.Forms.PictureBox();
            this.imglstMain = new System.Windows.Forms.ImageList(this.components);
            this.gpbxLog = new System.Windows.Forms.GroupBox();
            this.cmbxPaperSize = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPagesInput)).BeginInit();
            this.grpbxFrmDtls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDocsInput)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.gbpScanOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowLog)).BeginInit();
            this.gpbxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(401, 131);
            this.scanButton.Margin = new System.Windows.Forms.Padding(4);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(139, 28);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "Scan Now";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // numPagesInput
            // 
            this.numPagesInput.Location = new System.Drawing.Point(187, 55);
            this.numPagesInput.Margin = new System.Windows.Forms.Padding(4);
            this.numPagesInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPagesInput.Name = "numPagesInput";
            this.numPagesInput.Size = new System.Drawing.Size(58, 22);
            this.numPagesInput.TabIndex = 1;
            this.numPagesInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbxTwoSides
            // 
            this.cbxTwoSides.AutoSize = true;
            this.cbxTwoSides.Location = new System.Drawing.Point(295, 85);
            this.cbxTwoSides.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTwoSides.Name = "cbxTwoSides";
            this.cbxTwoSides.Size = new System.Drawing.Size(111, 21);
            this.cbxTwoSides.TabIndex = 2;
            this.cbxTwoSides.Text = "2-sided scan";
            this.cbxTwoSides.UseVisualStyleBackColor = true;
            this.cbxTwoSides.CheckedChanged += new System.EventHandler(this.cbxTwoSides_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pages per Form";
            // 
            // tbxOutput
            // 
            this.tbxOutput.Location = new System.Drawing.Point(9, 21);
            this.tbxOutput.Name = "tbxOutput";
            this.tbxOutput.Size = new System.Drawing.Size(532, 227);
            this.tbxOutput.TabIndex = 5;
            this.tbxOutput.Text = "";
            // 
            // grpbxFrmDtls
            // 
            this.grpbxFrmDtls.Controls.Add(this.lblRecievedBy);
            this.grpbxFrmDtls.Controls.Add(this.rdbPortalFallout);
            this.grpbxFrmDtls.Controls.Add(this.rdbFax);
            this.grpbxFrmDtls.Controls.Add(this.rdbPost);
            this.grpbxFrmDtls.Controls.Add(this.scanButton);
            this.grpbxFrmDtls.Controls.Add(this.cmbxFormType);
            this.grpbxFrmDtls.Controls.Add(this.lblFormType);
            this.grpbxFrmDtls.Controls.Add(this.cmbxWorkList);
            this.grpbxFrmDtls.Controls.Add(this.lblAppnType);
            this.grpbxFrmDtls.Location = new System.Drawing.Point(16, 131);
            this.grpbxFrmDtls.Name = "grpbxFrmDtls";
            this.grpbxFrmDtls.Size = new System.Drawing.Size(547, 172);
            this.grpbxFrmDtls.TabIndex = 6;
            this.grpbxFrmDtls.TabStop = false;
            this.grpbxFrmDtls.Text = "Form Details";
            // 
            // lblRecievedBy
            // 
            this.lblRecievedBy.AutoSize = true;
            this.lblRecievedBy.Location = new System.Drawing.Point(21, 103);
            this.lblRecievedBy.Name = "lblRecievedBy";
            this.lblRecievedBy.Size = new System.Drawing.Size(91, 17);
            this.lblRecievedBy.TabIndex = 7;
            this.lblRecievedBy.Text = "Recieved By:";
            // 
            // rdbPortalFallout
            // 
            this.rdbPortalFallout.AutoSize = true;
            this.rdbPortalFallout.Location = new System.Drawing.Point(320, 103);
            this.rdbPortalFallout.Name = "rdbPortalFallout";
            this.rdbPortalFallout.Size = new System.Drawing.Size(112, 21);
            this.rdbPortalFallout.TabIndex = 6;
            this.rdbPortalFallout.Text = "Portal Fallout";
            this.rdbPortalFallout.UseVisualStyleBackColor = true;
            // 
            // rdbFax
            // 
            this.rdbFax.AutoSize = true;
            this.rdbFax.Location = new System.Drawing.Point(225, 103);
            this.rdbFax.Name = "rdbFax";
            this.rdbFax.Size = new System.Drawing.Size(51, 21);
            this.rdbFax.TabIndex = 5;
            this.rdbFax.Text = "Fax";
            this.rdbFax.UseVisualStyleBackColor = true;
            // 
            // rdbPost
            // 
            this.rdbPost.AutoSize = true;
            this.rdbPost.Checked = true;
            this.rdbPost.Location = new System.Drawing.Point(121, 103);
            this.rdbPost.Name = "rdbPost";
            this.rdbPost.Size = new System.Drawing.Size(57, 21);
            this.rdbPost.TabIndex = 4;
            this.rdbPost.TabStop = true;
            this.rdbPost.Text = "Post";
            this.rdbPost.UseVisualStyleBackColor = true;
            // 
            // cmbxFormType
            // 
            this.cmbxFormType.FormattingEnabled = true;
            this.cmbxFormType.Items.AddRange(new object[] {
            "Auto Detect",
            "K1",
            "K2",
            "K4",
            "K3",
            "K6",
            "K7",
            "K8",
            "K9",
            "K10",
            "K11",
            "K12",
            "K13",
            "K15",
            "K16",
            "K19",
            "K20",
            "PA(B)",
            "PA(B) Amend",
            "WO(B)",
            "WO(B) Amend",
            "Unknown"});
            this.cmbxFormType.Location = new System.Drawing.Point(121, 66);
            this.cmbxFormType.Name = "cmbxFormType";
            this.cmbxFormType.Size = new System.Drawing.Size(311, 24);
            this.cmbxFormType.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmbxFormType, "Specify the form type or let the system automatically detect it");
            // 
            // lblFormType
            // 
            this.lblFormType.AutoSize = true;
            this.lblFormType.Location = new System.Drawing.Point(21, 69);
            this.lblFormType.Name = "lblFormType";
            this.lblFormType.Size = new System.Drawing.Size(80, 17);
            this.lblFormType.TabIndex = 3;
            this.lblFormType.Text = "Form Type:";
            // 
            // cmbxWorkList
            // 
            this.cmbxWorkList.FormattingEnabled = true;
            this.cmbxWorkList.Items.AddRange(new object[] {
            "Bankruptcy - Registrations",
            "Bankruptcy - Amendments",
            "Bankruptcy - Rectifications",
            "Bankruptcy - Withheld address",
            "LC - Registrations",
            "LC - Priority Notices",
            "LC - Rectifications",
            "LC - Renewals",
            "Searches - Full",
            "Searches - Bankruptcy",
            "Cancellations",
            "Part Cancelations"});
            this.cmbxWorkList.Location = new System.Drawing.Point(121, 33);
            this.cmbxWorkList.Name = "cmbxWorkList";
            this.cmbxWorkList.Size = new System.Drawing.Size(311, 24);
            this.cmbxWorkList.TabIndex = 0;
            // 
            // lblAppnType
            // 
            this.lblAppnType.AutoSize = true;
            this.lblAppnType.Location = new System.Drawing.Point(21, 36);
            this.lblAppnType.Name = "lblAppnType";
            this.lblAppnType.Size = new System.Drawing.Size(71, 17);
            this.lblAppnType.TabIndex = 1;
            this.lblAppnType.Text = "Work List:";
            // 
            // lblFormsToScan
            // 
            this.lblFormsToScan.AutoSize = true;
            this.lblFormsToScan.Location = new System.Drawing.Point(271, 57);
            this.lblFormsToScan.Name = "lblFormsToScan";
            this.lblFormsToScan.Size = new System.Drawing.Size(97, 17);
            this.lblFormsToScan.TabIndex = 7;
            this.lblFormsToScan.Text = "Forms to scan";
            // 
            // cbxScanAll
            // 
            this.cbxScanAll.AutoSize = true;
            this.cbxScanAll.Checked = true;
            this.cbxScanAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxScanAll.Location = new System.Drawing.Point(435, 55);
            this.cbxScanAll.Name = "cbxScanAll";
            this.cbxScanAll.Size = new System.Drawing.Size(45, 21);
            this.cbxScanAll.TabIndex = 8;
            this.cbxScanAll.Text = "All";
            this.cbxScanAll.UseVisualStyleBackColor = true;
            this.cbxScanAll.CheckedChanged += new System.EventHandler(this.cbxScanAll_CheckedChanged);
            // 
            // numDocsInput
            // 
            this.numDocsInput.Enabled = false;
            this.numDocsInput.Location = new System.Drawing.Point(375, 55);
            this.numDocsInput.Margin = new System.Windows.Forms.Padding(4);
            this.numDocsInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDocsInput.Name = "numDocsInput";
            this.numDocsInput.Size = new System.Drawing.Size(47, 22);
            this.numDocsInput.TabIndex = 10;
            this.numDocsInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbxSource
            // 
            this.cmbxSource.FormattingEnabled = true;
            this.cmbxSource.Location = new System.Drawing.Point(73, 21);
            this.cmbxSource.Name = "cmbxSource";
            this.cmbxSource.Size = new System.Drawing.Size(457, 24);
            this.cmbxSource.TabIndex = 11;
            this.cmbxSource.SelectedIndexChanged += new System.EventHandler(this.cmbxSource_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Source";
            // 
            // cbxPreview
            // 
            this.cbxPreview.AutoSize = true;
            this.cbxPreview.Location = new System.Drawing.Point(73, 84);
            this.cbxPreview.Name = "cbxPreview";
            this.cbxPreview.Size = new System.Drawing.Size(79, 21);
            this.cbxPreview.TabIndex = 16;
            this.cbxPreview.Text = "Preview";
            this.cbxPreview.UseVisualStyleBackColor = true;
            this.cbxPreview.Visible = false;
            // 
            // cbxScanAndSend
            // 
            this.cbxScanAndSend.AutoSize = true;
            this.cbxScanAndSend.Location = new System.Drawing.Point(161, 84);
            this.cbxScanAndSend.Name = "cbxScanAndSend";
            this.cbxScanAndSend.Size = new System.Drawing.Size(127, 21);
            this.cbxScanAndSend.TabIndex = 17;
            this.cbxScanAndSend.Text = "Scan and Send";
            this.cbxScanAndSend.UseVisualStyleBackColor = true;
            this.cbxScanAndSend.CheckedChanged += new System.EventHandler(this.cbxScanAndSend_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProg,
            this.tslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProg
            // 
            this.tsProg.Name = "tsProg";
            this.tsProg.Size = new System.Drawing.Size(200, 16);
            // 
            // tslblStatus
            // 
            this.tslblStatus.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size(47, 17);
            this.tslblStatus.Text = "Ready";
            // 
            // gbpScanOptions
            // 
            this.gbpScanOptions.Controls.Add(this.cmbxPaperSize);
            this.gbpScanOptions.Controls.Add(this.cmbxSource);
            this.gbpScanOptions.Controls.Add(this.label3);
            this.gbpScanOptions.Controls.Add(this.label1);
            this.gbpScanOptions.Controls.Add(this.cbxScanAndSend);
            this.gbpScanOptions.Controls.Add(this.cbxScanAll);
            this.gbpScanOptions.Controls.Add(this.cbxPreview);
            this.gbpScanOptions.Controls.Add(this.numDocsInput);
            this.gbpScanOptions.Controls.Add(this.numPagesInput);
            this.gbpScanOptions.Controls.Add(this.lblFormsToScan);
            this.gbpScanOptions.Controls.Add(this.cbxTwoSides);
            this.gbpScanOptions.Location = new System.Drawing.Point(16, 13);
            this.gbpScanOptions.Name = "gbpScanOptions";
            this.gbpScanOptions.Size = new System.Drawing.Size(547, 112);
            this.gbpScanOptions.TabIndex = 20;
            this.gbpScanOptions.TabStop = false;
            this.gbpScanOptions.Text = "Scanning Options";
            // 
            // pbxShowLog
            // 
            this.pbxShowLog.Location = new System.Drawing.Point(40, 3);
            this.pbxShowLog.Name = "pbxShowLog";
            this.pbxShowLog.Size = new System.Drawing.Size(16, 14);
            this.pbxShowLog.TabIndex = 21;
            this.pbxShowLog.TabStop = false;
            this.pbxShowLog.Click += new System.EventHandler(this.pbxShowLog_Click);
            // 
            // imglstMain
            // 
            this.imglstMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstMain.ImageStream")));
            this.imglstMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstMain.Images.SetKeyName(0, "expandDown1.bmp");
            this.imglstMain.Images.SetKeyName(1, "expandUp1.bmp");
            // 
            // gpbxLog
            // 
            this.gpbxLog.Controls.Add(this.pbxShowLog);
            this.gpbxLog.Controls.Add(this.tbxOutput);
            this.gpbxLog.Location = new System.Drawing.Point(16, 306);
            this.gpbxLog.Name = "gpbxLog";
            this.gpbxLog.Size = new System.Drawing.Size(547, 256);
            this.gpbxLog.TabIndex = 22;
            this.gpbxLog.TabStop = false;
            this.gpbxLog.Text = "Log";
            // 
            // cmbxPaperSize
            // 
            this.cmbxPaperSize.FormattingEnabled = true;
            this.cmbxPaperSize.Items.AddRange(new object[] {
            "A3",
            "A4",
            "A5"});
            this.cmbxPaperSize.Location = new System.Drawing.Point(448, 81);
            this.cmbxPaperSize.Name = "cmbxPaperSize";
            this.cmbxPaperSize.Size = new System.Drawing.Size(82, 24);
            this.cmbxPaperSize.TabIndex = 18;
            // 
            // ScanOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 606);
            this.Controls.Add(this.gpbxLog);
            this.Controls.Add(this.gbpScanOptions);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpbxFrmDtls);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScanOptions";
            this.Text = "Land Charges Scan";
            ((System.ComponentModel.ISupportInitialize)(this.numPagesInput)).EndInit();
            this.grpbxFrmDtls.ResumeLayout(false);
            this.grpbxFrmDtls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDocsInput)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbpScanOptions.ResumeLayout(false);
            this.gbpScanOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowLog)).EndInit();
            this.gpbxLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.NumericUpDown numPagesInput;
        private System.Windows.Forms.CheckBox cbxTwoSides;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox tbxOutput;
        private System.Windows.Forms.GroupBox grpbxFrmDtls;
        private System.Windows.Forms.Label lblAppnType;
        private System.Windows.Forms.ComboBox cmbxWorkList;
        private System.Windows.Forms.Label lblFormsToScan;
        private System.Windows.Forms.CheckBox cbxScanAll;
        private System.Windows.Forms.NumericUpDown numDocsInput;
        private System.Windows.Forms.ComboBox cmbxSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxPreview;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbxScanAndSend;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProg;
        private System.Windows.Forms.ComboBox cmbxFormType;
        private System.Windows.Forms.Label lblFormType;
        private System.Windows.Forms.GroupBox gbpScanOptions;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus;
        private System.Windows.Forms.PictureBox pbxShowLog;
        private System.Windows.Forms.ImageList imglstMain;
        private System.Windows.Forms.GroupBox gpbxLog;
        private System.Windows.Forms.RadioButton rdbPortalFallout;
        private System.Windows.Forms.RadioButton rdbFax;
        private System.Windows.Forms.RadioButton rdbPost;
        private System.Windows.Forms.Label lblRecievedBy;
        private System.Windows.Forms.ComboBox cmbxPaperSize;
    }
}

