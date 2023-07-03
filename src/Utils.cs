using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture
{
	static internal class Utils
	{
		public static Rectangle Inflate(this Rectangle rect, int v)
		{
			return new Rectangle(rect.X - v, rect.Y - v, rect.Width + v * 2, rect.Height + v * 2);
		}
		public static Rectangle Inflate(this Rectangle rect, double vd)
		{
			var v = (int)Math.Round(vd);
			return new Rectangle(rect.X - v, rect.Y - v, rect.Width + v * 2, rect.Height + v * 2);
		}

		public static Size Multiply(this Size size, double v)
		{
			return new Size((int)Math.Round(size.Width * v), (int)Math.Round(size.Height * v));
		}

		public static Point Divide(this Point size, double v)
		{
			return new Point((int)Math.Round(size.X / v), (int)Math.Round(size.Y / v));
		}

		public static int Min(this Size size)
		{
			return Math.Min(size.Width, size.Height);
		}

		public static int Max(this Size size)
		{
			return Math.Max(size.Width, size.Height);
		}

		public static int MinMax(this int value, Point minMax)
		{
			return Math.Min(Math.Max(value, minMax.X), minMax.Y);
		}
	}
}
