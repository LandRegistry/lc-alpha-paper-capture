using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;
using KaupischITC.ScanWIA;
using System.Drawing;
using System.Windows.Forms;

namespace PaperCapture
{
    class ScannerControlException : ApplicationException
    {
        internal ScannerControlException(string message)
            : base(message)
        {
        }
    }

    class ScannerControl
    {
        private ScannerDevice device;
        private bool useFlatbed;
        private int numPages;
        private bool twoSided;

        private const int RESOLUTION = 180;
        private bool MONOCHROME = true;
        private SizeF PAGESIZE = new SizeF(8.27f, 11.7f);
        private const int THRESHOLD = 180;

        internal ScannerControl(int pNumPages, bool pTwoSided, bool pUseFlatbed, string pPaperSize, bool pMonochrome)
        {
            this.PAGESIZE = new SizeF(8.27f, 11.7f); //default to A4
            if (pPaperSize == "A3") {this.PAGESIZE = new SizeF(11.67f, 16.47f);}
            else if (pPaperSize == "A5") { this.PAGESIZE = new SizeF(5.83f, 8.27f); }
            this.numPages = pNumPages;
            this.twoSided = pTwoSided;
            this.useFlatbed = pUseFlatbed; //if not useflatbed then use doc feeder
            this.MONOCHROME = pMonochrome;
            setupScanner();
            setupPicture();
        }

        internal List<Image> Scan()
        {
            return device.PerformScan().ToList();
        }
           

        private void setupScanner()
        {
            device = WiaDevice.GetFirstScannerDevice().AsScannerDevice();
            // Not checking the device's capabilities: for now, we're working on the assumption that we
            // control the exact model of scanner.
            if (this.useFlatbed)
            {
                device.DeviceSettings.DocumentHandlingSelect = this.twoSided ?
                                    DocumentHandlingSelect.Duplex : DocumentHandlingSelect.Flatbed;
            }
            else
            {
                device.DeviceSettings.DocumentHandlingSelect = this.twoSided ?
                    DocumentHandlingSelect.Duplex : DocumentHandlingSelect.Feeder;
            }
            device.DeviceSettings.Pages = numPages;// *(twoSided ? 2 : 1);
        }

        private void setupPicture()
        {
            //device.PictureSettings.CurrentIntent = MONOCHROME ? CurrentIntent.ImageTypeText : CurrentIntent.ImageTypeGrayscale;
            device.PictureSettings.CurrentIntent = MONOCHROME ? CurrentIntent.ImageTypeText : CurrentIntent.ImageTypeColor;
            device.PictureSettings.VerticalResolution = RESOLUTION;
            device.PictureSettings.HorizontalResolution = RESOLUTION;
            device.PictureSettings.HorizontalExtent = (int)(PAGESIZE.Width * RESOLUTION);
            device.PictureSettings.VerticalExtent = (int)(PAGESIZE.Height * RESOLUTION);
            device.PictureSettings.Threshold = THRESHOLD;
        }

        public string GetScannerName()
        {         
            ScannerDevice scnr = WiaDevice.GetFirstScannerDevice().AsScannerDevice();
            string scnrNam = scnr.DeviceSettings.DeviceName;
            return scnrNam;
        }


    }
}
