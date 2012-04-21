using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clarified
{
	public partial class ScreenProxy : Form
	{
		public ScreenProxy(Bitmap screenshot)
		{
			InitializeComponent();

			// set the image of the screenshot as the background of the form
			uxBackground.Image = screenshot;
		}

		/// <summary>
		/// An event that is raised when the form loads
		/// </summary>
		private void ScreenProxy_Load(object sender, EventArgs e)
		{

		}

		private void uxBackground_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
