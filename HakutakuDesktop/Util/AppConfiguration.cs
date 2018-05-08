using MovablePython;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HakutakuDesktop.Util
{
	public static class AppConfiguration
	{
		public static void SetConfigBool(string key, bool value)
		{
			Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

			if (confCollection[key] != null)
				confCollection[key].Value = value.ToString();
			else
				confCollection.Add(key, value.ToString());

			configManager.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);
		}

		public static string GetConfig(string key)
		{
			Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

			return confCollection[key]?.Value;
		}

		public static bool GetConfigBool(string key)
		{
			Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

			if (confCollection[key] != null)
				if (bool.TryParse(confCollection[key].Value, out bool val))
					return val;

			return false;
		}

		public static Hotkey GetConfigHotkey(string key)
		{
			Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

			try
			{
				if (confCollection[key] != null)
				{
					string hotkeyString = confCollection[key].Value;
					string[] hotkeyOptions = hotkeyString.Split(',');
					if (hotkeyOptions.Length == 5)
					{
						Keys keyCode = (Keys)Enum.Parse(typeof(Keys), hotkeyOptions[0]);
						bool shift = bool.Parse(hotkeyOptions[1]);
						bool control = bool.Parse(hotkeyOptions[2]);
						bool alt = bool.Parse(hotkeyOptions[3]);
						bool windows = bool.Parse(hotkeyOptions[4]);

						return new Hotkey(keyCode, shift, control, alt, windows);
					}
				}
			}
			catch(Exception ex)
			{
				Logger.WriteLog("Error getting hotkey from config: " + ex.Message);
			}

			return GetDefaultHotkey(key);
		}

		private static Hotkey GetDefaultHotkey(string key)
		{
			Hotkey hk = new Hotkey();
			switch (key)
			{
				case "OverlayHotkey": hk.KeyCode = Keys.F7; break;
				case "CloseProgramHotkey": hk.KeyCode = Keys.F6; break;
			}
			return hk;
		}

		public static void SetConfigHotkey(string key, Hotkey hotkey)
		{
			Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

			string hotkeyString = hotkey.KeyCode + "," 
									+ hotkey.Shift + "," 
									+ hotkey.Control + ","
									+ hotkey.Alt + ","
									+ hotkey.Windows;

			if (confCollection[key] != null)
				confCollection[key].Value = hotkeyString;
			else
				confCollection.Add(key, hotkeyString);

			configManager.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);
		}

		public static void SetConfigInt(string key, int value)
		{
			Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

			if (confCollection[key] != null)
				confCollection[key].Value = value.ToString();
			else
				confCollection.Add(key, value.ToString());

			configManager.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);
		}

		public static int GetConfigInt(string key)
		{
			Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

			if(confCollection[key] != null && int.TryParse(confCollection[key].Value, out int val))
				return val;

			return 1;
		}
	}
}
