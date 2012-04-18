using System.Windows.Forms;

namespace Clarified.Win32
{
	/// <summary>
	/// This class manages all of the icky windows hooking to capture low-level mouse events
	/// </summary>
	/// <remarks>
	/// Special credit goes to George Mamaladze (@gmamaladze) for this code from: 
	/// http://www.codeproject.com/Articles/7294/Processing-Global-Mouse-and-Keyboard-Hooks-in-C
	/// </remarks>
	public static partial class HookManager
	{
		/// <summary>
		/// Occurs when the mouse pointer is moved
		/// </summary>
		public static event MouseEventHandler MouseMove
		{
			add { Subscribe(ref _mouseMoveEvent, value); }
			remove { Unsubscribe(ref _mouseMoveEvent, value); }
		}

		/// <summary>
		/// Occurs when a click was performed by the mouse
		/// </summary>
		public static event MouseEventHandler MouseClick
		{
			add { Subscribe(ref _mouseClickEvent, value); }
			remove { Unsubscribe(ref _mouseClickEvent, value); }
		}

		/// <summary>
		/// Occurs when the mouse a mouse button is pressed
		/// </summary>
		public static event MouseEventHandler MouseDown
		{
			add { Subscribe(ref _mouseDownEvent, value); }
			remove { Unsubscribe(ref _mouseDownEvent, value); }
		}

		/// <summary>
		/// Occurs when a mouse button is released
		/// </summary>
		public static event MouseEventHandler MouseUp
		{
			add { Subscribe(ref _mouseUpEvent, value); }
			remove { Unsubscribe(ref _mouseUpEvent, value); }
		}

		#region Subscription Methods
		/// <summary>
		/// Abstraction to make sure we've setting the windows hook for event subscriptions
		/// </summary>
		private static void Subscribe(ref MouseEventHandler e, MouseEventHandler callback)
		{
			// establish the windows hook
			SetWindowsHook(); 
		
			// subscribe to the event
			e += callback;
		}

		/// <summary>
		/// Abstraction to make sure we unset the windows hook when we're done with it
		/// </summary>
		private static void Unsubscribe(ref MouseEventHandler e, MouseEventHandler callback)
		{
			// unsubscribe from the event
			e -= callback;

			// try to safely remove the windows hook
			TryUnhookWindowsHook();
		}
		#endregion

		#region Private Static Mouse Events
		private static event MouseEventHandler _mouseMoveEvent;
		private static event MouseEventHandler _mouseClickEvent;
		private static event MouseEventHandler _mouseDownEvent;
		private static event MouseEventHandler _mouseUpEvent;
		#endregion
	}
}
