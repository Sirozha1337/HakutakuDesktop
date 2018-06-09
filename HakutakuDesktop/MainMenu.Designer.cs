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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
			MovablePython.Hotkey hotkey1 = new MovablePython.Hotkey();
			MovablePython.Hotkey hotkey2 = new MovablePython.Hotkey();
			this.customTabControl1 = new System.Windows.Forms.CustomTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dontShow = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
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
			this.customTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textDisplayCount)).BeginInit();
			this.SuspendLayout();
			// 
			// customTabControl1
			// 
			this.customTabControl1.Controls.Add(this.tabPage1);
			this.customTabControl1.Controls.Add(this.tabPage2);
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
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dontShow);
			this.tabPage1.Controls.Add(this.label1);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
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
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.bDisplayTextOnTop);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.textDisplayCount);
			this.tabPage2.Controls.Add(this.bShowScan);
			this.tabPage2.Controls.Add(this.bAutoStart);
			this.tabPage2.Controls.Add(this.bConcatStrings);
			this.tabPage2.Controls.Add(this.closeProgramHotkeyInput);
			this.tabPage2.Controls.Add(this.toggleOverlayHotkeyInput);
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
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
			hotkey1.Alt = false;
			hotkey1.Control = false;
			hotkey1.KeyCode = System.Windows.Forms.Keys.None;
			hotkey1.Shift = false;
			hotkey1.Windows = false;
			this.closeProgramHotkeyInput.HotKey = hotkey1;
			resources.ApplyResources(this.closeProgramHotkeyInput, "closeProgramHotkeyInput");
			this.closeProgramHotkeyInput.Name = "closeProgramHotkeyInput";
			this.closeProgramHotkeyInput.ShortcutsEnabled = false;
			this.closeProgramHotkeyInput.HotkeyChanged += new System.EventHandler(this.closeProgramHotkeyInput_HotkeyChanged);
			// 
			// toggleOverlayHotkeyInput
			// 
			this.toggleOverlayHotkeyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			hotkey2.Alt = false;
			hotkey2.Control = false;
			hotkey2.KeyCode = System.Windows.Forms.Keys.None;
			hotkey2.Shift = false;
			hotkey2.Windows = false;
			this.toggleOverlayHotkeyInput.HotKey = hotkey2;
			resources.ApplyResources(this.toggleOverlayHotkeyInput, "toggleOverlayHotkeyInput");
			this.toggleOverlayHotkeyInput.Name = "toggleOverlayHotkeyInput";
			this.toggleOverlayHotkeyInput.ShortcutsEnabled = false;
			this.toggleOverlayHotkeyInput.HotkeyChanged += new System.EventHandler(this.toggleOverlayHotkeyInput_HotkeyChanged);
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
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textDisplayCount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CustomTabControl customTabControl1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
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
	}
}