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
			Console.WriteLine(x + " " + y);
			this.StartPosition = FormStartPosition.Manual;
			this.SetBounds(x, y, width, height);
			this.TopMost = true;
			this.ShowInTaskbar = false;
			this.AutoScroll = true;
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
