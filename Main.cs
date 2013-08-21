using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Clarified.Win32;
using System.Threading;
using System.Threading.Tasks;

namespace Clarified
{
	public partial class Main : Form
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		public Main()
		{
			// run the automatic winforms code
			InitializeComponent();

			// establish our custom border colors
			this.PenBorderActive = new Pen(Color.FromArgb(255, 227, 227, 227), 1);
			this.PenBorderInactive = new Pen(Color.Transparent);
			this.PenBorderCurrent = PenBorderActive;

			// create our pens for drawing the viewport grid
			this.PenCrosshair = new Pen(Color.Black, 1);
			this.PenGrid = new Pen(Color.FromArgb(50, Color.White), 1);

			// establish the viewport defaults
			this.ViewportWidth = uxViewport.Width;
			this.ViewportHeight = uxViewport.Height;
			this.HalfWidth = (ViewportWidth / 2);
			this.HalfHeight = (ViewportHeight / 2);
			this.ZoomLevel = 10;
			this.ZoomWidth = ViewportWidth / ZoomLevel;
			this.ZoomHeight = ViewportHeight / ZoomLevel;
			this.ZoomMidPoint = ZoomLevel / 2;

		}

		#region Hook Events
		/// <summary>
		/// A hook event for whenever the mouse is moved
		/// </summary>
		private void HookManager_MouseMove(object sender, MouseEventArgs e)
		{
			var screen = Screen.FromPoint(new Point { X = e.X, Y = e.Y });
			if (this.CurrentScreen == null || !this.CurrentScreen.Equals(screen))
			{
				this.CurrentScreen = screen;
				this.ScreenOffsetX = screen.Bounds.X;
				this.ScreenOffsetY = screen.Bounds.Y;
				this.CurrentScreenshot = this.TakeScreenshot(screen);
			}

			this.CurrentX = e.X;
			this.CurrentY = e.Y;

			if (e.X >= this.CurrentScreen.Bounds.X && e.Y >= this.CurrentScreen.Bounds.Y && e.X < this.CurrentScreen.Bounds.Right && e.Y < this.CurrentScreen.Bounds.Bottom)
			{
				// get the color under the cursor
				var color = this.GetScreenshotColorAt(e.X - this.CurrentScreen.Bounds.X, e.Y - this.CurrentScreen.Bounds.Y);

				// update the selected color
				this.UpdateColor(color);
			}

			uxViewport.Invalidate();
		}

		/// <summary>
		/// A hook event for whenever the mouse is clicked
		/// </summary>
		private void HookManager_MouseClick(object sender, MouseEventArgs e)
		{
			// prevent the click from going through
			((MouseEventExtArgs)e).Handled = true;

			// stop listening for events
			this.EndColorSelection();
		}
		#endregion

		#region Events for Main
		/// <summary>
		/// An event that is raised when the main windows loads
		/// </summary>
		private void Main_Load(object sender, EventArgs e)
		{
			// automatically start eye dropping
			this.BeginColorSelection();
		}

		/// <summary>
		/// An event that is raised when a key is pressed
		/// </summary>
		private void Main_KeyPress(object sender, KeyPressEventArgs e)
		{
			// exit the app when ESCAPE is pressed
			if (e.KeyChar == (char)Keys.Escape)
				this.Close();
		}

		/// <summary>
		/// An event that is raised when the window needs painting
		/// </summary>
		private void Main_Paint(object sender, PaintEventArgs e)
		{
			// draw a custom border around the window
			e.Graphics.DrawLine(this.PenBorderCurrent, 0, 0, 0, this.Height - 1);
			e.Graphics.DrawLine(this.PenBorderCurrent, 0, 0, this.Width - 1, 0);
			e.Graphics.DrawLine(this.PenBorderCurrent, this.Width - 1, 0, this.Width - 1, this.Height - 1);
			e.Graphics.DrawLine(this.PenBorderCurrent, 0, this.Height - 1, this.Width - 1, this.Height - 1);
		}

		/// <summary>
		/// An event that is raised when the window has focus
		/// </summary>
		private void Main_Activated(object sender, EventArgs e)
		{
			// set the active border
			this.PenBorderCurrent = this.PenBorderActive;
			this.Invalidate();
		}

		/// <summary>
		/// An event that is raised when the window loses focus
		/// </summary>
		private void Main_Deactivate(object sender, EventArgs e)
		{
			// set the inactive border
			this.PenBorderCurrent = this.PenBorderInactive;
			this.Invalidate();
		}

		/// <summary>
		/// An override to move the window from any part of the form
		/// </summary>
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCHITTEST:
					base.WndProc(ref m);

