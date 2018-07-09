using HakutakuDesktop.Util;

namespace HakutakuDesktop
{
	partial class MainMenu
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			MovablePython.Hotkey hotkey3 = new MovablePython.Hotkey();
			MovablePython.Hotkey hotkey4 = new MovablePython.Hotkey();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
			this.customTabControl1 = new System.Windows.Forms.CustomTabControl();
			this.helpPage = new System.Windows.Forms.TabPage();
			this.dontShow = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.settingsPage = new System.Windows.Forms.TabPage();
			this.bDisplayTextOnTop = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textDisplayCount = new System.Windows.Forms.NumericUpDown();
			this.bShowScan = new System.Windows.Forms.CheckBox();
			this.bAutoStart = new System.Windows.Forms.CheckBox();
			this.bConcatStrings = new System.Windows.Forms.CheckBox();
			this.closeProgramHotkeyInput = new HakutakuDesktop.Controls.HotkeyInputBox();
			this.toggleOverlayHotkeyInput = new HakutakuDesktop.Controls.HotkeyInputBox();
			this.srcLanguagesPage = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.srcLanguagesList = new System.Windows.Forms.TableLayoutPanel();
			this.customTabControl1.SuspendLayout();
			this.helpPage.SuspendLayout();
			this.settingsPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textDisplayCount)).BeginInit();
			this.srcLanguagesPage.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// customTabControl1
			// 
			this.customTabControl1.Controls.Add(this.helpPage);
			this.customTabControl1.Controls.Add(this.settingsPage);
			this.customTabControl1.Controls.Add(this.srcLanguagesPage);
			// 
			// 
			// 
			this.customTabControl1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.customTabControl1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
			this.customTabControl1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			this.customTabControl1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
			this.customTabControl1.DisplayStyleProvider.FocusTrack = true;
			this.customTabControl1.DisplayStyleProvider.HotTrack = true;
			this.customTabControl1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.customTabControl1.DisplayStyleProvider.Opacity = 1F;
			this.customTabControl1.DisplayStyleProvider.Overlap = 0;
			this.customTabControl1.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
			this.customTabControl1.DisplayStyleProvider.Radius = 2;
			this.customTabControl1.DisplayStyleProvider.ShowTabCloser = false;
			this.customTabControl1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
			this.customTabControl1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
			this.customTabControl1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
			resources.ApplyResources(this.customTabControl1, "customTabControl1");
			this.customTabControl1.HotTrack = true;
			this.customTabControl1.Name = "customTabControl1";
			this.customTabControl1.SelectedIndex = 0;
			this.customTabControl1.SelectedIndexChanged += new System.EventHandler(this.customTabControl1_SelectedIndexChanged);
			this.customTabControl1.Font = FontUtil.GetExtrabold(12F);
			// 
			// helpPage
			// 
			this.helpPage.Controls.Add(this.dontShow);
			this.helpPage.Controls.Add(this.label1);
			resources.ApplyResources(this.helpPage, "helpPage");
			this.helpPage.Name = "helpPage";
			this.helpPage.UseVisualStyleBackColor = true;
			this.tabPage1.Font = FontUtil.GetRegular(11F);
			// 
			// dontShow
			// 
			resources.ApplyResources(this.dontShow, "dontShow");
			this.dontShow.Font = FontUtil.GetExtrabold(8.25f);
			this.dontShow.Name = "dontShow";
			this.dontShow.UseVisualStyleBackColor = true;
			this.dontShow.CheckedChanged += new System.EventHandler(this.dontShow_CheckedChanged);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			this.label1.Font = FontUtil.GetRegular(11.25f);
			// 
			// settingsPage
			// 
			this.settingsPage.Controls.Add(this.bDisplayTextOnTop);
			this.settingsPage.Controls.Add(this.label4);
			this.settingsPage.Controls.Add(this.label3);
			this.settingsPage.Controls.Add(this.label2);
			this.settingsPage.Controls.Add(this.textDisplayCount);
			this.settingsPage.Controls.Add(this.bShowScan);
			this.settingsPage.Controls.Add(this.bAutoStart);
			this.settingsPage.Controls.Add(this.bConcatStrings);
			this.settingsPage.Controls.Add(this.closeProgramHotkeyInput);
			this.settingsPage.Controls.Add(this.toggleOverlayHotkeyInput);
			resources.ApplyResources(this.settingsPage, "settingsPage");
			this.settingsPage.Name = "settingsPage";
			this.settingsPage.UseVisualStyleBackColor = true;
			this.tabPage2.Font = FontUtil.GetRegular(12F);
			// 
			// bDisplayTextOnTop
			// 
			resources.ApplyResources(this.bDisplayTextOnTop, "bDisplayTextOnTop");
			this.bDisplayTextOnTop.Name = "bDisplayTextOnTop";
			this.bDisplayTextOnTop.UseVisualStyleBackColor = true;
			this.bDisplayTextOnTop.CheckedChanged += new System.EventHandler(this.bReplaceOriginalText_CheckedChanged);
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// textDisplayCount
			// 
			resources.ApplyResources(this.textDisplayCount, "textDisplayCount");
			this.textDisplayCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.textDisplayCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.textDisplayCount.Name = "textDisplayCount";
			this.textDisplayCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.textDisplayCount.ValueChanged += new System.EventHandler(this.textDisplayCount_ValueChanged);
			// 
			// bShowScan
			// 
			resources.ApplyResources(this.bShowScan, "bShowScan");
			this.bShowScan.Name = "bShowScan";
			this.bShowScan.UseVisualStyleBackColor = true;
			this.bShowScan.CheckedChanged += new System.EventHandler(this.bShowScan_CheckedChanged);
			// 
			// bAutoStart
			// 
			resources.ApplyResources(this.bAutoStart, "bAutoStart");
			this.bAutoStart.Name = "bAutoStart";
			this.bAutoStart.UseVisualStyleBackColor = true;
			this.bAutoStart.CheckedChanged += new System.EventHandler(this.bAutoStart_CheckedChanged);
			// 
			// bConcatStrings
			// 
			resources.ApplyResources(this.bConcatStrings, "bConcatStrings");
			this.bConcatStrings.Name = "bConcatStrings";
			this.bConcatStrings.UseVisualStyleBackColor = true;
			this.bConcatStrings.CheckedChanged += new System.EventHandler(this.bConcatStrings_CheckedChanged);
			// 
			// closeProgramHotkeyInput
			// 
			this.closeProgramHotkeyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			hotkey3.Alt = false;
			hotkey3.Control = false;
			hotkey3.KeyCode = System.Windows.Forms.Keys.None;
			hotkey3.Shift = false;
			hotkey3.Windows = false;
			this.closeProgramHotkeyInput.HotKey = hotkey3;
			resources.ApplyResources(this.closeProgramHotkeyInput, "closeProgramHotkeyInput");
			this.closeProgramHotkeyInput.Name = "closeProgramHotkeyInput";
			this.closeProgramHotkeyInput.ShortcutsEnabled = false;
			this.closeProgramHotkeyInput.HotkeyChanged += new System.EventHandler(this.closeProgramHotkeyInput_HotkeyChanged);
			// 
			// toggleOverlayHotkeyInput
			// 
			this.toggleOverlayHotkeyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			hotkey4.Alt = false;
			hotkey4.Control = false;
			hotkey4.KeyCode = System.Windows.Forms.Keys.None;
			hotkey4.Shift = false;
			hotkey4.Windows = false;
			this.toggleOverlayHotkeyInput.HotKey = hotkey4;
			resources.ApplyResources(this.toggleOverlayHotkeyInput, "toggleOverlayHotkeyInput");
			this.toggleOverlayHotkeyInput.Name = "toggleOverlayHotkeyInput";
			this.toggleOverlayHotkeyInput.ShortcutsEnabled = false;
			this.toggleOverlayHotkeyInput.HotkeyChanged += new System.EventHandler(this.toggleOverlayHotkeyInput_HotkeyChanged);
			// 
			// srcLanguagesPage
			// 
			this.srcLanguagesPage.Controls.Add(this.tableLayoutPanel1);
			resources.ApplyResources(this.srcLanguagesPage, "srcLanguagesPage");
			this.srcLanguagesPage.Name = "srcLanguagesPage";
			this.srcLanguagesPage.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.srcLanguagesList, 0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// srcLanguagesList
			// 
			resources.ApplyResources(this.srcLanguagesList, "srcLanguagesList");
			this.srcLanguagesList.Name = "srcLanguagesList";
			this.srcLanguagesList.AutoScroll = false;
			this.srcLanguagesList.HorizontalScroll.Enabled = false;
			this.srcLanguagesList.HorizontalScroll.Visible = false;
			this.srcLanguagesList.HorizontalScroll.Maximum = 0;
			this.srcLanguagesList.HorizontalScroll.Minimum = 0;
			this.srcLanguagesList.AutoScroll = true;

			// 
			// MainMenu
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.customTabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainMenu";
			this.customTabControl1.ResumeLayout(false);
			this.helpPage.ResumeLayout(false);
			this.helpPage.PerformLayout();
			this.settingsPage.ResumeLayout(false);
			this.settingsPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textDisplayCount)).EndInit();
			this.srcLanguagesPage.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CustomTabControl customTabControl1;
		private System.Windows.Forms.TabPage settingsPage;
		private System.Windows.Forms.TabPage helpPage;
		private System.Windows.Forms.CheckBox dontShow;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown textDisplayCount;
		private System.Windows.Forms.CheckBox bShowScan;
		private System.Windows.Forms.CheckBox bAutoStart;
		private System.Windows.Forms.CheckBox bConcatStrings;
		private Controls.HotkeyInputBox toggleOverlayHotkeyInput;
		private Controls.HotkeyInputBox closeProgramHotkeyInput;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox bDisplayTextOnTop;
		private System.Windows.Forms.TabPage srcLanguagesPage;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel srcLanguagesList;
	}
}