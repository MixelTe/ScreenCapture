using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
	public partial class FormPicture : Form
	{
		private bool _dragging = false;
		private Point _dragDif;

		public FormPicture(Bitmap picture, Point location)
		{
			InitializeComponent();
			Location = location;
			Size = picture.Size;
			DrawBorder(picture);
			BackgroundImage = picture;
			Cursor = Cursors.Arrow;
		}
		//protected override CreateParams CreateParams
		//{
		//	get
		//	{
		//		const int CS_DROPSHADOW = 0x20000;
		//		CreateParams cp = base.CreateParams;
		//		cp.ClassStyle |= CS_DROPSHADOW;
		//		return cp;
		//	}
		//}

		private void FormPicture_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right)
			{
				Close();
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
			_dragging = true;
			_dragDif = Point.Subtract(Location, new Size(Cursor.Position));
		}

		private void FormPicture_MouseMove(object sender, MouseEventArgs e)
		{
			if (_dragging)
			{
				Location = Point.Add(Cursor.Position, new Size(_dragDif));
			}
		}

		private void FormPicture_MouseUp(object sender, MouseEventArgs e)
		{
			_dragging = false;
		}
	}
}
