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

		/// <summary>
		/// Updates the color block with the selected color
		/// </summary>
		private void UpdateColor()
		{
			// get the color at the current cursor position from the screenshot
			var color = CurrentScreenshot.GetPixelSafe(CurrentX, CurrentY);

			// update the color block
			uxColor.BackColor = color;

			// update the RGB hex value
			uxRgbHex.Text = string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
			uxRgb.Text = string.Format("rgb({0:N0}, {1:N0}, {2:N0})", color.R, color.G, color.B);
			uxHsl.Text = string.Format("hsl({0:N0}, {1:N0}%, {2:N0}%)", color.GetHue(), color.GetSaturation() * 100, color.GetBrightness() * 100);
		}

		#region Private Events
		/// <summary>
		/// An event that is raised when the form loads
		/// </summary>
		private void Main_Load(object sender, EventArgs e)
		{
			this.CurrentScreenshot = new FastAccessBitmap(this.TakeScreenshot(), false);

			this.ViewportWidth = uxViewport.Width;
			this.ViewportHeight = uxViewport.Height;

			this.OffsetX = (ViewportWidth / 2);
			this.OffsetY = (ViewportHeight / 2);

			this.ZoomLevel = 6;
			this.ZoomWidth = ViewportWidth / ZoomLevel;
			this.ZoomHeight = ViewportHeight / ZoomLevel;
			this.ZoomMidPoint = ZoomLevel / 2;

			this.CrosshairPen = new Pen(Color.Black, 1);

			HookManager.MouseMove += HookManager_MouseMove;
			HookManager.MouseClick += HookManager_MouseClick;
		}

		/// <summary>
		/// An event that is raised when the viewport needs to paint
		/// </summary>
		private void uxViewport_Paint(object sender, PaintEventArgs e)
		{
			// get the screenshot offsets based on the cursor position
			var x = CurrentX - (ZoomWidth / 2);
			var y = CurrentY - (ZoomHeight / 2);

			// define the rectangles for the scale image
			var viewport = new Rectangle(0, 0, ViewportWidth, ViewportHeight);
			var screenshot = new Rectangle(x, y, ZoomWidth, ZoomHeight);
			var square = new Rectangle(OffsetX - ZoomMidPoint, OffsetY - ZoomMidPoint, ZoomLevel, ZoomLevel);

			// draw the screenshot at an offset based on the current cursor position
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(this.CurrentScreenshot, viewport, screenshot, GraphicsUnit.Pixel);

			// draw the pixel viewer at the center of the crosshair
			e.Graphics.DrawRectangle(CrosshairPen, square);
			
			// draw the horizontal piece of the crosshair
			e.Graphics.DrawLine(CrosshairPen, OffsetX, 0, OffsetX, (ViewportHeight / 2) - ZoomMidPoint);
			e.Graphics.DrawLine(CrosshairPen, OffsetX, (ViewportHeight / 2) + ZoomMidPoint, OffsetX, ViewportHeight);

			// draw the vertical piece of the crosshair
			e.Graphics.DrawLine(CrosshairPen, 0, OffsetY, (ViewportWidth / 2) - ZoomMidPoint, OffsetY);
			e.Graphics.DrawLine(CrosshairPen, (ViewportWidth / 2) + ZoomMidPoint, OffsetY, ViewportWidth, OffsetY);
		}

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

			// update the selected color
			this.UpdateColor();

			// force the viewport to repaint the screenshot
			uxViewport.Invalidate();
		}

		/// <summary>
		/// An event that is raised when the user clicks anyway
		/// </summary>
		private void HookManager_MouseClick(object sender, MouseEventArgs e)
		{
			// unsubscribe from the global mouse events
			HookManager.MouseMove -= HookManager_MouseMove;
			HookManager.MouseClick -= HookManager_MouseClick;

			// mark the event as handled
			var args = e as MouseEventExtArgs;
			if (args != null)
				args.Handled = true;
		}
		#endregion

		#region Private Properties
		/// <summary>
		/// A reference to the latest screenshot
		/// </summary>
		private FastAccessBitmap CurrentScreenshot { get; set; }

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
		/// Defines the zoom level for the viewport
		/// </summary>
		private int ZoomLevel { get; set; }

		/// <summary>
		/// Defines the midpoint of the zoom level for the crosshair square
		/// </summary>
		private int ZoomMidPoint { get; set; }

		/// <summary>
		/// Defines the width of the viewport
		/// </summary>
		private int ViewportWidth { get; set; }

		/// <summary>
		/// Defines the height of the viewport
		/// </summary>
		private int ViewportHeight { get; set; }

		/// <summary>
		/// Defines the selection width of the screenshot to be scaled
		/// </summary>
		private int ZoomWidth { get; set; }

		/// <summary>
		/// Defines the selection height of the screenshot to be scaled
		/// </summary>
		private int ZoomHeight { get; set; }

		/// <summary>
		/// Defines the max height of all the monitors combined
		/// </summary>
		private int MaxHeight { get; set; }

		/// <summary>
		/// Defines the max width of all the monitors combined
		/// </summary>
		private int MaxWidth { get; set; }

		/// <summary>
		/// Defines the pen used to draw the crosshairs
		/// </summary>
		private Pen CrosshairPen { get; set; }
		#endregion
	}
}
