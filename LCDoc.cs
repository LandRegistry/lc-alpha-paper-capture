using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PaperCapture
{
    public class LCDoc
    {
        private int seqNo;
        private string paperSize;
        private List<Image> imgLst;  

        public int SeqNo
        {
            get
            {
                return seqNo;
            }
            set
            {
                seqNo = value;
            }
        }

        public string PaperSize
        {
            get
            {
                return paperSize;
            }
            set
            {
                paperSize = value;
            }
        }


        public List<Image> ImgLst
        {
            get
            {
                if (imgLst == null)
                {
                    imgLst = new List<Image>();
                }
                return imgLst;
            }
            set
            {
                imgLst = value;
            }
        }
    }
}
