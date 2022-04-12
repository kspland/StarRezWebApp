using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
  

namespace RL.Models
{
    public class Sub
    {


        public static HttpStatusCode PerformRequest(string url, string method, string postData, out string result,  string AUTHINFO, out HttpStatusCode status)
        {
            
            Console.WriteLine("This is from the Request function");
            string authinfo;

            authinfo = Convert.ToBase64String(Encoding.Default.GetBytes(AUTHINFO));
            try
            {
                WebRequest req = HttpWebRequest.Create(url);
               

                req.Headers["Authorization"] = "Basic " + authinfo;
                req.Method = method;
                if (req.Method == "POST" || req.Method == "PUT")
                {
                    if (req.Method == "POST")
                    {
                        req.ContentType = "appliation/x-www-formurlencoded";
                    }
                    using (var writer = new StreamWriter(req.GetRequestStream()))
                    {
                        writer.Write(postData);
                    }
                }
                HttpWebResponse response = req.GetResponse() as HttpWebResponse;
                status = response.StatusCode;

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }


            }
            catch (WebException ex)
            {
                HttpWebResponse response = ex.Response as HttpWebResponse;
                if (response != null)
                {
                    status = response.StatusCode;
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        result = reader.ReadToEnd();
                    }
                }
                else
                {
                    status = HttpStatusCode.BadRequest;
                    result = "ERROR: " + ex.ToString();
                }

            }
            catch (Exception ex)
            {
                status = HttpStatusCode.BadRequest;
                result = "ERROR: " + ex.ToString();
            }
            return status;
        }


       
    }
}