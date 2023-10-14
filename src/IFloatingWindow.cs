using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture
{
	internal interface IFloatingWindow
	{
		bool Visible { get; }
		bool IsDisposed { get; }
		Point Location { set; }
		Size Size { get; }
		void Close();
		void Hide();
		void Show();
		void ToggleHighlight(bool enable);
		Bitmap GetPicture();
		void CopyToClipboard(bool ctrl);
	}
}
