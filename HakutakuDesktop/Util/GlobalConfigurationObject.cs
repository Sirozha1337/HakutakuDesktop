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
		private static int _maxTextDisplayCount = AppConfiguration.GetConfigInt("MaxTextDisplayCount");
		public static int MaxTextDisplayCount
		{
			get
			{
				return _maxTextDisplayCount;
			}
			set
			{
				AppConfiguration.SetConfigInt("MaxTextDisplayCount", value);
				_maxTextDisplayCount = value;
			}
		}
		
		private static bool _autoStart = AppConfiguration.GetConfigBool("Autostart");
		public static bool AutoStart
		{
			get
			{
				return _autoStart;
			}
			set
			{
				AppConfiguration.SetConfigBool("Autostart", value);
				_autoStart = value;
			}
		}

		private static bool _showScannedText = AppConfiguration.GetConfigBool("ShowScannedText");
		public static bool ShowScannedText
		{
			get
			{
				return _showScannedText;
			}
			set
			{
				AppConfiguration.SetConfigBool("ShowScannedText", value);
				_showScannedText = value;
			}
		}

		private static bool _concatenateWhenUnchanged = AppConfiguration.GetConfigBool("ConcatenateWhenUnchanged");
		public static bool ConcatenateWhenUnchanged
		{
			get
			{
				return _concatenateWhenUnchanged;
			}
			set
			{
				AppConfiguration.SetConfigBool("ConcatenateWhenUnchanged", value);
				_concatenateWhenUnchanged = value;
			}
		}

		private static bool _showHelpOnStartUp = AppConfiguration.GetConfigBool("ShowHelpOnStartUp");
		public static bool ShowHelpOnStartUp
		{
			get
			{
				return _showHelpOnStartUp;
			}
			set
			{
				AppConfiguration.SetConfigBool("ShowHelpOnStartUp", value);
				_showHelpOnStartUp = value;
			}
		}

		private static Hotkey _toggleOverlayHotkey = AppConfiguration.GetConfigHotkey("OverlayHotkey");
		public static Hotkey ToggleOverlayHotkey
		{
			get
			{
				return _toggleOverlayHotkey.Clone();
			}
			set
			{
				AppConfiguration.SetConfigHotkey("OverlayHotkey", value);
				_toggleOverlayHotkey = value;
			}
		}

		private static Hotkey _closeProgramHotkey = AppConfiguration.GetConfigHotkey("CloseProgramHotkey");
		public static Hotkey CloseProgramHotkey
		{
			get
			{
				return _closeProgramHotkey.Clone();
			}
			set
			{
				AppConfiguration.SetConfigHotkey("CloseProgramHotkey", value);
				_closeProgramHotkey = value;
			}
		}
	}
}
