﻿using System;
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
			string translatedText;
			try
			{
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
				translatedText = response_json[0][0][0].ToString();
			}
			catch (Exception ex)
			{
				translatedText = text;
				Logger.WriteLog("Error translating text. Exception: " + ex.Message);
			}

			/* FIX Encoding */
			byte[] bytes = Encoding.Default.GetBytes(translatedText);
			translatedText = Encoding.UTF8.GetString(bytes);

			Logger.WriteLog("Finish translation");

			return translatedText;
		}
	}
}
