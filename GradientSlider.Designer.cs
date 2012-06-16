namespace Clarified
{
	partial class GradientSlider
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.uxSliderTrack = new System.Windows.Forms.PictureBox();
			this.uxSliderHandle = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.uxSliderTrack)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSliderHandle)).BeginInit();
			this.SuspendLayout();
			// 
			// uxSliderTrack
			// 
			this.uxSliderTrack.BackColor = System.Drawing.Color.Transparent;
			this.uxSliderTrack.Image = global::Clarified.Properties.Resources.dragtrack;
			this.uxSliderTrack.Location = new System.Drawing.Point(0, 0);
			this.uxSliderTrack.Name = "uxSliderTrack";
			this.uxSliderTrack.Size = new System.Drawing.Size(227, 22);
			this.uxSliderTrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.uxSliderTrack.TabIndex = 1;
			this.uxSliderTrack.TabStop = false;
			// 
			// uxSliderHandle
			// 
			this.uxSliderHandle.BackColor = System.Drawing.Color.Transparent;
			this.uxSliderHandle.Image = global::Clarified.Properties.Resources.draghandle;
			this.uxSliderHandle.Location = new System.Drawing.Point(3, 3);
			this.uxSliderHandle.Name = "uxSliderHandle";
			this.uxSliderHandle.Size = new System.Drawing.Size(16, 16);
			this.uxSliderHandle.TabIndex = 2;
			this.uxSliderHandle.TabStop = false;
			this.uxSliderHandle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uxSliderHandle_MouseDown);
			this.uxSliderHandle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uxSliderHandle_MouseMove);
			this.uxSliderHandle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uxSliderHandle_MouseUp);
			// 
			// GradientSlider
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.uxSliderHandle);
			this.Controls.Add(this.uxSliderTrack);
			this.Name = "GradientSlider";
			this.Size = new System.Drawing.Size(227, 22);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.GradientSlider_Paint);
			((System.ComponentModel.ISupportInitialize)(this.uxSliderTrack)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxSliderHandle)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox uxSliderTrack;
		private System.Windows.Forms.PictureBox uxSliderHandle;
	}
}
