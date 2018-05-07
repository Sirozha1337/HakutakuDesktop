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
			MovablePython.Hotkey hotkey1 = new MovablePython.Hotkey();
			MovablePython.Hotkey hotkey2 = new MovablePython.Hotkey();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
			this.customTabControl1 = new System.Windows.Forms.CustomTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dontShow = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
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
			this.customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.customTabControl1.Font = new System.Drawing.Font("Open Sans ExtraBold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.customTabControl1.HotTrack = true;
			this.customTabControl1.Location = new System.Drawing.Point(0, 0);
			this.customTabControl1.Name = "customTabControl1";
			this.customTabControl1.SelectedIndex = 0;
			this.customTabControl1.Size = new System.Drawing.Size(584, 361);
			this.customTabControl1.TabIndex = 0;
			this.customTabControl1.SelectedIndexChanged += new System.EventHandler(this.customTabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dontShow);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Font = new System.Drawing.Font("Open Sans ExtraBold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabPage1.Location = new System.Drawing.Point(4, 32);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(576, 325);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Help";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dontShow
			// 
			this.dontShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.dontShow.AutoSize = true;
			this.dontShow.Location = new System.Drawing.Point(393, 298);
			this.dontShow.Name = "dontShow";
			this.dontShow.Size = new System.Drawing.Size(175, 19);
			this.dontShow.TabIndex = 4;
			this.dontShow.Text = "Don\'t show this on startup";
			this.dontShow.UseVisualStyleBackColor = true;
			this.dontShow.CheckedChanged += new System.EventHandler(this.dontShow_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(164, 200);
			this.label1.TabIndex = 3;
			this.label1.Text = "HOW TO USE:\r\n1. Open overlay\r\n2. Select an area\r\n3. Choose languages\r\n4. Press tr" +
    "anslate\r\n5. Get your translation\r\n\r\nHOTKEYS:\r\nF6 - Close program\r\nF7 - Show over" +
    "lay\r\n";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.closeProgramHotkeyInput);
			this.tabPage2.Controls.Add(this.toggleOverlayHotkeyInput);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.textDisplayCount);
			this.tabPage2.Controls.Add(this.bShowScan);
			this.tabPage2.Controls.Add(this.bAutoStart);
			this.tabPage2.Controls.Add(this.bConcatStrings);
			this.tabPage2.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabPage2.Location = new System.Drawing.Point(4, 32);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(576, 325);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Settings";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 158);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(155, 20);
			this.label4.TabIndex = 8;
			this.label4.Text = "Exit Program Hotkey:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(169, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Toggle Overlay Hotkey:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(243, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(199, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Max Text Display Windows:";
			// 
			// textDisplayCount
			// 
			this.textDisplayCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textDisplayCount.Location = new System.Drawing.Point(448, 12);
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
			this.textDisplayCount.Size = new System.Drawing.Size(120, 28);
			this.textDisplayCount.TabIndex = 3;
			this.textDisplayCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// bShowScan
			// 
			this.bShowScan.AutoSize = true;
			this.bShowScan.Location = new System.Drawing.Point(8, 40);
			this.bShowScan.Name = "bShowScan";
			this.bShowScan.Size = new System.Drawing.Size(157, 24);
			this.bShowScan.TabIndex = 2;
			this.bShowScan.Text = "Show scanned text";
			this.bShowScan.UseVisualStyleBackColor = true;
			// 
			// bAutoStart
			// 
			this.bAutoStart.AutoSize = true;
			this.bAutoStart.Location = new System.Drawing.Point(8, 10);
			this.bAutoStart.Name = "bAutoStart";
			this.bAutoStart.Size = new System.Drawing.Size(203, 24);
			this.bAutoStart.TabIndex = 1;
			this.bAutoStart.Text = "Start on Windows startup";
			this.bAutoStart.UseVisualStyleBackColor = true;
			// 
			// bConcatStrings
			// 
			this.bConcatStrings.AutoSize = true;
			this.bConcatStrings.Location = new System.Drawing.Point(8, 70);
			this.bConcatStrings.Name = "bConcatStrings";
			this.bConcatStrings.Size = new System.Drawing.Size(350, 24);
			this.bConcatStrings.TabIndex = 0;
			this.bConcatStrings.Text = "Concatenate strings when selection unchanged";
			this.bConcatStrings.UseVisualStyleBackColor = true;
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
			this.closeProgramHotkeyInput.Location = new System.Drawing.Point(179, 156);
			this.closeProgramHotkeyInput.Name = "closeProgramHotkeyInput";
			this.closeProgramHotkeyInput.ShortcutsEnabled = false;
			this.closeProgramHotkeyInput.Size = new System.Drawing.Size(100, 28);
			this.closeProgramHotkeyInput.TabIndex = 6;
			this.closeProgramHotkeyInput.Text = "(none)";
			this.closeProgramHotkeyInput.WordWrap = false;
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
			this.toggleOverlayHotkeyInput.Location = new System.Drawing.Point(179, 108);
			this.toggleOverlayHotkeyInput.Name = "toggleOverlayHotkeyInput";
			this.toggleOverlayHotkeyInput.ShortcutsEnabled = false;
			this.toggleOverlayHotkeyInput.Size = new System.Drawing.Size(100, 28);
			this.toggleOverlayHotkeyInput.TabIndex = 5;
			this.toggleOverlayHotkeyInput.Text = "(none)";
			this.toggleOverlayHotkeyInput.WordWrap = false;
			this.toggleOverlayHotkeyInput.HotkeyChanged += new System.EventHandler(this.toggleOverlayHotkeyInput_HotkeyChanged);
			// 
			// MainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.Controls.Add(this.customTabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 400);
			this.Name = "MainMenu";
			this.Text = "Main Menu";
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
	}
}