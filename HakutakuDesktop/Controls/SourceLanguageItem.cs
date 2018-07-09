﻿using hakutaku.DataModels;
using hakutaku.Util;
using HakutakuDesktop.Util;
using System.Windows.Forms;

namespace hakutaku.Controls
{
	public partial class SourceLanguageItem : UserControl
	{
		private enum ButtonAction
		{
			Download,
			Update,
			Delete
		}

		private ButtonAction currentAction;
		private SourceLanguageUpdateData data;

		public SourceLanguageItem()
		{
			InitializeComponent();
			this.language.Font = FontUtil.GetExtrabold(10F);
		}

		public void SetData(SourceLanguageUpdateData sourceLanguageUpdateData)
		{
			this.data = sourceLanguageUpdateData;
			this.language.Text = sourceLanguageUpdateData.Name;
			SetButtonAction(sourceLanguageUpdateData.Downloaded ? (sourceLanguageUpdateData.NeedUpdate ? ButtonAction.Update : ButtonAction.Delete) : ButtonAction.Download);
			this.showInSelect.Checked = sourceLanguageUpdateData.ShowInSelect;
		}

		private void SetButtonAction(ButtonAction action)
		{
			currentAction = action;
			switch (action)
			{
				case ButtonAction.Download:
					this.downloadButton.Text = "Download"; break;
				case ButtonAction.Update:
					this.downloadButton.Text = "Update"; break;
				case ButtonAction.Delete:
					this.downloadButton.Text = "Delete"; break;
			}
		}

		private async void downloadButton_ClickAsync(object sender, System.EventArgs e)
		{
			switch (currentAction)
			{
				case ButtonAction.Download:
					this.downloadButton.Enabled = false;
					await UpdateUtility.Download(this.data);
					this.downloadButton.Enabled = true;
					SetButtonAction(ButtonAction.Delete);
					break;
				case ButtonAction.Delete:
					this.downloadButton.Enabled = false;
					await UpdateUtility.Remove(this.data);
					this.downloadButton.Enabled = true;
					SetButtonAction(ButtonAction.Download);
					break;
				case ButtonAction.Update:
					this.downloadButton.Enabled = false;
					await UpdateUtility.Update(this.data);
					this.downloadButton.Enabled = true;
					SetButtonAction(ButtonAction.Delete);
					break;
			}
		}
	}
}