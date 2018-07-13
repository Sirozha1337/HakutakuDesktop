using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakutaku.DataModels
{
	public class Language
	{
		public string Name { get; set; }
		public string Code { get; set; }
	}

	public class SourceLanguage : Language
	{
		public DateTime LastModifyDate { get; set; }
	}

	public class SourceLanguageUpdateData : SourceLanguage
	{
		public string DownloadURL { get; set; }
	}

	public class SourceLanguageItemData : SourceLanguageUpdateData
	{
		public bool Downloaded { get; set; }
		public bool NeedUpdate { get; set; }
		public bool ShowInSelect { get; set; }
	}
}
