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
            this.scanButton = new System.Windows.Forms.Button();
            this.numPagesInput = new System.Windows.Forms.NumericUpDown();
            this.cbxTwoSides = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxOutput = new System.Windows.Forms.RichTextBox();
            this.grpbxFrmDtls = new System.Windows.Forms.GroupBox();
            this.cmbxWorkType = new System.Windows.Forms.ComboBox();
            this.lblAppnType = new System.Windows.Forms.Label();
            this.lblFormsToScan = new System.Windows.Forms.Label();
            this.cbxScanAll = new System.Windows.Forms.CheckBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.numDocsInput = new System.Windows.Forms.NumericUpDown();
            this.cmbxSource = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPreview = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbxScanAndSend = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProg = new System.Windows.Forms.ToolStripProgressBar();
            this.cbxA3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPagesInput)).BeginInit();
            this.grpbxFrmDtls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDocsInput)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(339, 219);
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
            this.numPagesInput.Location = new System.Drawing.Point(162, 53);
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
            this.cbxTwoSides.Location = new System.Drawing.Point(269, 92);
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
            this.label1.Location = new System.Drawing.Point(36, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pages per Form";
            // 
            // tbxOutput
            // 
            this.tbxOutput.Location = new System.Drawing.Point(14, 295);
            this.tbxOutput.Name = "tbxOutput";
            this.tbxOutput.Size = new System.Drawing.Size(463, 259);
            this.tbxOutput.TabIndex = 5;
            this.tbxOutput.Text = "";
            // 
            // grpbxFrmDtls
            // 
            this.grpbxFrmDtls.Controls.Add(this.cmbxWorkType);
            this.grpbxFrmDtls.Controls.Add(this.lblAppnType);
            this.grpbxFrmDtls.Location = new System.Drawing.Point(16, 120);
            this.grpbxFrmDtls.Name = "grpbxFrmDtls";
            this.grpbxFrmDtls.Size = new System.Drawing.Size(461, 81);
            this.grpbxFrmDtls.TabIndex = 6;
            this.grpbxFrmDtls.TabStop = false;
            this.grpbxFrmDtls.Text = "Form Details";
            // 
            // cmbxWorkType
            // 
            this.cmbxWorkType.FormattingEnabled = true;
            this.cmbxWorkType.Items.AddRange(new object[] {
            "Bankruptcy Registration",
            "Land Charges Registration",
            "Amendment",
            "Cancellation",
            "Search",
            "Official Copy"});
            this.cmbxWorkType.Location = new System.Drawing.Point(121, 33);
            this.cmbxWorkType.Name = "cmbxWorkType";
            this.cmbxWorkType.Size = new System.Drawing.Size(311, 24);
            this.cmbxWorkType.TabIndex = 0;
            // 
            // lblAppnType
            // 
            this.lblAppnType.AutoSize = true;
            this.lblAppnType.Location = new System.Drawing.Point(32, 36);
            this.lblAppnType.Name = "lblAppnType";
            this.lblAppnType.Size = new System.Drawing.Size(81, 17);
            this.lblAppnType.TabIndex = 1;
            this.lblAppnType.Text = "Work Type:";
            // 
            // lblFormsToScan
            // 
            this.lblFormsToScan.AutoSize = true;
            this.lblFormsToScan.Location = new System.Drawing.Point(250, 55);
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
            this.cbxScanAll.Location = new System.Drawing.Point(408, 55);
            this.cbxScanAll.Name = "cbxScanAll";
            this.cbxScanAll.Size = new System.Drawing.Size(45, 21);
            this.cbxScanAll.TabIndex = 8;
            this.cbxScanAll.Text = "All";
            this.cbxScanAll.UseVisualStyleBackColor = true;
            this.cbxScanAll.CheckedChanged += new System.EventHandler(this.cbxScanAll_CheckedChanged);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(11, 275);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(36, 17);
            this.lblLog.TabIndex = 9;
            this.lblLog.Text = "Log:";
            // 
            // numDocsInput
            // 
            this.numDocsInput.Enabled = false;
            this.numDocsInput.Location = new System.Drawing.Point(354, 53);
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
            this.cmbxSource.Location = new System.Drawing.Point(100, 12);
            this.cmbxSource.Name = "cmbxSource";
            this.cmbxSource.Size = new System.Drawing.Size(377, 24);
            this.cmbxSource.TabIndex = 11;
            this.cmbxSource.SelectedIndexChanged += new System.EventHandler(this.cmbxSource_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Source";
            // 
            // cbxPreview
            // 
            this.cbxPreview.AutoSize = true;
            this.cbxPreview.Location = new System.Drawing.Point(183, 93);
            this.cbxPreview.Name = "cbxPreview";
            this.cbxPreview.Size = new System.Drawing.Size(79, 21);
            this.cbxPreview.TabIndex = 16;
            this.cbxPreview.Text = "Preview";
            this.cbxPreview.UseVisualStyleBackColor = true;
            // 
            // cbxScanAndSend
            // 
            this.cbxScanAndSend.AutoSize = true;
            this.cbxScanAndSend.Location = new System.Drawing.Point(39, 93);
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
            this.tsProg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 565);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(490, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProg
            // 
            this.tsProg.Name = "tsProg";
            this.tsProg.Size = new System.Drawing.Size(200, 16);
            // 
            // cbxA3
            // 
            this.cbxA3.AutoSize = true;
            this.cbxA3.Location = new System.Drawing.Point(387, 93);
            this.cbxA3.Name = "cbxA3";
            this.cbxA3.Size = new System.Drawing.Size(47, 21);
            this.cbxA3.TabIndex = 19;
            this.cbxA3.Text = "A3";
            this.cbxA3.UseVisualStyleBackColor = true;
            // 
            // ScanOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 587);
            this.Controls.Add(this.cbxA3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbxScanAndSend);
            this.Controls.Add(this.cbxPreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbxSource);
            this.Controls.Add(this.numDocsInput);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.cbxScanAll);
            this.Controls.Add(this.lblFormsToScan);
            this.Controls.Add(this.grpbxFrmDtls);
            this.Controls.Add(this.tbxOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTwoSides);
            this.Controls.Add(this.numPagesInput);
            this.Controls.Add(this.scanButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScanOptions";
            this.Text = "LC Scanning";
            ((System.ComponentModel.ISupportInitialize)(this.numPagesInput)).EndInit();
            this.grpbxFrmDtls.ResumeLayout(false);
            this.grpbxFrmDtls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDocsInput)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbxWorkType;
        private System.Windows.Forms.Label lblFormsToScan;
        private System.Windows.Forms.CheckBox cbxScanAll;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.NumericUpDown numDocsInput;
        private System.Windows.Forms.ComboBox cmbxSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxPreview;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbxScanAndSend;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProg;
        private System.Windows.Forms.CheckBox cbxA3;
    }
}

