
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace HakutakuDesktop
{
	class CustomApplicationContext : ApplicationContext
	{
		// Icon graphic from http://prothemedesign.com/circular-icons/
		private static readonly string IconFileName = "logo.ico";
		private static readonly string DefaultTooltip = "Translate any text from screen";

		public static OverlayForm _mainForm;
		public static SelectionForm _selectionForm;

		/// <summary>
		/// This class should be created and passed into Application.Run( ... )
		/// </summary>
		public CustomApplicationContext()
		{
			InitializeContext();
			_mainForm = new OverlayForm();
			_selectionForm = new SelectionForm();
			_selectionForm.Owner = _mainForm;
			InterceptKeys.SetCallback(HotKey);
			notifyIcon.ContextMenuStrip.Items.Clear();
			notifyIcon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("&Exit", null, exitItem_Click));
		}


		private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = false;
		}

		#region the child forms

		private void HotKey(Keys key)
		{
			if (key == Keys.F7)
			{
				if (_mainForm.Visible)
				{
					DisableOverlay();
				}
				else
				{
					EnableOverlay();
				}
			}
			if (key == Keys.F6)
			{
				Logger.WriteLog("Exiting app");
				Application.Exit();
			}
		}

		private void DisableOverlay()
		{
			Logger.WriteLog("Disabling overlay");
			_mainForm.Hide();
			_selectionForm.Hide();
		}

		private void EnableOverlay()
		{
			Logger.WriteLog("Showing overlay");
			_mainForm.Show();
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
			// before we exit, let forms clean themselves up.
			if (_mainForm != null) { _mainForm.Close(); }
			if (_selectionForm != null) { _selectionForm.Close(); }

			notifyIcon.Visible = false; // should remove lingering tray icon
			base.ExitThreadCore();
		}

		#endregion generic code framework
	}
}
