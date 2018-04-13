using System;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;
using HakutakuDesktop.Util;

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
			this.Left = 0;
			this.Top = 0;
			Width = Screen.PrimaryScreen.Bounds.Width;
			Height = Screen.PrimaryScreen.Bounds.Height;
			_engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
			Logger.WriteLog(String.Format("Overlay form initialized. Width: {0}. Height: {1}. Left: {2}. Top: {3}", Width, Height, Left, Top));
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
		
		void Execute(Point point1, Point point2)
		{
			Logger.WriteLog("Start text recognition");
			if (!this.executing)
			{
				this.executing = true;
				if (point1.X != point2.X && point1.Y != point2.Y)
				{
					var sc = ImageUtil.GetScreenCapture(point1, point2);
					using (var img = PixConverter.ToPix(sc))
					{
						using (var page = _engine.Process(img))
						{
							Program._selectionForm.SetPage(
								TesseractUtil.ProccessPage(page),
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
				Logger.WriteLog("Finish text recognition");
			}
		}
	}
}
