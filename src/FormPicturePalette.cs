using ScreenCapture.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
	public partial class FormPicturePalette : Form
	{
		private readonly static Bitmap _iconVisible = Resources.show;
		private readonly static Bitmap _iconHidden = Resources.hide;
		private readonly int _pictureSize = 100;
		private readonly int _pictureMargin = 2;
		private readonly int _padding = 2;
		private readonly int _cornerR = 8;
		private Rectangle _formRect;
		private Brush _selectionBrush = new SolidBrush(Color.FromArgb(96, 128, 128, 128));
		private Size _size;
		private int _count;
		private int _selected = -1;

		public FormPicturePalette()
		{
			SetSizeAndLocation();
			var back = DrawBack();
			InitializeComponent();
			Size = _formRect.Size;
			BackgroundImage = back;
			DrawPictures();

			PB_selection.BackgroundImage = new Bitmap(Width, Height);
			Disposed += OnDisposed;
		}

		private void OnDisposed(object sender, EventArgs e)
		{
			if (_selectionBrush != null)
			{
				_selectionBrush.Dispose();
				_selectionBrush = null;
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x80; // WS_EX_TOOLWINDOW
				return cp;
			}
		}

		private void FormPicturePalette_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void SetSizeAndLocation()
		{
			var maxCountX = Screen.PrimaryScreen.Bounds.Width / _pictureSize;
			_count = App.Ins.PicturesCount;
			var countSide = (int)Math.Ceiling(Math.Sqrt(_count));
			var countX = Math.Min(countSide, maxCountX);
			var countY = (int)Math.Ceiling(_count / (float)countX);
			var pictureSize = _pictureSize + _pictureMargin * 2;
			_size = new Size(countX, countY);
			Size = new Size(countX * pictureSize + _padding * 2, countY * pictureSize + _padding * 2);
			Location = new Point(Cursor.Position.X - Width / 2, Cursor.Position.Y - Height / 2);
			_formRect = new Rectangle(Location, Size);
		}

		private Bitmap DrawBack()
		{
			var screenPicture = new Bitmap(Width, Height);
			using (var g = Graphics.FromImage(screenPicture))
			using (var brush = new SolidBrush(Color.FromArgb(32, 128, 128, 128)))
			{
				g.CopyFromScreen(Location.X, Location.Y, 0, 0, Size);
				g.FillRoundedRectangle(brush, new Rectangle(Point.Empty, Size), _cornerR);
			}
			
			return screenPicture;
		}
		
		private void DrawPictures()
		{
			var pictureSize = _pictureSize + _pictureMargin * 2;
			var i = 0;
			using (var g = Graphics.FromImage(BackgroundImage))
			using (var brush = new SolidBrush(Color.FromArgb(64, 128, 128, 128)))
			using (var brushIcon = new SolidBrush(Color.FromArgb(255, 128, 128, 128)))
			{
				foreach (var picture in App.Ins.GetPictures())
				{
					var x = i % _size.Width;
					var y = i / _size.Width;
					i++;
					var src = new Rectangle(0, 0, picture.Picture.Width, picture.Picture.Height);
					var max = Math.Max(src.Width, src.Height);
					var mul = _pictureSize / (float)max;
					var w = (int)Math.Round(src.Width * mul);
					var h = (int)Math.Round(src.Height * mul);
					var dst = new Rectangle(
						_padding + x * pictureSize + _pictureMargin + (_pictureSize - w) / 2,
						_padding + y * pictureSize + _pictureMargin + (_pictureSize - h) / 2,
						w,
						h);
					var rect = new Rectangle(_padding + x * pictureSize + _pictureMargin, _padding + y * pictureSize + _pictureMargin, _pictureSize, _pictureSize);
					g.FillRoundedRectangle(brush, rect, 8);
					g.DrawImage(picture.Picture, dst, src, GraphicsUnit.Pixel);
					
					var icon = picture.Visible ? _iconVisible : _iconHidden;
					src = new Rectangle(0, 0, icon.Width, icon.Height);
					dst = new Rectangle(rect.Location.Add(10, 10), new Size(16, 16));
					g.FillRoundedRectangle(brushIcon, dst.Inflate(4), 4);
					g.DrawImage(icon, dst, src, GraphicsUnit.Pixel);
				}
			}
			BackgroundImage = BackgroundImage;
		}

		private void Timer_checkCursor_Tick(object sender, EventArgs e)
		{
			var cur = Cursor.Position;
			var form = new Rectangle(Location, Size);
			if (!form.Contains(cur))
			{
				Close();
			}
		}

		private void FormPicturePalette_MouseMove(object sender, MouseEventArgs e)
		{
			var pictureSize = _pictureSize + _pictureMargin * 2;
			var ix = (e.X - _padding) / pictureSize;
			var iy = (e.Y - _padding) / pictureSize;

			var i = -1;
			if (ix >= 0 && ix < _size.Width && iy >= 0 && iy < _size.Height)
			{
				i = iy * _size.Width + ix;
				if (i >= _count)
					i = -1;
			}

			if (i == _selected)
				return;

			DrawSelection(i);
		}

		private void DrawSelection(int selected)
		{
			if (selected == _selected)
				return;
			_selected = selected;

			var x = _selected % _size.Width;
			var y = _selected / _size.Width;
			var pictureSize = _pictureSize + _pictureMargin * 2;

			using (var g = Graphics.FromImage(PB_selection.BackgroundImage))
			{
				g.Clear(Color.Transparent);
				if (_selected >= 0)
				{
					var rect = new Rectangle(_padding + x * pictureSize + _pictureMargin, _padding + y * pictureSize + _pictureMargin, _pictureSize, _pictureSize);
					g.FillRoundedRectangle(_selectionBrush, rect, 8);
				}
			}
			PB_selection.BackgroundImage = PB_selection.BackgroundImage;
			PB_selection.Refresh();
		}
	}
}
