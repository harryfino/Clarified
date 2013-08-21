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
			this.uxClose = new System.Windows.Forms.Label();
			this.uxTitle = new System.Windows.Forms.Label();
			this.uxStart = new System.Windows.Forms.Label();
			this.uxColorPalette = new System.Windows.Forms.Panel();
			this.uxHsl = new System.Windows.Forms.Label();
			this.uxRgb = new System.Windows.Forms.Label();
			this.uxRgbHex = new System.Windows.Forms.Label();
			this.uxCopyHEX = new System.Windows.Forms.Label();
			this.uxCopyRGB = new System.Windows.Forms.Label();
			this.uxCopyHSL = new System.Windows.Forms.Label();
			this.uxColor = new System.Windows.Forms.PictureBox();
			this.uxViewport = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.uxColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxViewport)).BeginInit();
			this.SuspendLayout();
			// 
			// uxClose
			// 
			this.uxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.uxClose.Location = new System.Drawing.Point(437, 1);
			this.uxClose.Name = "uxClose";
			this.uxClose.Size = new System.Drawing.Size(32, 32);
			this.uxClose.TabIndex = 1;
			this.uxClose.Click += new System.EventHandler(this.uxClose_Click);
			this.uxClose.Paint += new System.Windows.Forms.PaintEventHandler(this.uxClose_Paint);
			this.uxClose.MouseEnter += new System.EventHandler(this.uxClose_MouseEnter);
			this.uxClose.MouseLeave += new System.EventHandler(this.uxClose_MouseLeave);
			// 
			// uxTitle
			// 
			this.uxTitle.AutoSize = true;
			this.uxTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
			this.uxTitle.Location = new System.Drawing.Point(7, 5);
			this.uxTitle.Name = "uxTitle";
			this.uxTitle.Size = new System.Drawing.Size(89, 30);
			this.uxTitle.TabIndex = 2;
			this.uxTitle.Text = "Clarified";
			// 
			// uxStart
			// 
			this.uxStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uxStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.uxStart.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(197)))));
			this.uxStart.Location = new System.Drawing.Point(315, 303);
			this.uxStart.Name = "uxStart";
			this.uxStart.Size = new System.Drawing.Size(144, 30);
			this.uxStart.TabIndex = 4;
			this.uxStart.Text = "Get a color";
			this.uxStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.uxStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uxStart_MouseUp);
			// 
			// uxColorPalette
			// 
			this.uxColorPalette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uxColorPalette.Location = new System.Drawing.Point(315, 255);
			this.uxColorPalette.Name = "uxColorPalette";
			this.uxColorPalette.Size = new System.Drawing.Size(142, 37);
			this.uxColorPalette.TabIndex = 22;
			// 
			// uxHsl
			// 
			this.uxHsl.AutoSize = true;
			this.uxHsl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxHsl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
			this.uxHsl.Location = new System.Drawing.Point(312, 197);
			this.uxHsl.Name = "uxHsl";
			this.uxHsl.Size = new System.Drawing.Size(67, 17);
			this.uxHsl.TabIndex = 21;
			this.uxHsl.Text = "hsl(0, 0, 0)";
			// 
			// uxRgb
			// 
			this.uxRgb.AutoSize = true;
			this.uxRgb.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxRgb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
			this.uxRgb.Location = new System.Drawing.Point(312, 146);
			this.uxRgb.Name = "uxRgb";
			this.uxRgb.Size = new System.Drawing.Size(72, 17);
			this.uxRgb.TabIndex = 20;
			this.uxRgb.Text = "rgb(0, 0, 0)";
			// 
			// uxRgbHex
			// 
			this.uxRgbHex.AutoSize = true;
			this.uxRgbHex.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxRgbHex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
			this.uxRgbHex.Location = new System.Drawing.Point(313, 99);
			this.uxRgbHex.Name = "uxRgbHex";
			this.uxRgbHex.Size = new System.Drawing.Size(58, 17);
			this.uxRgbHex.TabIndex = 19;
			this.uxRgbHex.Text = "#000000";
			// 
			// uxCopyHEX
			// 
			this.uxCopyHEX.AutoSize = true;
			this.uxCopyHEX.Cursor = System.Windows.Forms.Cursors.Hand;
			this.uxCopyHEX.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxCopyHEX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(197)))));
			this.uxCopyHEX.Location = new System.Drawing.Point(312, 116);
			this.uxCopyHEX.Name = "uxCopyHEX";
			this.uxCopyHEX.Size = new System.Drawing.Size(31, 13);
			this.uxCopyHEX.TabIndex = 23;
			this.uxCopyHEX.Text = "copy";
			this.uxCopyHEX.Click += new System.EventHandler(this.uxCopyHEX_Click);
			// 
			// uxCopyRGB
			// 
			this.uxCopyRGB.AutoSize = true;
			this.uxCopyRGB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.uxCopyRGB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxCopyRGB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(197)))));
			this.uxCopyRGB.Location = new System.Drawing.Point(312, 167);
			this.uxCopyRGB.Name = "uxCopyRGB";
			this.uxCopyRGB.Size = new System.Drawing.Size(31, 13);
			this.uxCopyRGB.TabIndex = 24;
			this.uxCopyRGB.Text = "copy";
			this.uxCopyRGB.Click += new System.EventHandler(this.uxCopyRGB_Click);
			// 
			// uxCopyHSL
			// 
			this.uxCopyHSL.AutoSize = true;
			this.uxCopyHSL.Cursor = System.Windows.Forms.Cursors.Hand;
			this.uxCopyHSL.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxCopyHSL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(197)))));
			this.uxCopyHSL.Location = new System.Drawing.Point(312, 217);
			this.uxCopyHSL.Name = "uxCopyHSL";
			this.uxCopyHSL.Size = new System.Drawing.Size(31, 13);
			this.uxCopyHSL.TabIndex = 25;
			this.uxCopyHSL.Text = "copy";
			this.uxCopyHSL.Click += new System.EventHandler(this.uxCopyHSL_Click);
			// 
			// uxColor
			// 
			this.uxColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uxColor.BackColor = System.Drawing.Color.White;
			this.uxColor.Location = new System.Drawing.Point(315, 41);
			this.uxColor.Name = "uxColor";
			this.uxColor.Size = new System.Drawing.Size(142, 50);
			this.uxColor.TabIndex = 18;
			this.uxColor.TabStop = false;
			this.uxColor.Paint += new System.Windows.Forms.PaintEventHandler(this.uxColor_Paint);
			// 
			// uxViewport
			// 
			this.uxViewport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.uxViewport.Location = new System.Drawing.Point(13, 41);
			this.uxViewport.Name = "uxViewport";
			this.uxViewport.Size = new System.Drawing.Size(290, 290);
			this.uxViewport.TabIndex = 3;
			this.uxViewport.TabStop = false;
			this.uxViewport.Paint += new System.Windows.Forms.PaintEventHandler(this.uxViewport_Paint);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(470, 344);
			this.Controls.Add(this.uxCopyHSL);
			this.Controls.Add(this.uxCopyRGB);
			this.Controls.Add(this.uxCopyHEX);
			this.Controls.Add(this.uxColorPalette);
			this.Controls.Add(this.uxHsl);
			this.Controls.Add(this.uxRgb);
			this.Controls.Add(this.uxRgbHex);
			this.Controls.Add(this.uxColor);
			this.Controls.Add(this.uxStart);
			this.Controls.Add(this.uxViewport);
			this.Controls.Add(this.uxTitle);
			this.Controls.Add(this.uxClose);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Main";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Main";
			this.TopMost = true;
			this.Activated += new System.EventHandler(this.Main_Activated);
			this.Deactivate += new System.EventHandler(this.Main_Deactivate);
			this.Load += new System.EventHandler(this.Main_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
			((System.ComponentModel.ISupportInitialize)(this.uxColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxViewport)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label uxClose;
		private System.Windows.Forms.Label uxTitle;
		private System.Windows.Forms.PictureBox uxViewport;
		private System.Windows.Forms.Label uxStart;
		private System.Windows.Forms.Panel uxColorPalette;
		private System.Windows.Forms.Label uxHsl;
		private System.Windows.Forms.Label uxRgb;
		private System.Windows.Forms.Label uxRgbHex;
		private System.Windows.Forms.PictureBox uxColor;
		private System.Windows.Forms.Label uxCopyHEX;
		private System.Windows.Forms.Label uxCopyRGB;
		private System.Windows.Forms.Label uxCopyHSL;
	}
}

