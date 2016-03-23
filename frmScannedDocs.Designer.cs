namespace PaperCapture
{
    partial class frmScannedDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScannedDocs));
            this.trvwMain = new System.Windows.Forms.TreeView();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRotate = new System.Windows.Forms.ToolStripButton();
            this.tsbPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbtnMoveDown = new System.Windows.Forms.ToolStripButton();
            this.tbtnUp = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblDoc = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgBr = new System.Windows.Forms.ToolStripProgressBar();
            this.tsLblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.imgLstIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnScanMore = new System.Windows.Forms.Button();
            this.lblBatchDetl = new System.Windows.Forms.Label();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvwMain
            // 
            this.trvwMain.AllowDrop = true;
            this.trvwMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trvwMain.ItemHeight = 18;
            this.trvwMain.Location = new System.Drawing.Point(12, 51);
            this.trvwMain.Name = "trvwMain";
            this.trvwMain.Size = new System.Drawing.Size(278, 568);
            this.trvwMain.TabIndex = 22;
            this.trvwMain.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvwMain_ItemDrag);
            this.trvwMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvwMain_AfterSelect);
            this.trvwMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.trvwMain_DragEnter);
            // 
            // pbxImage
            // 
            this.pbxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxImage.Location = new System.Drawing.Point(307, 51);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(471, 568);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImage.TabIndex = 21;
            this.pbxImage.TabStop = false;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(665, 625);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(113, 23);
            this.btnSend.TabIndex = 27;
            this.btnSend.Text = "Send Docs";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(477, 625);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRotate,
            this.tsbPrev,
            this.tsbNext,
            this.tsbDelete,
            this.tbtnMoveDown,
            this.tbtnUp,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(813, 25);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRotate
            // 
            this.tsbRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRotate.Image = ((System.Drawing.Image)(resources.GetObject("tsbRotate.Image")));
            this.tsbRotate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRotate.Name = "tsbRotate";
            this.tsbRotate.Size = new System.Drawing.Size(23, 22);
            this.tsbRotate.Text = "Rotate 90";
            this.tsbRotate.Click += new System.EventHandler(this.tsbRotate_Click);
            // 
            // tsbPrev
            // 
            this.tsbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrev.Image")));
            this.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.Size = new System.Drawing.Size(23, 22);
            this.tsbPrev.Text = "Previous Page";
            this.tsbPrev.ToolTipText = "Previous Page";
            this.tsbPrev.Click += new System.EventHandler(this.tsbPrev_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(23, 22);
            this.tsbNext.Text = "Next Page";
            this.tsbNext.ToolTipText = "Next Page";
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "Delete Page";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tbtnMoveDown
            // 
            this.tbtnMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("tbtnMoveDown.Image")));
            this.tbtnMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnMoveDown.Name = "tbtnMoveDown";
            this.tbtnMoveDown.Size = new System.Drawing.Size(23, 22);
            this.tbtnMoveDown.Text = "Down";
            this.tbtnMoveDown.ToolTipText = "Move Page Down";
            this.tbtnMoveDown.Click += new System.EventHandler(this.tbtnMoveDown_Click);
            // 
            // tbtnUp
            // 
            this.tbtnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnUp.Image = ((System.Drawing.Image)(resources.GetObject("tbtnUp.Image")));
            this.tbtnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnUp.Name = "tbtnUp";
            this.tbtnUp.Size = new System.Drawing.Size(23, 22);
            this.tbtnUp.Text = "Up";
            this.tbtnUp.ToolTipText = "Move Page Up";
            this.tbtnUp.Click += new System.EventHandler(this.tbtnUp_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblDoc,
            this.tsProgBr,
            this.tsLblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(813, 23);
            this.statusStrip1.TabIndex = 32;
            // 
            // tsslblDoc
            // 
            this.tsslblDoc.Name = "tsslblDoc";
            this.tsslblDoc.Size = new System.Drawing.Size(49, 18);
            this.tsslblDoc.Text = "Status";
            // 
            // tsProgBr
            // 
            this.tsProgBr.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsProgBr.Name = "tsProgBr";
            this.tsProgBr.Size = new System.Drawing.Size(100, 17);
            // 
            // tsLblStatus
            // 
            this.tsLblStatus.Name = "tsLblStatus";
            this.tsLblStatus.Size = new System.Drawing.Size(0, 18);
            // 
            // imgLstIcons
            // 
            this.imgLstIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstIcons.ImageStream")));
            this.imgLstIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstIcons.Images.SetKeyName(0, "699044-icon-55-document-text-128.png");
            this.imgLstIcons.Images.SetKeyName(1, "trash.png");
            this.imgLstIcons.Images.SetKeyName(2, "movedocup.png");
            // 
            // btnScanMore
            // 
            this.btnScanMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanMore.Location = new System.Drawing.Point(558, 625);
            this.btnScanMore.Name = "btnScanMore";
            this.btnScanMore.Size = new System.Drawing.Size(101, 23);
            this.btnScanMore.TabIndex = 33;
            this.btnScanMore.Text = "Scan More";
            this.btnScanMore.UseVisualStyleBackColor = true;
            this.btnScanMore.Click += new System.EventHandler(this.btnScanMore_Click);
            // 
            // lblBatchDetl
            // 
            this.lblBatchDetl.AutoSize = true;
            this.lblBatchDetl.Location = new System.Drawing.Point(12, 31);
            this.lblBatchDetl.Name = "lblBatchDetl";
            this.lblBatchDetl.Size = new System.Drawing.Size(0, 17);
            this.lblBatchDetl.TabIndex = 34;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Split page into new document";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // frmScannedDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 677);
            this.Controls.Add(this.lblBatchDetl);
            this.Controls.Add(this.btnScanMore);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.trvwMain);
            this.Controls.Add(this.pbxImage);
            this.Name = "frmScannedDocs";
            this.Text = "Scanned Documents";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvwMain;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRotate;
        private System.Windows.Forms.ToolStripButton tsbPrev;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ImageList imgLstIcons;
        private System.Windows.Forms.ToolStripStatusLabel tsslblDoc;
        private System.Windows.Forms.ToolStripProgressBar tsProgBr;
        private System.Windows.Forms.ToolStripStatusLabel tsLblStatus;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Button btnScanMore;
        private System.Windows.Forms.Label lblBatchDetl;
        private System.Windows.Forms.ToolStripButton tbtnMoveDown;
        private System.Windows.Forms.ToolStripButton tbtnUp;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}