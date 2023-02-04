using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenCapture
{
	internal static class Program
	{
		public static Hotkey Hotkey = new Hotkey
		{
			KeyCode = Keys.Oemtilde,
			Shift = true
		};
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
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

		public static Rectangle Inflate(this Rectangle rect, int v)
		{
			return new Rectangle(rect.X - v, rect.Y - v, rect.Width + v * 2, rect.Height + v * 2);
		}
	}
}
