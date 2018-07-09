using hakutaku.DataModels;
using HakutakuDesktop.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace hakutaku.Util
{
	public static class WebUtil
	{
		public static SourceLanguage[] GetSourceLanguages()
		{
			SourceLanguage[] aRet = null;
			var url = AppConfiguration.GetUpdateServerUrl();
			if (!string.IsNullOrEmpty(url))
			{
				using (var webClient = new WebClient())
				{
					var json = webClient.DownloadString(url);
					aRet = JsonConvert.DeserializeObject<SourceLanguage[]>(json);
				}
			}
			return aRet;
		}

		public static void Download(string downloadURL, string fullFileName)
		{
			using (var webClient = new WebClient())
				webClient.DownloadFile(downloadURL, fullFileName);
		}
	}
}
