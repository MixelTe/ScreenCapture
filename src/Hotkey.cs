using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.InteropServices;

namespace ScreenCapture
{
    public class Hotkey : IMessageFilter, IDisposable
	{
		#region Interop

		[DllImport("user32.dll", SetLastError = true)]
		private static extern int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern int UnregisterHotKey(IntPtr hWnd, int id);

		private const uint WM_HOTKEY = 0x312;

		private const uint MOD_ALT = 0x1;
		private const uint MOD_CONTROL = 0x2;
		private const uint MOD_SHIFT = 0x4;
		private const uint MOD_WIN = 0x8;

		private const uint ERROR_HOTKEY_ALREADY_REGISTERED = 1409;

		#endregion

		private static int _currentID;
		private const int maximumID = 0xBFFF;
		
		private Keys _keyCode;
        private bool _shift;
        private bool _control;
        private bool _alt;
		private bool _windows;

		[XmlIgnore]
		private int _id;
		[XmlIgnore]
		private bool _registered;
		private bool disposedValue;

		public event HandledEventHandler Pressed;

		public Hotkey() : this(Keys.None, false, false, false, false)
		{
			// No work done here!
		}
		
		public Hotkey(Keys keyCode, bool shift, bool control, bool alt, bool windows)
		{
			// Assign properties
			KeyCode = keyCode;
			Shift = shift;
			Control = control;
			Alt = alt;
			Windows = windows;

			// Register us as a message filter
			Application.AddMessageFilter(this);
		}

		public Hotkey Clone()
		{
			return new Hotkey(_keyCode, _shift, _control, _alt, _windows);
		}

		public bool TryRegister()
		{
			try
			{
				return Register();
			}
			catch
			{ 
				return false; 
			}
		}

		public bool Register()
        {
			if (_registered)
				throw new NotSupportedException("You cannot register a hotkey that is already registered");
        
			if (Empty)
				throw new NotSupportedException("You cannot register an empty hotkey");

			_id = _currentID;
			_currentID = (_currentID + 1) % maximumID;

			// Translate modifier keys into unmanaged version
			uint modifiers = (Alt ? MOD_ALT : 0) | (Control ? MOD_CONTROL : 0) |
							(Shift ? MOD_SHIFT : 0) | (Windows ? MOD_WIN : 0);

			// Register the hotkey
			if (RegisterHotKey(IntPtr.Zero, _id, modifiers, _keyCode) == 0)
			{ 
				// Is the error that the hotkey is registered?
				if (Marshal.GetLastWin32Error() == ERROR_HOTKEY_ALREADY_REGISTERED)
					return false;
				else
					throw new Win32Exception();
			}

			_registered = true;

			return true;
		}

		public void Unregister()
		{
			if (!_registered)
				throw new NotSupportedException("You cannot unregister a hotkey that is not registered");

			if (UnregisterHotKey(IntPtr.Zero, _id) == 0)
				throw new Win32Exception();

			_registered = false;
		}

		private void Reregister()
		{
			if (!_registered)
				return;

			Unregister();
			Register();
		}

		public bool PreFilterMessage(ref Message message)
		{
			if (message.Msg != WM_HOTKEY)
				return false;

			if (_registered && (message.WParam.ToInt32() == _id))
				return OnPressed();
			else
				return false;
		}

		private bool OnPressed()
		{
			var handledEventArgs = new HandledEventArgs(false);
			Pressed?.Invoke(this, handledEventArgs);

			return handledEventArgs.Handled;
		}

        public override string ToString()
        {
			// We can be empty
			if (Empty)
			{ return "(none)"; }

			// Build key name
			string keyName = Enum.GetName(typeof(Keys), _keyCode);;
			switch (_keyCode)
			{
				case Keys.D0:
				case Keys.D1:
				case Keys.D2:
				case Keys.D3:
				case Keys.D4:
				case Keys.D5:
				case Keys.D6:
				case Keys.D7:
				case Keys.D8:
				case Keys.D9:
					// Strip the first character
					keyName = keyName.Substring(1);
					break;
				default:
					// Leave everything alone
					break;
			}

            // Build modifiers
            string modifiers = "";
            if (_shift)
            { modifiers += "Shift+"; }
            if (_control)
            { modifiers += "Control+"; }
            if (_alt)
            { modifiers += "Alt+"; }
			if (_windows)
			{ modifiers += "Windows+"; }

			// Return result
            return modifiers + keyName;
        }

		public bool Empty
		{
			get { return _keyCode == Keys.None; }
		}

		public bool Registered
		{
			get { return _registered; }
		}

        public Keys KeyCode
        {
            get { return _keyCode; }
            set
			{
				// Save and reregister
				_keyCode = value;
				Reregister();
			}
        }

        public bool Shift
        {
            get { return _shift; }
            set 
			{
				// Save and reregister
				_shift = value;
				Reregister();
			}
        }

        public bool Control
        {
            get { return _control; }
            set
			{ 
				// Save and reregister
				_control = value;
				Reregister();
			}
        }

        public bool Alt
        {
            get { return _alt; }
            set
			{ 
				// Save and reregister
				_alt = value;
				Reregister();
			}
        }

		public bool Windows
		{
			get { return _windows; }
			set 
			{
				// Save and reregister
				_windows = value;
				Reregister();
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					Application.RemoveMessageFilter(this);
				}

				if (Registered)
					Unregister();

				disposedValue = true;
			}
		}

		~Hotkey()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
