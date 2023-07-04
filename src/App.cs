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
		public int PicturesCount { get => _pictures.Count; }
		private readonly List<FormPicture> _pictures = new List<FormPicture>();
		private readonly ToolStripMenuItem _itemCloseAll;
		private readonly ToolStripMenuItem _itemHideAll;
		private readonly ToolStripMenuItem _itemOpenedCount;
		private FormCapture _formCapture;
		private FormPicturePalette _formPicturePalette;
		private FormSettings _formSettings;
		private FormAbout _formAbout;
		private int VisiblePictures { get => _pictures.Count(p => p.Visible); }
		private bool[] _pictureVisibility = new bool[0];
		private bool _allWasHidden;

		public App()
		{
			Ins = this;
			_itemCloseAll = new ToolStripMenuItem("Close all", Resources.stop, CloseAll);
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
						_itemCloseAll,
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
			TrayIcon.ContextMenuStrip.Opened += ContextMenuStrip_Opened;

			Program.Hotkey.Pressed += Hotkey_Pressed;
			var r = Program.Hotkey.TryRegister();
			if (!r)
				TrayIcon.ShowBalloonTip(500, "Register Hotkey", $"Cannot register hotkey: {Program.Hotkey}", ToolTipIcon.Error);
			
			Program.HotkeyPalette.Pressed += HotkeyPalette_Pressed;
			r = Program.HotkeyPalette.TryRegister();
			if (!r)
				TrayIcon.ShowBalloonTip(500, "Register Hotkey", $"Cannot register hotkey: {Program.HotkeyPalette}", ToolTipIcon.Error);
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

		public IEnumerable<FormPicture> GetPictures()
		{
			return _pictures.AsEnumerable();
		}

		public FormPicture GetPicture(int i)
		{
			return _pictures[i];
		}


		private void UpdateOpenedCount()
		{
			_itemOpenedCount.Text = $"Pictures: {VisiblePictures}/{_pictures.Count}";
		}

		private void Hotkey_Pressed(object sender, System.ComponentModel.HandledEventArgs e)
		{
			if (_formSettings?.ChangingHotkey != true)
			{
				Capture();
			}
		}

		private void HotkeyPalette_Pressed(object sender, System.ComponentModel.HandledEventArgs e)
		{
			if (_formSettings?.ChangingHotkey != true)
			{
				if (_formPicturePalette == null || _formPicturePalette.IsDisposed)
				{
					_formPicturePalette = new FormPicturePalette();
					_formPicturePalette.Show();
				}
				else
				{
					_formPicturePalette.Close();
				}
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
				_formCapture.Close();
				return;
			}
			_allWasHidden = VisiblePictures == 0;
			if (!_allWasHidden)
				_pictureVisibility = _pictures.Select(p => p.Visible).ToArray();
			HidePictures();
			_formCapture = new FormCapture();
			_formCapture.FormClosing += (object sender, FormClosingEventArgs e) =>
			{
				if (_formCapture.PictureCaptured || _allWasHidden)
					ShowSelectedPictures();
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

		void TogglePicturesVisibility(object sender, EventArgs e)
		{
			if (VisiblePictures == 0) ShowPictures();
			else HidePictures();
		}
		void HidePictures()
		{
			_pictures.ForEach(f => f.Hide());
		}
		void ShowPictures()
		{
			_pictures.ForEach(f => f.Show());
		}
		void ShowSelectedPictures()
		{
			for (int i = 0; i < Math.Min(_pictures.Count, _pictureVisibility.Length); i++)
			{
				if (_pictureVisibility[i])
					_pictures[i].Show();
			}
		}

		private void ContextMenuStrip_Opened(object sender, EventArgs e)
		{
			var anyPictures = _pictures.Count > 0;
			_itemCloseAll.Enabled = anyPictures;
			_itemHideAll.Enabled = anyPictures;
			SetShowHideItem(VisiblePictures == 0);
			UpdateOpenedCount();
		}

		private void SetShowHideItem(bool hidden)
		{
			if (hidden)
			{
				_itemHideAll.Text = "Show all";
				_itemHideAll.Image = Resources.show;
			}
			else
			{
				_itemHideAll.Text = "Hide all";
				_itemHideAll.Image = Resources.hide;
			}
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
