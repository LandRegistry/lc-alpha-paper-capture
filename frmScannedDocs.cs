using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KaupischITC.ScanWIA;

namespace PaperCapture
{
    public partial class frmScannedDocs : Form
    {
        public frmScannedDocs(ScanOptions pOwner)
        {

            InitializeComponent();
            this.parentFrm = pOwner;
        }

        private ScanOptions parentFrm;
        private List<LCDoc> docBatch;
        private string workType;
        private bool showingPrev = false;
        private ImageList imgLst;

        /// <summary>
        /// Adds nodes to the tree view to allow the user to check before sending the batch
        /// </summary>
        /// <param name="pDocBatch">List of LCDoc objects</param>
        public void buildTree(List<LCDoc> pDocBatch, string pWorkType)
        {
            this.workType = pWorkType;
            docBatch = pDocBatch;
            trvwMain.Nodes.Clear();
            trvwMain.ItemHeight = 32;
            imgLst = new ImageList();
            imgLst.ImageSize = new Size(32, 32);
            imgLst.Images.Add(imgLstIcons.Images[0]);
            foreach (LCDoc doc in docBatch)
            {                
                foreach (Image img in doc.ImgLst)
                {
                    imgLst.Images.Add(img);
                }
            }
            int imgCtr = 0;
            trvwMain.ImageList = imgLst;
            foreach (LCDoc doc in docBatch)
            {
                
                TreeNode[] array = new TreeNode[doc.ImgLst.Count];
                for (int i = 0; i < doc.ImgLst.Count;  i++)
                { 
                    TreeNode imgNode = new TreeNode((i+1).ToString(), imgCtr+1, imgCtr+1);
                    array[i] = imgNode; 
                }

                TreeNode treeNode = new TreeNode(doc.SeqNo.ToString(), 0, 0, array);
                trvwMain.Nodes.Add(treeNode);
                imgCtr++;
            }
            trvwMain.ExpandAll();
            trvwMain.SelectedNode = trvwMain.Nodes[0].Nodes[0];

        }

        /// <summary>
        /// When there is a change on the treeview display the page in the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvwMain_AfterSelect(object sender, TreeViewEventArgs e)
        {      
            showPage();
            showingPrev = false;
        }

        /// <summary>
        /// Show the selected page from the treeview
        /// </summary>
        private void showPage()
        {
            TreeNode node = trvwMain.SelectedNode;
            if (node.Parent == null) //try to move to the next image
            {
                if (!showingPrev)
                {
                    if (trvwMain.SelectedNode.NextVisibleNode != null)
                    {
                        trvwMain.SelectedNode = trvwMain.SelectedNode.NextVisibleNode;
                    }
                }
                else
                {
                    if (trvwMain.SelectedNode.PrevVisibleNode != null)
                    {
                        trvwMain.SelectedNode = trvwMain.SelectedNode.PrevVisibleNode;
                    }
                }
            }
            if (node != null)
            {            
                if (node.Parent != null) //we are on an image
                {
                    TreeNode parentNode = node.Parent;
                    tsslblDoc.Text = string.Format("Document {0} Page {1}", parentNode.Text, node.Text);
                    int docNo = Convert.ToInt32(parentNode.Text) - 1;
                    int pageNo = Convert.ToInt32(node.Text) - 1;
                    pbxImage.Image = docBatch[docNo].ImgLst[pageNo];
                }
            }

        }

        /// <summary>
        /// Button to allow user to rotate the image through 180 degrees if it was scanned upside down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotate_Click(object sender, EventArgs e)
        {
            rotatePage();
        }

        /// <summary>
        /// Button to send the batch to the Document API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            sendBatch();
        }

