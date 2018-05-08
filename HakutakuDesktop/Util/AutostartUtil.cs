using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HakutakuDesktop.Util
{
	static class AutostartUtil
	{
		public static void RegisterStartup(bool isChecked)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
					("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

			if (isChecked)
			{
				registryKey.SetValue("hakutaku", Application.ExecutablePath);
			}
			else
			{
				registryKey.DeleteValue("hakutaku");
			}
		}
	}
}
