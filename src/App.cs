using ScreenCapture.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
	internal class App : ApplicationContext
	{
		private readonly NotifyIcon _trayIcon;

		public App()
		{
			_trayIcon = new NotifyIcon()
			{
				Icon = Resources.AppIcon,
				ContextMenuStrip = new ContextMenuStrip()
				{
					Items = { 
						new ToolStripMenuItem("Exit", Resources.close, Exit),
					}
				},
				Visible = true
			};
			_trayIcon.Click += TrayIcon_Click;
		}

		private void TrayIcon_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Left)
			{
				var form = new FormCapture();
				form.Show();
			}
		}

		void Exit(object sender, EventArgs e)
		{
			_trayIcon.Visible = false;

			Application.Exit();
		}
	}
}
