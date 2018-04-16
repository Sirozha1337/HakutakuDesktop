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
		private Button _translateButton;
		private Button _hideControlsButton;
		private RichTextBox _textArea;
		private ComboBox _srcLangSelector;
		private ComboBox _dstLangSelector;

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
			this.Controls.Add(_translateButton);

			_textArea = new ResizableTextArea();
			_textArea.Multiline = true;
			_textArea.Font = new Font("Arial Unicode MS", 14);
			_textArea.Visible = false;
			_textArea.ReadOnly = true;
			this.Controls.Add(_textArea);
			
			_srcLangSelector = new ComboBox();
			_srcLangSelector.DataSource = new Language[]
			{
				new Language{Code = "eng", Name = "English"},
				new Language{Code = "jap", Name = "Japanese"},
				new Language{Code = "rus", Name = "Russian"}
			};
			_srcLangSelector.DisplayMember = "Name";
			_srcLangSelector.ValueMember = "Code";
			this.Controls.Add(_srcLangSelector);

			_dstLangSelector = new ComboBox();
			_dstLangSelector.DataSource = new Language[]
			{
				new Language{Code = "eng", Name = "English"},
				new Language{Code = "jap", Name = "Japanese"},
				new Language{Code = "rus", Name = "Russian"}
			};
			_dstLangSelector.DisplayMember = "Name";
			_dstLangSelector.ValueMember = "Code";
			this.Controls.Add(_dstLangSelector);

			_hideControlsButton = new Button();
			_hideControlsButton.Text = "X";
			_hideControlsButton.BackColor = Color.Wheat;
			_hideControlsButton.Click += new EventHandler((object sender, EventArgs e) =>
			{
				_textArea.Visible = false;
				ControlsSetState(false);
				CustomApplicationContext._mainForm.Clear();
				this.Refresh();
			});
			this.Controls.Add(_hideControlsButton);

			ControlsSetState(false);
		}

		private void ControlsSetState(bool state)
		{
			_translateButton.Visible = state;
			_srcLangSelector.Visible = state;
			_dstLangSelector.Visible = state;
			_hideControlsButton.Visible = state;
		}

		private async void Translate_ClickAsync(object sender, EventArgs e)
		{
			Logger.WriteLog("Translate Button Clicked");
			if (!RecognitionUtil._engineBusy)
			{
				_textArea.Visible = false;
				int x = Math.Min(_startPoint.X, _endPoint.X);
				int y = Math.Min(_startPoint.Y, _endPoint.Y);
				int width = Math.Abs(_startPoint.X - _endPoint.X);
				int height = Math.Abs(_startPoint.Y - _endPoint.Y);
				string srcLang = (string)_srcLangSelector.SelectedValue;
				string dstLang = (string)_dstLangSelector.SelectedValue;
				string text = await Task.Run(() => RecognitionUtil.Execute(x, y, width, height, srcLang, dstLang));

				Point point = LayoutUtil.GetPositionForTextArea(new Rectangle(x, y, width, height), 400, 200);
				_textArea.Visible = true;
				_textArea.SetBounds(point.X, point.Y, 400, 200);
				_textArea.Text = text;
			}
		}

		public void RegionSelected()
		{
			_repaintSelection = false;
			PaintRegion(this.CreateGraphics());
			ControlsSetState(true);
			int x = Math.Min(_startPoint.X, _endPoint.X);
			int y = Math.Max(_startPoint.Y, _endPoint.Y);
			_translateButton.SetBounds(x, y, 100, 50);
			_srcLangSelector.SetBounds(x + 100, y, 100, 50);
			_dstLangSelector.SetBounds(x + 200, y, 100, 50);
			_hideControlsButton.SetBounds(x + 300, y, 50, 50);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			
			PaintRegion(e.Graphics);

			if (!RecognitionUtil._engineBusy && _repaintSelection)
			{
				_textArea.Visible = false;
				ControlsSetState(false);
			}
		}

		private void PaintRegion(Graphics graphics)
		{
			Rectangle window = new Rectangle(
				Math.Min(_startPoint.X, _endPoint.X),
				Math.Min(_startPoint.Y, _endPoint.Y),
				Math.Abs(_startPoint.X - _endPoint.X),
				Math.Abs(_startPoint.Y - _endPoint.Y));

			Pen pen = new Pen(Brushes.Red);
			if (window.Height > 0 && window.Width > 0)
				graphics.DrawRectangle(pen, window);
		}
	}
}
