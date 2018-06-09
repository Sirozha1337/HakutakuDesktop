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
		public TextDisplay(Rectangle selectedArea, string text)
		{
			InitializeComponent();
			var positionRect = Positioning(selectedArea, text);
			this.textArea.Text = text;
			this.StartPosition = FormStartPosition.Manual;
			this.ClientSize = new Size(positionRect.Width, positionRect.Height);
			this.Location = new Point(positionRect.X, positionRect.Y);
			this.TopMost = true;
			this.ShowInTaskbar = false;
			this.AutoScroll = true;
		}

		private Rectangle Positioning(Rectangle selectedArea, string text)
		{
			Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
			int titleHeight = screenRectangle.Top - this.Top;
			int borderWidth = (this.Width - this.ClientSize.Width) / 2;
			return LayoutUtil.GetParamsForTextArea(selectedArea, text, borderWidth, titleHeight);
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
