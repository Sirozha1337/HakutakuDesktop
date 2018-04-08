using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public static Form _mainForm;
		public static SelectionForm _selectionForm;

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			_mainForm = new OverlayForm();
			_selectionForm = new SelectionForm();
			InterceptKeys.SetCallback(HotKey);
			Logger.WriteLog("Launching app");
			Application.Run(_mainForm);
			InterceptKeys.RemoveCallback();
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
