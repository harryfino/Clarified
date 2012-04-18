using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Clarified.Win32
{
	public static partial class HookManager
	{
		/// <summary>
		/// A callback function which will be called every time a mouse activity detected
		/// </summary>
		/// <param name="nCode">
		/// [in] Specifies whether the hook procedure must process the message. 
		/// If nCode is HC_ACTION, the hook procedure must process the message. 
		/// If nCode is less than zero, the hook procedure must pass the message to the 
		/// CallNextHookEx function without further processing and must return the 
		/// value returned by CallNextHookEx.
		/// </param>
		/// <param name="wParam">
		/// [in] Specifies whether the message was sent by the current thread. 
		/// If the message was sent by the current thread, it is nonzero; otherwise, it is zero. 
		/// </param>
		/// <param name="lParam">
		/// [in] Pointer to a CWPSTRUCT structure that contains details about the message. 
		/// </param>
		/// <returns>
		/// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx. 
		/// If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx 
		/// and return the value it returns; otherwise, other applications that have installed WH_CALLWNDPROC 
		/// hooks will not receive hook notifications and may behave incorrectly as a result. If the hook 
		/// procedure does not call CallNextHookEx, the return value should be zero. 
		/// </returns>
		private static int MouseHookProc(int nCode, int wParam, IntPtr lParam)
		{
			if (nCode >= 0)
			{
				// marshall the data from callback
				MouseLLHookStruct mouseHookStruct = (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));

				MouseButtons buttonClicked = MouseButtons.None;
				bool mouseDown = false;
				bool mouseUp = false;

				switch (wParam)
				{
					case WM_LBUTTONDOWN:
						mouseDown = true;
						buttonClicked = MouseButtons.Left;
						break;
					case WM_LBUTTONUP:
						mouseUp = true;
						buttonClicked = MouseButtons.Left;
						break;
					case WM_RBUTTONDOWN:
						mouseDown = true;
						buttonClicked = MouseButtons.Right;
						break;
					case WM_RBUTTONUP:
						mouseUp = true;
						buttonClicked = MouseButtons.Right;
						break;
				}

				// generate event 
				MouseEventExtArgs e = new MouseEventExtArgs(buttonClicked, 1, mouseHookStruct.Point.X, mouseHookStruct.Point.Y, 0);

				#region Invoke Subscribed Events
				if (_mouseUpEvent != null && mouseUp)
					_mouseUpEvent.Invoke(null, e);

				if (_mouseDownEvent != null && mouseDown)
					_mouseDownEvent.Invoke(null, e);

				if (_mouseClickEvent != null && buttonClicked != MouseButtons.None)
					_mouseClickEvent.Invoke(null, e);

				if (_mouseMoveEvent != null && (_oldX != mouseHookStruct.Point.X || _oldY != mouseHookStruct.Point.Y))
				{
					_oldX = mouseHookStruct.Point.X;
					_oldY = mouseHookStruct.Point.Y;

					if (_mouseMoveEvent != null)
						_mouseMoveEvent.Invoke(null, e);
				}
				#endregion

				// do not call the next hook if we've handle this event
				if (e.Handled)
					return -1;
			}

			// call next hook
			return CallNextHookEx(_mouseHookHandle, nCode, wParam, lParam);
		}

		#region Hooking and Unhooking Static Methods
		/// <summary>
		/// Sets the window hook procedure if it's not already hooked
		/// </summary>
		private static void SetWindowsHook()
		{
			// install mouse hook only if it is not installed and must be installed
			if (_mouseHookHandle == 0)
			{
				// hold an internal reference so GC doesn't clean this up
				_mouseHookDelegate = MouseHookProc;

				using (var process = Process.GetCurrentProcess())
				using (var module = process.MainModule)
					// install the windows hook
					_mouseHookHandle = SetWindowsHookEx(WH_MOUSE_LL, _mouseHookDelegate, GetModuleHandle(module.ModuleName), 0);

				// NOTE: this method doesn't work anymore
				// _mouseHookHandle = SetWindowsHookEx(WH_MOUSE_LL, _mouseHookDelegate, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);

				if (_mouseHookHandle == 0)
				{
					// returns the error code returned by the last unmanaged function called using platform invoke that has the DllImportAttribute.SetLastError flag set
					int errorCode = Marshal.GetLastWin32Error();
					
					// initializes and throws a new instance of the Win32Exception class with the specified error
					throw new Win32Exception(errorCode);
				}
			}
		}

		/// <summary>
		/// Safely unhooks our window procedure
		/// </summary>
		private static void TryUnhookWindowsHook()
		{
			// if no subsribers are registered unsubsribe from hook
			if (_mouseClickEvent == null && _mouseDownEvent == null && _mouseMoveEvent == null && _mouseUpEvent == null)
				UnhookWindowsHook();
		}

		/// <summary>
		/// Unhooks our window hook procedure
		/// </summary>
		private static void UnhookWindowsHook()
        {
			if (_mouseHookHandle != 0)
            {
                // uninstall hook
				int result = UnhookWindowsHookEx(_mouseHookHandle);

                // reset invalid handle
				_mouseHookHandle = 0;

                // free up for GC
                _mouseHookDelegate = null;

                // if failed and exception must be thrown
                if (result == 0)
                {
					// returns the error code returned by the last unmanaged function called using platform invoke that has the DllImportAttribute.SetLastError flag set
					int errorCode = Marshal.GetLastWin32Error();

					// initializes and throws a new instance of the Win32Exception class with the specified error
					throw new Win32Exception(errorCode);
                }
            }
        }
		#endregion

		#region Private Statics
		/// <summary>
		/// The CallWndProc hook procedure is an application-defined or library-defined callback 
		/// function used with the SetWindowsHookEx function. The HOOKPROC type defines a pointer 
		/// to this callback function. CallWndProc is a placeholder for the application-defined 
		/// or library-defined function name.
		/// </summary>
		/// <param name="nCode">
		/// [in] Specifies whether the hook procedure must process the message. 
		/// If nCode is HC_ACTION, the hook procedure must process the message. 
		/// If nCode is less than zero, the hook procedure must pass the message to the 
		/// CallNextHookEx function without further processing and must return the 
		/// value returned by CallNextHookEx.
		/// </param>
		/// <param name="wParam">
		/// [in] Specifies whether the message was sent by the current thread. 
		/// If the message was sent by the current thread, it is nonzero; otherwise, it is zero. 
		/// </param>
		/// <param name="lParam">
		/// [in] Pointer to a CWPSTRUCT structure that contains details about the message. 
		/// </param>
		/// <returns>
		/// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx. 
		/// If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx 
		/// and return the value it returns; otherwise, other applications that have installed WH_CALLWNDPROC 
		/// hooks will not receive hook notifications and may behave incorrectly as a result. If the hook 
		/// procedure does not call CallNextHookEx, the return value should be zero. 
		/// </returns>
		/// <remarks>
		/// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookfunctions/callwndproc.asp
		/// </remarks>
		private delegate int HookProc(int nCode, int wParam, IntPtr lParam);

		/// <summary>
		/// This field is not objectively needed but we need to keep a reference on a delegate which will be 
		/// passed to unmanaged code. To avoid GC to clean it up.
		/// When passing delegates to unmanaged code, they must be kept alive by the managed application 
		/// until it is guaranteed that they will never be called.
		/// </summary>
		private static HookProc _mouseHookDelegate;

		/// <summary>
		/// Stores the handle to the mouse hook procedure
		/// </summary>
		private static int _mouseHookHandle;

		/// <summary>
		/// Stores the last X coordinate so we can tell if we've moved the mouse
		/// </summary>
		private static int _oldX;

		/// <summary>
		/// Stores the last Y coordinate so we can tell if we've moved the mouse
		/// </summary>
		private static int _oldY;
		#endregion
	}
}
