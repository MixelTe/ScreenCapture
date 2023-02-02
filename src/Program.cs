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
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new App());
		}

		public static Rectangle Inflate(this Rectangle rect, int v)
		{
			return new Rectangle(rect.X - v, rect.Y - v, rect.Width + v * 2, rect.Height + v * 2);
		}
	}
}
