using ScreenCapture.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
	internal class App : ApplicationContext
	{
		public static App Ins;
		public readonly NotifyIcon TrayIcon;
		private readonly List<FormPicture> _pictures = new List<FormPicture>();
		private readonly ToolStripMenuItem _itemHideAll;
		private readonly ToolStripMenuItem _itemOpenedCount;
		private bool _hideAll = false;
		private FormCapture _formCapture;
		private FormSettings _formSettings;
		private FormAbout _formAbout;

		public App()
		{
			Ins = this;
			_itemHideAll = new ToolStripMenuItem("Hide all", Resources.hide, TogglePicturesVisibility);
			_itemOpenedCount = new ToolStripMenuItem("") { Enabled = false };
			UpdateOpenedCount();
			TrayIcon = new NotifyIcon()
			{
				Icon = Resources.AppIcon,
				ContextMenuStrip = new ContextMenuStrip()
				{
					Items = {
						new ToolStripMenuItem("Settings", Resources.settings, OpenSettings),
						new ToolStripMenuItem("Close all", Resources.stop, CloseAll),
						_itemHideAll,
						_itemOpenedCount,
						new ToolStripSeparator(),
						new ToolStripMenuItem("About", null, OpenAbout),
						new ToolStripMenuItem("Quit", Resources.close, Quit),
					}
				},
				Visible = true,
				Text = $"Screen Capture v{Application.ProductVersion}"
			};
			TrayIcon.Click += TrayIcon_Click;

			Program.Hotkey.Pressed += Hotkey_Pressed;
			var r = Program.Hotkey.TryRegister();
			if (!r)
				TrayIcon.ShowBalloonTip(500, "Register Hotkey", "Cannot register hotkey", ToolTipIcon.Error);
		}

		public void RegisterPicture(FormPicture picture)
		{
			_pictures.Add(picture);
			UpdateOpenedCount();
		}

		public void UnregisterPicture(FormPicture picture)
		{
			_pictures.Remove(picture);
			UpdateOpenedCount();
		}

		private void UpdateOpenedCount()
		{
			_itemOpenedCount.Text = $"Pictures: {_pictures.Count}";
		}

		private void Hotkey_Pressed(object sender, System.ComponentModel.HandledEventArgs e)
		{
			if (_formSettings?.ChangingHotkey != true)
			{
				Capture();
			}
		}

		private void TrayIcon_Click(object sender, EventArgs e)
		{
			var me = (e as MouseEventArgs);
			if (me.Button == MouseButtons.Left)
			{
				Capture();
			}
			else if (me.Button == MouseButtons.Middle)
			{
				var image = Clipboard.GetImage();
				if (image != null)
				{
					var location = new Point(Cursor.Position.X - image.Width / 2, Cursor.Position.Y - image.Height - 10);
					var form = new FormPicture(new Bitmap(image), location);
					form.Show();
				}
				else
				{
					TrayIcon.ShowBalloonTip(500, "Open image", "No image in clipboard!", ToolTipIcon.Error);
				}
			}
		}

		void Capture()
		{
			if (_formCapture != null && !_formCapture.IsDisposed)
			{
				TogglePicturesVisibility();
				_formCapture.Close();
				return;
			}
			_pictures.ForEach(f => f.Hide());
			_formCapture = new FormCapture();
			_formCapture.FormClosing += (object sender, FormClosingEventArgs e) =>
			{
				if (_formCapture.PictureCaptured || !_hideAll)
					ShowPictures();
			};
			_formCapture.Show();
		}

		void Quit(object sender, EventArgs e)
		{
			TrayIcon.Visible = false;

			Application.Exit();
		}

		void CloseAll(object sender, EventArgs e)
		{
			for (int i = _pictures.Count - 1; i >= 0; i--)
			{
				_pictures[i].Close();
			}
		}

		void OpenSettings(object sender, EventArgs e)
		{
			if (_formSettings == null || _formSettings.IsDisposed)
			{
				_formSettings = new FormSettings();
				_formSettings.Show();
			}
			else
			{
				_formSettings.Focus();
			}
		}

		void TogglePicturesVisibility(object sender, EventArgs e) => TogglePicturesVisibility();
		void TogglePicturesVisibility()
		{
			if (_hideAll) ShowPictures();
			else HidePictures();
		}
		void HidePictures()
		{
			_hideAll = true;
			_pictures.ForEach(f => f.Hide());
			_itemHideAll.Text = "Show all";
			_itemHideAll.Image = Resources.show;
		}
		void ShowPictures()
		{
			_hideAll = false;
			_pictures.ForEach(f => f.Show());
			_itemHideAll.Text = "Hide all";
			_itemHideAll.Image = Resources.hide;
		}

		void OpenAbout(object sender, EventArgs e)
		{
			if (_formAbout == null || _formAbout.IsDisposed)
			{
				_formAbout = new FormAbout();
				_formAbout.Show();
			}
			else
			{
				_formAbout.Focus();
			}
		}
	}
}
