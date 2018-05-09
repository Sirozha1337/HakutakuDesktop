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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextDisplay));
			this.textArea = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// textArea
			// 
			this.textArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.textArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textArea.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textArea.Location = new System.Drawing.Point(0, 0);
			this.textArea.Margin = new System.Windows.Forms.Padding(0);
			this.textArea.Name = "textArea";
			this.textArea.ReadOnly = true;
			this.textArea.Size = new System.Drawing.Size(800, 450);
			this.textArea.TabIndex = 0;
			this.textArea.Text = "";
			// 
			// TextDisplay
			// 
			//this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 200);
			this.Controls.Add(this.textArea);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TextDisplay";
			this.Text = "Text Display";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox textArea;
	}
}