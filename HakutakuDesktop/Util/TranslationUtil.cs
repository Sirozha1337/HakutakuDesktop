using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tesseract;

namespace HakutakuDesktop.Util
{
	public static class TranslationUtil
	{
		public static string Translate(string text, string srcLang, string dstLang)
		{
			Logger.WriteLog("Start translation");
			string encodedText = HttpUtility.UrlEncode(text);

			string url = String.Format(
				"https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
				srcLang, 
				dstLang,
				srcLang);

			string translatedText;
			using (WebClient wc = new WebClient())
			{
				translatedText = wc.DownloadString(url);
			}

			Logger.WriteLog("Finish translation");

			return translatedText;
		}
	}
}
