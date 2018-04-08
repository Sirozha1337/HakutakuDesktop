using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace HakutakuDesktop
{
	public partial class OverlayForm : Form
	{
		private TesseractEngine _engine;
		private bool executing = false;
		bool mouseDown = false;
		Point mouseDownPoint = Point.Empty;
		Point mousePoint = Point.Empty;

		public OverlayForm()
		{
			InitializeComponent();
			TopMost = true;
			ShowInTaskbar = false;
			FormBorderStyle = FormBorderStyle.None;
			BackColor = Color.LightGreen;
			TransparencyKey = Color.Red;
			Opacity = 0.1;
			Width = Screen.PrimaryScreen.Bounds.Width;
			Height = Screen.PrimaryScreen.Bounds.Height;
			_engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			mouseDown = true;
			mousePoint = mouseDownPoint = e.Location;
			Program._selectionForm._startPoint = mouseDownPoint;
			Program._selectionForm._repaintSelection = mouseDown;
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			mouseDown = false;
			Program._selectionForm._repaintSelection = false;
			Execute(mouseDownPoint, mousePoint);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			mousePoint = e.Location;
			Program._selectionForm._endPoint = mousePoint;
			if(mouseDown)
				Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (mouseDown)
			{
				Rectangle window = new Rectangle(
					Math.Min(mouseDownPoint.X, mousePoint.X),
					Math.Min(mouseDownPoint.Y, mousePoint.Y),
					Math.Abs(mouseDownPoint.X - mousePoint.X),
					Math.Abs(mouseDownPoint.Y - mousePoint.Y));
				Region r = new Region(window);
				if (window.Height > 0 && window.Width > 0)
					e.Graphics.FillRegion(Brushes.Red, r);
			}

			if (!Program._selectionForm.Visible)
				Program._selectionForm.Show();
			Program._selectionForm.Refresh();
		}
		
		Bitmap GetScreenCapture(Point point1, Point point2)
		{
			int x = Math.Min(point1.X, point2.X);
			int y = Math.Min(point1.Y, point2.Y);
			int width = Math.Abs(point1.X - point2.X);
			int height = Math.Abs(point1.Y - point2.Y);
			Rectangle bounds = new Rectangle(x, y, width, height);
			Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				g.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
			}
			return bitmap;
		}

		public static byte[] ImageToByte(Image img)
		{
			ImageConverter converter = new ImageConverter();
			return (byte[])converter.ConvertTo(img, typeof(byte[]));
		}

		void Execute(Point point1, Point point2)
		{
			System.Diagnostics.Debug.WriteLine("Start executing " + executing);
			if (!this.executing)
			{
				this.executing = true;
				if (point1.X != point2.X && point1.Y != point2.Y)
				{
					var sc = GetScreenCapture(point1, point2);
					using (var img = PixConverter.ToPix(sc))
					{
						using (var page = _engine.Process(img))
						{
							Program._selectionForm.SetPage(
								ProccessPage(page),
								Math.Min(point1.X, point2.X),
								Math.Min(point1.Y, point2.Y),
								Math.Abs(point1.X - point2.X),
								Math.Abs(point1.Y - point2.Y)
							);
							Program._selectionForm.Refresh();
						}
					}
				}
				this.executing = false;
				System.Diagnostics.Debug.WriteLine("Finish executing " + executing);
			}
		}

		TextOverlay[] ProccessPage(Page page)
		{
			List<TextOverlay> textOverlays = new List<TextOverlay>();
			using (var iter = page.GetIterator())
			{
				do
				{
					string text = iter.GetText(PageIteratorLevel.TextLine);
					var t = iter.GetProperties();
					if (!string.IsNullOrEmpty(text))
					{
						string translatedText = text;
						Rect rect;
						if (iter.TryGetBoundingBox(PageIteratorLevel.TextLine, out rect))
						{
							textOverlays.Add(new TextOverlay
							{
								x = rect.X1,
								y = rect.Y1,
								ySize = Math.Abs(rect.Y1 - rect.Y2),
								Text = translatedText
							});
						}
						Console.WriteLine(translatedText);
					}
				} while (iter.Next(PageIteratorLevel.TextLine));
			}
			return textOverlays.ToArray();
		}
	}
}
