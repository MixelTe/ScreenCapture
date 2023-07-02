﻿using System;
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
		private bool _settingValues = false;

		public FormSettings()
		{
			InitializeComponent();
			Location = new Point(Cursor.Position.X - Width / 2, Cursor.Position.Y - Height - 10);
			SetValues();
		}

		public void SetValues()
		{
			_settingValues = true;
			Inp_hotkey.Text = Program.Hotkey.ToString();
			CB_border.Checked = Program.Settings.DrawBorder;
			CB_shadow.Checked = Program.Settings.DrawShadow;
			_settingValues = false;
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
			Program.Settings.DrawBorder = true;
			Program.Settings.DrawShadow = true;
			Program.Settings.Save();

			Program.Hotkey.SetHotkey(Program.Settings.Hotkey);
			Program.Hotkey.TryRegister();
			SetValues();
		}

		private void CB_shadow_CheckedChanged(object sender, EventArgs e)
		{
			if (_settingValues) return;
			Program.Settings.DrawShadow = CB_shadow.Checked;
			Program.Settings.Save();
		}

		private void CB_border_CheckedChanged(object sender, EventArgs e)
		{
			if (_settingValues) return;
			Program.Settings.DrawBorder = CB_border.Checked;
			Program.Settings.Save();
		}
	}
}
