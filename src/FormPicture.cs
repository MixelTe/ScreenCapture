using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
	public partial class FormPicture : Form
	{
		private readonly Bitmap _picture;
		private bool _dragging = false;
		private Point _dragDif;

		public FormPicture(Bitmap picture, Point location)
		{
			_picture = picture.Clone(new Rectangle(Point.Empty, picture.Size), picture.PixelFormat);
			InitializeComponent();						 
			Location = location;						 
			Size = picture.Size;						 
			DrawBorder(picture);						 
			BackgroundImage = picture;					 
			Cursor = Cursors.Arrow;						 
														 
			App.Ins.Pictures.Add(this);					 
		}												 
		protected override CreateParams CreateParams	 
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x80; // WS_EX_TOOLWINDOW
				//cp.ClassStyle |= 0x20000; // CS_DROPSHADOW
				return cp;
			}
		}

		private void FormPicture_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right)
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

		private void FormPicture_FormClosed(object sender, FormClosedEventArgs e)
		{
			App.Ins.Pictures.Remove(this);
		}
	}
}
