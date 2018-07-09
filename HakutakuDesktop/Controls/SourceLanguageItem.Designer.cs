﻿namespace hakutaku.Controls
{
	partial class SourceLanguageItem
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.language = new System.Windows.Forms.Label();
			this.downloadButton = new System.Windows.Forms.Button();
			this.showInSelect = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 3;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel.Controls.Add(this.downloadButton, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.showInSelect, 2, 0);
			this.tableLayoutPanel.Controls.Add(this.language, 0, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 1;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(350, 50);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// language
			// 
			this.language.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.language.AutoSize = true;
			this.language.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.language.Location = new System.Drawing.Point(31, 13);
			this.language.Margin = new System.Windows.Forms.Padding(0);
			this.language.Name = "language";
			this.language.Size = new System.Drawing.Size(77, 24);
			this.language.TabIndex = 0;
			this.language.Text = "Russian";
			// 
			// downloadButton
			// 
			this.downloadButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.downloadButton.Location = new System.Drawing.Point(143, 3);
			this.downloadButton.Name = "downloadButton";
			this.downloadButton.Size = new System.Drawing.Size(99, 44);
			this.downloadButton.TabIndex = 1;
			this.downloadButton.Text = "Download";
			this.downloadButton.UseVisualStyleBackColor = true;
			this.downloadButton.Click += new System.EventHandler(this.downloadButton_ClickAsync);
			// 
			// showInSelect
			// 
			this.showInSelect.AutoSize = true;
			this.showInSelect.Dock = System.Windows.Forms.DockStyle.Fill;
			this.showInSelect.Location = new System.Drawing.Point(248, 3);
			this.showInSelect.Name = "showInSelect";
			this.showInSelect.Size = new System.Drawing.Size(99, 44);
			this.showInSelect.TabIndex = 2;
			this.showInSelect.Text = "Show in select";
			this.showInSelect.UseVisualStyleBackColor = true;
			// 
			// SourceLanguageItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "SourceLanguageItem";
			this.Size = new System.Drawing.Size(350, 50);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label language;
		private System.Windows.Forms.Button downloadButton;
		private System.Windows.Forms.CheckBox showInSelect;
	}
}
