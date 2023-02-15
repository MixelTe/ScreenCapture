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
	public partial class FormSettings : Form
	{
		public bool ChangingHotkey => !IsDisposed && Inp_hotkey.Focused;

		public FormSettings()
		{
			InitializeComponent();
			Location = new Point(Cursor.Position.X - Width / 2, Cursor.Position.Y - Height - 10);
			Inp_hotkey.Text = Program.Hotkey.ToString();
		}

		private void Inp_hotkey_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void Inp_hotkey_KeyDown(object sender, KeyEventArgs e)
		{
			Program.Hotkey.KeyCode = e.KeyCode;
			Program.Hotkey.Shift = e.Shift;
			Program.Hotkey.Control = e.Control;
			Program.Hotkey.Alt = e.Alt;
			Program.Hotkey.TryRegister();
			Program.Settings.Hotkey = e.KeyData;
			Program.Settings.Save();
			Inp_hotkey.Text = Program.Hotkey.ToString();
		}

		private void FormSettings_Click(object sender, EventArgs e)
		{
			ActiveControl = null;
		}

		private void Btn_reset_Click(object sender, EventArgs e)
		{
			Program.Settings.Hotkey = new Settings().Hotkey;
			Program.Settings.Save();
			Program.Hotkey.KeyCode = Program.Settings.Hotkey & Keys.KeyCode;
			Program.Hotkey.Control = (Program.Settings.Hotkey & Keys.Control) != 0;
			Program.Hotkey.Shift = (Program.Settings.Hotkey & Keys.Shift) != 0;
			Program.Hotkey.Alt = (Program.Settings.Hotkey & Keys.Alt) != 0;
			Program.Hotkey.TryRegister();
		}
	}
}
