using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorInput
{
	public partial class ColorInput : UserControl
	{
		public event EventHandler ColorChanged;

		private ColorDialogAlpha _colorDialog = new ColorDialogAlpha();
		private Color _color;
		private bool _isColorInClipboard;
		private Color _colorInClipboard;

		public Color Color
		{
			get => _color;
			set {
				_color = value;
				Btn.BackColor = _color;
			}
		}

		public ColorInput()
		{
			InitializeComponent();
			Disposed += OnDisposed;
			ContextMenuStrip1.Opening += ContextMenu_Opening;
			ToolStripMenuItem_copy.Click += Copy_Click;
			ToolStripMenuItem_paste.Click += Paste_Click;
		}

		private void OnDisposed(object sender, EventArgs e)
		{
			if (_colorDialog != null)
				_colorDialog.Dispose();

			_colorDialog = null;
		}

		private void Btn_Click(object sender, EventArgs e)
		{
			_colorDialog.Color = _color;
			if (_colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				Color = _colorDialog.Color;
				ColorChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		private void ContextMenu_Opening(object sender, CancelEventArgs e)
		{
			_isColorInClipboard = GetColorFromClipboard(out _colorInClipboard);
			ToolStripMenuItem_paste.Enabled = _isColorInClipboard;
		}

		private bool GetColorFromClipboard(out Color color)
		{
			color = Color.Red;
			if (!Clipboard.ContainsText())
				return false;
			var text = Clipboard.GetText();
			return ColorFromString(text, out color);
		}

		private bool ColorFromString(string str, out Color color)
		{
			color = Color.Red;
			
			var striped = str.Substring(5, str.Length - 6);
			if (striped.Length < 7) return false;

			var parts = striped.Split(',');
			if (parts.Length != 4) return false;

			var r = int.Parse(parts[0], CultureInfo.InvariantCulture);
			var g = int.Parse(parts[1], CultureInfo.InvariantCulture);
			var b = int.Parse(parts[2], CultureInfo.InvariantCulture);
			var a = int.Parse(parts[3], CultureInfo.InvariantCulture);

			color = Color.FromArgb(a, r, g, b);
			return true;
		}

		private string ColorToString(Color c)
		{
			return FormattableString.Invariant($"rgba({c.R},{c.G},{c.B},{c.A})");
		}

		private void Paste_Click(object sender, EventArgs e)
		{
			if (_isColorInClipboard)
			{
				Color = _colorInClipboard;
				ColorChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		private void Copy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(ColorToString(Color));
		}
	}
}
