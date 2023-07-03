using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ColorInput
{
	internal class ColorDialogAlpha : ColorDialog
	{
		private AlphaInput _alphaInput = new AlphaInput();
		private Panel _panel = new Panel();

		public ColorDialogAlpha() : base()
		{
			FullOpen = true;
		}

		protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
		{
			var r = base.HookProc(hWnd, msg, wparam, lparam);
			if (msg == WM_INITDIALOG)
			{
				var hWndAlpha = _alphaInput.Handle;
				_alphaInput.Bounds = new Rectangle(6, 165, _alphaInput.Width, _alphaInput.Height);
				SetParent(hWndAlpha, hWnd);

				var hWndPanel = _panel.Handle;
				_panel.Bounds = new Rectangle(228, 270, 232, 40);
				SetParent(hWndPanel, hWnd);
			}
			else if (msg == WM_SHOWWINDOW)
			{
				Timeout(15, () =>
				{
					_alphaInput.BringToFront();
					_alphaInput.Refresh();
					_panel.BringToFront();
					_panel.Refresh();
				});
			}
			else if (msg == WM_LBUTTONUP)
			{
				_alphaInput.Refresh();
			}
			//else if (msg == WM_COMMAND || msg == WM_CHAR || msg == WM_LBUTTONDOWN)
			//{
			//	Color = Color.FromArgb(_alphaInput.Alpha, Color);
			//}
			return r;
		}

		public void Timeout(int ms, Action action)
		{
			var timer = new Timer()
			{
				Interval = ms
			};
			timer.Tick += (object sender, EventArgs e) =>
			{
				action();
				timer.Stop();
				timer.Dispose();
			};
			timer.Start();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				if (_alphaInput != null)
					_alphaInput.Dispose();

				if (_panel != null)
					_panel.Dispose();

				_alphaInput = null;
				_panel = null;
			}
		}

		public new DialogResult ShowDialog(IWin32Window owner)
		{
			_alphaInput.Alpha = Color.A;
			var r = base.ShowDialog(owner);
			Color = Color.FromArgb(_alphaInput.Alpha, Color);
			return r;
		}

		[DllImport("user32.dll")]
		private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		private const int WM_INITDIALOG = 0x110;
		private const int WM_SHOWWINDOW = 0x18;
		private const int WM_LBUTTONUP = 0x0202;
		//// messages that indicate a color change:
		//private const int WM_COMMAND = 0x111;
		//private const int WM_CHAR = 0x102;
		//private const int WM_LBUTTONDOWN = 0x201;
	}
}

