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
	public partial class FormTextbox : Form, IFloatingWindow
	{
		private readonly TextboxMod _textbox = new TextboxMod();
		private Bitmap _preview = null;
		private bool _dragging = false;
		private Point _dragDif;

		public FormTextbox(Point location, Size size)
		{
			App.Ins.RegisterWindow(this);
			InitializeComponent();
			Location = location;
			Size = size;
			Controls.Add(_textbox);
			_textbox.KeyUp += Textbox_KeyUp;
			_textbox.BorderStyle = BorderStyle.None;
			_textbox.Dock = DockStyle.Fill;
			_textbox.ReadOnly = true;
			_textbox.BackColor = Program.Settings.TextBgColor.MakeOpaque();
			_textbox.ForeColor = Program.Settings.TextColor.MakeOpaque();
			_textbox.Font = new Font(_textbox.Font.FontFamily, Program.Settings.TextSize);

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

		protected override void WndProc(ref Message m)
		{
			var cGrip = 10;
			if (m.Msg == 0x84) // Trap WM_NCHITTEST
			{
				Point pos = new Point(m.LParam.ToInt32());
				pos = PointToClient(pos);
				//if (pos.Y < cCaption)
				//{
				//	m.Result = (IntPtr)2;  // HTCAPTION
				//	return;
				//}
				if (pos.X >= ClientSize.Width - cGrip && pos.Y >= ClientSize.Height - cGrip)
				{
					m.Result = (IntPtr)17; // HTBOTTOMRIGHT
					return;
				}
			}
			base.WndProc(ref m);
		}

		private void OnDisposed(object sender, EventArgs e)
		{
			App.Ins.UnregisterWindow(this);
			if (_preview != null)
			{
				_preview.Dispose();
				_preview = null;
			}
		}

		public void ToggleHighlight(bool enable)
		{
			if (enable)
				_textbox.BackColor = Program.Settings.HighlightColor.MakeOpaque();
			else
				_textbox.BackColor = Program.Settings.TextBgColor.MakeOpaque();
		}

		private void FormTextbox_MouseDown(object sender, MouseEventArgs e)
		{
			_dragging = true;
			_dragDif = Point.Subtract(Location, new Size(Cursor.Position));
			Cursor = Cursors.SizeAll;
		}

		private void FormTextbox_MouseMove(object sender, MouseEventArgs e)
		{
			if (_dragging)
			{
				Location = Point.Add(Cursor.Position, new Size(_dragDif));
				Cursor = Cursors.SizeAll;
			}
			else
			{
				Cursor = Cursors.Default;
			}
		}

		private void FormTextbox_MouseUp(object sender, MouseEventArgs e)
		{
			_dragging = false;
		}

		private void Textbox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				_textbox.ReadOnly = true;
				_textbox.BackColor = Program.Settings.TextBgColor.MakeOpaque();
				button1.Focus();
			}
		}

		private void FormTextbox_DoubleClick(object sender, EventArgs e)
		{
			_textbox.ReadOnly = false;
			_textbox.Focus();
		}

		private void FormTextbox_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right
				&& _textbox.ReadOnly)
			{
				Close();
			}
			if ((e as MouseEventArgs).Button == MouseButtons.Middle)
			{
				CopyToClipboard(ModifierKeys.HasFlag(Keys.Control));
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			if (ModifierKeys.HasFlag(Keys.Control))
			{
				_textbox.Font = new Font(_textbox.Font.FontFamily, Math.Max(_textbox.Font.Size + Math.Sign(e.Delta), 2));
			}
		}

		public Bitmap GetPicture()
		{
			_preview = new Bitmap(Width, Height);
			using (var g = Graphics.FromImage(_preview))
			using (var bb = new SolidBrush(Program.Settings.TextBgColor))
			using (var bt = new SolidBrush(Program.Settings.TextColor))
			{
				g.FillRectangle(bb, 0, 0, Width, Height);
				g.DrawString(_textbox.Text, _textbox.Font, bt, new RectangleF(0, 0, Width, Height));
			}
			return _preview;
		}

		public void CopyToClipboard(bool ctrl)
		{
			_textbox.SelectAll();
			_textbox.Copy();
			_textbox.DeselectAll();
			var title = Program.Settings.Language == 1 ? "Копирование заметки" : "Copy note";
			var text = Program.Settings.Language == 1 ? "Заметка сопированна!" : "Note is copied!";
			App.Ins.TrayIcon.ShowBalloonTip(0, title, text, ToolTipIcon.Info);
		}

		public void SetTextFromClipboard()
		{
			_textbox.ReadOnly = false;
			_textbox.Paste();
			_textbox.ReadOnly = true;
		}
	}
	class TextboxMod : RichTextBox
	{
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x84 && ReadOnly)
			{
				m.Result = new IntPtr(-1);
				return;
			}
			base.WndProc(ref m);
		}
	}
}
