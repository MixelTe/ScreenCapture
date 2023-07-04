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

namespace ScreenCapture
{
	public partial class FormAbout : Form
	{
		private readonly Dictionary<string, string> _texts = new Dictionary<string, string>() {
			{"version", Program.Settings.Language == 1 ? "Версия" : "Version" },
			{"copyTitle", Program.Settings.Language == 1 ? "Захват экрана: исходный код" : "ScreenCapture: Source code" },
			{"copyText", Program.Settings.Language == 1 ? "\n\nСкопированно" : "\n\nCopied to clipboard" },
		};

		public FormAbout()
		{
			InitializeComponent();
			Location = new Point(Cursor.Position.X - Width / 2, Cursor.Position.Y - Height - 10);
			Lbl_version.Text = $"{_texts["version"]}: {Application.ProductVersion}";
			SetTexts();
		}

		private void SetTexts()
		{
			if (Program.Settings.Language == 1)
			{
				Text = "Про программу";
				Lbl_title.Text = "Захват экрана";
			}
		}


		private void Btn_gh_Click(object sender, EventArgs e)
		{
			var link = "https://github.com/MixelTe/ScreenCapture";
			try
			{
				var psInfo = new ProcessStartInfo
				{
					FileName = link,
					UseShellExecute = true
				};
				Process.Start(psInfo);
			}
			catch (Exception)
			{
				Clipboard.SetText(link);
				MessageBox.Show(link + _texts["copyText"], _texts["copyTitle"], MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
