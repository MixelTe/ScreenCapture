using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace ScreenCapture
{
	internal static class Program
	{
		public static readonly string KeyName = @"HKEY_CURRENT_USER\Software\MixelTe\ScreenCapture";
		public static Settings Settings = new Settings();
		public static Hotkey Hotkey;
		public static Hotkey HotkeyPalette;
		public static Mutex mutex;

		[STAThread]
		static void Main()
		{
			mutex = new Mutex(true, "ScreenCapture{27b4fde6-827f-41dd-b0da-c325bc820645}", out var isNewCreated);
			Settings.Load();

			if (isNewCreated)
			{
				Hotkey = new Hotkey();
				Hotkey.SetHotkey(Settings.Hotkey);
				HotkeyPalette = new Hotkey();
				HotkeyPalette.SetHotkey(Settings.HotkeyPalette);
				try
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new App());
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error\n{ex.Message}", "Screen Capture", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				Hotkey.Unregister();
				HotkeyPalette.Unregister();
			}
			else
			{
				MessageBox.Show("Already launched", "Screen Capture");
			}
		}
	}
}
