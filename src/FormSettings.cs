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
			SetTexts();
		}

		private void SetValues()
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
			Inp_lang.SelectedIndex = Program.Settings.Language;
			_settingValues = false;
		}

		private void SetTexts()
		{
			if (Program.Settings.Language == 1)
			{
				Text = "Захват экрана: Настройки";
				Lbl_hotkey.Text = "Клавиша";
				CB_vignette.Text = "Виньетка";
				Lbl_vColor.Text = "Цвет";
				Lbl_vSize.Text = "Размер";
				CB_shadow.Text = "Тень";
				CB_border.Text = "Рамка";
				Lbl_pColor.Text = "Размер ручки";
				Lbl_zoom.Text = "Шаг зума %";
				CB_palette.Text = "Палитра";
				Lbl_pHotkey.Text = "Клавиша";
				Lbl_pSize.Text = "Размер";
				Lbl_highlight.Text = "Подсветка";
				Lbl_lang.Text = "Язык";
				Btn_reset.Text = "Сбросить";
				TextBoxHelp.Text = @"                   ---   Горячая клавиша   ---
Нажатие -> вырезать часть экрана
Двойное нажатие -> скрыть/показать картинки

          ---   Иконка приложения на панели   ---
Нажатие ЛКМ -> вырезать часть экрана
Нажатие СКМ -> открыть скопированную картинку

             ---  Окно вырезанной картинки   ---
Нажатие СКМ -> скопировать
Нажатие ПКМ -> закрыть
Ctrl + ЛКМ -> рисовать
Ctrl + ПКМ -> стирать
Колесо мыши -> зум
Клавиша 0 -> сбросить зум

                            ---   Палитра   ---
Горячая клавиша -> открыть
Нажатие ЛКМ -> скрыть/показать картинку
Нажатие СКМ -> скопировать картинку
Нажатие ПКМ -> закрыть картинку
Двойное нажатие ЛКМ -> картинку к курсору

Некоторые настройки не применяются к уже открытым картинкам";
			}
			else
			{
				Text = "Screen Capture: Settings";
				Lbl_hotkey.Text = "Hotkey";
				CB_vignette.Text = "Draw vignette";
				Lbl_vColor.Text = "Color";
				Lbl_vSize.Text = "Size";
				CB_shadow.Text = "Draw shadow";
				CB_border.Text = "Draw border";
				Lbl_pColor.Text = "Pen color";
				Lbl_zoom.Text = "Zoom step %";
				CB_palette.Text = "Palette";
				Lbl_pHotkey.Text = "Hotkey";
				Lbl_pSize.Text = "Size";
				Lbl_highlight.Text = "Highlight";
				Lbl_lang.Text = "Language";
				Btn_reset.Text = "Reset";
				TextBoxHelp.Text = @"                             ---   Hotkey   ---
Press -> capture
Double press -> hide/show pictures

                   ---   App icon in taskbar   ---
Left click -> capture
Middle click -> open image from clipboard

                 ---  Captured Image popup   ---
Middle click -> copy
Right click -> close
Ctrl + Left button -> draw
Ctrl + Right button -> erase
Scroll wheel -> zoom
Key 0 -> reset zoom

                              ---   Palette   ---
Hotkey -> open
Left click -> hide/show picture
Middle click -> copy picture
Right click -> close picture
Double left click -> picture to cursor

Some settings do not apply to existing popup pictures";
			}
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
			SetTexts();
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

		private void Inp_lang_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_settingValues || Inp_lang.SelectedIndex > 1)
				return;
			Program.Settings.Language = Inp_lang.SelectedIndex;
			Program.Settings.Save();
			SetTexts();
		}
	}
}
