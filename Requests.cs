using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Configuration;

namespace PaperCapture
{
    class Requests
    {

        private static string caseworkAPI = ConfigurationManager.AppSettings["CaseworkApiUrl"];
        private static string caseworkEnvironment = ConfigurationManager.AppSettings["caseworkEnvironment"];

        private static dynamic PostJSON(string url, string data)
        {
            try
            {
                ctr = 0;
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
                request.ContentType = "application/json";
                request.ContentLength = bytes.Length;
                Stream s = request.GetRequestStream();
                s.Write(bytes, 0, bytes.Length);
                s.Close();

                WebResponse response = request.GetResponse();
                byte[] rdata;
                using (var ms = new MemoryStream())
                {
                    response.GetResponseStream().CopyTo(ms);
                    rdata = ms.ToArray();
                }

                string resp = System.Text.Encoding.UTF8.GetString(rdata);
                return JsonConvert.DeserializeObject(resp);
            }
            catch (Exception exp)
            {                
                throw new System.ArgumentException("Error posting data to " + url + ". "+ exp.Message);             
            }
        }

        private static int ctr;

        private static dynamic Get(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";            

            WebResponse response = request.GetResponse();
            byte[] rdata;
            using (var ms = new MemoryStream())
            {
                response.GetResponseStream().CopyTo(ms);
                rdata = ms.ToArray();
            }

            string resp = System.Text.Encoding.UTF8.GetString(rdata);
            return JsonConvert.DeserializeObject(resp);
        }

        private static dynamic PostImage(string url, Image image, bool pMonochrome)
        {
            MemoryStream ms = new MemoryStream();
            string imgNam = @"C:\temp\newscantif";
            string fileExt;
            string imgFormat;
            EncoderParameters pars = new EncoderParameters(1);
            EncoderParameter par;
            System.Drawing.Imaging.Encoder coder = System.Drawing.Imaging.Encoder.Compression;
            //set compression parameters
            if (pMonochrome)
            {
                fileExt = ".tif";
                imgFormat = "image/tiff";
                par = new EncoderParameter(coder, (long)EncoderValue.CompressionCCITT4);                
            }
            else
            {
                fileExt = ".jpg";
                imgFormat = "image/jpeg";
                par = new EncoderParameter(coder, (long)EncoderValue.ColorTypeCMYK);
                
            }
            ImageCodecInfo codec = getEncoderInfo(imgFormat);
            pars.Param[0] = par;
            //image.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
            ctr++;
            image.Save(imgNam + ctr.ToString() + fileExt , codec, pars);
            image.Save(ms, codec, pars);
            Image img = Image.FromStream(ms);
            byte[] bytes = ms.ToArray();
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = imgFormat;
            request.ContentLength = bytes.Length;
            Stream s = request.GetRequestStream();
            s.Write(bytes, 0, bytes.Length);
            s.Close();
            WebResponse response = request.GetResponse();
            byte[] rdata;
            using (var stream = new MemoryStream())
            {
                response.GetResponseStream().CopyTo(stream);
                rdata = stream.ToArray();
            }
            string resp = System.Text.Encoding.UTF8.GetString(rdata);
            return JsonConvert.DeserializeObject(resp);
        }

        /// <summary>
        /// Add an image to a document, the first page calls a route on casework-api that returns the form type unless
        /// the caseworker has chose to override it. 
        /// 
        /// Subsequent pages pass in the document id. 
        /// 
        /// pDeliveryInd is "Postal" - post
        ///                 "Fax" - fax
        ///                 "Portal" - portal fallout
        /// </summary>
        /// <param name="pDocID"></param>
        /// <param name="pImage"></param>
        /// <param name="pPaperSize"></param>
        /// <param name="pFormType"></param>
        /// <returns></returns>
        internal static dynamic AddImageToDocument(int pDocID, Image pImage, string pPaperSize, string pFormType)
        {
            try
            {
                bool vMonochrome = true;
                if (!ImageFormat.Tiff.Equals(pImage.RawFormat))
                {
                    vMonochrome = false;
                }               
                dynamic document;
                string url = caseworkAPI + @"/forms/";
                if (pDocID > 0)
                { url = url + pDocID.ToString() + "/"; } //subsequent pages use a different route
                url = url + pPaperSize;
                if (pFormType != "") { url = url + "?type=" + pFormType; } //passing in form type bypasses the OCR process            
                document = PostImage(url, pImage, vMonochrome);
                return document;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        internal static string GetFormType(int documentID)
        {
            string url = caseworkAPI + @"/forms/" + documentID.ToString();
            dynamic formtype = Get(url);
            return formtype.type;
        }

        internal static string GetAPIStatus()
        {
            string url = caseworkAPI + @"/health";
            dynamic APIStatus = "";
            try
            {
                dynamic response = Get(url);
                dynamic data = JsonConvert.DeserializeObject(response.ToString());
                APIStatus = "LC Casework API status: " + data.dependencies["land-charges"];
            }
            catch (Exception exp)
            {
                APIStatus = exp.Message.ToString();
            }
            string configavail = "*" + caseworkEnvironment + "*";
            if (configavail == "**")
            {
                if (!(File.Exists("PaperCapture.exe.config")))
                {
                    MessageBox.Show("PaperCapture.exe.config not found. This file should sit in the same directory as PaperCapture.exe");
                    return "Could not find PaperCapture.exe.config, Environment could not be configured";
                }
            }
            return "Environment: " + caseworkEnvironment + ": " + APIStatus.ToString();
        }


        internal static void CreateWorklistItem(int pDocumentID, string pFormType, string pWorkType, string pDelivery)
        {
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            data["application_type"] = pFormType;
            data["date_received"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data["document_id"] = pDocumentID;
            data["work_type"] = pWorkType;
            data["delivery_method"] = pDelivery;
            data["application_data"] = "";
            string json = JsonConvert.SerializeObject(data);
            dynamic id = PostJSON(caseworkAPI + @"/applications", json);
        }

        public static ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

    }
}