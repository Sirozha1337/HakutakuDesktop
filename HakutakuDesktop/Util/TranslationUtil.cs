using System;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;

namespace HakutakuDesktop.Util
{
	public class Language
	{
		public string Code { get; set; }
		public string Name { get; set; }
	}

	public static class TranslationUtil
	{
		public static string Translate(string text, string srcLang, string dstLang)
		{
			Logger.WriteLog("Start translation");
			string translatedText = "";
			if (srcLang != dstLang)
			{
				try
				{
					text = text.Replace('\n', ' ').Replace('\r', ' ');
					
					string encodedText = HttpUtility.UrlEncode(text, Encoding.UTF8);
					
					srcLang = srcLang.Substring(0, 2);
					dstLang = dstLang.Substring(0, 2);

					string url = String.Format(
						"https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
						srcLang,
						dstLang,
						encodedText);

					string response;
					using (WebClient wc = new WebClient())
					{
						wc.Encoding = Encoding.UTF8;
						wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.110 Safari/537.36");
						response = wc.DownloadString(url);
					}

					JArray response_json = JArray.Parse(response);
					JArray array = JArray.FromObject(response_json[0]);
					foreach (var obj in array)
					{
						translatedText = translatedText + " " + obj[0].ToString();
					}
				}
				catch (Exception ex)
				{
					translatedText = text;
					Logger.WriteLog("Error translating text. Exception: " + ex.Message);
				}
			}
			else
			{
				translatedText = text.Trim(' ', '\r', '\n');
			}
			Logger.WriteLog("Finish translation");

			return translatedText;
		}
	}
}
