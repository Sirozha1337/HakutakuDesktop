using System;
using System.Drawing;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	public partial class OverlayForm : Form
	{
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
			Program._selectionForm._endPoint = mousePoint;
			Program._selectionForm.RegionSelected();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (mouseDown)
			{
				mousePoint = e.Location;
				Program._selectionForm._endPoint = mousePoint;
				Invalidate();
			}
		}

		public void Clear()
		{
			mouseDown = false;
			mouseDownPoint = mousePoint = new Point();
			this.Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			
			Rectangle window = new Rectangle(
				Math.Min(mouseDownPoint.X, mousePoint.X),
				Math.Min(mouseDownPoint.Y, mousePoint.Y),
				Math.Abs(mouseDownPoint.X - mousePoint.X),
				Math.Abs(mouseDownPoint.Y - mousePoint.Y));
			Region r = new Region(window);
			if (window.Height > 0 && window.Width > 0)
				e.Graphics.FillRegion(Brushes.Red, r);

			if (!Program._selectionForm.Visible)
				Program._selectionForm.Show();

			Program._selectionForm.Refresh();
		}
	}
}
