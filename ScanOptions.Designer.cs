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
            this.scanButton = new System.Windows.Forms.Button();
            this.numPagesInput = new System.Windows.Forms.NumericUpDown();
            this.twoSidesCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPagesInput)).BeginInit();
            this.SuspendLayout();
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(224, 81);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(75, 23);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "Scan Now";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // numPagesInput
            // 
            this.numPagesInput.Location = new System.Drawing.Point(179, 11);
            this.numPagesInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPagesInput.Name = "numPagesInput";
            this.numPagesInput.Size = new System.Drawing.Size(120, 20);
            this.numPagesInput.TabIndex = 1;
            this.numPagesInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // twoSidesCheckbox
            // 
            this.twoSidesCheckbox.AutoSize = true;
            this.twoSidesCheckbox.Location = new System.Drawing.Point(179, 37);
            this.twoSidesCheckbox.Name = "twoSidesCheckbox";
            this.twoSidesCheckbox.Size = new System.Drawing.Size(86, 17);
            this.twoSidesCheckbox.TabIndex = 2;
            this.twoSidesCheckbox.Text = "2-sided scan";
            this.twoSidesCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of pages per application";
            // 
            // ScanOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 117);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.twoSidesCheckbox);
            this.Controls.Add(this.numPagesInput);
            this.Controls.Add(this.scanButton);
            this.Name = "ScanOptions";
            this.Text = "Set Scan Options";
            ((System.ComponentModel.ISupportInitialize)(this.numPagesInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.NumericUpDown numPagesInput;
        private System.Windows.Forms.CheckBox twoSidesCheckbox;
        private System.Windows.Forms.Label label1;
    }
}

