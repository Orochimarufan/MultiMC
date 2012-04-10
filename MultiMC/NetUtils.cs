using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using Newtonsoft.Json;

namespace MultiMC
{
	class NetUtils
	{
		public static WebResponse HttpPostGetResponse(string uri, Dictionary<string,string> data, Encoding enc)
		{
			WebRequest request = WebRequest.Create(uri);
			request.Method = WebRequestMethods.Http.Post;
			request.ContentType = "application/x-www-form-urlencoded";
			List<string> dataParts = new List<string>();
			foreach (KeyValuePair<string,string> pair in data)
			{
				dataParts.Add(string.Concat(Uri.EscapeDataString(pair.Key),"=",
											Uri.EscapeDataString(pair.Value)));
			}
			byte[] bytes = enc.GetBytes(string.Join("&",dataParts));
			Stream reqStream = null;
			try
			{
				request.ContentLength = bytes.Length;
				request.Headers[HttpRequestHeader.ContentEncoding] = enc.EncodingName;
				reqStream = request.GetRequestStream();
				reqStream.Write(bytes,0,bytes.Length);
			}
			catch (WebException e)
			{
				Console.Write(new StringBuilder("HttpPost: Request Error: ").Append(e.Message));
				//TODO: Need to implement a Message Dialog here
			}
			finally
			{
				if (reqStream!=null)
				{
					reqStream.Close();
				}
			}
			try
			{
				return request.GetResponse();
			}
			catch (WebException e)
			{
				Console.Write(new StringBuilder("HttpPost: Response Error: ").Append(e.Message));
				//TODO: Another MessageDialog
			}
			return null;
		}
		public static string HttpResponseReadString(WebResponse response, Encoding defaultEncoding)
		{
			StreamReader responseReader = new StreamReader(response.GetResponseStream());
				int length = Convert.ToInt32(response.Headers[HttpResponseHeader.ContentLength]);
				byte[] buf = new byte[length];
				responseReader.BaseStream.Read(buf,0,length);
				responseReader.Close();
				Encoding remoteEnc = Encoding.GetEncoding(response.Headers[HttpResponseHeader.ContentEncoding],defaultEncoding.EncoderFallback,defaultEncoding.DecoderFallback);
				return remoteEnc.GetString(buf);
		}
		public static string HttpPost(string uri, Dictionary<string,string> data, Encoding enc)
		{
			WebResponse response = HttpPostGetResponse(uri, data, enc);
			if (response == null)
				return null;
			string a = HttpResponseReadString(response,enc);
			response.Close();
			return a;
		}
		public static string HttpPost(string uri, Dictionary<string,string> data)
		{
			return HttpPost(uri, data, Encoding.UTF8);
		}
		public static T HttpPostGetJson<T>(string uri, Dictionary<string,string> data, Encoding enc)
		{
			string response = HttpPost(uri, data, enc);
			if (response==null) return default(T);
			return JsonConvert.DeserializeObject<T>(response);
		}
	}
}
