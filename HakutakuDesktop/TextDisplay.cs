using HakutakuDesktop.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	public partial class TextDisplay : Form
	{
		public TextDisplay(string text, int x, int y, int width, int height)
		{
			InitializeComponent();
			this.textArea.Text = text;
			this.StartPosition = FormStartPosition.Manual;
			Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
			int titleHeight = screenRectangle.Top - this.Top;
			this.ClientSize = new Size(width, height + titleHeight);
			this.Location = new Point(x, y - titleHeight);
			//this.SetBounds(x, y - titleHeight, width, height + titleHeight);
			this.TopMost = true;
			this.ShowInTaskbar = false;
			this.AutoScroll = true;
			Console.WriteLine("TextDisp X:" + this.Left);
			Console.WriteLine("TextDisp width:" + this.Width);
			Console.WriteLine(this.ClientSize);
			Console.WriteLine(this.ClientRectangle);
		}

		public void SetText(string text)
		{
			if (GlobalConfigurationObject.ConcatenateWhenUnchanged && !string.IsNullOrEmpty(this.textArea.Text))
			{
				textArea.Text = textArea.Text + "\n" + text;
				textArea.Select(textArea.TextLength - 1, textArea.TextLength);
				textArea.ScrollToCaret();
			}
			else
				textArea.Text = text;
		}
	}
}
