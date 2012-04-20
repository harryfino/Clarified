using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Clarified
{
	public delegate byte[] PixelEnumeratorCallback(byte[] color, Point memoryPosition);

	public sealed class FastAccessBitmap: IDisposable
	{
		#region Constants
		public const PixelFormat PixelFormatDuringEdit = PixelFormat.Format24bppRgb;
		#endregion

		#region Fields
		private byte[] _imageRaw;
		private BitmapData _imageData;
		private int _stride;
		private object _lockSync;
		#endregion

		#region Implicit Casting
		public static implicit operator Image(FastAccessBitmap fastAccessBitmap)
		{
			return fastAccessBitmap.Image;
		}

		public static implicit operator Bitmap(FastAccessBitmap fastAccessBitmap)
		{
			return fastAccessBitmap.Image;
		}
		#endregion

		#region Constructors
		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public FastAccessBitmap(int width, int height)
		{
			// Validate Arguments
			if (width <= 0)
				throw new ArgumentOutOfRangeException("width");

			if (height <= 0)
				throw new ArgumentOutOfRangeException("height");

			// Set Fields
			_lockSync = new object();

			// Set Properties
			this.Width = width;
			this.Height = height;
			this.Image = new Bitmap(width, height, FastAccessBitmap.PixelFormatDuringEdit);
		}

		/// <exception cref="System.ArgumentNullException"/>
		public FastAccessBitmap(Bitmap image, bool createCopy)
		{
			// Validate Argument
			if (image == null)
				throw new ArgumentNullException("image");

			// Set Fields
			_lockSync = new object();

			// Set Properties
			this.Width = image.Width;
			this.Height = image.Height;
			this.Image = createCopy ? new Bitmap(image) : image;

			// Convert Image To Proper Pixel Format
			if (this.Image.PixelFormat != FastAccessBitmap.PixelFormatDuringEdit)
			{
				// Create New Bitmap With Proper Pixel Format
				Bitmap newImage = new Bitmap(this.Width, this.Height, FastAccessBitmap.PixelFormatDuringEdit);

				// Copy Data
				using (Graphics grfx = Graphics.FromImage(newImage))
				{
					grfx.DrawImageUnscaled(this.Image, 0, 0);
				}

				// Dispose Previous Image
				this.Image.Dispose();

				// Switch Images
				this.Image = newImage;
			}
		}
		#endregion

		#region Properties
		public int Height { get; private set; }
		public int Width { get; private set; }
		public Bitmap Image { get; private set; }
		public bool IsLocked { get; private set; }
		#endregion

		#region Pixel Access Members
		public byte[] Pixels
		{
			get
			{
				lock (_lockSync)
				{
					this.ValidateLockState();
					return _imageRaw;
				}
			}

			set
			{
				lock (_lockSync)
				{
					this.ValidateLockState();

					// Validate Length
					if (value == null || value.Length != _imageRaw.Length)
						throw new ArgumentOutOfRangeException("value");

					_imageRaw = value;
				}
			}
		}

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		/// <exception cref="System.InvalidOperationException"/>
		public Color GetPixel(int x, int y)
		{
			lock (_lockSync)
			{
				this.ValidateLockState();

				// Validate Arguments
				if (x < 0 || x >= this.Width)
					throw new ArgumentOutOfRangeException("x");

				if (y < 0 || y >= this.Height)
					throw new ArgumentOutOfRangeException("y");

				// Calculate Base Position
				int basePosition = (y * _stride) + (x * 3);

				// Decode Color Values
				byte blue = _imageRaw[basePosition + 0];
				byte green = _imageRaw[basePosition + 1];
				byte red = _imageRaw[basePosition + 2];

				return Color.FromArgb(red, green, blue);
			}
		}

		public Color GetPixelSafe(int x, int y)
		{
			Color color = Color.Black;

			this.LockToEdit(false);
			color = this.GetPixel(x, y);
			this.ReleaseFromEdit(true);

			return color;
		}

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		/// <exception cref="System.InvalidOperationException"/>
		public void SetPixel(int x, int y, Color color)
		{
			lock (_lockSync)
			{
				this.ValidateLockState();

				// Validate Arguments
				if (x < 0 || x >= this.Width)
					throw new ArgumentOutOfRangeException("x");

				if (y < 0 || y >= this.Height)
					throw new ArgumentOutOfRangeException("y");

				// Calculate Base Position
				int basePosition = (y * _stride) + (x * 3);

				// Set Color
				_imageRaw[basePosition + 0] = color.B;
				_imageRaw[basePosition + 1] = color.G;
				_imageRaw[basePosition + 2] = color.R;
			}
		}

		public void ForEachPixel(PixelEnumeratorCallback callback)
		{
			lock (_lockSync)
			{
				this.ValidateLockState();

				// Validate Arguments
				if (callback == null)
					throw new ArgumentNullException("callback");

				// Process All Pixels
				byte[] colorBuffer = new byte[3];
				int maxX = (this.Width * 3);
				for (int y = 0; y < _imageRaw.Length; y += _stride)
				{
					for (int x = y; x < (y + maxX); x += 3)
					{
						// Pre-Compute Entry Points
						int posB = x;
						int posG = x + 1;
						int posR = x + 2;

						// Extract Color Data
						colorBuffer[0] = _imageRaw[posR];
						colorBuffer[1] = _imageRaw[posG];
						colorBuffer[2] = _imageRaw[posB];

						// Perform Function
						byte[] newColor = callback(colorBuffer, new Point(x, y));

						// Set Color Values
						_imageRaw[posB] = colorBuffer[2];
						_imageRaw[posG] = colorBuffer[1];
						_imageRaw[posR] = colorBuffer[0];
					}
				}
			}
		}

		private byte[] GetPixelRaw(int x, int y)
		{
			lock (_lockSync)
			{
				// Validate State
				if (_imageRaw == null || _imageRaw.Length <= 0)
					throw new InvalidOperationException("Not locked properly");

				// Validate Arguments
				if (x < 0 || x >= this.Width)
					throw new ArgumentOutOfRangeException("x");

				if (y < 0 || y >= this.Height)
					throw new ArgumentOutOfRangeException("y");

				// Calculate Base Position
				int basePosition = (y * _stride) + (x * 3);

				// Decode Color Values
				byte[] color = new byte[3];
				color[2] = _imageRaw[basePosition + 0];
				color[1] = _imageRaw[basePosition + 1];
				color[0] = _imageRaw[basePosition + 2];

				return color;
			}
		}
		#endregion

		#region Bitmap Memory Management
		public void LockToEdit(bool refreshPixels)
		{
			lock (_lockSync)
			{
				// Quick Return If Already Locked
				if (this.IsLocked)
					return;

				// Perform Lock
				_imageData = this.Image.LockBits(new Rectangle(0, 0, this.Width, this.Height), ImageLockMode.ReadWrite, FastAccessBitmap.PixelFormatDuringEdit);
				this.IsLocked = true;

				// Store Image Parameters
				_stride = _imageData.Stride;

				// Copy Raw Data Into Managed Memory Space
				if (_imageRaw == null || _imageRaw.Length == 0 || refreshPixels)
					this.RefreshPixels();
			}
		}

		/// <exception cref="System.Exception"/>
		public void ReleaseFromEdit(bool ignoreChanges)
		{
			lock (_lockSync)
			{
				// Quick Return If Already Released
				if (!this.IsLocked)
					return;

				if (!ignoreChanges)
				{
					// Copy Edited Data Into Unmanaged Memory Space
					Marshal.Copy(_imageRaw, 0, _imageData.Scan0, _imageRaw.Length);
				}

				// Perform Release
				this.Image.UnlockBits(_imageData);
				this.IsLocked = false;
			}
		}

		public void RefreshPixels()
		{
			lock (_lockSync)
			{
				// Verify State
				if (!this.IsLocked)
					throw new InvalidOperationException("Not locked properly");

				// Copy Raw Data Into Managed Memory Space
				_imageRaw = new byte[_stride * this.Height];
				Marshal.Copy(_imageData.Scan0, _imageRaw, 0, _imageRaw.Length);
			}
		}

		private void ValidateLockState()
		{
			if (!this.IsLocked)
				throw new InvalidOperationException("Object must be locked before pixels may be accessed.");
		}
		#endregion

		#region Optimized Methods
		public void ConvertToGreyscale()
		{
			lock (_lockSync)
			{
				// Verify In Locked Mode
				bool isLocked = this.IsLocked;
				if (!isLocked)
					this.LockToEdit(true);

				// Process All Pixels
				int maxX = (this.Width * 3);
				for (int y = 0; y < _imageRaw.Length; y += _stride)
				{
					for (int x = y; x < (y + maxX); x += 3)
					{
						// Pre-Compute Entry Points
						int posB = x;
						int posG = x + 1;
						int posR = x + 2;

						// Compute New Value
						byte luminance = Convert.ToByte((_imageRaw[posR] * 0.3) + (_imageRaw[posG] * 0.59) + (_imageRaw[posB] * 0.11));

						// Set Color Values
						_imageRaw[posB] = luminance;
						_imageRaw[posG] = luminance;
						_imageRaw[posR] = luminance;
					}
				}

				// Leave Locked Mode
				if (!isLocked)
					this.ReleaseFromEdit(false);
			}
		}

		public void ApplyGreyscaleThreshold(byte threshold)
		{
			lock (_lockSync)
			{
				// Verify In Locked Mode
				bool isLocked = this.IsLocked;
				if (!isLocked)
					this.LockToEdit(true);

				// Define Color Constants
				byte black = 0;
				byte white = 255;

				// Process All Pixels
				int maxX = (this.Width * 3);
				for (int y = 0; y < _imageRaw.Length; y += _stride)
				{
					for (int x = y; x < (y + maxX); x += 3)
					{
						// Compute New Value
						byte value = _imageRaw[x] >= threshold ? white : black;

						// Set Color Values
						_imageRaw[x] = value;
						_imageRaw[x + 1] = value;
						_imageRaw[x + 2] = value;
					}
				}

				// Leave Locked Mode
				if (!isLocked)
					this.ReleaseFromEdit(false);
			}
		}

		public Padding CaluclateWhiteSpaceMargins()
		{
			lock (_lockSync)
			{
				// Verify Image Data
				if (_imageRaw == null || _imageRaw.Length <= 0)
				{
					this.LockToEdit(true);
					this.ReleaseFromEdit(true);
				}

				// Get Base Color
				byte[] baseColor = this.GetPixelRaw(0, 0);

				// Initialize Result
				Padding whiteSpaceMargins = new Padding(0);

				int maxX = this.Width * 3;

				// Check Top Lines
				for (int y = 0; y < _imageRaw.Length; y += _stride)
				{
					bool allSameColor = true;

					for (int x = y; x < (y + maxX); x += 3)
					{
						// Compare Color
						if (_imageRaw[x + 2] != baseColor[0] ||
							_imageRaw[x + 1] != baseColor[1] ||
							_imageRaw[x + 0] != baseColor[2])
						{
							allSameColor = false;
							break;
						}
					}

					if (allSameColor)
						whiteSpaceMargins.Top += 1;
					else
						break;
				}

				// Is Entire Image The Same Color?
				if (whiteSpaceMargins.Top == this.Height)
					return whiteSpaceMargins;

				// Check Bottom Lines
				for (int y = (_imageRaw.Length - _stride); y >= 0; y -= _stride)
				{
					bool allSameColor = true;

					for (int x = y; x < (y + maxX); x += 3)
					{
						// Compare Color
						if (_imageRaw[x + 2] != baseColor[0] ||
							_imageRaw[x + 1] != baseColor[1] ||
							_imageRaw[x + 0] != baseColor[2])
						{
							allSameColor = false;
							break;
						}
					}

					if (allSameColor)
						whiteSpaceMargins.Bottom += 1;
					else
						break;
				}

				// Check Left Lines
				for (int x = 0; x < _stride; x += 3)
				{
					bool allSameColor = true;

					for (int y = x; y < _imageRaw.Length; y += _stride)
					{
						// Compare Color
						if (_imageRaw[y + 2] != baseColor[0] ||
							_imageRaw[y + 1] != baseColor[1] ||
							_imageRaw[y + 0] != baseColor[2])
						{
							allSameColor = false;
							break;
						}
					}

					if (allSameColor)
						whiteSpaceMargins.Left += 1;
					else
						break;
				}

				// Check Right Lines
				for (int x = ((this.Width - 1) * 3); x >= 0; x -= 3)
				{
					bool allSameColor = true;

					for (int y = x; y < _imageRaw.Length; y += _stride)
					{
						// Compare Color
						if (_imageRaw[y + 2] != baseColor[0] ||
							_imageRaw[y + 1] != baseColor[1] ||
							_imageRaw[y + 0] != baseColor[2])
						{
							allSameColor = false;
							break;
						}
					}

					if (allSameColor)
						whiteSpaceMargins.Right += 1;
					else
						break;
				}

				return whiteSpaceMargins;
			}
		}
		#endregion

		#region IDisposable Members
		private bool _disposed;

		public void Dispose()
		{
			this.Dispose(true);

			GC.SuppressFinalize(this);
		}

		~FastAccessBitmap()
		{
			this.Dispose(false);
		}

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					if (this.Image != null)
						this.Image.Dispose();
				}

				this.Image = null;
				_disposed = true;
			}
		}
		#endregion
	}
}
