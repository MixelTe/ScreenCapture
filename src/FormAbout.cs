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
		public FormAbout()
		{
			InitializeComponent();
			Location = new Point(Cursor.Position.X - Width / 2, Cursor.Position.Y - Height - 10);
			Lbl_version.Text = $"Version: {Application.ProductVersion}";
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
				MessageBox.Show(link + "\n\nCopied to clipboard", "ScreenCapture: Source code", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
