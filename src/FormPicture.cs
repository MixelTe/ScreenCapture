using ScreenCapture.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScreenCapture
{
	public partial class FormPicture : Form
	{
		private readonly static Icon _iconPencil = Resources.pencil;
		private readonly static Icon _iconCircle = Resources.circle;
		private readonly static Cursor _pencil = new Cursor(_iconPencil.Handle);
		private readonly static Cursor _circle = new Cursor(_iconCircle.Handle);
		private readonly Bitmap _picture;
		private readonly Bitmap _drawings;
		private readonly Pen _pen;
		private bool _dragging = false;
		private int _drawing = 0;
		private Point _dragDif;
		private Point _lastPos;

		public FormPicture(Bitmap picture, Point location)
		{
			_picture = picture.Clone(new Rectangle(Point.Empty, picture.Size), picture.PixelFormat);
			InitializeComponent();						 
			Location = location;						 
			Size = picture.Size;						 
			if (Program.Settings.DrawBorder)
				DrawBorder(picture);
			BackgroundImage = picture;

			_drawings = new Bitmap(picture.Size.Width, picture.Size.Height);
			PictureDraw.Location = Point.Empty;
			PictureDraw.Size = Size;
			PictureDraw.Image = _drawings;

			_pen = new Pen(Program.Settings.PenColor);

			App.Ins.Pictures.Add(this);
		}
		protected override CreateParams CreateParams	 
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x80; // WS_EX_TOOLWINDOW
				if (Program.Settings.DrawShadow)
					cp.ClassStyle |= 0x20000; // CS_DROPSHADOW
				return cp;
			}
		}

		private void FormPicture_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right 
				&& !ModifierKeys.HasFlag(Keys.Control))
			{
				Close();
			}
			else if ((e as MouseEventArgs).Button == MouseButtons.Middle)
			{
				Clipboard.SetImage(_picture);
				App.Ins.TrayIcon.ShowBalloonTip(0, "Copy image", "Image is copied!", ToolTipIcon.Info);
			}
		}

		private void DrawBorder(Bitmap image)
		{
			using (var g = Graphics.FromImage(image))
			{
				g.DrawRectangle(
					new Pen(Color.FromArgb(128, 128, 128, 128)),
					new Rectangle(0, 0, Size.Width - 1, Size.Height - 1)
				);
			}
		}

		private void FormPicture_MouseDown(object sender, MouseEventArgs e)
		{
			if (ModifierKeys.HasFlag(Keys.Control))
			{
				_drawing = e.Button == MouseButtons.Right ? -1 : 1;
				_lastPos = Point.Subtract(Cursor.Position, new Size(Location));
				Draw();
				if (e.Button == MouseButtons.Right)
					Cursor = _circle;
				else
					Cursor = _pencil;
			}
			else
			{
				_dragging = true;
				_dragDif = Point.Subtract(Location, new Size(Cursor.Position));
				Cursor = Cursors.SizeAll;
			}
		}

		private void FormPicture_MouseMove(object sender, MouseEventArgs e)
		{
			if (_dragging)
			{
				Location = Point.Add(Cursor.Position, new Size(_dragDif));
				Cursor = Cursors.SizeAll;
			}
			else if (_drawing != 0)
			{
				if (e.Button == MouseButtons.Right)
					Cursor = _circle;
				else
					Cursor = _pencil;
				var pos = Point.Subtract(Cursor.Position, new Size(Location));
				Draw(pos);
				_lastPos = pos;
			}
			else
			{
				if (ModifierKeys.HasFlag(Keys.Control))
				{
					if (e.Button == MouseButtons.Right)
						Cursor = _circle;
					else
						Cursor = _pencil;
				}
				else
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void FormPicture_MouseUp(object sender, MouseEventArgs e)
		{
			_dragging = false;
			_drawing = 0;
		}

		private void FormPicture_FormClosed(object sender, FormClosedEventArgs e)
		{
			_drawings.Dispose();
			App.Ins.Pictures.Remove(this);
		}

		private void Draw()
		{
			using (var g = Graphics.FromImage(PictureDraw.Image))
			{
				if (_drawing > 0)
				{
					g.FillEllipse(Brushes.Lime, new Rectangle(_lastPos, new Size(1, 1)));
				}
				else
				{
					g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
					g.FillEllipse(Brushes.Transparent, new Rectangle(_lastPos, Size.Empty).Inflate(16));
				}
				PictureDraw.Image = PictureDraw.Image;
			}
		}
		private void Draw(Point p)
		{
			using (var g = Graphics.FromImage(PictureDraw.Image))
			{
				if (_drawing > 0)
				{
					g.DrawLine(_pen, _lastPos, p);
				}
				else
				{
					g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
					g.FillEllipse(Brushes.Transparent, new Rectangle(p, Size.Empty).Inflate(16));
				}
				PictureDraw.Image = PictureDraw.Image;
			}
		}

		private void FormPicture_Key(object sender, KeyEventArgs e)
		{
			if (ModifierKeys.HasFlag(Keys.Control))
			{
				if (MouseButtons == MouseButtons.Right)
					Cursor = _circle;
				else
					Cursor = _pencil;
			}
			else
			{
				Cursor = Cursors.Default;
			}
		}
	}
}
