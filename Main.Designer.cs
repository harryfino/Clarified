namespace Clarified
{
	partial class Main
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
			this.uxViewport = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.uxColorPalette = new System.Windows.Forms.Panel();
			this.uxClipboardHsl = new System.Windows.Forms.PictureBox();
			this.uxClipboardRgb = new System.Windows.Forms.PictureBox();
			this.uxClipboardRgbHex = new System.Windows.Forms.PictureBox();
			this.uxGrabColor = new System.Windows.Forms.Button();
			this.uxHsl = new System.Windows.Forms.Label();
			this.uxRgb = new System.Windows.Forms.Label();
			this.uxRgbHex = new System.Windows.Forms.Label();
			this.uxColor = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.uxViewport)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardHsl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardRgb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardRgbHex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxColor)).BeginInit();
			this.SuspendLayout();
			// 
			// uxViewport
			// 
			this.uxViewport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.uxViewport.Location = new System.Drawing.Point(10, 10);
			this.uxViewport.Name = "uxViewport";
			this.uxViewport.Size = new System.Drawing.Size(290, 290);
			this.uxViewport.TabIndex = 3;
			this.uxViewport.TabStop = false;
			this.uxViewport.Paint += new System.Windows.Forms.PaintEventHandler(this.uxViewport_Paint);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.panel1.Controls.Add(this.uxColorPalette);
			this.panel1.Controls.Add(this.uxClipboardHsl);
			this.panel1.Controls.Add(this.uxClipboardRgb);
			this.panel1.Controls.Add(this.uxClipboardRgbHex);
			this.panel1.Controls.Add(this.uxGrabColor);
			this.panel1.Controls.Add(this.uxHsl);
			this.panel1.Controls.Add(this.uxRgb);
			this.panel1.Controls.Add(this.uxRgbHex);
			this.panel1.Controls.Add(this.uxColor);
			this.panel1.Location = new System.Drawing.Point(299, 9);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10);
			this.panel1.Size = new System.Drawing.Size(148, 292);
			this.panel1.TabIndex = 9;
			// 
			// uxColorPalette
			// 
			this.uxColorPalette.Location = new System.Drawing.Point(13, 152);
			this.uxColorPalette.Name = "uxColorPalette";
			this.uxColorPalette.Size = new System.Drawing.Size(122, 70);
			this.uxColorPalette.TabIndex = 17;
			// 
			// uxClipboardHsl
			// 
			this.uxClipboardHsl.BackColor = System.Drawing.Color.Transparent;
			this.uxClipboardHsl.Image = global::Clarified.Properties.Resources.Clipboard;
			this.uxClipboardHsl.Location = new System.Drawing.Point(13, 113);
			this.uxClipboardHsl.Name = "uxClipboardHsl";
			this.uxClipboardHsl.Size = new System.Drawing.Size(16, 16);
			this.uxClipboardHsl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.uxClipboardHsl.TabIndex = 16;
			this.uxClipboardHsl.TabStop = false;
			this.uxClipboardHsl.Click += new System.EventHandler(this.uxClipboardHsl_Click);
			// 
			// uxClipboardRgb
			// 
			this.uxClipboardRgb.BackColor = System.Drawing.Color.Transparent;
			this.uxClipboardRgb.Image = global::Clarified.Properties.Resources.Clipboard;
			this.uxClipboardRgb.Location = new System.Drawing.Point(13, 91);
			this.uxClipboardRgb.Name = "uxClipboardRgb";
			this.uxClipboardRgb.Size = new System.Drawing.Size(16, 16);
			this.uxClipboardRgb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.uxClipboardRgb.TabIndex = 15;
			this.uxClipboardRgb.TabStop = false;
			this.uxClipboardRgb.Click += new System.EventHandler(this.uxClipboardRgb_Click);
			// 
			// uxClipboardRgbHex
			// 
			this.uxClipboardRgbHex.BackColor = System.Drawing.Color.Transparent;
			this.uxClipboardRgbHex.Image = global::Clarified.Properties.Resources.Clipboard;
			this.uxClipboardRgbHex.Location = new System.Drawing.Point(13, 69);
			this.uxClipboardRgbHex.Name = "uxClipboardRgbHex";
			this.uxClipboardRgbHex.Size = new System.Drawing.Size(16, 16);
			this.uxClipboardRgbHex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.uxClipboardRgbHex.TabIndex = 14;
			this.uxClipboardRgbHex.TabStop = false;
			this.uxClipboardRgbHex.Click += new System.EventHandler(this.uxClipboardRgbHex_Click);
			// 
			// uxGrabColor
			// 
			this.uxGrabColor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxGrabColor.Location = new System.Drawing.Point(13, 238);
			this.uxGrabColor.Name = "uxGrabColor";
			this.uxGrabColor.Size = new System.Drawing.Size(122, 41);
			this.uxGrabColor.TabIndex = 13;
			this.uxGrabColor.Text = "Grab A Color";
			this.uxGrabColor.UseVisualStyleBackColor = true;
			this.uxGrabColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uxGrabColor_MouseUp);
			// 
			// uxHsl
			// 
			this.uxHsl.AutoSize = true;
			this.uxHsl.ForeColor = System.Drawing.Color.White;
			this.uxHsl.Location = new System.Drawing.Point(35, 116);
			this.uxHsl.Name = "uxHsl";
			this.uxHsl.Size = new System.Drawing.Size(58, 13);
			this.uxHsl.TabIndex = 12;
			this.uxHsl.Text = "hsl(0, 0, 0)";
			// 
			// uxRgb
			// 
			this.uxRgb.AutoSize = true;
			this.uxRgb.ForeColor = System.Drawing.Color.White;
			this.uxRgb.Location = new System.Drawing.Point(35, 93);
			this.uxRgb.Name = "uxRgb";
			this.uxRgb.Size = new System.Drawing.Size(61, 13);
			this.uxRgb.TabIndex = 11;
			this.uxRgb.Text = "rgb(0, 0, 0)";
			// 
			// uxRgbHex
			// 
			this.uxRgbHex.AutoSize = true;
			this.uxRgbHex.ForeColor = System.Drawing.Color.White;
			this.uxRgbHex.Location = new System.Drawing.Point(35, 71);
			this.uxRgbHex.Name = "uxRgbHex";
			this.uxRgbHex.Size = new System.Drawing.Size(50, 13);
			this.uxRgbHex.TabIndex = 10;
			this.uxRgbHex.Text = "#000000";
			// 
			// uxColor
			// 
			this.uxColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.uxColor.BackColor = System.Drawing.Color.White;
			this.uxColor.Location = new System.Drawing.Point(13, 13);
			this.uxColor.Name = "uxColor";
			this.uxColor.Size = new System.Drawing.Size(122, 50);
			this.uxColor.TabIndex = 9;
			this.uxColor.TabStop = false;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Clarified.Properties.Resources.Background;
			this.ClientSize = new System.Drawing.Size(459, 310);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.uxViewport);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Main";
			this.ShowInTaskbar = false;
			this.Text = "Clarified";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Main_Load);
			((System.ComponentModel.ISupportInitialize)(this.uxViewport)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardHsl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardRgb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardRgbHex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxColor)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox uxViewport;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button uxGrabColor;
		private System.Windows.Forms.Label uxHsl;
		private System.Windows.Forms.Label uxRgb;
		private System.Windows.Forms.Label uxRgbHex;
		private System.Windows.Forms.PictureBox uxColor;
		private System.Windows.Forms.PictureBox uxClipboardRgbHex;
		private System.Windows.Forms.PictureBox uxClipboardHsl;
		private System.Windows.Forms.PictureBox uxClipboardRgb;
		private System.Windows.Forms.Panel uxColorPalette;
	}
}

