using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HakutakuDesktop.Util
{
	public static class LayoutUtil
	{
		private static int _screenWidth;
		private static int _screenHeight;
		public static int ScreenWidth
		{
			get
			{
				if (_screenWidth == 0)
					_screenWidth = Screen.PrimaryScreen.Bounds.Width;
				return _screenWidth;
			}
		}

		public static int ScreenHeight
		{
			get
			{
				if (_screenHeight == 0)
					_screenHeight = Screen.PrimaryScreen.Bounds.Height;
				return _screenHeight;
			}
		}

		public static Point GetPositionForTextArea(Rectangle selectedArea, int width, int height)
		{
			if (selectedArea.X + selectedArea.Width + width < ScreenWidth)
				return new Point(selectedArea.X + selectedArea.Width, selectedArea.Y);
			if (selectedArea.X - width > 0)
				return new Point(selectedArea.X - width, selectedArea.Y);
			if (selectedArea.Y - height > 0)
				return new Point(selectedArea.X, selectedArea.Y - height);

			return new Point(0, 0);
		}
	}
}
