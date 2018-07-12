using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakutakuDesktop.Util
{
	public static class ISOCodesUtil
	{
		private class ISOCodesDatabase
		{
			private static readonly Dictionary<string, string> Iso3ToIso2 = new Dictionary<string, string>();
			private static readonly Dictionary<string, string> Iso3ToIso2Alt = new Dictionary<string, string>();

			public ISOCodesDatabase(string dbPath)
			{
				using (TextFieldParser parser = new TextFieldParser(dbPath))
				{
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					while (!parser.EndOfData)
					{
						string[] fields = parser.ReadFields();
						Iso3ToIso2.Add(fields[1], fields[0]);
						Iso3ToIso2Alt.Add(fields[2], fields[0]);
					}
				}
			}

			public string GetISO2Code(string iso3Code)
			{
				if (Iso3ToIso2.ContainsKey(iso3Code))
					return Iso3ToIso2[iso3Code];

				if (Iso3ToIso2Alt.ContainsKey(iso3Code))
					return Iso3ToIso2Alt[iso3Code];

				return null;
			}
		}

		private static ISOCodesDatabase _isoCodesDb = null;
		private static readonly string _dbPath = "./langdata/country_codes.csv";

		public static string GetISO2Code(string iso3Code)
		{
			if (_isoCodesDb == null)
				_isoCodesDb = new ISOCodesDatabase(_dbPath);

			return _isoCodesDb.GetISO2Code(iso3Code);
		}
	}
}
