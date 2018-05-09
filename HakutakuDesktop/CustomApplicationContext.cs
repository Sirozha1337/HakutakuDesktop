
using HakutakuDesktop.Util;
using MovablePython;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	class CustomApplicationContext : ApplicationContext
	{
		private static readonly string IconFileName = "logo.ico";
		private static readonly string DefaultTooltip = "Translate any text from screen";

		public static OverlayForm _overlayForm;
		public static SelectionForm _selectionForm;
		public static MainMenu _mainMenu;
		public static CustomApplicationContext _mainContext;

		private static Hotkey _hkToggleOverlay;
		private static Hotkey _hkExitApp;
		/// <summary>
		/// This class should be created and passed into Application.Run( ... )
		/// </summary>
		public CustomApplicationContext()
		{
			InitializeContext();
			BindHotkeys();

			_mainContext = this;
			_overlayForm = new OverlayForm();
			_selectionForm = new SelectionForm();
			
			if(!GlobalConfigurationObject.ShowHelpOnStartUp)
			{
				ShowMain(0);
			}
			_selectionForm.Owner = _overlayForm;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
			notifyIcon.ContextMenuStrip.Items.Clear();
			notifyIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem(resources.GetString("tabPage2.Text"), null, settingsItem_Click));
			notifyIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem(resources.GetString("tabPage1.Text"), null, helpItem_Click));
			notifyIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("&Exit", null, exitItem_Click));
		}
		
		private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = false;
		}

		#region Hotkeys
		public void BindHotkeys()
		{
			UnbindHotkeys();

			_hkToggleOverlay = GlobalConfigurationObject.ToggleOverlayHotkey;
			_hkExitApp = GlobalConfigurationObject.CloseProgramHotkey;

			_hkExitApp.Pressed += delegate { ExitThreadCore(); };
			_hkToggleOverlay.Pressed += delegate { ToggleOverlay(); };

			if (!_hkToggleOverlay.GetCanRegister(notifyIcon.ContextMenuStrip))
			{
				Logger.WriteLog("Unable to register open overlay hotkey.");
			}
			else
			{
				_hkToggleOverlay.Register(notifyIcon.ContextMenuStrip);
			}
			if (!_hkExitApp.GetCanRegister(notifyIcon.ContextMenuStrip))
			{
				Logger.WriteLog("Unable to register open overlay hotkey.");
			}
			else
			{
				_hkExitApp.Register(notifyIcon.ContextMenuStrip);
			}
		}

		private void UnbindHotkeys()
		{
			if (_hkToggleOverlay != null && _hkToggleOverlay.Registered)
			{ _hkToggleOverlay.Unregister(); }
			if (_hkExitApp != null && _hkExitApp.Registered)
			{ _hkExitApp.Unregister(); }
		}
		#endregion

		#region the child forms
		private void ShowMain(int tabIndex)
		{
			if (_mainMenu == null || _mainMenu.IsDisposed)
				_mainMenu = new MainMenu();
			_mainMenu.SelectedTabIndex = tabIndex;
			_mainMenu.Show();
		}

		private void ToggleOverlay()
		{
			if (_overlayForm.Visible)
			{
				DisableOverlay();
			}
			else
			{
				EnableOverlay();
			}
		}

		private void DisableOverlay()
		{
			_overlayForm.Hide();
			_selectionForm.Hide();
		}

		private void EnableOverlay()
		{
			_overlayForm.Show();
			_selectionForm.Show();
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e) { EnableOverlay(); }

		// From http://stackoverflow.com/questions/2208690/invoke-notifyicons-context-menu
		private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
				mi.Invoke(notifyIcon, null);
			}
		}

		#endregion the child forms

		#region generic code framework

		private System.ComponentModel.IContainer components;    // a list of components to dispose when the context is disposed
		private NotifyIcon notifyIcon;                          // the icon that sits in the system tray

		private void InitializeContext()
		{
			components = new System.ComponentModel.Container();
			notifyIcon = new NotifyIcon(components)
			{
				ContextMenuStrip = new ContextMenuStrip(),
				Icon = new Icon(IconFileName),
				Text = DefaultTooltip,
				Visible = true
			};
			notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
			notifyIcon.DoubleClick += notifyIcon_DoubleClick;
			notifyIcon.MouseUp += notifyIcon_MouseUp;
		}

		/// <summary>
		/// When the application context is disposed, dispose things like the notify icon.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null) { components.Dispose(); }
		}

		/// <summary>
		/// When the help button pressed, open form with help.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void helpItem_Click(object sender, EventArgs e)
		{
			ShowMain(0);
		}

		/// <summary>
		/// When the settings button pressed, open form with settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void settingsItem_Click(object sender, EventArgs e)
		{
			ShowMain(1);
		}

		/// <summary>
		/// When the exit menu item is clicked, make a call to terminate the ApplicationContext.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitItem_Click(object sender, EventArgs e)
		{
			ExitThread();
		}

		/// <summary>
		/// If we are presently showing a form, clean it up.
		/// </summary>
		protected override void ExitThreadCore()
		{
			// Unregister hotkeys
			UnbindHotkeys();
			// before we exit, let forms clean themselves up.
			if (_overlayForm != null) { _overlayForm.Close(); }
			if (_selectionForm != null) { _selectionForm.Close(); }
			if (_mainMenu != null) { _mainMenu.Close(); }
			
			notifyIcon.Visible = false; // should remove lingering tray icon
			base.ExitThreadCore();
		}

		#endregion generic code framework
	}
}
