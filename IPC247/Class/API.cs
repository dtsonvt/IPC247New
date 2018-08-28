using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace IPC247
{
    public static class API
    {
        public static string API_POS(string LinkAPI, string json)
        {
            string jsonretun = "";
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(LinkAPI);
                request.KeepAlive = false;
                request.ProtocolVersion = System.Net.HttpVersion.Version10;
                request.Method = "POST";
                //request.Headers.Add("Authorization", Config.ServiceMPOSVNM_Authorization);
                request.Headers.Add("Authorization", "No " );
                //Set timeout cho httpWebRequest
                request.Timeout = 60000;
                // turn our request string into a byte stream
                byte[] postBytes = Encoding.UTF8.GetBytes(json);

                // this is important - make sure you specify type this way
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json;charset=\"utf-8\"";
                request.ContentLength = postBytes.Length;
                
                //request.CookieContainer = Cookies;
                //request.UserAgent = currentUserAgent;
                Stream requestStream = request.GetRequestStream();

                // now send it
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Dispose();
                requestStream.Close();

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    jsonretun = rdr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "API", "API_POS()", ex.ToString()));
			}
            return jsonretun;
        }
        public static string API_SaveQuote(string LinkAPI, string store,string json)
        {
            string jsonretun = "";
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(LinkAPI);
                request.KeepAlive = false;
                request.ProtocolVersion = System.Net.HttpVersion.Version10;
                request.Method = "POST";
                request.ContentType = "x-www-form-urlencoded";
                //request.Headers.Add("Authorization", Config.ServiceMPOSVNM_Authorization);
                //Set timeout cho httpWebRequest
                request.Timeout = 60000;
                // turn our request string into a byte stream
                byte[] postBytes = Encoding.UTF8.GetBytes(json);

                // this is important - make sure you specify type this way
                request.ContentType = "application/json; charset=UTF-8";
                
                request.Accept = "application/json";
                request.ContentLength = postBytes.Length;
                //request.CookieContainer = Cookies;
                //request.UserAgent = currentUserAgent;
                Stream requestStream = request.GetRequestStream();

                // now send it
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Dispose();
                requestStream.Close();

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    jsonretun = rdr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "API", "API_SaveQuote()", ex.ToString()));
			}
            return jsonretun;
        }
        public static string API_GET(string LinkAPI)
        {
            string jsonretun = "";
            try
            {

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(LinkAPI);
                request.KeepAlive = false;
                request.ProtocolVersion = System.Net.HttpVersion.Version10;
                request.Method = "GET";
                request.Timeout = 60000;
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    jsonretun = rdr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "API", "API_GET()", ex.ToString()));
			}
            return jsonretun;
        }
        public static string API_GET_Rep(string LinkAPI)
        {
            string jsonretun = "";
            try
            {

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(LinkAPI);
                request.KeepAlive = false;
                request.ProtocolVersion = System.Net.HttpVersion.Version10;
                request.Method = "GET";
                request.Timeout = 60000;
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    jsonretun = rdr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "API", "API_GET_Rep()", ex.ToString()));
			}
            return jsonretun.Replace("=0=","\r\n");
        }

		public static void API_ERRORLOG(ERRORLOG  log)
		{
			try
			{
				string str = "[" +
				string.Format(@" {{""Key"":""IP"",""value"":""{0}"",""Type"":""string""}},
								{{""Key"":""UserName"",""value"":""{1}"",""Type"":""string""}},
								{{""Key"":""Form"",""value"":""{2}"",""Type"":""string""}},
								{{""Key"":""Event"",""value"":""{3}"",""Type"":""string""}},
								{{""Key"":""ErrorDescription"",""value"":""{4}"",""Type"":""Base64""}}"
			 , log.IP //0
			 , Form_Main.user.Username //1
			 , log.Form //2
			 , log.Event //3
			 , Convert.ToBase64String(Encoding.UTF8.GetBytes(log.ErrorDescription)) //4
			) + "]"; //6
									 //  JObject json = JObject.Parse(str);
				var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_Insert_ERROR_LOG", Param = str });
				string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_SaveQuote";
				json = API.API_POS(sLink, json);
				dynamic jsondata = JObject.Parse(json);
				var jsondataChild = jsondata.GetValue("Data");
			}
			catch
			{
			}
		}

    }
}
