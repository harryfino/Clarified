using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clarified
{
	public partial class GradientSlider : UserControl
	{
		#region Constructor
		/// <summary>
		/// Default constructor
		/// </summary>
		public GradientSlider()
		{
			InitializeComponent();

			/// NOTE: if you don't set the handle's parent to the track, then
			/// you'll end up with the background color of the handle being 
			/// the same as whatever the main form's background color is
			uxSliderHandle.Parent = uxSliderTrack;

			// set a default background brush
			this.BackgroundBrush = new SolidBrush(Color.Black);

			// figure out the limits of where the slider can be dragged
			_sliderRange = uxSliderTrack.Width - uxSliderHandle.Width;
		}
		#endregion

		#region Public Events
		/// <summary>
		/// An event that is raised when the value of the slider has changed
		/// </summary>
		public event EventHandler ValueChanged;
		#endregion

		#region Public Methods
		/// <summary>
		/// Sets the background gradient that is used when drawing this control
		/// </summary>
		public void SetBackgroundGradient(Brush gradient)
		{
			// update our background brush
			this.BackgroundBrush = gradient;

			// force a redraw
			this.Invalidate();
		}
		#endregion

		#region Private Events
		/// <summary>
		/// An event that is raised when painting this control
		/// </summary>
		private void GradientSlider_Paint(object sender, PaintEventArgs e)
		{
			// paint the background with our custom brush
			e.Graphics.FillRectangle(this.BackgroundBrush, this.ClientRectangle);
		}

		/// <summary>
		/// An event that is raised when the user presses the mouse button down
		/// </summary>
		private void uxSliderHandle_MouseDown(object sender, MouseEventArgs e)
		{
			// start dragging and keep track of where we started
			_dragging = true;
			_dragStartPosition = e.X;
		}

		/// <summary>
		/// An event that is raised when the user releases the mouse button
		/// </summary>
		private void uxSliderHandle_MouseUp(object sender, MouseEventArgs e)
		{
			// stop the dragging event when they release the mouse
			_dragging = false;
		}

		/// <summary>
		/// An event that is raised when the user moves the mouse over the slider handle
		/// </summary>
		private void uxSliderHandle_MouseMove(object sender, MouseEventArgs e)
		{
			// early exit if we're not dragging
			if (!_dragging)
				return;

			// get the new slider position
			var sliderPos = uxSliderHandle.Left + (e.X - _dragStartPosition);
			
			// restrict the position
			sliderPos = Math.Max(sliderPos, 0);
			sliderPos = Math.Min(sliderPos, (int)_sliderRange);
			
			// update the handle with the new position
			uxSliderHandle.Left = sliderPos;

			// update the internal value
			_value = sliderPos / _sliderRange;
				
			// notify any subscribers that we've changed the value
			if (this.ValueChanged != null) 
				this.ValueChanged(this, EventArgs.Empty);
		}
		#endregion

		#region Private Properties and Members
		/// <summary>
		/// Defines the valid range for the slider
		/// </summary>
		private decimal _sliderRange = 0M;

		/// <summary>
		/// Defines the internal value of the slider (a decimal percentage)
		/// </summary>
		private decimal _value = 0M;

		/// <summary>
		/// Defines the current drag state of the control
		/// </summary>
		private bool _dragging = false;

		/// <summary>
		/// Defines the starting position of the drag event
		/// </summary>
		private int _dragStartPosition = 0;

		/// <summary>
		/// Defines the brush used to paint the background of the control
		/// </summary>
		private Brush BackgroundBrush { get; set; }
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets and sets the position of the slider handle
		/// </summary>
		public decimal Value
		{
			get { return _value; }

			set
			{
				// set the internal value
				_value = value;

				// and move the slider handle into the correct position
				uxSliderHandle.Left = (int)Math.Floor(_sliderRange * value);
			}
		}
		#endregion
	}
}
