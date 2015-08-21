using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;
using KaupischITC.ScanWIA;
using System.Drawing;

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
        private int numPages;
        private bool twoSided;

        private const int RESOLUTION = 180;
        private const bool MONOCHROME = true;
        private SizeF PAGESIZE = new SizeF(8.27f, 11.7f);
        private const int THRESHOLD = 180;

        internal ScannerControl(int numPages, bool twoSided)
        {
            this.numPages = numPages;
            this.twoSided = twoSided;

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
            device.DeviceSettings.DocumentHandlingSelect = this.twoSided ?
                DocumentHandlingSelect.Duplex : DocumentHandlingSelect.Feeder;
            device.DeviceSettings.Pages = numPages * (twoSided ? 2 : 1);
        }

        private void setupPicture()
        {
            device.PictureSettings.CurrentIntent = MONOCHROME ? CurrentIntent.ImageTypeText : CurrentIntent.ImageTypeGrayscale;
            device.PictureSettings.VerticalResolution = RESOLUTION;
            device.PictureSettings.HorizontalResolution = RESOLUTION;
            device.PictureSettings.HorizontalExtent = (int)(PAGESIZE.Width * RESOLUTION);
            device.PictureSettings.VerticalExtent = (int)(PAGESIZE.Height * RESOLUTION);
            device.PictureSettings.Threshold = THRESHOLD;
        }


    }
}
