using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
	}
}
