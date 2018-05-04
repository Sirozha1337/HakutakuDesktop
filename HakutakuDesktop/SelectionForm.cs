using HakutakuDesktop.Util;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using HakutakuDesktop.Controls;
using System.Collections.Generic;

namespace HakutakuDesktop
{
	public partial class SelectionForm : Form
	{
		public Point _startPoint;
		public Point _endPoint;
		public bool _repaintSelection;
		private Button _translateButton;
		private ComboBox _srcLangSelector;
		private ComboBox _dstLangSelector;
		private LoadingCircle _loadingCircle;
		private List<TextDisplay> textDisplays = new List<TextDisplay>();
		private bool selectionChanged = false;

		public SelectionForm()
		{
			InitializeComponent();
			TopMost = true;
			ShowInTaskbar = false;
			FormBorderStyle = FormBorderStyle.None;
			BackColor = Color.LightGray;
			TransparencyKey = Color.LightGray;
			Left = 0;
			Top = 0;
			Width = LayoutUtil.ScreenWidth;
			Height = LayoutUtil.ScreenHeight;
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

			_translateButton = new Button();
			_translateButton.BackColor = Color.Wheat;
			_translateButton.Text = "Translate";
			_translateButton.Click += new EventHandler(Translate_ClickAsync);
			this.Controls.Add(_translateButton);
			
			_srcLangSelector = new ComboBox();
			_srcLangSelector.DataSource = new Language[]
			{
				new Language{Code = "eng", Name = "English"},
				new Language{Code = "jap", Name = "Japanese"},
				new Language{Code = "rus", Name = "Russian"},
				new Language{Code = "comic", Name = "Comic"}
			};
			_srcLangSelector.DisplayMember = "Name";
			_srcLangSelector.ValueMember = "Code";
			this.Controls.Add(_srcLangSelector);

			_dstLangSelector = new ComboBox();
			_dstLangSelector.DataSource = new Language[]
			{
				new Language{Code = "eng", Name = "English"},
				new Language{Code = "jap", Name = "Japanese"},
				new Language{Code = "rus", Name = "Russian"},
				new Language{Code = "comic", Name = "Comic"}
			};
			_dstLangSelector.DisplayMember = "Name";
			_dstLangSelector.ValueMember = "Code";
			this.Controls.Add(_dstLangSelector);

			_loadingCircle = new LoadingCircle();
			_loadingCircle.Active = false;
			_loadingCircle.BackColor = Color.White;
			_loadingCircle.Color = Color.Black;
			_loadingCircle.ForeColor = SystemColors.HotTrack;
			_loadingCircle.InnerCircleRadius = 15;
			_loadingCircle.Location = new Point(151, 138);
			_loadingCircle.Name = "loadingCircle";
			_loadingCircle.NumberSpoke = 12;
			_loadingCircle.OuterCircleRadius = 30;
			_loadingCircle.RotationSpeed = 80;
			_loadingCircle.SpokeThickness = 2;
			_loadingCircle.StylePreset = LoadingCircle.StylePresets.MacOSX;
			_loadingCircle.TabIndex = 14;
			_loadingCircle.Text = "loadingCircle";
			_loadingCircle.Visible = false;
			this.Controls.Add(_loadingCircle);

			ControlsSetState(false);
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			foreach (var txt in textDisplays)
				if (!txt.IsDisposed)
					if (this.Visible)
						txt.Show();
					else
						txt.Hide();
		}

		private void RemoveGarbageText()
		{
			for (int i = 0; i < textDisplays.Count; i++)
			{
				if (textDisplays[i].IsDisposed)
				{
					textDisplays.Remove(textDisplays[i]);
					i--;
				}
			}
		}

		private void ShowText(string text, int x, int y, int width, int height, bool showInPrevious)
		{
			if (!(showInPrevious && !textDisplays[textDisplays.Count - 1].IsDisposed))
			{
				var textDisplay = new TextDisplay(text, x, y, width, height);
				textDisplay.Owner = this;
				textDisplay.Show();
				textDisplays.Add(textDisplay);
			}
			else
				textDisplays[textDisplays.Count - 1].SetText(text);
			RemoveGarbageText();
		}

		private void ControlsSetState(bool state)
		{
			_translateButton.Visible = state;
			_srcLangSelector.Visible = state;
			_dstLangSelector.Visible = state;
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
				string srcLang = (string)_srcLangSelector.SelectedValue;
				string dstLang = (string)_dstLangSelector.SelectedValue;

				_loadingCircle.Visible = true;
				_loadingCircle.BringToFront();
				Point buttonLocation = _translateButton.Location;
				_loadingCircle.Size = new Size(width, height);
				_loadingCircle.SetBounds(buttonLocation.X, buttonLocation.Y, _translateButton.Width, _translateButton.Height);
				_loadingCircle.Active = true;

				string text = await Task.Run(() => RecognitionUtil.Execute(x, y, width, height, srcLang, dstLang));

				Point point = LayoutUtil.GetPositionForTextArea(new Rectangle(x, y, width, height), 400, 200);
				ShowText(text, point.X, point.Y, Math.Max(width, 400), Math.Max(height, 200), selectionChanged);

				_loadingCircle.Visible = false;
				_loadingCircle.Active = false;
				selectionChanged = true;
			}
		}

		public void RegionSelected()
		{
			selectionChanged = false;
			_repaintSelection = false;
			ControlsSetState(true);
			int x = Math.Max(_startPoint.X, _endPoint.X);
			int y = Math.Max(_startPoint.Y, _endPoint.Y);
			_translateButton.SetBounds(x - 100, y, 100, 50);
			_srcLangSelector.SetBounds(x - 300, y, 100, 50);
			_dstLangSelector.SetBounds(x - 200, y, 100, 50);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			
			PaintRegion(e.Graphics);

			if (!RecognitionUtil._engineBusy && _repaintSelection)
			{
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
