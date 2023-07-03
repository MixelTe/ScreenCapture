using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorInput
{
	internal partial class AlphaInput : UserControl
	{
		public event EventHandler AlphaChanged;
		private int _alpha;

		public int Alpha
		{
			get => _alpha;
			set {
				_alpha = value;
				Inp_range.Value = _alpha;
				Inp.Value = _alpha;
			}
		}

		public AlphaInput()
		{
			InitializeComponent();
		}

		private void Inp_range_Scroll(object sender, EventArgs e)
		{
			Alpha = Inp_range.Value;
			AlphaChanged?.Invoke(this, EventArgs.Empty);
		}

		private void Inp_ValueChanged(object sender, EventArgs e)
		{
			Alpha = (int)Inp.Value;
			AlphaChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
