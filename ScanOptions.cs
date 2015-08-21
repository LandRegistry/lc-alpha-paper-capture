using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace PaperCapture
{
    public partial class ScanOptions : Form
    {
        public ScanOptions()
        {
            InitializeComponent();
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            // Just scan 1 for now...
            ScannerControl control = new ScannerControl((int)numPagesInput.Value, twoSidesCheckbox.Checked);
            List<Image> images = control.Scan();

            if (images.Count > 0)
            {
                int id = Requests.CreateDocument();
                foreach (Image image in images)
                {
                    Requests.AddImageToDocument(id, image);
                }
                string formType = Requests.GetFormType(id);
                Requests.CreateWorklistItem(id, formType, "bank_regn");
                MessageBox.Show("Worklist item created");
            }
        }
    }
}
