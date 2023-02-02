﻿using ScreenCapture.Properties;
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
		public readonly List<Form> Pictures = new List<Form>();
		private bool _hideAll = false;
		private ToolStripMenuItem _itemHideAll;

		public App()
		{
			Ins = this;
			_itemHideAll = new ToolStripMenuItem("Hide all", Resources.hide, HideAll);
			TrayIcon = new NotifyIcon()
			{
				Icon = Resources.AppIcon,
				ContextMenuStrip = new ContextMenuStrip()
				{
					Items = { 
						new ToolStripMenuItem("Exit", Resources.close, Exit),
						new ToolStripMenuItem("Close all", Resources.stop, CloseAll),
						_itemHideAll,
					}
				},
				Visible = true,
				Text = "Screen Capture v1.1"
			};
			TrayIcon.Click += TrayIcon_Click;
		}

		private void TrayIcon_Click(object sender, EventArgs e)
		{
			var me = (e as MouseEventArgs);
			if (me.Button == MouseButtons.Left)
			{
				Pictures.ForEach(f => f.Hide());
				var form = new FormCapture();
				Pictures.ForEach(f => f.Show());
				_hideAll = false;
				_itemHideAll.Text = "Hide all";
				_itemHideAll.Image = Resources.hide;
				form.Show();
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

		void Exit(object sender, EventArgs e)
		{
			TrayIcon.Visible = false;

			Application.Exit();
		}

		void CloseAll(object sender, EventArgs e)
		{
			for (int i = Pictures.Count - 1; i >= 0; i--)
			{
				Pictures[i].Close();
			}
		}

		void HideAll(object sender, EventArgs e)
		{
			_hideAll = !_hideAll;
			if (_hideAll)
			{
				Pictures.ForEach(f => f.Hide());
				_itemHideAll.Text = "Show all";
				_itemHideAll.Image = Resources.show;
			}
			else
			{
				Pictures.ForEach(f => f.Show());
				_itemHideAll.Text = "Hide all";
				_itemHideAll.Image = Resources.hide;
			}
		}
	}
}
