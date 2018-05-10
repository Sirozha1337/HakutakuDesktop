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
			this._translateButton = new System.Windows.Forms.Button();
			this._srcLangSelector = new System.Windows.Forms.ComboBox();
			this._dstLangSelector = new System.Windows.Forms.ComboBox();
			this._loadingCircle = new HakutakuDesktop.Controls.LoadingCircle();
			this.SuspendLayout();
			// 
			// _translateButton
			// 
			this._translateButton.BackColor = System.Drawing.Color.White;
			this._translateButton.Location = new System.Drawing.Point(0, 0);
			this._translateButton.Name = "_translateButton";
			this._translateButton.Size = new System.Drawing.Size(75, 23);
			this._translateButton.TabIndex = 0;
			this._translateButton.Font = new System.Drawing.Font("Open Sans ExtraBold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._translateButton.Text = "Translate";
			this._translateButton.UseVisualStyleBackColor = false;
			// 
			// _srcLangSelector
			// 
			this._srcLangSelector.DisplayMember = "Name";
			this._srcLangSelector.Location = new System.Drawing.Point(0, 0);
			this._srcLangSelector.Name = "_srcLangSelector";
			this._srcLangSelector.Size = new System.Drawing.Size(121, 21);
			this._srcLangSelector.TabIndex = 1;
			this._srcLangSelector.ValueMember = "Code";
			// 
			// _dstLangSelector
			// 
			this._dstLangSelector.DisplayMember = "Name";
			this._dstLangSelector.Location = new System.Drawing.Point(0, 0);
			this._dstLangSelector.Name = "_dstLangSelector";
			this._dstLangSelector.Size = new System.Drawing.Size(121, 21);
			this._dstLangSelector.TabIndex = 2;
			this._dstLangSelector.ValueMember = "Code";
			// 
			// _loadingCircle
			// 
			this._loadingCircle.Active = false;
			this._loadingCircle.BackColor = System.Drawing.Color.White;
			this._loadingCircle.Color = System.Drawing.Color.Black;
			this._loadingCircle.ForeColor = System.Drawing.SystemColors.HotTrack;
			this._loadingCircle.InnerCircleRadius = 5;
			this._loadingCircle.Location = new System.Drawing.Point(151, 138);
			this._loadingCircle.Name = "_loadingCircle";
			this._loadingCircle.NumberSpoke = 12;
			this._loadingCircle.OuterCircleRadius = 11;
			this._loadingCircle.RotationSpeed = 80;
			this._loadingCircle.Size = new System.Drawing.Size(0, 0);
			this._loadingCircle.SpokeThickness = 2;
			this._loadingCircle.StylePreset = HakutakuDesktop.Controls.LoadingCircle.StylePresets.MacOSX;
			this._loadingCircle.TabIndex = 14;
			this._loadingCircle.Text = "loadingCircle";
			this._loadingCircle.Visible = false;
			// 
			// SelectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightGray;
			this.Top = 0;
			this.Left = 0;
			this.Width = LayoutUtil.ScreenWidth;
			this.Height = LayoutUtil.ScreenHeight;
			this.Controls.Add(this._translateButton);
			this.Controls.Add(this._srcLangSelector);
			this.Controls.Add(this._dstLangSelector);
			this.Controls.Add(this._loadingCircle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SelectionForm";
			this.ShowInTaskbar = false;
			this.Text = "SelectionForm";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.LightGray;
			this.ResumeLayout(false);

		}

		#endregion
	}
}