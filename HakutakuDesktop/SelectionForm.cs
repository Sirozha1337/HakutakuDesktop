using HakutakuDesktop.Util;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	public partial class SelectionForm : Form
	{
		public Point _startPoint;
		public Point _endPoint;
		public bool _repaintSelection;
		private string _page;
		private Rectangle _pageRectangle;
		private Button _translateButton;
		private RichTextBox _textArea;

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
			_translateButton.Click += new EventHandler(Translate_ClickAsync);
			_translateButton.Visible = false;
			this.Controls.Add(_translateButton);

			_textArea = new RichTextBox();
			_textArea.Multiline = true;
			_textArea.Visible = false;
			_textArea.Font = new Font("Arial", 14);
			this.Controls.Add(_textArea);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

		}

		private async void Translate_ClickAsync(object sender, EventArgs e)
		{
			Logger.WriteLog("Translate Button Clicked");
			if (!RecognitionUtil._engineBusy)
			{
				int x = Math.Min(_startPoint.X, _endPoint.X);
				int y = Math.Min(_startPoint.Y, _endPoint.Y);
				int width = Math.Abs(_startPoint.X - _endPoint.X);
				int height = Math.Abs(_startPoint.Y - _endPoint.Y);
				string text = await Task.Run(() => RecognitionUtil.Execute(x, y, width, height, "en", "ru"));
				
				_textArea.Visible = true;
				_textArea.SetBounds(x, y, width, height);
				_textArea.Text = text;
			}
		}

		public void RegionSelected()
		{
			_translateButton.Visible = true;
			_translateButton.SetBounds(_startPoint.X, Math.Max(_startPoint.Y, _endPoint.Y), 100, 100);

			_repaintSelection = false;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (_repaintSelection)
			{
				_textArea.Visible = false;
				_translateButton.Visible = false;

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
		}
	}
}
