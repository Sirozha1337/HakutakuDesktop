using HakutakuDesktop.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	public partial class MainMenu : Form
	{
		public int SelectedTabIndex
		{
			set
			{
				customTabControl1.SelectedIndex = value;
			}
		}

		public MainMenu()
		{
			InitializeComponent();
			dontShow.Checked = AppConfiguration.GetConfigBool("ShowHelpOnStartUp");
		}

		private void dontShow_CheckedChanged(object sender, EventArgs e)
		{
			AppConfiguration.SetConfig("ShowHelpOnStartUp", dontShow.Checked);
		}

		private void LoadSettings()
		{
			bShowScan.Checked = GlobalConfigurationObject.ShowScannedText;
			bConcatStrings.Checked = GlobalConfigurationObject.ConcatenateWhenUnchanged;
			bAutoStart.Checked = GlobalConfigurationObject.AutoStart;
			toggleOverlayHotkeyInput.HotKey = GlobalConfigurationObject.toggleOverlayHotkey.Clone();
			closeProgramHotkeyInput.HotKey = GlobalConfigurationObject.closeProgramHotkey.Clone();
			textDisplayCount.Value = GlobalConfigurationObject.MaxTextDisplayCount;
		}

		private void customTabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (customTabControl1.SelectedIndex == 1)
			{
				LoadSettings();
			}
		}

		private void toggleOverlayHotkeyInput_HotkeyChanged(object sender, EventArgs e)
		{
			AppConfiguration.SetConfigHotkey("OverlayHotkey", toggleOverlayHotkeyInput.HotKey);
			GlobalConfigurationObject.Reload();
			CustomApplicationContext._mainContext.BindHotkeys();
		}

		private void closeProgramHotkeyInput_HotkeyChanged(object sender, EventArgs e)
		{
			AppConfiguration.SetConfigHotkey("CloseProgramHotkey", closeProgramHotkeyInput.HotKey);
			GlobalConfigurationObject.Reload();
			CustomApplicationContext._mainContext.BindHotkeys();
		}

		private void bConcatStrings_CheckedChanged(object sender, EventArgs e)
		{
			AppConfiguration.SetConfig("ConcatenateWhenUnchanged", bConcatStrings.Checked);
			GlobalConfigurationObject.Reload();
		}
	}
}
