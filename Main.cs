using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clarified.Win32;

namespace Clarified
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		/// <summary>
		/// An event raised when the mouse moves
		/// </summary>
		private void HookManager_MouseMove(object sender, MouseEventArgs e)
		{
			// update the text with the new mouse coordinates
			uxDebugText.Text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y);
		}

		/// <summary>
		/// An event that is raised when the user clicks the debug checkbox
		/// </summary>
		private void uxDebugCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (uxDebugCheckBox.Checked)
				HookManager.MouseMove += HookManager_MouseMove;
			else
				HookManager.MouseMove -= HookManager_MouseMove;
		}
	}
}
