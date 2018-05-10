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

		private static int CountLines(string text)
		{
			int count = 0;
			string[] lines = text.Split('\n');
			count += lines.Length;
			foreach(var l in lines)
			{
				count = count + (int)Math.Round(l.Length / 40.0f);
			}
			return count;
		}

		public static Rectangle GetParamsForTextArea(Rectangle selectedArea, string text)
		{
			Rectangle rectangle = new Rectangle();
			int lines = CountLines(text);
			int width = lines > 1 ? 400 : text.Length * 10;
			int height = lines * 15;

			if (!GlobalConfigurationObject.DisplayTextOnTop)
			{
				if (selectedArea.X + selectedArea.Width + width < ScreenWidth)
				{
					rectangle.X = selectedArea.X + selectedArea.Width;
					rectangle.Y = selectedArea.Y;
				}
				else if (selectedArea.X - width > 0)
				{
					rectangle.X = selectedArea.X - width;
					rectangle.Y = selectedArea.Y;
				}
				else if (selectedArea.Y - height > 0)
				{
					rectangle.X = selectedArea.X;
					rectangle.Y = selectedArea.Y - height;
				}
				else
				{
					rectangle.X = 0;
					rectangle.Y = 0;
				}
				rectangle.Width = width;
				rectangle.Height = height;
			}
			else
			{
				rectangle.X = selectedArea.X;
				rectangle.Y = selectedArea.Y;
				rectangle.Width = selectedArea.Width;
				rectangle.Height = selectedArea.Height;
			}
			
			return rectangle;
		}
	}
}
