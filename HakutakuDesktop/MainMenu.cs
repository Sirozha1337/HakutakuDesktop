﻿using hakutaku.Controls;
using hakutaku.DataModels;
using hakutaku.Util;
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
			dontShow.Checked = GlobalConfigurationObject.ShowHelpOnStartUp;
		}

		private void dontShow_CheckedChanged(object sender, EventArgs e)
		{
			GlobalConfigurationObject.ShowHelpOnStartUp = dontShow.Checked;
		}

		private async void LoadSourceLanguagesAsync()
		{
			if(this.srcLanguagesList.RowCount == 0)
			{
				SourceLanguageItemData[] sourceLanguages = await UpdateUtility.CheckUpdate();
				this.srcLanguagesList.RowCount = sourceLanguages.Length;
				for (int i = 0; i < sourceLanguages.Length; i++)
				{
					SourceLanguageItem sourceLanguageItem = new SourceLanguageItem();
					sourceLanguageItem.SetData(sourceLanguages[i]);
					this.srcLanguagesList.Controls.Add(sourceLanguageItem, 0, i);
				}
			}
		}

		private void LoadSettings()
		{
			bShowScan.Checked = GlobalConfigurationObject.ShowScannedText;
			bConcatStrings.Checked = GlobalConfigurationObject.ConcatenateWhenUnchanged;
			bAutoStart.Checked = GlobalConfigurationObject.AutoStart;
			toggleOverlayHotkeyInput.HotKey = GlobalConfigurationObject.ToggleOverlayHotkey;
			closeProgramHotkeyInput.HotKey = GlobalConfigurationObject.CloseProgramHotkey;
			textDisplayCount.Value = GlobalConfigurationObject.MaxTextDisplayCount;
			bDisplayTextOnTop.Checked = GlobalConfigurationObject.DisplayTextOnTop;
		}

		private void customTabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (customTabControl1.SelectedIndex == 1)
			{
				LoadSettings();
			}
			if(customTabControl1.SelectedIndex == 2)
			{
				LoadSourceLanguagesAsync();
			}
		}

		private void toggleOverlayHotkeyInput_HotkeyChanged(object sender, EventArgs e)
		{
			GlobalConfigurationObject.ToggleOverlayHotkey = toggleOverlayHotkeyInput.HotKey;
			CustomApplicationContext._mainContext.BindHotkeys();
		}

		private void closeProgramHotkeyInput_HotkeyChanged(object sender, EventArgs e)
		{
			GlobalConfigurationObject.CloseProgramHotkey = closeProgramHotkeyInput.HotKey;
			CustomApplicationContext._mainContext.BindHotkeys();
		}

		private void bConcatStrings_CheckedChanged(object sender, EventArgs e)
		{
			GlobalConfigurationObject.ConcatenateWhenUnchanged = bConcatStrings.Checked;
		}

		private void bShowScan_CheckedChanged(object sender, EventArgs e)
		{
			GlobalConfigurationObject.ShowScannedText = bShowScan.Checked;
		}

		private void textDisplayCount_ValueChanged(object sender, EventArgs e)
		{
			GlobalConfigurationObject.MaxTextDisplayCount = (int)textDisplayCount.Value;
		}

		private void bAutoStart_CheckedChanged(object sender, EventArgs e)
		{
			GlobalConfigurationObject.AutoStart = bAutoStart.Checked;
		}

		private void bReplaceOriginalText_CheckedChanged(object sender, EventArgs e)
		{
			GlobalConfigurationObject.DisplayTextOnTop = bDisplayTextOnTop.Checked;
		}
	}
}
