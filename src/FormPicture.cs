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
		public Bitmap Picture { get => _picture; }

		private readonly static Icon _iconPencil = Resources.pencil;
		private readonly static Icon _iconCircle = Resources.circle;
		private readonly static Cursor _pencil = new Cursor(_iconPencil.Handle);
		private readonly static Cursor _circle = new Cursor(_iconCircle.Handle);
		private readonly static Pen _penBorder = new Pen(Color.FromArgb(128, 128, 128, 128), 2);
		private Bitmap _picture;
		private Pen _pen;
		private bool _dragging = false;
		private int _drawing = 0;
		private Point _dragDif;
		private Point _lastPos;
		private Size _size;
		private int _zoom = 0;
		private Point _minMaxZoom;
		private double Zoom { get => Math.Pow(Program.Settings.ZoomStep, _zoom); }

		public FormPicture(Bitmap picture, Point location)
		{
			App.Ins.RegisterPicture(this);
			_picture = picture;
			InitializeComponent();
			Location = location;
			Size = picture.Size;
			_size = Size;
			BackgroundImage = picture;
			
			var drawings = new Bitmap(picture.Size.Width, picture.Size.Height);
			PictureDraw.Dock = DockStyle.Fill;
			PictureDraw.BackgroundImage = drawings;
			
			PB_highlight.Dock = DockStyle.Fill;
			PB_highlight.BackColor = Program.Settings.HighlightColor;
			PB_highlight.Visible = false;

			_pen = new Pen(Program.Settings.PenColor);

			float minScreenSide = Screen.PrimaryScreen.Bounds.Size.Min();
			_minMaxZoom.X = (int)Math.Ceiling(Math.Log(32f / _size.Min(), Program.Settings.ZoomStep));
			_minMaxZoom.Y = (int)Math.Floor(Math.Log(minScreenSide / _size.Max(), Program.Settings.ZoomStep));
			Disposed += OnDisposed;
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

		public void ToggleHighlight(bool enable)
		{
			PB_highlight.Visible = enable;
		}

		private void OnDisposed(object sender, EventArgs e)
		{
			if (_pen != null)
			{
				_pen.Dispose();
				_pen = null;
			}
			if (_picture != null)
			{
				_picture.Dispose();
				_picture = null;
			}
			if (PictureDraw.BackgroundImage != null)
			{
				PictureDraw.BackgroundImage.Dispose();
				PictureDraw.BackgroundImage = null;
			}
		}

		private void FormPicture_Click(object sender, EventArgs e)
		{
			ToggleHighlight(false);
			if ((e as MouseEventArgs).Button == MouseButtons.Right 
				&& !ModifierKeys.HasFlag(Keys.Control))
			{
				Close();
			}
			else if ((e as MouseEventArgs).Button == MouseButtons.Middle)
			{
				CopyPictureToClipboard();
			}
		}

		public void CopyPictureToClipboard()
		{
			Clipboard.SetImage(_picture);
			var title = Program.Settings.Language == 1 ? "Копирование картинки" : "Copy image";
			var text = Program.Settings.Language == 1 ? "Картинка сопированна!" : "Image is copied!";
			App.Ins.TrayIcon.ShowBalloonTip(0, title, text, ToolTipIcon.Info);
		}

		private void FormPicture_Paint(object sender, PaintEventArgs e)
		{
			if (!Program.Settings.DrawBorder || _penBorder == null) 
				return;
			var g = e.Graphics;
			g.DrawRectangle(
				_penBorder,
				new Rectangle(0, 0, Size.Width, Size.Height)
			);
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
				if (e.Button != MouseButtons.Left)
					return;

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
			App.Ins.UnregisterPicture(this);
		}

		private void Draw() => Draw(Point.Empty, false);
		private void Draw(Point p) => Draw(p, true);
		private void Draw(Point p, bool pointExist)
		{
			var zoom = Zoom;
			var lastPos = _lastPos.Divide(zoom);
			var point = pointExist ? p.Divide(zoom) : lastPos;

			using (var g = Graphics.FromImage(PictureDraw.BackgroundImage))
			{
				if (_drawing > 0)
				{
					if (pointExist)
						if (_pen != null)
							g.DrawLine(_pen, lastPos, point);
					else
						g.FillEllipse(Brushes.Lime, new Rectangle(lastPos, new Size(1, 1)));
				}
				else
				{
					g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
					g.FillEllipse(Brushes.Transparent, new Rectangle(point, Size.Empty).Inflate(16 / Zoom));
				}
				PictureDraw.Refresh();
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

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			SetZoom(_zoom + Math.Sign(e.Delta));
		}

		private void FormPicture_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '0')
				SetZoom(0);
		}

		private void SetZoom(int zoom)
		{
			_zoom = zoom.MinMax(_minMaxZoom);
			Size = _size.Multiply(Zoom);
		}
	}
}