					if ((int)m.Result == HTCLIENT)
						m.Result = (IntPtr)HTCAPTION;

					return;
			}

			base.WndProc(ref m);
		}
		#endregion

		#region Events for uxClose
		/// <summary>
		/// An event that is raised when the mouse is over the close label
		/// </summary>
		private void uxClose_MouseEnter(object sender, EventArgs e)
		{
			// change the background color to #f0f0f0
			uxClose.BackColor = Color.FromArgb(255, 240, 240, 240);
		}

		/// <summary>
		/// An event that is raised when the mouse is no longer over the label
		/// </summary>
		private void uxClose_MouseLeave(object sender, EventArgs e)
		{
			// reset the background color
			uxClose.BackColor = Color.Transparent;
		}

		/// <summary>
		/// An event that is raised when the close label needs to be painted
		/// </summary>
		private void uxClose_Paint(object sender, PaintEventArgs e)
		{
			// paint the cross icon onto the label
			e.Graphics.DrawImage(Clarified.Properties.Resources.Cross, new Rectangle(11, 11, 10, 10));
		}

		/// <summary>
		/// An event that is raised when the close label is clicked
		/// </summary>
		private void uxClose_Click(object sender, EventArgs e)
		{
			// close the application
			this.Close();
		}
		#endregion

		#region Events for uxViewport
		/// <summary>
		/// An event that is raised when the viewport is repainted
		/// </summary>
		private void uxViewport_Paint(object sender, PaintEventArgs e)
		{
			if (this.CurrentScreenshot != null)
			{
				// get the screenshot offsets based on the cursor position
				var x = CurrentX - ScreenOffsetX - (ZoomWidth / 2);
				var y = CurrentY - ScreenOffsetY - (ZoomHeight / 2);

				// define the rectangles for the scale image
				var viewport = new Rectangle(0, 0, ViewportWidth, ViewportHeight);
				var screenshot = new Rectangle(x, y, ZoomWidth, ZoomHeight);
				var square = new Rectangle(HalfWidth - ZoomMidPoint, HalfHeight - ZoomMidPoint, ZoomLevel, ZoomLevel);

				// draw the screenshot at an offset based on the current cursor position
				e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
				e.Graphics.DrawImage(this.CurrentScreenshot, viewport, screenshot, GraphicsUnit.Pixel);

				// draw the pixel viewer at the center of the crosshair
				e.Graphics.DrawRectangle(PenCrosshair, square);

				// draw the horizontal piece of the crosshair
				e.Graphics.DrawLine(PenCrosshair, HalfWidth, 0, HalfWidth, HalfHeight - ZoomMidPoint);
				e.Graphics.DrawLine(PenCrosshair, HalfWidth, HalfHeight + ZoomMidPoint, HalfWidth, ViewportHeight);

				// draw the vertical piece of the crosshair
				e.Graphics.DrawLine(PenCrosshair, 0, HalfHeight, HalfWidth - ZoomMidPoint, HalfHeight);
				e.Graphics.DrawLine(PenCrosshair, HalfWidth + ZoomMidPoint, HalfHeight, ViewportWidth, HalfHeight);

				// draw vertical grid from the center out
				for (var i = 0; i < HalfWidth; i += ZoomLevel)
				{
					e.Graphics.DrawLine(PenGrid, HalfWidth + i + ZoomMidPoint, 0, HalfWidth + i + ZoomMidPoint, ViewportHeight);
					e.Graphics.DrawLine(PenGrid, HalfWidth - i - ZoomMidPoint, 0, HalfWidth - i - ZoomMidPoint, ViewportHeight);
				}

				// draw horizontal grid from the center out
				for (var i = 0; i < HalfHeight; i += ZoomLevel)
				{
					// draw a vertical line
					e.Graphics.DrawLine(PenGrid, 0, HalfHeight + i + ZoomMidPoint, ViewportWidth, HalfHeight + i + ZoomMidPoint);
					e.Graphics.DrawLine(PenGrid, 0, HalfHeight - i - ZoomMidPoint, ViewportWidth, HalfHeight - i - ZoomMidPoint);
				}
			}

			// draw a custom border around the window
			e.Graphics.DrawLine(this.PenBorderActive, 1, 1, 1, uxViewport.Height);
			e.Graphics.DrawLine(this.PenBorderActive, 1, 1, uxViewport.Width, 1);
			e.Graphics.DrawLine(this.PenBorderActive, uxViewport.Width, 0, uxViewport.Width, uxViewport.Height);
			e.Graphics.DrawLine(this.PenBorderActive, 0, uxViewport.Height, uxViewport.Width, uxViewport.Height);
		}
		#endregion

		#region Events for uxStart
		/// <summary>
		/// An event that is raised when the start label is clicked
		/// </summary>
		private void uxStart_MouseUp(object sender, MouseEventArgs e)
		{
			if (uxStart.Enabled)
			{
				// reset the screen
				this.CurrentScreen = null;
				this.CurrentScreenshot = null;

				// start capturing the mouse events
				this.BeginColorSelection();
			}
		}
		#endregion

		#region Events for colorBlock
		/// <summary>
		/// An event that is raised when the user clicks on one of the colors in the palette
		/// </summary>
		private void colorBlock_Click(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			if (panel != null)
			{
				// update the selected color to this color palette selection
				this.UpdateColor(panel.BackColor);
			}
		}

		/// <summary>
		/// An event that is raised when the user starts hovering over a color panel
		/// </summary>
		private void colorBlock_MouseEnter(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			if (panel != null)
			{
				var outerBorder = panel.ClientRectangle;
				var outerBorderSize = 1;

				var innerBorder = new Rectangle(outerBorder.Location, outerBorder.Size);
				var innerBorderSize = 1;

				innerBorder.Inflate(-outerBorderSize, -outerBorderSize);

				using (var graphics = panel.CreateGraphics())
				{
					ControlPaint.DrawBorder(graphics, innerBorder,
						Color.FromArgb(255, 0, 125, 197), innerBorderSize, ButtonBorderStyle.Solid,
						Color.FromArgb(255, 0, 125, 197), innerBorderSize, ButtonBorderStyle.Solid,
						Color.FromArgb(255, 0, 125, 197), innerBorderSize, ButtonBorderStyle.Solid,
						Color.FromArgb(255, 0, 125, 197), innerBorderSize, ButtonBorderStyle.Solid);
				}
			}
		}

		/// <summary>
		/// An event that is raised when the user stops hovering over a color panel
		/// </summary>
		private void colorBlock_MouseLeave(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			if (panel != null)
			{
				// force the panel to redraw so it loses the border
				panel.Invalidate();
			}
		}
		#endregion

		#region Events for uxColor
		/// <summary>
		/// An event that is raised when the color box is painted
		/// </summary>
		private void uxColor_Paint(object sender, PaintEventArgs e)
		{
			var outerBorder = uxColor.ClientRectangle;
			var outerBorderSize = 1;

			var innerBorder = new Rectangle(outerBorder.Location, outerBorder.Size);
			var innerBorderSize = 3;

			innerBorder.Inflate(-outerBorderSize, -outerBorderSize);

			ControlPaint.DrawBorder(e.Graphics, outerBorder,
				uxColor.BackColor, outerBorderSize, ButtonBorderStyle.Solid,
				uxColor.BackColor, outerBorderSize, ButtonBorderStyle.Solid,
				uxColor.BackColor, outerBorderSize, ButtonBorderStyle.Solid,
				uxColor.BackColor, outerBorderSize, ButtonBorderStyle.Solid);

			ControlPaint.DrawBorder(e.Graphics, innerBorder,
				this.BackColor, innerBorderSize, ButtonBorderStyle.Solid,
				this.BackColor, innerBorderSize, ButtonBorderStyle.Solid,
				this.BackColor, innerBorderSize, ButtonBorderStyle.Solid,
				this.BackColor, innerBorderSize, ButtonBorderStyle.Solid);
		}
		#endregion

		#region Events for uxCopy links
		/// <summary>
		/// An event that is raised when the copy hex link is clicked
		/// </summary>
		private void uxCopyHEX_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(uxRgbHex.Text);
			uxCopyHEX.Text = "copied!";

			ResetCopyLabel((Label)sender);
		}

		/// <summary>
		/// An event that is raised when the copy rgb link is clicked
		/// </summary>
		private void uxCopyRGB_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(uxRgb.Text);
			uxCopyRGB.Text = "copied!";

			ResetCopyLabel((Label)sender);
		}

		/// <summary>
		/// An event that is raised when the copy hsl link is clicked
		/// </summary>
		private void uxCopyHSL_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(uxHsl.Text);
			uxCopyHSL.Text = "copied!";

			ResetCopyLabel((Label)sender);
		}
		#endregion

		#region Helper Functions
		/// <summary>
		/// Starts capturing the mouse events
		/// </summary>
		private void BeginColorSelection()
		{
			// prevent multiple color selections
			uxStart.Enabled = false;

			// subscribe to the mouse hooks
			HookManager.MouseMove += HookManager_MouseMove;
			HookManager.MouseClick += HookManager_MouseClick;
		}

		/// <summary>
		/// Stops capturing the mouse events
		/// </summary>
		private void EndColorSelection()
		{
			// unsubscribe
			HookManager.MouseMove -= HookManager_MouseMove;
			HookManager.MouseClick -= HookManager_MouseClick;

			// add the selected color to the palette
			this.AddColorToPalette(uxColor.BackColor);

			// allow the user to start another color selection
			uxStart.Enabled = true;
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

			// create a new color block
			var colorBlock = new Panel() { Height = paletteSize, Width = paletteSize, BackColor = color, Cursor = Cursors.Hand };

			// wire up the click event to change the selected color
			colorBlock.Click += colorBlock_Click;

			// wire up the mouse enter/leave events to give the panel a hover-border
			colorBlock.MouseEnter += colorBlock_MouseEnter;
			colorBlock.MouseLeave += colorBlock_MouseLeave;

			// figure out where to put it
			if (numColors > 0)
			{
				var lastControl = uxColorPalette.Controls[numColors - 1];

				offsetX = lastControl.Right + paddingSize;
				offsetY = lastControl.Top;

				if (numColors % 7 == 0)
				{
					// go to the new row
					offsetX = 0;
					offsetY = lastControl.Bottom + paddingSize;
				}
			}

			// adjust the coordinates before we add it
			colorBlock.Left = offsetX;
			colorBlock.Top = offsetY;

			// add it to the list
			uxColorPalette.Controls.Add(colorBlock);
		}

		/// <summary>
		/// Grab a screenshot of the specific monitor
		/// </summary>
		private FastAccessBitmap TakeScreenshot(Screen currentScreen)
		{
			var left = currentScreen.Bounds.X;
			var top = currentScreen.Bounds.Y;
			var width = currentScreen.Bounds.Width;
			var height = currentScreen.Bounds.Height;
			var size = currentScreen.Bounds.Size;
			var screenshot = new Bitmap(width, height, PixelFormat.Format24bppRgb);

			using (var graphics = Graphics.FromImage(screenshot))
			{
				var source = new Point(left, top);
				var destination = new Point(0, 0);

				graphics.CopyFromScreen(source, destination, size);
			}

			return new FastAccessBitmap(screenshot, false);
		}

		/// <summary>
		/// Gets the color from the screenshot at the specified coordinates
		/// </summary>
		private Color GetScreenshotColorAt(int x, int y)
		{
			// get the color at the current cursor position from the screenshot
			return CurrentScreenshot.GetPixelSafe(x, y);
		}

		/// <summary>
		/// Updates the color block with the selected color
		/// </summary>
		private void UpdateColor(Color color)
		{
			// update the color block
			uxColor.BackColor = color;

			// update the RGB hex value
			uxRgbHex.Text = string.Format("#{0:x2}{1:x2}{2:x2}", color.R, color.G, color.B);
			uxRgb.Text = string.Format("rgb({0:N0}, {1:N0}, {2:N0})", color.R, color.G, color.B);
			uxHsl.Text = string.Format("hsl({0:N0}, {1:N0}%, {2:N0}%)", color.GetHue(), color.GetSaturation() * 100, color.GetBrightness() * 100);
		}

		/// <summary>
		/// An async function to delay the resetting of the copy link text
		/// </summary>
		private async void ResetCopyLabel(Label label)
		{
			// wait 2 seconds before setting it back
			await Task.Delay(2000);
			label.Text = "copy";
		}
		#endregion

		#region Properties
		private const int WM_NCHITTEST = 0x84;
		private const int HTCLIENT = 0x1;
		private const int HTCAPTION = 0x2;

		private Pen PenBorderActive { get; set; }
		private Pen PenBorderInactive { get; set; }
		private Pen PenBorderCurrent { get; set; }
		private Pen PenCrosshair { get; set; }
		private Pen PenGrid { get; set; }

		private Screen CurrentScreen { get; set; }
		private FastAccessBitmap CurrentScreenshot { get; set; }
		private int ScreenOffsetX { get; set; }
		private int ScreenOffsetY { get; set; }
		private int CurrentX { get; set; }
		private int CurrentY { get; set; }
		private int HalfWidth { get; set; }
		private int HalfHeight { get; set; }
		private int ZoomLevel { get; set; }
		private int ZoomMidPoint { get; set; }
		private int ViewportWidth { get; set; }
		private int ViewportHeight { get; set; }
		private int ZoomWidth { get; set; }
		private int ZoomHeight { get; set; }
		#endregion
	}
}
