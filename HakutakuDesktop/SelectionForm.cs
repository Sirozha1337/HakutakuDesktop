using HakutakuDesktop.Util;
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
		private Button _translateButton;

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

			_translateButton = new Button();
			_translateButton.BackColor = Color.Wheat;
			_translateButton.Text = "Translate";
			_translateButton.Click += new EventHandler(Translate_Click);
			_translateButton.Visible = false;
			this.Controls.Add(_translateButton);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

		}

		private void Translate_Click(object sender, EventArgs e)
		{
			Logger.WriteLog("Translate Button Clicked");
			if (!RecognitionUtil._engineBusy)
			{
				int x = Math.Min(_startPoint.X, _endPoint.X);
				int y = Math.Min(_startPoint.Y, _endPoint.Y);
				int width = Math.Abs(_startPoint.X - _endPoint.X);
				int height = Math.Abs(_startPoint.Y - _endPoint.Y);

				SetPage(
					RecognitionUtil.Execute(x, y, width, height, "en", "ru"),
					x,
					y,
					width,
					height
				);
			}
		}

		public void RegionSelected()
		{
			_translateButton.Visible = true;
			_translateButton.SetBounds(_startPoint.X, Math.Max(_startPoint.Y, _endPoint.Y), 100, 100);

			_repaintSelection = false;
		}

		public void SetPage(TextOverlay[] page, int x, int y, int width, int height)
		{
			_page = page;
			_pageRectangle = new Rectangle(x, y, width, height);
			this.Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (_repaintSelection)
			{
				_page = null;
				Region r = new Region(e.ClipRectangle);

				Rectangle window = new Rectangle(
					Math.Min(_startPoint.X, _endPoint.X),
					Math.Min(_startPoint.Y, _endPoint.Y),
					Math.Abs(_startPoint.X - _endPoint.X),
					Math.Abs(_startPoint.Y - _endPoint.Y));

				Pen pen = new Pen(Brushes.Red);
				if (window.Height > 0 && window.Width > 0)
					e.Graphics.DrawRectangle(pen, window);
			}

			if(_page != null)
			{
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
