using System;
using System.Collections.Generic;
using System.Drawing;
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
		public bool DrawVignette = true;
		public Color VignetteColor = Color.FromArgb(128, Color.DarkViolet);
		public int VignetteSize = 16;
		public float ZoomStep = 1.15f;
		public Keys HotkeyPalette = Keys.Oemtilde | Keys.Control | Keys.Shift;
		public bool EnablePalette = true;
		public int PaletteSize = 100;
		public Color HighlightColor = Color.FromArgb(128, Color.DarkViolet);

		public void Load()
		{
			RegSerializer.Load(Program.KeyName, this);
		}

		public void Save()
		{
			RegSerializer.Save(Program.KeyName, this);
		}
	}
}
