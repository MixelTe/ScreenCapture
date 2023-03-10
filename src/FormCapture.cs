using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
	public partial class FormCapture : Form
	{
		public bool PictureCaptured = false;
		private Point _selectionStart = new Point(-1, -1);
		private Rectangle _selection;

		public FormCapture()
		{
			var size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			var screenPicture = new Bitmap(size.Width, size.Height);
			using (var g = Graphics.FromImage(screenPicture))
			{
				g.CopyFromScreen(0, 0, 0, 0, size);
			}
			InitializeComponent();
			BackgroundImage = screenPicture;
			Size = size;
			Cursor = Cursors.Cross;
		}

		private void FormCapture_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right)
			{
				Close();
			}
		}

		private void FormCapture_MouseDown(object sender, MouseEventArgs e)
		{
			_selectionStart = e.Location;
		}

		private void FormCapture_MouseUp(object sender, MouseEventArgs e)
		{
			UpdateSelection(e.Location);
			CapturePicture();
		}

		private void FormCapture_MouseMove(object sender, MouseEventArgs e)
		{
			if (_selectionStart.X >= 0)
				UpdateSelection(e.Location);
		}

		private void FormCapture_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(Pens.Lime, _selection);
		}

		private void UpdateSelection(Point mousePos)
		{
			Invalidate(_selection.Inflate(2));
			var w = Math.Abs(_selectionStart.X - mousePos.X);
			var h = Math.Abs(_selectionStart.Y - mousePos.Y);
			var x = Math.Min(_selectionStart.X, mousePos.X);
			var y = Math.Min(_selectionStart.Y, mousePos.Y);

			_selection = new Rectangle(x, y, w, h);
			Invalidate(_selection.Inflate(2));
		}

		private void CapturePicture()
		{
			if (_selection.Width <= 0 || _selection.Height <= 0) return;

			var picture = new Bitmap(_selection.Width, _selection.Height);
			using (var g = Graphics.FromImage(picture))
			{
				g.DrawImage(BackgroundImage, 0, 0, _selection, GraphicsUnit.Pixel);
			}

			var form = new FormPicture(picture, _selection.Location);
			form.Show();
			PictureCaptured = true;
			Close();
		}
	}
}
