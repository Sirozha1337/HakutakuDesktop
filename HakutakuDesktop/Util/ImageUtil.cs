using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HakutakuDesktop.Util
{
	public static class ImageUtil
	{
		public static Bitmap GetScreenCapture(Point point1, Point point2)
		{
			Logger.WriteLog("Start screen capture");

			int x = Math.Min(point1.X, point2.X);
			int y = Math.Min(point1.Y, point2.Y);
			int width = Math.Abs(point1.X - point2.X) - 1;
			int height = Math.Abs(point1.Y - point2.Y) - 1;

			Logger.WriteLog(String.Format("Capturing screen at specified location: {0}, {1}", x, y));

			Rectangle bounds = new Rectangle(x, y, width, height);
			Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				g.CopyFromScreen(bounds.Left + 1, bounds.Top + 1, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
			}

			Logger.WriteLog("Screen captured");

			bitmap.Save("captured_image.png");

			return MagnifyBitmap(bitmap);
		}

		public static Bitmap MagnifyBitmap(Bitmap original)
		{
			float width = original.Width * 2;
			float height = original.Height * 2;
			var brush = new SolidBrush(Color.Black);
			float scale = Math.Min(width / original.Width, height / original.Height);

			Bitmap scaled = new Bitmap((int)width, (int)height);
			using (Graphics graphics = Graphics.FromImage(scaled))
			{
				// uncomment for higher quality output
				graphics.InterpolationMode = InterpolationMode.High;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.SmoothingMode = SmoothingMode.AntiAlias;

				var scaleWidth = (int)(original.Width * scale);
				var scaleHeight = (int)(original.Height * scale);

				graphics.FillRectangle(brush, new RectangleF(0, 0, width, height));
				graphics.DrawImage(original, ((int)width - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight);
			}
			scaled.Save("magnified_image.png");
			return scaled;
		}

		public static byte[] ImageToByte(Image img)
		{
			Logger.WriteLog("Converting image to byte stream");
			ImageConverter converter = new ImageConverter();
			return (byte[])converter.ConvertTo(img, typeof(byte[]));
		}
	}
}
