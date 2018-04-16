using System;
using System.Threading;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		private static string appGuid = "hakutaku-desktop-app";

		[STAThread]
		static void Main()
		{
			using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
			{
				if (!mutex.WaitOne(0, false))
				{
					MessageBox.Show("Instance already running. Press F7 to display overlay. Press F6 to exit app.");
					return;
				}
				GC.Collect();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				try
				{
					Logger.WriteLog("Launching app");
					var applicationContext = new CustomApplicationContext();
					Application.Run(applicationContext);
				}
				catch (Exception ex)
				{
					Logger.WriteLog("App crash: " + ex.Message);
					MessageBox.Show(ex.Message, "Program Terminated Unexpectedly",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				InterceptKeys.RemoveCallback();
			}
		}
	}
}
