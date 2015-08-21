using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;

namespace PaperCapture
{
    class Requests
    {
        private static dynamic PostJSON(string url, string data)
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

        internal static int CreateDocument()
        {
            dynamic document = PostJSON("http://localhost:5014/document", "{}");
            return document.id;
        }

        internal static void AddImageToDocument(int documentID, Image image)
        {
            dynamic document = PostImage("http://localhost:5014/document/" + documentID.ToString() + "/image", image);
        }

        internal static string GetFormType(int documentID)
        {
            dynamic formtype = Get("http://localhost:5014/document/" + documentID.ToString() + "/image/1/formtype");
            return formtype.type;
        }

        internal static void CreateWorklistItem(int documentID, string formType, string workType)
        {
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            data["application_type"] = formType;
            data["date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data["document_id"] = documentID;
            data["work_type"] = workType;
            string json = JsonConvert.SerializeObject(data);
            PostJSON("http://localhost:5006/manual", json);
        }
    }
}