        /// <summary>
        /// Iterates through the scanned forms, uses the document API to create the document and the worklist item. 
        /// </summary>
        private void sendBatch()
        {
            try
            {
                tsProgBr.Maximum = imgLst.Images.Count;
                //work out the step from the number of images to send
                tsProgBr.Step = 1;
                int i = 0;
                foreach (LCDoc doc in docBatch)
                {
                    tsLblStatus.Text = "Sending Form " + (i+1).ToString();
                    Application.DoEvents();
                    int id = 0; // Requests.CreateDocument();
                    int x = 0;
                    dynamic vDoc;
                    string formType = "";
                    foreach (Image image in doc.ImgLst)
                    {
                        vDoc = Requests.AddImageToDocument(id, image, doc.PaperSize);
                        id = vDoc.id;
                        formType = vDoc.form_type;
                        tsLblStatus.Text = "Sending Form " + (i+1).ToString() + " page " + (x + 1).ToString();
                        tsProgBr.PerformStep();
                        Application.DoEvents();
                        x++;
                    }
                    Requests.CreateWorklistItem(id, formType, this.workType);
                    this.parentFrm.LogMsg("Worklist item created: ID " + id.ToString() + " Type: " + formType + Environment.NewLine);                    
                    i ++;
                }
                tsLblStatus.Text = "Transfer Complete ";
            }
            catch (Exception exp)
            {
                try
                {
                    string msg = this.parentFrm.MsgTranslate(exp.Message);
                    this.parentFrm.showAndLog("An Error Occured: " + msg);

                }
                catch
                {
                    this.parentFrm.showAndLog("An Error Occured: " + exp.Message);
                }
            }
            Close();
        }

    
        /// <summary>
        /// Displays the images associated with the selected node int he picture box.
        /// </summary>
        private void viewPage()
        {
            TreeNode node = trvwMain.SelectedNode;
            if (node != null)
            {
                if (node.Parent != null) //we are on an image
                {
                    TreeNode parentNode = node.Parent;
                    tsslblDoc.Text = string.Format("Document {0} Page {1}", parentNode.Text, node.Text);
                    int docNo = Convert.ToInt32(parentNode.Text) - 1;
                    int pageNo = Convert.ToInt32(node.Text) - 1;
                    previewImage(docBatch[docNo].ImgLst[pageNo]);
                }
            }
        }

        
        private void tsbPreview_Click(object sender, EventArgs e)
        {
            viewPage();
        }

        /// <summary>
        /// Show the selected image in the preview window
        /// </summary>
        /// <param name="pImg"></param>
        private void previewImage(Image pImg)
        {
            frmPreview prvw = new frmPreview();
            prvw.SetImg(pImg);
            prvw.ShowDialog();
        }

        /// <summary>
        /// User can cancel the scan and send process at this stage, nothing will be send and 
        /// the documents will have to be scanned again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Button to show the next document page in the tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            nextPage();
        }

        /// <summary>
        /// Show the next page in the selected document or the first page of the next document.
        /// </summary>
        private void nextPage()
        {
            if (trvwMain.SelectedNode.NextVisibleNode != null)
            {
                trvwMain.SelectedNode = trvwMain.SelectedNode.NextVisibleNode;
            }
            trvwMain.Focus();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            prevPage();
        }

        private void prevPage()
        {
            showingPrev = true;
            if (trvwMain.SelectedNode.PrevVisibleNode != null)
            {
                trvwMain.SelectedNode = trvwMain.SelectedNode.PrevVisibleNode;
            }
            trvwMain.Focus();
        }

        private void pbxPreview_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void rotatePage()
        {
            pbxImage.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            showPage();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            nextPage();
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            prevPage();
        }

        private void tsbRotate_Click(object sender, EventArgs e)
        {
            rotatePage();
        }

        private void lblImageDetl_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.parentFrm.LogMsg("Sending documents was cancelled");
            Close();
        }

        private void frmScannedDocs_Load(object sender, EventArgs e)
        {

        }

        private string getPaperSize(Image pImage)
        {
            //work out whether this is an A4 or A3 document.            
            MessageBox.Show("Width: " + pImage.PhysicalDimension.Width + " height: " + pImage.PhysicalDimension.Height);
            return "A4";
        }

  

       
    }
}
