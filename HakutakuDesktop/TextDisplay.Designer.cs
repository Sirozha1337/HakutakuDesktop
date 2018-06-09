using HakutakuDesktop.Util;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	partial class TextDisplay
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitiliazeSingleTextArea()
		{
			this.translationTextArea = CreateTextArea("translationTextArea");
			// 
			// textArea
			// 
			this.Controls.Add(this.translationTextArea);
		}

		private RichTextBox CreateTextArea(string name)
		{
			var textArea = new System.Windows.Forms.RichTextBox();
			textArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textArea.Dock = System.Windows.Forms.DockStyle.Fill;
			textArea.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			textArea.Location = new System.Drawing.Point(0, 0);
			textArea.Margin = new System.Windows.Forms.Padding(0);
			textArea.Name = name;
			textArea.ReadOnly = true;
			textArea.TabIndex = 0;
			textArea.Text = "";
			return textArea;
		}

		private void InitializeTabLayout()
		{
			this.languages = new System.Windows.Forms.CustomTabControl();
			this.languages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.languages.Location = new System.Drawing.Point(0, 0);
			this.languages.Name = "languages";
			this.languages.SelectedIndex = 0;
			this.languages.TabIndex = 0;
			this.languages.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.languages.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
			this.languages.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			this.languages.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
			this.languages.DisplayStyleProvider.FocusTrack = true;
			this.languages.DisplayStyleProvider.HotTrack = true;
			this.languages.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.languages.DisplayStyleProvider.Opacity = 1F;
			this.languages.DisplayStyleProvider.Overlap = 1;
			this.languages.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
			this.languages.DisplayStyleProvider.Radius = 2;
			this.languages.DisplayStyleProvider.ShowTabCloser = false;
			this.languages.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
			this.languages.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
			this.languages.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
			this.languages.SizeMode = TabSizeMode.Fixed;
			this.languages.Font = new System.Drawing.Font("Open Sans ExtraBold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.languages.SuspendLayout();

			this.translation = new System.Windows.Forms.TabPage();
			this.translation.SuspendLayout();
			this.translation.UseVisualStyleBackColor = true;
			this.translation.Text = "Translation";
			this.translationTextArea = CreateTextArea("translationTextArea");
			this.languages.Controls.Add(this.translation);
			this.translation.Controls.Add(translationTextArea);

			this.source = new System.Windows.Forms.TabPage();
			this.source.SuspendLayout();
			this.source.UseVisualStyleBackColor = true;
			this.source.Text = "Source";
			this.sourceTextArea = CreateTextArea("sourceTextArea");
			this.languages.Controls.Add(this.source);
			this.source.Controls.Add(this.sourceTextArea);

			this.Resize += new System.EventHandler((object sender, System.EventArgs e) =>
			{
				var width = languages.ClientSize.Width;
				this.languages.ItemSize = new System.Drawing.Size(width / languages.TabCount - 3, 24);
			});

			this.Controls.Add(this.languages);
			this.languages.ResumeLayout(false);
			this.source.ResumeLayout(false);
			this.translation.ResumeLayout(false);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextDisplay));
			this.SuspendLayout();
			if (GlobalConfigurationObject.ShowScannedText)
			{
				InitializeTabLayout();
			}
			else
			{
				InitiliazeSingleTextArea();
			}
			// 
			// TextDisplay
			// 
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TextDisplay";
			this.Text = "Text Display";
			this.ResumeLayout(true);

		}

		#endregion

		private System.Windows.Forms.CustomTabControl languages;
		private System.Windows.Forms.TabPage source;
		private System.Windows.Forms.TabPage translation;
		private System.Windows.Forms.RichTextBox translationTextArea;
		private System.Windows.Forms.RichTextBox sourceTextArea;
	}
}