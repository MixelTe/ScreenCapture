using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
	internal class Settings
	{
		public Keys Hotkey = Keys.Oemtilde | Keys.Control;

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
