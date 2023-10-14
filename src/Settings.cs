using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
	internal class Settings
	{
		public Keys Hotkey = Keys.Oemtilde | Keys.Control;
		public bool DrawBorder = true;
		public bool DrawShadow = true;
		public Color PenColor = Color.Lime;
		public Color EraserColor = Color.White;
		public bool DrawVignette = true;
		public bool HideOnCapture = true;
		public Color VignetteColor = Color.FromArgb(128, Color.DarkViolet);
		public int VignetteSize = 16;
		public float ZoomStep = 1.15f;
		public Keys HotkeyPalette = Keys.Oemtilde | Keys.Control | Keys.Shift;
		public bool EnablePalette = true;
		public int PaletteSize = 100;
		public Color HighlightColor = Color.FromArgb(128, Color.DarkViolet);
		public int Language = 0; // 0:en; 1:ru
		public bool LanguageSelected = false;
		public Color TextColor = Color.Black;
		public Color TextBgColor = Color.White;
		public int TextSize = 14;


		public void Load()
		{
			RegSerializer.Load(Program.KeyName, this);
			if (!LanguageSelected && CultureInfo.CurrentCulture.Name.StartsWith("ru"))
				Language = 1;
		}

		public void Save()
		{
			RegSerializer.Save(Program.KeyName, this);
		}
	}
}
