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
			bShowScan.Checked = AppConfiguration.GetConfigBool("ShowScannedText");
			bConcatStrings.Checked = AppConfiguration.GetConfigBool("ConcatenateWhenUnchanged");
			bAutoStart.Checked = AppConfiguration.GetConfigBool("Autostart");
			toggleOverlayHotkeyInput.HotKey = AppConfiguration.GetConfigHotkey("OverlayHotkey");
		    closeProgramHotkeyInput.HotKey = AppConfiguration.GetConfigHotkey("CloseProgramHotkey");
		}

		private void customTabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (customTabControl1.SelectedIndex == 1)
			{
				LoadSettings();
			}
		}
	}
}
