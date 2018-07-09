using hakutaku.DataModels;
using HakutakuDesktop.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakutaku.Util
{
	public static class UpdateUtility
	{
		private static SourceLanguageUpdateData[] sourceLanguagesUpdateData = null;

		public static Task<SourceLanguageUpdateData[]> CheckUpdate()
		{
			return Task.Run(() =>
			{
				if (sourceLanguagesUpdateData != null)
				{
					return sourceLanguagesUpdateData;
				}

				SourceLanguage[] sourceLanguages = WebUtil.GetSourceLanguages();
				var downloaded = GetCurrentDownloadedLanguages();
				var showStatus = GlobalConfigurationObject.ShowSourceLanguageInSelect;

				return sourceLanguages
						.Select(lang =>
							new SourceLanguageUpdateData
							{
								Name = lang.Name,
								Code = lang.Code,
								Downloaded = downloaded.ContainsKey(lang.Code),
								DownloadURL = lang.DownloadURL,
								LastModifyDate = lang.LastModifyDate,
								NeedUpdate = downloaded.ContainsKey(lang.Code) ? (lang.LastModifyDate > downloaded[lang.Code]) : false
							})
						.ToArray();
			});
		}

		private static Dictionary<string, DateTime> GetCurrentDownloadedLanguages()
		{
			Dictionary<string, DateTime> keyValuePairs = new Dictionary<string, DateTime>();

			string[] files = Directory.GetFiles("tessdata");
			foreach(var file in files)
			{
				keyValuePairs.Add(Path.GetFileNameWithoutExtension(file), File.GetLastWriteTime(file));
			}

			return keyValuePairs;
		}
		
		private static string GetFullPathForLanguage(string code)
		{
			return String.Format("./tessdata/{0}.traineddata", code);
		}

		public static Task Download(SourceLanguageUpdateData data)
		{
			return Task.Run(() =>
			{
				WebUtil.Download(data.DownloadURL, GetFullPathForLanguage(data.Code));
			});
		}

		public static Task Remove(SourceLanguageUpdateData data)
		{
			return Task.Run(() =>
			{
				File.Delete(GetFullPathForLanguage(data.Code));
				var dict = GlobalConfigurationObject.ShowSourceLanguageInSelect;
				if(dict.ContainsKey(data.Code))
					dict.Remove(data.Code);
				GlobalConfigurationObject.ShowSourceLanguageInSelect = dict;
			});
			throw new NotImplementedException();
		}

		public static Task Update(SourceLanguageUpdateData data)
		{
			return Task.Run(() =>
			{
				WebUtil.Download(data.DownloadURL, GetFullPathForLanguage(data.Code));
			});
		}
	}
}
