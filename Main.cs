using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
			InitializeScreenSize();
		}

		/// <summary>
		/// Initializes the size of all the user's monitors
		/// </summary>
		private void InitializeScreenSize()
		{
			foreach (var screen in Screen.AllScreens)
			{
				this.MaxWidth += screen.Bounds.Width;
				if (screen.Bounds.Height > this.MaxHeight)
					this.MaxHeight = screen.Bounds.Height;
			}
		}

		/// <summary>
		/// Takes a screenshot of all the user's monitors
		/// </summary>
		private Bitmap TakeScreenshot()
		{
			var screenshot = new Bitmap(this.MaxWidth, this.MaxHeight, PixelFormat.Format24bppRgb);
			using (var graphics = Graphics.FromImage(screenshot))
			{
				var basePoint = new Point(0, 0);
				var offsetPoint = new Point(0, 0);
				
				foreach (var screen in Screen.AllScreens)
				{
					var screenSize = new Size(screen.Bounds.Width, screen.Bounds.Height);
					var screenGrab = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
					using (var g = Graphics.FromImage(screenGrab))
					{
						g.CopyFromScreen(offsetPoint, basePoint, screenSize);
						graphics.DrawImage(screenGrab, offsetPoint);
						offsetPoint.X += screen.Bounds.Width;
					}
				}
			}

			return screenshot;
		}

		#region Private Events
		/// <summary>
		/// An event raised when the mouse moves
		/// </summary>
		private void HookManager_MouseMove(object sender, MouseEventArgs e)
		{
			// update the text with the new mouse coordinates
			uxDebugText.Text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y);

			// update the cursor position
			this.CurrentX = e.X;
			this.CurrentY = e.Y;

			// force the viewport to repaint the screenshot
			uxViewport.Invalidate();
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

		/// <summary>
		/// An event that is raised when the viewport needs to paint
		/// </summary>
		private void uxViewport_Paint(object sender, PaintEventArgs e)
		{
			// draw the screenshot at an offset based on the current cursor position
			e.Graphics.DrawImage(this.CurrentScreenshot, new Point(OffsetX - CurrentX, OffsetY - CurrentY));
		}

		/// <summary>
		/// An event that is raised when the form loads
		/// </summary>
		private void Main_Load(object sender, EventArgs e)
		{
			this.CurrentScreenshot = this.TakeScreenshot();

			this.OffsetX = (uxViewport.Width / 2);
			this.OffsetY = (uxViewport.Height / 2);
		}
		#endregion

		#region Private Properties
		/// <summary>
		/// A reference to the latest screenshot
		/// </summary>
		private Bitmap CurrentScreenshot { get; set; }

		/// <summary>
		/// Defines the current X position of the cursor
		/// </summary>
		private int CurrentX { get; set; }

		/// <summary>
		/// Defines the current Y position of the cursor
		/// </summary>
		private int CurrentY { get; set; }

		/// <summary>
		/// Defines the amount to offset the X coordinate in order to center the image
		/// </summary>
		private int OffsetX { get; set; }

		/// <summary>
		/// Defines the amount to offset the Y coordinate in order to center the image
		/// </summary>
		private int OffsetY { get; set; }

		/// <summary>
		/// Defines the max height of all the monitors combined
		/// </summary>
		private int MaxHeight { get; set; }

		/// <summary>
		/// Defines the max width of all the monitors combined
		/// </summary>
		private int MaxWidth { get; set; }
		#endregion
	}
}
