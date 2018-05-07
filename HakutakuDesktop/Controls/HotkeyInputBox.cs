using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MovablePython;

namespace HakutakuDesktop.Controls
{
	partial class HotkeyInputBox : TextBox
	{
		#region Properties to hide from the designer
		[Browsable(false)]
		public new string[] Lines { get { return new string[] { Text }; } private set { base.Lines = value; } }
		[Browsable(false)]
		public override bool Multiline { get { return false; } }
		[Browsable(false)]
		public new char PasswordChar { get; set; }
		[Browsable(false)]
		public new ScrollBars ScrollBars { get; set; }
		[Browsable(false)]
		public override bool ShortcutsEnabled { get { return false; } }
		[Browsable(false)]
		public override string Text { get { return base.Text; } set { base.Text = value; } }
		[Browsable(false)]
		public new bool WordWrap { get; set; }
		#endregion
		private Hotkey _hotkey;
		public Hotkey HotKey {
			get
			{
				if (_hotkey == null)
					_hotkey = new Hotkey();
				return _hotkey;
			}
			set
			{
				_hotkey = value;
				this.RefreshText();
			}
		}

		public void Reset()
		{
			HotKey.KeyCode = Keys.None;
			HotKey.Windows = false;
			HotKey.Control = false;
			HotKey.Alt = false;
			HotKey.Shift = false;
		}

		private void RefreshText()
		{
			Text = HotKey.ToString();
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			RefreshText();
			base.OnPaint(e);
		}

		const int WM_KEYDOWN = 0x100;
		const int WM_KEYUP = 0x101;
		const int WM_CHAR = 0x102;
		const int WM_SYSCHAR = 0x106;
		const int WM_SYSKEYDOWN = 0x104;
		const int WM_SYSKEYUP = 0x105;
		const int WM_IME_CHAR = 0x286;

		private int _keysPressed = 0;

		protected override bool ProcessKeyMessage(ref Message m)
		{
			if (m.Msg == WM_KEYUP || m.Msg == WM_SYSKEYUP)
			{
				_keysPressed--;
			}

			if (m.Msg != WM_CHAR && m.Msg != WM_SYSCHAR && m.Msg != WM_IME_CHAR)
			{
				KeyEventArgs e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);

				if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
					this.Reset();
				else
				{
					// Print Screen doesn't seem to be part of WM_KEYDOWN/WM_SYSKEYDOWN...
					if (m.Msg == WM_KEYDOWN || m.Msg == WM_SYSKEYDOWN || e.KeyCode == Keys.PrintScreen)
					{
						// Start over if we had no keys pressed, or have a selection (since it's always select all)
						if (_keysPressed < 1 || SelectionLength > 0)
							this.Reset();

						//if (e.KeyCode )
						//    this.Windows = true;

						HotKey.Control = e.Control;
						HotKey.Shift = e.Shift;
						HotKey.Alt = e.Alt; 

						if (e.KeyCode != Keys.ShiftKey
							&& e.KeyCode != Keys.ControlKey
							&& e.KeyCode != Keys.Menu)
							HotKey.KeyCode = e.KeyCode;

						_keysPressed++;
					}
				}

				// Pretty readable output
				RefreshText();

				// Select the end of our textbox
				Select(TextLength, 0);
			}

			return true;
		}
	}
}