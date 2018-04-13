using System;
using System.Drawing;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	public class TextOverlay
	{
		public int x;
		public int y;
		public string Text;
		public int ySize;
	}

	public partial class SelectionForm : Form
	{
		public Point _startPoint;
		public Point _endPoint;
		public bool _repaintSelection;
		private TextOverlay[] _page;
		private Rectangle _pageRectangle;

		public SelectionForm()
		{
			InitializeComponent();
			TopMost = true;
			ShowInTaskbar = false;
			FormBorderStyle = FormBorderStyle.None;
			BackColor = Color.LightGreen;
			TransparencyKey = Color.LightGreen;
			Width = Screen.PrimaryScreen.Bounds.Width;
			Height = Screen.PrimaryScreen.Bounds.Height;
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
		}

		public void SetPage(TextOverlay[] page, int x, int y, int width, int height)
		{
			_page = page;
			_pageRectangle = new Rectangle(x, y, width, height);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Console.WriteLine("Repaint selection? " + _startPoint + " " + _endPoint);
			if (_repaintSelection)
			{
				_page = null;
				Region r = new Region(e.ClipRectangle);
				Console.WriteLine(e.ClipRectangle);
				Rectangle window = new Rectangle(
					Math.Min(_startPoint.X, _endPoint.X),
					Math.Min(_startPoint.Y, _endPoint.Y),
					Math.Abs(_startPoint.X - _endPoint.X),
					Math.Abs(_startPoint.Y - _endPoint.Y));
				//r.Xor(window);
				Pen pen = new Pen(Brushes.Red);
				if (window.Height > 0 && window.Width > 0)
					e.Graphics.DrawRectangle(pen, window);
			}

			if(_page != null)
			{
				Console.WriteLine("Repainting text");

				e.Graphics.FillRegion(Brushes.White, new Region(_pageRectangle));

				foreach (var line in _page)
				{
					int x = line.x + Math.Min(_pageRectangle.X, _pageRectangle.X);
					int y = line.y + Math.Min(_pageRectangle.Y, _pageRectangle.Y);
					Font drawFont = new Font("Arial", line.ySize);
					e.Graphics.DrawString(
										line.Text,
										drawFont, 
										Brushes.Black, 
										x,
										y);
					drawFont.Dispose();
				}
			}
		}
	}
}
