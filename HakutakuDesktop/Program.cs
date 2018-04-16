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
		public static OverlayForm _mainForm;
		public static SelectionForm _selectionForm;

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
				_mainForm = new OverlayForm();
				_selectionForm = new SelectionForm();
				_selectionForm.Owner = _mainForm;
				InterceptKeys.SetCallback(HotKey);
				Logger.WriteLog("Launching app");
				Application.Run(_mainForm);
				InterceptKeys.RemoveCallback();
			}
		}

		private static void HotKey(Keys key)
		{
			if (key == Keys.F7)
			{
				if (_mainForm.Visible)
				{
					Logger.WriteLog("Hiding form");
					_mainForm.Hide();
					_selectionForm.Hide();
				}
				else
				{
					Logger.WriteLog("Showing form");
					_mainForm.Show();
					_selectionForm.Show();
				}
			}
			if (key == Keys.F6)
			{
				Logger.WriteLog("Exiting app");
				Application.Exit();
			}
		}
	}
}
