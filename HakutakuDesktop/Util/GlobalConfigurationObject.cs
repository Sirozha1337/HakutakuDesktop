using MovablePython;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakutakuDesktop.Util
{
	public static class GlobalConfigurationObject
	{
		public static int MaxTextDisplayCount;
		public static bool AutoStart;
		public static bool ShowScannedText;
		public static bool ConcatenateWhenUnchanged;
		public static bool ShowHelpOnStartUp;
		public static Hotkey toggleOverlayHotkey;
		public static Hotkey closeProgramHotkey;

		public static void Reload()
		{
			ShowScannedText = AppConfiguration.GetConfigBool("ShowScannedText");
			ConcatenateWhenUnchanged = AppConfiguration.GetConfigBool("ConcatenateWhenUnchanged");
			AutoStart = AppConfiguration.GetConfigBool("Autostart");
			ShowHelpOnStartUp = AppConfiguration.GetConfigBool("ShowHelpOnStartUp");
			toggleOverlayHotkey = AppConfiguration.GetConfigHotkey("OverlayHotkey");
			closeProgramHotkey = AppConfiguration.GetConfigHotkey("CloseProgramHotkey");
			MaxTextDisplayCount = AppConfiguration.GetConfigInt("MaxTextDisplayCount");
		}
	}
}
