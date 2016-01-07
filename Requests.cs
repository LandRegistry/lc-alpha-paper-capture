using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using System.Windows.Forms;

namespace PaperCapture
{
    class Requests
    {
        private static string documentAPI = @"http://localhost:5014";
        private static string caseworkAPI = @"http://localhost:5006";
        private static dynamic PostJSON(string url, string data)
        {
            try
            {
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

        private static dynamic PostImage(string url, Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.ToArray();

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "image/jpeg";
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

        internal static dynamic AddImageToDocument(int pDocID, Image pImage, string pPaperSize)
        {
            try
            {
                dynamic document;
                if (pDocID == 0) //first images calls different route
                {
                    document = PostImage(caseworkAPI + @"/forms/" + pPaperSize, pImage);
                }
                else
                {
                    document = PostImage(caseworkAPI + @"/forms/" + pDocID.ToString() + "/" + pPaperSize, pImage);
                }
                MessageBox.Show("Document " + document.id + " created");
                return document; 
            }
            catch (Exception exp)
            {
                throw exp;
            }
           }

        internal static string GetFormType(int documentID)
        {
//            string url = caseworkAPI + @"/forms/" + documentID.ToString() + "/images/1/formtype";
            string url = caseworkAPI + @"/forms/" + documentID.ToString();
            dynamic formtype = Get(url);
            return formtype.type;
        }

        internal static void CreateWorklistItem(int documentID, string formType, string workType)
        {
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            data["application_type"] = formType;
            data["date_received"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data["document_id"] = documentID;
            data["work_type"] = workType;
            data["application_data"] = "";
            string json = JsonConvert.SerializeObject(data);
            dynamic id = PostJSON(caseworkAPI + @"/applications", json);
        }
    }
}