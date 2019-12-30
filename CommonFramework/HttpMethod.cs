using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonFramework
{
   public class HttpMethod
    {
        public CookieContainer cc = new CookieContainer();
        public string Get(string url, Dictionary<string,string> header,string encode ="GB2312")
        {
            var result = string.Empty;
            if (IsHttps(url))
            {
                 ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => { return true; });
                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
           
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
          
                request.CookieContainer = cc;
               
            if (header != null)
            {
                foreach (var key in header.Keys)
                {
                    if (key.ToUpper() == "USER-AGENT")
                    {
                        request.UserAgent = header[key];
                    }
                    else
                    {
                        request.Headers[key] = header[key];
                    }
                }
            }
            WebResponse response = null;
                Stream responseStream = null; ;
                StreamReader reader = null;
                try
                {
                    response = request.GetResponse();
                    
                    responseStream =response.GetResponseStream();
                    reader = new System.IO.StreamReader(responseStream, Encoding.GetEncoding(encode));
                    result = reader.ReadToEnd();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                        reader.Dispose();
                    }
                    if (responseStream != null)
                    {
                        responseStream.Close();
                        responseStream.Dispose();
                    }
                }
            return result;

        }

        public string Post(string url, string data,Dictionary<string,string> header,string encode="UTF-8")
        {
            var result = string.Empty;
            if (IsHttps(url))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => { return true; });
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            byte[] postData = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.CookieContainer = cc;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.ContentLength = postData.Length;
            if (header != null)
            {
                foreach (var key in header.Keys)
                {
                    if (key == "User-Agent")
                    {
                        request.UserAgent = header[key];
                    }
                    else
                    {
                        request.Headers[key] = header[key];
                    }
                }
            }
            using (System.IO.Stream outputStream = request.GetRequestStream())
            {
                outputStream.Write(postData, 0, postData.Length);
            }

            Stream responseStream = null; ;
            StreamReader reader = null;
            try
            {
                responseStream = request.GetResponse().GetResponseStream();
                reader = new System.IO.StreamReader(responseStream, Encoding.GetEncoding(encode));
                result = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();
                }
            }

            return result;
        }

        private  bool IsHttps(string url)
        {
            if (url.ToUpper().StartsWith("HTTPS")) return true;
            else return false;
        }

        public  List<Cookie> GetAllCookies()
        {
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });
            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }
            return lstCookies;
        }

    }
}
