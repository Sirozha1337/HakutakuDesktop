using System;
using System.IO;

namespace HakutakuDesktop
{
	public static class Logger
	{
		private static string LogPath = "./error.log";

		public static void WriteLog(string text)
		{
			if (!File.Exists(LogPath))
			{
				File.Create(LogPath);
			}

			#if DEBUG
				System.Diagnostics.Debug.WriteLine(text);
			#endif

			using (StreamWriter stream = File.AppendText(LogPath))
			{
				stream.WriteLine(String.Format("{0} {1}", DateTime.Now, text));
			}
		}
	}
}
