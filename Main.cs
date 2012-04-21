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
using System.Drawing.Drawing2D;

namespace Clarified
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
			InitializeScreenSize();
		}

		#region Helper Methods
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
		/// Begins the color selection process
		/// </summary>
		private void BeginColorSelection()
		{
			// disable this button until they select a color
			uxGrabColor.Enabled = false;

			// take a snapshot
			this.CurrentScreenshot = new FastAccessBitmap(this.TakeScreenshot(), false);

			// create a screen proxy to prevent the screen from changing while we're sniffing the pixels
			this.Proxy = new ScreenProxy(this.CurrentScreenshot) { Width = MaxWidth, Height = MaxHeight, Top = 0, Left = 0 };
			this.Proxy.Show();

			// hook the mouse and start tracking the movement
			HookManager.MouseMove += HookManager_MouseMove;
			HookManager.MouseClick += HookManager_MouseClick;

			// draw the viewport
			uxViewport.Invalidate();
		}

		/// <summary>
		/// Ends the color selection and adds the selected color to the palette
		/// </summary>
		private void EndColorSelection()
		{
			// unsubscribe from the global mouse events
			HookManager.MouseMove -= HookManager_MouseMove;
			HookManager.MouseClick -= HookManager_MouseClick;

			// close the proxy
			if (this.Proxy != null && this.Proxy.Visible)
			{
				this.Proxy.Close();
				this.Proxy = null;
			}

			// add the selected color to the palette
			this.AddColorToPalette(uxColor.BackColor);

			// allow the grab button to be used again
			uxGrabColor.Enabled = true;
		}

		/// <summary>
		/// Adds a new color to the color palette
		/// </summary>
		private void AddColorToPalette(Color color)
		{
			var paletteSize = 16;
			var paddingSize = 5;
			var numColors = uxColorPalette.Controls.Count;
			var offsetX = 0;
			var offsetY = 0;

			// create a new color panel
			var colorPanel = new Panel() { Height = paletteSize, Width = paletteSize, BackColor = color };

			// wire up the click event to change the selected color
			colorPanel.Click += colorPanel_Click;

			// figure out where to put it
			if ( numColors > 0 )
			{
				var lastControl = uxColorPalette.Controls[numColors - 1];

				offsetX = lastControl.Right + paddingSize;
				offsetY = lastControl.Top;

				if (numColors % 6 == 0)
				{
					// go to the new row
					offsetX = 0;
					offsetY = lastControl.Bottom + paddingSize;
				}
			}

			// adjust the coordinates before we add it
			colorPanel.Left = offsetX;
			colorPanel.Top = offsetY;

			// add it to the list
			uxColorPalette.Controls.Add(colorPanel);
		}

		/// <summary>
		/// Gets the color from the screenshot at the specified coordinates
		/// </summary>
		private Color GetScreenshotColorAt(int x, int y)
		{
			if (x >= 0 && x < MaxWidth && y >= 0 && y < MaxHeight)
			{
				// get the color at the current cursor position from the screenshot
				return CurrentScreenshot.GetPixelSafe(x, y);
			}

			// invalid color selection
			return Color.Black;
		}

		/// <summary>
		/// Updates the color block with the selected color
		/// </summary>
		private void UpdateColor(Color color)
		{
			// update the color block
			uxColor.BackColor = color;

			// update the RGB hex value
			uxRgbHex.Text = string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
			uxRgb.Text = string.Format("rgb({0:N0}, {1:N0}, {2:N0})", color.R, color.G, color.B);
			uxHsl.Text = string.Format("hsl({0:N0}, {1:N0}%, {2:N0}%)", color.GetHue(), color.GetSaturation() * 100, color.GetBrightness() * 100);
		}
		#endregion

		#region Private Events
		/// <summary>
		/// An event that is raised when the form loads
		/// </summary>
		private void Main_Load(object sender, EventArgs e)
		{
			this.ViewportWidth = uxViewport.Width;
			this.ViewportHeight = uxViewport.Height;

			this.HalfWidth = (ViewportWidth / 2);
			this.HalfHeight = (ViewportHeight / 2);

			this.ZoomLevel = 10;
			this.ZoomWidth = ViewportWidth / ZoomLevel;
			this.ZoomHeight = ViewportHeight / ZoomLevel;
			this.ZoomMidPoint = ZoomLevel / 2;

			this.CrosshairPen = new Pen(Color.Black, 1);
			this.GridPen = new Pen(Color.FromArgb(50, Color.White), 1);

			// auto-start the color selection
			this.BeginColorSelection();
		}

		/// <summary>
		/// An event that is raised when the user clicks the clipboard icon for RGB-Hex
		/// </summary>
		private void uxClipboardRgbHex_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(uxRgbHex.Text);
		}

		/// <summary>
		/// An event that is raised when the user clicks the clipboard icon for RGB
		/// </summary>
		private void uxClipboardRgb_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(uxRgb.Text);
		}

		/// <summary>
		/// An event that is raised when the user clicks the clipboard icons for HSL
		/// </summary>
		private void uxClipboardHsl_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(uxHsl.Text);
		}

		/// <summary>
		/// An event that is raised when the user clicks the grab button
		/// </summary>
		private void uxGrabColor_MouseUp(object sender, MouseEventArgs e)
		{
			if (uxGrabColor.Enabled)
			{
				// initialize the mouse coordinates
				var mousePoint = new Point(e.X, e.Y);
				this.CurrentX = uxGrabColor.PointToScreen(mousePoint).X;
				this.CurrentY = uxGrabColor.PointToScreen(mousePoint).Y;

				// start the color selection
				this.BeginColorSelection();
			}
		}

		/// <summary>
		/// An event that is raised when the viewport needs to paint
		/// </summary>
		private void uxViewport_Paint(object sender, PaintEventArgs e)
		{
			if (this.CurrentScreenshot != null)
			{
				// get the screenshot offsets based on the cursor position
				var x = CurrentX - (ZoomWidth / 2);
				var y = CurrentY - (ZoomHeight / 2);

				// define the rectangles for the scale image
				var viewport = new Rectangle(0, 0, ViewportWidth, ViewportHeight);
				var screenshot = new Rectangle(x, y, ZoomWidth, ZoomHeight);
				var square = new Rectangle(HalfWidth - ZoomMidPoint, HalfHeight - ZoomMidPoint, ZoomLevel, ZoomLevel);

				// draw the screenshot at an offset based on the current cursor position
				e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
				e.Graphics.DrawImage(this.CurrentScreenshot, viewport, screenshot, GraphicsUnit.Pixel);

				// draw the pixel viewer at the center of the crosshair
				e.Graphics.DrawRectangle(CrosshairPen, square);

				// draw the horizontal piece of the crosshair
				e.Graphics.DrawLine(CrosshairPen, HalfWidth, 0, HalfWidth, HalfHeight - ZoomMidPoint);
				e.Graphics.DrawLine(CrosshairPen, HalfWidth, HalfHeight + ZoomMidPoint, HalfWidth, ViewportHeight);

				// draw the vertical piece of the crosshair
				e.Graphics.DrawLine(CrosshairPen, 0, HalfHeight, HalfWidth - ZoomMidPoint, HalfHeight);
				e.Graphics.DrawLine(CrosshairPen, HalfWidth + ZoomMidPoint, HalfHeight, ViewportWidth, HalfHeight);

				// draw vertical grid from the center out
				for (var i = 0; i < HalfWidth; i += ZoomLevel)
				{
					e.Graphics.DrawLine(GridPen, HalfWidth + i + ZoomMidPoint, 0, HalfWidth + i + ZoomMidPoint, ViewportHeight);
					e.Graphics.DrawLine(GridPen, HalfWidth - i - ZoomMidPoint, 0, HalfWidth - i - ZoomMidPoint, ViewportHeight);
				}

				// draw horizontal grid from the center out
				for (var i = 0; i < HalfHeight; i += ZoomLevel)
				{
					// draw a vertical line
					e.Graphics.DrawLine(GridPen, 0, HalfHeight + i + ZoomMidPoint, ViewportWidth, HalfHeight + i + ZoomMidPoint);
					e.Graphics.DrawLine(GridPen, 0, HalfHeight - i - ZoomMidPoint, ViewportWidth, HalfHeight - i - ZoomMidPoint);
				}
			}
		}

		/// <summary>
		/// An event that is raised when the user clicks on one of the colors in the palette
		/// </summary>
		private void colorPanel_Click(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			if (panel != null)
			{
				// update the selected color to this color palette selection
				this.UpdateColor(panel.BackColor);
			}
		}

		/// <summary>
		/// An event raised when the mouse moves
		/// </summary>
		private void HookManager_MouseMove(object sender, MouseEventArgs e)
		{
			// update the cursor position
			this.CurrentX = e.X;
			this.CurrentY = e.Y;

			// get the color under the cursor
			var color = this.GetScreenshotColorAt(e.X, e.Y);

			// update the selected color
			this.UpdateColor(color);

			// force the viewport to repaint the screenshot
			uxViewport.Invalidate();
		}

		/// <summary>
		/// An event that is raised when the user clicks anyway
		/// </summary>
		private void HookManager_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.X > this.Left && e.X < this.Right && e.Y < this.Bottom && e.Y > this.Top)
				return;

			// end the color selection
			this.EndColorSelection();

			var args = e as MouseEventExtArgs;
			if (args != null)
				args.Handled = true;

			// make sure the viewport has the last image
			uxViewport.Invalidate();
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
		private int HalfWidth { get; set; }

		/// <summary>
		/// Defines the amount to offset the Y coordinate in order to center the image
		/// </summary>
		private int HalfHeight { get; set; }

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

		/// <summary>
		/// Defines the pen used to draw the grids
		/// </summary>
		private Pen GridPen { get; set; }

		/// <summary>
		/// Defines the form that will act as a proxy
		/// </summary>
		private ScreenProxy Proxy { get; set; }
		#endregion
	}
}
