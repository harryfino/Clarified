namespace Clarified
{
	partial class ScreenProxy
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.uxBackground = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.uxBackground)).BeginInit();
			this.SuspendLayout();
			// 
			// uxBackground
			// 
			this.uxBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.uxBackground.BackColor = System.Drawing.Color.Black;
			this.uxBackground.Cursor = System.Windows.Forms.Cursors.Cross;
			this.uxBackground.Location = new System.Drawing.Point(0, 0);
			this.uxBackground.Margin = new System.Windows.Forms.Padding(0);
			this.uxBackground.Name = "uxBackground";
			this.uxBackground.Size = new System.Drawing.Size(493, 337);
			this.uxBackground.TabIndex = 0;
			this.uxBackground.TabStop = false;
			this.uxBackground.Click += new System.EventHandler(this.uxBackground_Click);
			// 
			// ScreenProxy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Maroon;
			this.ClientSize = new System.Drawing.Size(494, 336);
			this.ControlBox = false;
			this.Controls.Add(this.uxBackground);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ScreenProxy";
			this.Text = "ScreenProxy";
			this.Load += new System.EventHandler(this.ScreenProxy_Load);
			((System.ComponentModel.ISupportInitialize)(this.uxBackground)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox uxBackground;
	}
}