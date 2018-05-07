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
			this.customTabControl1 = new System.Windows.Forms.CustomTabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.dontShow = new System.Windows.Forms.CheckBox();
			this.customTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
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
			// 
			// tabPage2
			// 
			this.tabPage2.Font = new System.Drawing.Font("Open Sans ExtraBold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabPage2.Location = new System.Drawing.Point(4, 32);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(576, 325);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Settings";
			this.tabPage2.UseVisualStyleBackColor = true;
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
			// dontShow
			// 
			this.dontShow.AutoSize = true;
			this.dontShow.Location = new System.Drawing.Point(393, 298);
			this.dontShow.Name = "dontShow";
			this.dontShow.Size = new System.Drawing.Size(175, 19);
			this.dontShow.TabIndex = 4;
			this.dontShow.Text = "Don\'t show this on startup";
			this.dontShow.UseVisualStyleBackColor = true;
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
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CustomTabControl customTabControl1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.CheckBox dontShow;
		private System.Windows.Forms.Label label1;
	}
}