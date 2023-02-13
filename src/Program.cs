using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace ScreenCapture
{
	internal static class Program
	{
		public static Hotkey Hotkey;
		public static Mutex mutex;

		[STAThread]
		static void Main()
		{
			mutex = new Mutex(true, "ScreenCapture{27b4fde6-827f-41dd-b0da-c325bc820645}", out var isNewCreated);

			if (isNewCreated)
			{
				Hotkey = new Hotkey
				{
					KeyCode = Keys.Oemtilde,
					Shift = true
				};
				try
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new App());
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error\n{ex.Message}", "Screen Capture", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				Hotkey.Unregister();
			}
			else
			{
				MessageBox.Show("Already launched", "Screen Capture");
			}
		}

		public static Rectangle Inflate(this Rectangle rect, int v)
		{
			return new Rectangle(rect.X - v, rect.Y - v, rect.Width + v * 2, rect.Height + v * 2);
		}
	}
}
