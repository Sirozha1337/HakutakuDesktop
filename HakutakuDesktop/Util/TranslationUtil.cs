using System;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;

namespace HakutakuDesktop.Util
{
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

					string encodedText = HttpUtility.UrlEncode(text);

					string url = String.Format(
						"https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
						srcLang,
						dstLang,
						text);

					string response;
					using (WebClient wc = new WebClient())
					{
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

				/* FIX Encoding */
				byte[] bytes = Encoding.Default.GetBytes(translatedText);
				translatedText = Encoding.UTF8.GetString(bytes);
			}
			else
			{
				translatedText = text;
			}
			Logger.WriteLog("Finish translation");

			return translatedText;
		}
	}
}
