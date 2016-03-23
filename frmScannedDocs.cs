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
        /// <summary>
        /// This unit allows caseworkers to double check the images that have been scanned and make minor amendments before sending.
        /// </summary>
        /// <param name="pOwner"></param>
        public frmScannedDocs(ScanOptions pOwner)
        {

            InitializeComponent();
            this.parentFrm = pOwner;
            trvwMain.ItemDrag += new ItemDragEventHandler(trvwMain_ItemDrag);
            trvwMain.DragEnter += new DragEventHandler(trvwMain_DragEnter);
            trvwMain.DragOver += new DragEventHandler(trvwMain_DragOver);
            trvwMain.DragDrop += new DragEventHandler(trvwMain_DragDrop);

        }

        private ScanOptions parentFrm;
        private List<LCDoc> docBatch;
        private string workType;
        private string formTypeOverride;
        private string deliveryInd;
        private bool showingPrev = false;
        private ImageList imgLst;
        private bool monochrome;

        /// <summary>
        /// Adds nodes to the tree view to allow the user to check before sending the batch
        /// </summary>
        /// <param name="pDocBatch">List of LCDoc objects</param>
        public void buildTree(List<LCDoc> pDocBatch, string pWorkType, string pFormTypeOverride, string pDeliveryInd, bool pMonochrome)
        {
            this.workType = pWorkType;
            this.formTypeOverride = pFormTypeOverride;
            this.deliveryInd = pDeliveryInd;
            this.monochrome = pMonochrome;
            if (pFormTypeOverride != "")
            {
                lblBatchDetl.Text = pWorkType.ToUpper() + " | " + pFormTypeOverride + " | " + pDeliveryInd;
            }
            else
            {
                lblBatchDetl.Text = pWorkType.ToUpper() + " | " + pDeliveryInd;
            }
            this.docBatch = pDocBatch;
            refreshTree();
        }

        private void refreshTree()
        {
            trvwMain.Nodes.Clear();
            if (docBatch.Count > 0)
            {
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
                    for (int i = 0; i < doc.ImgLst.Count; i++)
                    {
                        TreeNode imgNode = new TreeNode((i + 1).ToString(), imgCtr + 1, imgCtr + 1);
                        array[i] = imgNode;
                    }

                    TreeNode treeNode = new TreeNode(doc.SeqNo.ToString(), 0, 0, array);
                    trvwMain.Nodes.Add(treeNode);
                    imgCtr++;
                }
                trvwMain.ExpandAll();
               // trvwMain.SelectedNode = trvwMain.Nodes[0].Nodes[0];
            }
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
            if (docBatch.Count <= 0)
            {
                return;
            }
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
                    int docNo = parentNode.Index;
                    int pageNo = node.Index;
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
            if (docBatch.Count > 0)
            {
                sendBatch();
            }
            else
            {
                MessageBox.Show("There are no documents to send");
            }
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
                    tsLblStatus.Text = "Sending Form " + (i + 1).ToString();
                    Application.DoEvents();
                    int id = 0; // Requests.CreateDocument();
                    int x = 0;
                    dynamic vDoc;
                    string formType = "";
                    foreach (Image image in doc.ImgLst)
                    {
                        //detect paper size as various sizes could have beendragged together
                        string paperSize = getPaperSize(image);
                        //pass id of 0 to indicate first page of a new document   

                        vDoc = Requests.AddImageToDocument(id, image, paperSize, formTypeOverride);
                        if (id == 0)
                        {
                            id = vDoc.id;
                            formType = vDoc.form_type.ToString();
                        }
                        tsLblStatus.Text = "Sending Form " + (i + 1).ToString() + " page " + (x + 1).ToString();
                        tsProgBr.PerformStep();
                        Application.DoEvents();
                        x++;
                    }
                    Requests.CreateWorklistItem(id, formType, this.workType, this.deliveryInd);
                    //Requests.CreateWorklistItem(id, formType, "all", this.deliveryInd);
                    this.parentFrm.LogMsg("Worklist item created: ID " + id.ToString() + " Type: " + formType + Environment.NewLine);
                    i++;
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
            this.parentFrm.ContinueScanning(false, docBatch);
            Close();
        }

        private string getPaperSize(Image pImg)
        {
            //float imageHeightPrint = pImg.Height / pImg.VerticalResolution * 100;
            float imageWidthPrint = pImg.Width / pImg.HorizontalResolution * 100;
            string paperSize = "A4";
            if (imageWidthPrint < 900)
                paperSize = "A5";
            else if (imageWidthPrint > 1350)
                paperSize = "A3";
            this.parentFrm.LogMsg("paper size " + paperSize + ":  width " + imageWidthPrint.ToString());
            return paperSize;
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
            if (docBatch.Count <= 0)
            {
                return;
            }
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
            if (docBatch.Count <= 0)
            {
                return;
            }
            showingPrev = true;
            if (trvwMain.SelectedNode.PrevVisibleNode != null)
            {
                trvwMain.SelectedNode = trvwMain.SelectedNode.PrevVisibleNode;
            }
            trvwMain.Focus();
        }

        private void rotatePage()
        {
            if (docBatch.Count <= 0)
            {
                return;
            }
            pbxImage.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            showPage();
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.parentFrm.LogMsg("Sending documents was cancelled");
            Close();
        }


        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (docBatch.Count <= 0)
            {
                return;
            }
            TreeNode node = trvwMain.SelectedNode;
            TreeNode parentNode = node.Parent;
            tsslblDoc.Text = string.Format("Document {0} Page {1}", parentNode.Text, node.Text);
            int docNo = Convert.ToInt32(parentNode.Text) - 1;
            int pageNo = Convert.ToInt32(node.Text) - 1;
            //remove the selected page
            docBatch[docNo].ImgLst.RemoveAt(pageNo);
            if (docBatch[docNo].ImgLst.Count <= 0)
            {
                //if there are no other pages delete the document
                docBatch.RemoveAt(docNo);
            }
            //resequence docBatch so the node names are correct upon refreshing the treeview
            for (int i = 0; i < docBatch.Count; i++)
            {
                docBatch[i].SeqNo = i + 1;
            }
            //rebuild the tree
            refreshTree();
        }

        private void trvwMain_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void trvwMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void trvwMain_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = trvwMain.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            trvwMain.SelectedNode = trvwMain.GetNodeAt(targetPoint);
        }

        private void trvwMain_DragDrop(object sender, DragEventArgs e)
        {

            // Retrieve the client coordinates of the drop location.
            Point targetPoint = trvwMain.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = trvwMain.GetNodeAt(targetPoint);            
            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if ((targetNode == null) || (draggedNode == null))
            {
                //one or other of the nodes not detected. return before we get an AV
                return;
            }
            int draggedDocNo;
            if (draggedNode.Parent == null)
            {
                tsLblStatus.Text = "dragged node has no parent";
                draggedDocNo = Convert.ToInt32(targetNode.Parent.Text) - 1;
                //return; //cant dragdrop a document node
            }
            else
            {
                draggedDocNo = Convert.ToInt32(draggedNode.Parent.Text) - 1;
            }
            //break if target node create new doc   
            if (targetNode == null)
            {
                //TODO create new document in tree
                return;
            }

            int draggedPageNo = Convert.ToInt32(draggedNode.Text) - 1;
            int targetDocNo;
            int targetPageNo;
            if (targetNode.Parent != null)//they dragged on to a page node
            {
                targetDocNo = Convert.ToInt32(targetNode.Parent.Text) - 1;
                targetPageNo = Convert.ToInt32(targetNode.Text) - 1;
            }
            else //they dragged on to a document node
            {
                targetDocNo = Convert.ToInt32(targetNode.Text) - 1;
                //work out the last page
                targetPageNo = Convert.ToInt32(targetNode.Nodes.Count - 1);
            }

            if ((draggedDocNo == targetDocNo))
            {
                if ((draggedPageNo != targetPageNo))
                {
                    tsLblStatus.Text = "Moved page " + (draggedPageNo + 1).ToString() + " to be page " + (targetPageNo + 1).ToString() + " on doc " + (draggedDocNo + 1).ToString();
                    //MoveElement(ref docBatch[targetDocNo].ImgLst, draggedPageNo, targetPageNo);

                    var element = docBatch[targetDocNo].ImgLst[draggedPageNo];
                    if (draggedPageNo > targetPageNo)
                    {
                        docBatch[targetDocNo].ImgLst.RemoveAt(draggedPageNo);
                        docBatch[targetDocNo].ImgLst.Insert(targetPageNo, element);
                    }
                    else
                    {
                        docBatch[targetDocNo].ImgLst.Insert(targetPageNo + 1, element);
                        docBatch[targetDocNo].ImgLst.RemoveAt(draggedPageNo);
                    }
                    refreshTree();
                }
                return;
            }

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    if (targetNode.Parent != null)
                        targetNode = targetNode.Parent;

                    //move the data 
                    Image img = docBatch[draggedDocNo].ImgLst[draggedPageNo];
                    tsLblStatus.Text = " Insert into doc " + (targetDocNo + 1).ToString() + " page number " + (targetPageNo + 1).ToString();
                    docBatch[targetDocNo].ImgLst.Insert(targetPageNo, img);
                    tsLblStatus.Text = " Remove from doc " + (draggedDocNo + 1).ToString() + " page number " + (draggedPageNo + 1).ToString(); docBatch[draggedDocNo].ImgLst.RemoveAt(draggedPageNo);
                    //targetNode.Nodes.Add(draggedNode);

                    if (docBatch[draggedDocNo].ImgLst.Count <= 0)
                    {
                        docBatch.RemoveAt(draggedDocNo); //if there are no other pages delete the document
                    }

                    //resequence docBatch so the node names are correct upon refreshing the treeview
                    for (int i = 0; i < docBatch.Count; i++)
                    {
                        docBatch[i].SeqNo = i + 1;
                    }
                    //rebuild the tree
                    refreshTree();
                    this.parentFrm.LogMsg("doc no " + (draggedDocNo + 1).ToString() + " page no " + (draggedPageNo + 1).ToString() +
                    " to doc no" + (targetDocNo + 1).ToString() + " page no " + (targetPageNo + 1).ToString());
                }
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        public static void MoveElement(ref List<Image> list, int fromIndex, int toIndex)
        {
            if (fromIndex == toIndex) return;
            if ((fromIndex < 0) || (fromIndex >= list.Count))
            {
                throw new ArgumentException("From index is invalid");
            }
            if ((toIndex < 0) || (toIndex >= list.Count))
            {
                throw new ArgumentException("To index is invalid");
            }

            var element = list[fromIndex];


            if (fromIndex > toIndex)
            {
                list.RemoveAt(fromIndex);
                list.Insert(toIndex, element);
            }
            else
            {
                list.Insert(toIndex, element);
                list.RemoveAt(fromIndex);
            }
        }

        private void btnScanMore_Click(object sender, EventArgs e)
        {
            this.parentFrm.LogMsg("Scan More documents");
            this.parentFrm.ContinueScanning(true, docBatch);
            Close();
        }

        private void moveUp()
        {
            if (docBatch.Count <= 0)
            {
                return;
            }
            if (trvwMain.SelectedNode.PrevVisibleNode != null)
            {
                int sourcePageNo = trvwMain.SelectedNode.Index;
                int sourceDocNo = trvwMain.SelectedNode.Parent.Index;
                int targetDocNo;
                int targetPageNo;
                if (trvwMain.SelectedNode.PrevVisibleNode.Parent == null)
                {   //move to another document
                    targetDocNo = trvwMain.SelectedNode.PrevVisibleNode.Index;
                    targetPageNo = 0; //make it the first page
                }
                else
                { //page in same document selected
                    targetDocNo = trvwMain.SelectedNode.PrevVisibleNode.Parent.Index;
                    targetPageNo = trvwMain.SelectedNode.PrevVisibleNode.Index; 
                }

                var element = docBatch[sourceDocNo].ImgLst[sourcePageNo];
                if (sourcePageNo > targetPageNo)
                {
                    docBatch[sourceDocNo].ImgLst.RemoveAt(sourcePageNo);
                    docBatch[targetDocNo].ImgLst.Insert(targetPageNo, element);
                }
                else
                {
                    docBatch[targetDocNo].ImgLst.Insert(targetPageNo + 1, element);
                    docBatch[sourceDocNo].ImgLst.RemoveAt(sourcePageNo);
                }
                if (docBatch[sourceDocNo].ImgLst.Count <= 0)
                {
                    docBatch.RemoveAt(sourceDocNo);
                }
                refreshTree();
            }
            trvwMain.Focus();
        }


        private void moveDown()
        {
            if (docBatch.Count <= 0)
            {
                return;
            }
            if (trvwMain.SelectedNode.NextVisibleNode != null)
            {
                int sourcePageNo = trvwMain.SelectedNode.Index;
                int sourceDocNo = trvwMain.SelectedNode.Parent.Index;
                int targetDocNo;
                int targetPageNo;
                if (trvwMain.SelectedNode.NextVisibleNode.Parent == null)
                {   //move to another document
                    targetDocNo = trvwMain.SelectedNode.NextVisibleNode.Index;
                    targetPageNo = 0; //make it the first page
                }
                else
                { //page in same document selected
                    targetDocNo = trvwMain.SelectedNode.NextVisibleNode.Parent.Index;
                    targetPageNo = trvwMain.SelectedNode.NextVisibleNode.Index; ;
                }

                var element = docBatch[sourceDocNo].ImgLst[sourcePageNo];
                if (sourcePageNo > targetPageNo)
                {
                    docBatch[sourceDocNo].ImgLst.RemoveAt(sourcePageNo);
                    docBatch[targetDocNo].ImgLst.Insert(targetPageNo, element);
                }
                else
                {
                    docBatch[targetDocNo].ImgLst.Insert(targetPageNo + 1, element);
                    docBatch[sourceDocNo].ImgLst.RemoveAt(sourcePageNo);
                }
                if (docBatch[sourceDocNo].ImgLst.Count <= 0)
                {
                    docBatch.RemoveAt(sourceDocNo);
                }
                refreshTree();
            }
            trvwMain.Focus();
        }

        private void splitPage()
        {
            int sourcePageNo = trvwMain.SelectedNode.Index;
            int sourceDocNo = trvwMain.SelectedNode.Parent.Index;
            if (docBatch[sourceDocNo].ImgLst.Count == 1)
            {
                tsLblStatus.Text = "You cannot split a 1 page document";
            }

            var element = docBatch[sourceDocNo].ImgLst[sourcePageNo];
            docBatch[sourceDocNo].ImgLst.RemoveAt(sourcePageNo);
            LCDoc vDoc = new LCDoc();
            vDoc.SeqNo = docBatch.Count + 1;            
            vDoc.PaperSize = ((LCDoc)(docBatch[sourceDocNo])).PaperSize;
            //docBatch[targetDocNo].ImgLst.Insert(targetPageNo, );
            vDoc.ImgLst.Add(element);          
            docBatch.Add(vDoc);
            refreshTree();
            this.parentFrm.LogMsg("page " + sourcePageNo.ToString() + " of doc " + sourceDocNo.ToString() + " split out into document " + vDoc.SeqNo.ToString()); 
        }

        private void tbtnMoveDown_Click(object sender, EventArgs e)
        {
            moveDown();
        }

        private void tbtnUp_Click(object sender, EventArgs e)
        {
            moveUp();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            splitPage();
        }

    }
}
