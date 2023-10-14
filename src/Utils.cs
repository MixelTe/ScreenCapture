using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

		public static Point Divide(this Point point, double v)
		{
			return new Point((int)Math.Round(point.X / v), (int)Math.Round(point.Y / v));
		}

		public static Point Add(this Point point, int dx, int dy)
		{
			return new Point(point.X + dx, point.Y + dy);
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

		public static Color MakeOpaque(this Color color)
		{
			return Color.FromArgb(255, color.R, color.G, color.B);
		}

		public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
		{
			int diameter = radius * 2;
			Size size = new Size(diameter, diameter);
			Rectangle arc = new Rectangle(bounds.Location, size);
			GraphicsPath path = new GraphicsPath();

			if (radius == 0)
			{
				path.AddRectangle(bounds);
				return path;
			}

			// top left arc  
			path.AddArc(arc, 180, 90);

			// top right arc  
			arc.X = bounds.Right - diameter;
			path.AddArc(arc, 270, 90);

			// bottom right arc  
			arc.Y = bounds.Bottom - diameter;
			path.AddArc(arc, 0, 90);

			// bottom left arc 
			arc.X = bounds.Left;
			path.AddArc(arc, 90, 90);

			path.CloseFigure();
			return path;
		}

		public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
		{
			if (graphics == null)
				throw new ArgumentNullException("graphics");
			if (pen == null)
				throw new ArgumentNullException("pen");

			using (var path = RoundedRect(bounds, cornerRadius))
			{
				graphics.DrawPath(pen, path);
			}
		}

		public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
		{
			if (graphics == null)
				throw new ArgumentNullException("graphics");
			if (brush == null)
				throw new ArgumentNullException("brush");

			using (var path = RoundedRect(bounds, cornerRadius))
			{
				graphics.FillPath(brush, path);
			}
		}
	}
}
