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
		private static SourceLanguageItemData[] sourceLanguagesUpdateData = null;

		public static Task<SourceLanguageItemData[]> CheckUpdate()
		{
			return Task.Run(() =>
			{
				if (sourceLanguagesUpdateData != null)
				{
					return sourceLanguagesUpdateData;
				}

				SourceLanguageUpdateData[] sourceLanguages = WebUtil.GetSourceLanguages();
				SourceLanguage[] downloaded = AppConfiguration.GetInstalledLanguages();
				Dictionary<string, SourceLanguage> downloadedDict = downloaded.ToDictionary(lang => lang.Code);

				var showStatus = GlobalConfigurationObject.ShowSourceLanguageInSelect;

				return sourceLanguages
						.Select(lang =>
							new SourceLanguageItemData
							{
								Name = lang.Name,
								Code = lang.Code,
								Downloaded = downloadedDict.ContainsKey(lang.Code),
								DownloadURL = lang.DownloadURL,
								LastModifyDate = lang.LastModifyDate,
								NeedUpdate = downloadedDict.ContainsKey(lang.Code) ? (lang.LastModifyDate > downloadedDict[lang.Code].LastModifyDate) : false,
								ShowInSelect = showStatus != null && showStatus.ContainsKey(lang.Code)
							})
						.ToArray();
			});
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

				var srcLangList = GlobalConfigurationObject.SourceLanguages.ToList();
				srcLangList.Add(data);
				GlobalConfigurationObject.SourceLanguages = srcLangList.ToArray();
			});
		}

		public static Task Remove(SourceLanguage data)
		{
			return Task.Run(() =>
			{
				File.Delete(GetFullPathForLanguage(data.Code));
				var dict = GlobalConfigurationObject.ShowSourceLanguageInSelect;
				if(dict != null && dict.ContainsKey(data.Code))
					dict.Remove(data.Code);
				GlobalConfigurationObject.ShowSourceLanguageInSelect = dict;

				var srcLangList = GlobalConfigurationObject.SourceLanguages.ToList();
				var index = srcLangList.FindIndex(lang => lang.Code == data.Code);
				srcLangList.RemoveAt(index);
				GlobalConfigurationObject.SourceLanguages = srcLangList.ToArray();
			});
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
