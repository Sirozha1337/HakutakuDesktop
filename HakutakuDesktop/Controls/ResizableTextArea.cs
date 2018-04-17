using System;
using System.Windows.Forms;

namespace HakutakuDesktop.Controls
{
	class ResizableTextArea : RichTextBox
	{
		private bool isDrag = false;
		private int lastY = 0;
		private int lastX = 0;
		private int padding = 15;

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			Cursor.Current = Cursors.Default;
			isDrag = false;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Y >= (this.ClientRectangle.Bottom - padding) &&
				e.Y <= (this.ClientRectangle.Bottom + padding)) || 
				(e.Y >= (this.ClientRectangle.Top - padding) &&
				e.Y <= (this.ClientRectangle.Top + padding)))
			{
				isDrag = true;
				lastY = e.Y;
			}

			if ((e.X >= (this.ClientRectangle.Left - padding) &&
				e.X <= (this.ClientRectangle.Left + padding)) ||
				(e.X >= (this.ClientRectangle.Right - padding) &&
				e.X <= (this.ClientRectangle.Right + padding)))
			{
				isDrag = true;
				lastX = e.X;
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (isDrag)
			{
				int newHeight = this.Height + (e.Y - lastY);
				if (newHeight >= 100)
				{
					this.Height = newHeight;
					lastY = e.Y;
				}

				int newWidth = this.Width + (e.X - lastX);
				if (newWidth >= 100)
				{
					this.Width = newWidth;
					lastX = e.X;
				}
			}

			bool horizontal = 
				(e.X >= (this.ClientRectangle.Left - padding) &&
				e.X <= (this.ClientRectangle.Left + padding))
				||
				(e.X >= (this.ClientRectangle.Right - padding) &&
				e.X <= (this.ClientRectangle.Right + padding));

			bool vertical =
				(e.Y >= (this.ClientRectangle.Bottom - padding) &&
				e.Y <= (this.ClientRectangle.Bottom + padding))
				||
				(e.Y >= (this.ClientRectangle.Top - padding) &&
				e.Y <= (this.ClientRectangle.Top + padding));

			if(horizontal || vertical)
			{
				if (horizontal)
					Cursor.Current = Cursors.SizeWE;

				if (vertical)
					Cursor.Current = Cursors.SizeNS;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (isDrag)
			{
				isDrag = false;
			}
		}

	}
}
