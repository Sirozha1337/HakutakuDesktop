using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakutaku.DataModels
{
	public class SourceLanguage
	{
		public string Name { get; set; }
		public string DownloadURL { get; set; }
		public string Code { get; set; }
		public DateTime LastModifyDate { get; set; }
	}

	public class SourceLanguageUpdateData : SourceLanguage
	{
		public bool Downloaded { get; set; }
		public bool NeedUpdate { get; set; }
		public bool ShowInSelect { get; set; }
	}
}
