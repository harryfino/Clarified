using System;
using System.Drawing;

namespace Clarified
{
	public class SuperColor
	{
		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public SuperColor() { }

		/// <summary>
		/// Overloaded constructor that allows the user to set the hue, saturation, and lightness
		/// </summary>
		public SuperColor(int h, int s, int l)
		{
			// initialize the color by HSL
			this.SetHSL(h, s, l);
		}

		/// <summary>
		/// Overloaded constructor that allows the user to set the RGB by way of the color class
		/// </summary>
		public SuperColor(Color color)
		{
			// initialize the color by RGB
			this.SetRGB(color.R, color.G, color.B);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// A helper method to update the color with RGB values
		/// </summary>
		public void SetRGB(int r, int g, int b)
		{
			// get the easy stuff out of the way
			this.R = r; this.G = g; this.B = b;

			var fr = (r / 255F);
			var fg = (g / 255F);
			var fb = (b / 255F);
			var fh = 0F;
			var fs = 0F;
			var fl = 0F;

			var max = Math.Max(fr, Math.Max(fg, fb));
			var min = Math.Min(fr, Math.Min(fg, fb));
			var diff = max - min;
			var add = max + min;

			if (min == max) 
				fh = 0;
			else if (fr == max) 
				fh = ((60 * (fg - fb) / diff) + 360) % 360;
			else if (fg == max) 
				fh = (60 * (fb - fr) / diff) + 120;
			else 
				fh = (60 * (fr - fg) / diff) + 240;

			fl = 0.5F * add;

			if (fl == 0) 
				fs = 0;
			else if (fl == 1) 
				fs = 1;
			else if (fl <= 0.5) 
				fs = diff / add;
			else 
				fs = diff / (2 - add);

			this.H = (int)Math.Floor(fh);
			this.S = (int)Math.Floor(fs * 100);
			this.L = (int)Math.Floor(fl * 100);
		}

		/// <summary>
		/// A helper method that updates the color with HSL values
		/// </summary>
		public void SetHSL(int h, int s, int l)
		{
			// get the easy stuff out of the way
			this.H = h; this.S = s; this.L = l;


			float fh = h / 360f;
			float fs = s / 100f;
			float fl = l / 100f;

			float q = 0F;
			
			if (fl <= 0.5f) 
				q = fl * (1f + fs);
			else 
				q = fl + fs - (fl * fs);

			float p = 2f * fl - q;
			float tr = fh + (1f / 3f);
			float tg = fh;
			float tb = fh - (1f / 3f);

			this.R = (int)Math.Floor(this.GetHue(p, q, tr) * 255f);
			this.G = (int)Math.Floor(this.GetHue(p, q, tg) * 255f);
			this.B = (int)Math.Floor(this.GetHue(p, q, tb) * 255f);
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// A helper method that gets the hue of a color
		/// </summary>
		private float GetHue(float p, float q, float h)
		{
			if (h < 0f) 
				h += 1f;
			else if (h > 1f) 
				h -= 1f;

			if ((h * 6f) < 1f) 
				return p + (q - p) * h * 6f;
			else if ((h * 2f) < 1f) 
				return q;
			else if ((h * 3f) < 2f) 
				return p + (q - p) * ((2f / 3f) - h) * 6f;
			else
				return p;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Defines the RED portion of the color
		/// </summary>
		public int R { get; private set; }

		/// <summary>
		/// Defines the GREEN portion of the color
		/// </summary>
		public int G { get; private set; }

		/// <summary>
		/// Defines the BLUE portion of the color
		/// </summary>
		public int B { get; private set; }

		/// <summary>
		/// Defines the HUE portion of the color
		/// </summary>
		public int H { get; private set; }

		/// <summary>
		/// Defines the SATURATION portion of the color
		/// </summary>
		public int S { get; private set; }

		/// <summary>
		/// Defines the LIGHTNESS portion of the color
		/// </summary>
		public int L { get; private set; }
		#endregion

		/// <summary>
		/// Implicit conversion to the Color class
		/// </summary>
		public static implicit operator Color(SuperColor color)
		{
			return Color.FromArgb(color.R, color.G, color.B);
		}
	}
}
