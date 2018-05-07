using HakutakuDesktop.Controls;
using HakutakuDesktop.Util;
using System.Drawing;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	partial class SelectionForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionForm));
			this.SuspendLayout();
			//
			// Translate Button
			//
			_translateButton = new Button();
			_translateButton.BackColor = Color.Wheat;
			_translateButton.Text = "Translate";
			this.Controls.Add(_translateButton);

			//
			// Source Language
			//
			_srcLangSelector = new ComboBox();
			_srcLangSelector.DisplayMember = "Name";
			_srcLangSelector.ValueMember = "Code";
			this.Controls.Add(_srcLangSelector);

			//
			// Destination Language
			//
			_dstLangSelector = new ComboBox();
			_dstLangSelector.DisplayMember = "Name";
			_dstLangSelector.ValueMember = "Code";
			this.Controls.Add(_dstLangSelector);

			//
			// Loading Circle
			//
			_loadingCircle = new LoadingCircle();
			_loadingCircle.Active = false;
			_loadingCircle.BackColor = Color.White;
			_loadingCircle.Color = Color.Black;
			_loadingCircle.ForeColor = SystemColors.HotTrack;
			_loadingCircle.InnerCircleRadius = 15;
			_loadingCircle.Location = new Point(151, 138);
			_loadingCircle.Name = "loadingCircle";
			_loadingCircle.NumberSpoke = 12;
			_loadingCircle.OuterCircleRadius = 30;
			_loadingCircle.RotationSpeed = 80;
			_loadingCircle.SpokeThickness = 2;
			_loadingCircle.StylePreset = LoadingCircle.StylePresets.MacOSX;
			_loadingCircle.TabIndex = 14;
			_loadingCircle.Text = "loadingCircle";
			_loadingCircle.Visible = false;
			this.Controls.Add(_loadingCircle);

			// 
			// SelectionForm
			// 
			TopMost = true;
			ShowInTaskbar = false;
			FormBorderStyle = FormBorderStyle.None;
			BackColor = Color.LightGray;
			TransparencyKey = Color.LightGray;
			Left = 0;
			Top = 0;
			Width = LayoutUtil.ScreenWidth;
			Height = LayoutUtil.ScreenHeight;
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SelectionForm";
			this.Text = "SelectionForm";
			this.ResumeLayout(false);

		}

		#endregion
	}
}