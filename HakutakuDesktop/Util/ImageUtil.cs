using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HakutakuDesktop.Util
{
	public static class ImageUtil
	{
		public static Bitmap GetScreenCapture(int x, int y, int width, int height)
		{
			Logger.WriteLog("Start screen capture");
			
			width -= 1;
			height -= 1;

			Logger.WriteLog(String.Format("Capturing screen at specified location: {0}, {1}", x, y));

			Rectangle bounds = new Rectangle(x, y, width, height);
			Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				g.CopyFromScreen(bounds.Left + 1, bounds.Top + 1, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
			}

			Logger.WriteLog("Screen captured");

			bitmap.Save("captured_image.png");

			return bitmap;
		}

		public static Bitmap MagnifyBitmap(Bitmap original, int scaleFactor)
		{
			float width = original.Width * scaleFactor;
			float height = original.Height * scaleFactor;
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
				graphics.DrawImage(original, ((int)width - scaleWidth) / scaleFactor, ((int)height - scaleHeight) / scaleFactor, scaleWidth, scaleHeight);
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
