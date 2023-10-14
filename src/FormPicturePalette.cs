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
		private readonly static Bitmap _iconClosed = Resources.close;
		private readonly int _pictureSize = Program.Settings.PaletteSize;
		private readonly int _pictureMargin = 4;
		private readonly int _pictureCorner = 8;
		private readonly int _padding = 4;
		private readonly int _cornerR = 8;
		private readonly IFloatingWindow[] _windows;
		private Rectangle _formRect;
		private Brush _selectionBrush = new SolidBrush(Color.FromArgb(96, 128, 128, 128));
		private Size _size;
		private int _selected = -1;

		public FormPicturePalette()
		{
			_windows = App.Ins.GetWindows().ToArray();
			SetSizeAndLocation();
			var back = DrawBack();
			InitializeComponent();
			Size = _formRect.Size;
			BackgroundImage = back;
			DrawPictures();

			PB_selection.BackgroundImage = new Bitmap(Width, Height);
			DrawSelection();

			Disposed += OnDisposed;
		}

		private void OnDisposed(object sender, EventArgs e)
		{
			if (_selectionBrush != null)
			{
				_selectionBrush.Dispose();
				_selectionBrush = null;
			}
			if (BackgroundImage != null)
			{
				BackgroundImage.Dispose();
				BackgroundImage = null;
			}
			if (PB_selection.BackgroundImage != null)
			{
				PB_selection.BackgroundImage.Dispose();
				PB_selection.BackgroundImage = null;
			}
			foreach (var picture in _windows)
			{
				if (!picture.IsDisposed)
					picture.ToggleHighlight(false);
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
			var countSide = (int)Math.Ceiling(Math.Sqrt(_windows.Length));
			var countX = Math.Min(countSide, maxCountX);
			var countY = (int)Math.Ceiling(_windows.Length / (float)countX);
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
			using (var g = Graphics.FromImage(BackgroundImage))
			using (var brush = new SolidBrush(Color.FromArgb(64, 128, 128, 128)))
			{
				for (int i = 0; i < _windows.Length; i++)
				{
					var picture = _windows[i].GetPicture();
					var rect = GetPictureRect(i);
					var src = new Rectangle(0, 0, picture.Width, picture.Height);
					var max = Math.Max(src.Width, src.Height);
					var mul = _pictureSize / (float)max;
					var w = (int)Math.Round(src.Width * mul);
					var h = (int)Math.Round(src.Height * mul);
					var dst = new Rectangle(
						rect.X + (_pictureSize - w) / 2,
						rect.Y + (_pictureSize - h) / 2,
						w, h);
					g.FillRoundedRectangle(brush, rect, _pictureCorner);
					g.DrawImage(picture, dst, src, GraphicsUnit.Pixel);
				}
			}
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
				if (i >= _windows.Length)
					i = -1;
			}

			if (i == _selected)
				return;

			DrawSelection(i);
		}

		private void DrawSelection() => DrawSelection(_selected, true);
		private void DrawSelection(int selected) => DrawSelection(selected, false);
		private void DrawSelection(int selected, bool forceRedraw)
		{
			if (selected == _selected && !forceRedraw || IsDisposed)
				return;

			ToggleSelectedWindowHighlight(false);
			_selected = selected;
			ToggleSelectedWindowHighlight(true);

			using (var g = Graphics.FromImage(PB_selection.BackgroundImage))
			using (var brushIcon = new SolidBrush(Color.FromArgb(255, 128, 128, 128)))
			{
				g.Clear(Color.Transparent);
				if (_selected >= 0)
				{
					g.FillRoundedRectangle(_selectionBrush, GetPictureRect(_selected), _pictureCorner);
				}

				for (int i = 0; i < _windows.Length; i++)
				{
					var picture = _windows[i];
					var rect = GetPictureRect(i);
					var icon = picture.IsDisposed ? _iconClosed : (picture.Visible ? _iconVisible : _iconHidden);
					var src = new Rectangle(0, 0, icon.Width, icon.Height);
					var dst = new Rectangle(rect.Location.Add(10, 10), new Size(16, 16));
					g.FillRoundedRectangle(brushIcon, dst.Inflate(4), 4);
					g.DrawImage(icon, dst, src, GraphicsUnit.Pixel);
				}
			}
			PB_selection.Refresh();
		}

		private void ToggleSelectedWindowHighlight(bool enable)
		{
			if (GetSelectedPicture(out var picture))
				picture.ToggleHighlight(enable);
		}

		private bool GetSelectedPicture(out IFloatingWindow window)
		{
			window = null;
			if (_selected >= 0 && _selected < _windows.Length)
			{
				var p = _windows[_selected];
				if (!p.IsDisposed)
				{
					window = p;
					return true;
				}
			}
			return false;
		}

		private Rectangle GetPictureRect(int i)
		{
			var x = i % _size.Width;
			var y = i / _size.Width;
			var pictureSize = _pictureSize + _pictureMargin * 2;

			return new Rectangle(_padding + x * pictureSize + _pictureMargin, _padding + y * pictureSize + _pictureMargin, _pictureSize, _pictureSize);
		}

		private void FormPicturePalette_MouseClick(object sender, MouseEventArgs e)
		{
			if (!GetSelectedPicture(out var window) || IsDisposed)
				return;

			if (e.Button == MouseButtons.Left)
			{
				if (window.Visible)
					window.Hide();
				else
					window.Show();
				BringToFront();
			}
			else if (e.Button == MouseButtons.Right)
			{
				window.Close();
			}
			else if (e.Button == MouseButtons.Middle)
			{
				window.CopyToClipboard(ModifierKeys.HasFlag(Keys.Control));
			}

			DrawSelection();
		}

		private void FormPicturePalette_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!GetSelectedPicture(out var picture))
				return;

			var cursor = Cursor.Position;
			picture.Location = new Point(
				cursor.X - picture.Size.Width / 2,
				cursor.Y - picture.Size.Height / 2
				);
			picture.Show();

			Close();
		}
	}
}
