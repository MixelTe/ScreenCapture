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
			ColorInp_pen.Color = Program.Settings.PenColor;
			CB_vignette.Checked = Program.Settings.DrawVignette;
			Panel_vignette.Enabled = Program.Settings.DrawVignette;
			ColorInp_vignette.Color = Program.Settings.VignetteColor;
			Inp_vignette.Value = Program.Settings.VignetteSize;
			Inp_zoomStep.Value = ((decimal)Program.Settings.ZoomStep - 1) * 100;
			CB_palette.Checked = Program.Settings.EnablePalette;
			Panel_palette.Enabled = Program.Settings.EnablePalette;
			Inp_paletteHotkey.Text = Program.HotkeyPalette.ToString();
			Inp_paletteSize.Value = Program.Settings.PaletteSize;
			ColorInp_highlight.Color = Program.Settings.HighlightColor;
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
			Program.Settings = new Settings();
			Program.Settings.Save();

			Program.Hotkey.SetHotkey(Program.Settings.Hotkey);
			Program.Hotkey.TryRegister();

			Program.HotkeyPalette.SetHotkey(Program.Settings.HotkeyPalette);
			Program.HotkeyPalette.TryRegister();

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

		private void CB_vignette_CheckedChanged(object sender, EventArgs e)
		{
			if (_settingValues) return;
			Panel_vignette.Enabled = CB_vignette.Checked;
			Program.Settings.DrawVignette = CB_vignette.Checked;
			Program.Settings.Save();
		}

		private void Inp_vignette_ValueChanged(object sender, EventArgs e)
		{
			if (_settingValues) return;
			Program.Settings.VignetteSize = (int)Inp_vignette.Value;
			Program.Settings.Save();
		}

		private void ColorInp_pen_ColorChanged(object sender, EventArgs e)
		{
			Program.Settings.PenColor = ColorInp_pen.Color;
			Program.Settings.Save();
		}

		private void ColorInp_vignette_ColorChanged(object sender, EventArgs e)
		{
			Program.Settings.VignetteColor = ColorInp_vignette.Color;
			Program.Settings.Save();
		}

		private void Inp_zoomStep_ValueChanged(object sender, EventArgs e)
		{
			if (_settingValues) return;
			Program.Settings.ZoomStep = 1 + (int)Inp_zoomStep.Value / 100f;
			Program.Settings.Save();
		}

		private void CB_palette_CheckedChanged(object sender, EventArgs e)
		{
			if (_settingValues) return;
			Panel_palette.Enabled = CB_palette.Checked;
			Program.Settings.EnablePalette = CB_palette.Checked;
			Program.Settings.Save();
		}

		private void Inp_paletteHotkey_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void Inp_paletteHotkey_KeyDown(object sender, KeyEventArgs e)
		{
			Program.HotkeyPalette.KeyCode = e.KeyCode;
			Program.HotkeyPalette.Shift = e.Shift;
			Program.HotkeyPalette.Control = e.Control;
			Program.HotkeyPalette.Alt = e.Alt;
			Program.HotkeyPalette.TryRegister();
			Program.Settings.HotkeyPalette = e.KeyData;
			Program.Settings.Save();
			Inp_paletteHotkey.Text = Program.HotkeyPalette.ToString();
		}

		private void Inp_paletteSize_ValueChanged(object sender, EventArgs e)
		{
			if (_settingValues) return;
			Program.Settings.PaletteSize = (int)Inp_paletteSize.Value;
			Program.Settings.Save();
		}

		private void ColorInp_highlight_ColorChanged(object sender, EventArgs e)
		{
			Program.Settings.HighlightColor = ColorInp_highlight.Color;
			Program.Settings.Save();
		}
	}
}
