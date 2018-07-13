using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json.Linq;

namespace HakutakuDesktop.Util
{
	public static class TranslationUtil
	{
		private static Dictionary<string, Func<string, string>> languageSpecificActions;
		
		private static Func<string, string> GetLanguageSpecificAction(string lang)
		{
			if(languageSpecificActions == null)
			{
				languageSpecificActions = new Dictionary<string, Func<string, string>>();
				languageSpecificActions.Add("jap", (string text) =>
				{
					return text.Replace('ぁ', 'あ')
								.Replace('ぃ', 'い')
								.Replace('ぅ', 'う')
								.Replace('ぇ', 'え')
								.Replace('ぉ', 'お')
								.Replace("カゝ", "か")
								.Replace('ヵ', 'カ')
								.Replace('ゎ', 'わ')
								.Replace('〈', 'く')
								.Replace("<", "く")
								.Replace("＜", "く")
								.Replace("︿", "く")
								.Replace("\\|二", "に")
								.Replace("_", "一")
								.Replace("I", "ー")
								.Replace("1", "ー")
								.Replace(" ", "")
								.Replace("\\.", "")
								.Replace("}」", "こ")
								.Replace("/.", "!")
								.Replace(",=", "コ")
								.Replace("、 ", "い")
								.Replace("%", "")
								.Replace("=", "コ")
								.Replace(",", "");
				});
				languageSpecificActions.Add("eng", (string text) =>
				{
					return text.ToLower();
				});
			}
			if (languageSpecificActions.ContainsKey(lang))
				return languageSpecificActions[lang];
			else
				return null;
		}

		public static string TrimText(string text)
		{
			Regex regex = new Regex("[ ]{2,}");
			text = text.Replace('\n', ' ').Replace('\r', ' ').Trim();
			text = regex.Replace(text, " ");

			return text;
		}

		public static string Translate(string text, string srcLang, string dstLang)
		{
			Logger.WriteLog("Start translation");
			string translatedText = "";
			if (srcLang != dstLang)
			{
				try
				{

					Console.WriteLine("Text before action" + text);
					Func<string, string> action = GetLanguageSpecificAction(srcLang);
					if(action != null)
						text = action(text);
					Console.WriteLine("Text after action" + text);
					string encodedText = HttpUtility.UrlEncode(text, Encoding.UTF8);
					
					srcLang = ISOCodesUtil.GetISO2Code(srcLang);
					dstLang = ISOCodesUtil.GetISO2Code(dstLang);

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
