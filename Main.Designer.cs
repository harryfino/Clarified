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
			this.uxDebugText = new System.Windows.Forms.Label();
			this.uxDebugLabel = new System.Windows.Forms.Label();
			this.uxViewport = new System.Windows.Forms.PictureBox();
			this.uxColor = new System.Windows.Forms.PictureBox();
			this.uxRgbHex = new System.Windows.Forms.Label();
			this.uxRgb = new System.Windows.Forms.Label();
			this.uxHsl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.uxViewport)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxColor)).BeginInit();
			this.SuspendLayout();
			// 
			// uxDebugText
			// 
			this.uxDebugText.AutoSize = true;
			this.uxDebugText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxDebugText.Location = new System.Drawing.Point(12, 26);
			this.uxDebugText.Name = "uxDebugText";
			this.uxDebugText.Size = new System.Drawing.Size(137, 17);
			this.uxDebugText.TabIndex = 0;
			this.uxDebugText.Text = "x={0:0000}; y={1:0000}";
			// 
			// uxDebugLabel
			// 
			this.uxDebugLabel.AutoSize = true;
			this.uxDebugLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxDebugLabel.Location = new System.Drawing.Point(12, 9);
			this.uxDebugLabel.Name = "uxDebugLabel";
			this.uxDebugLabel.Size = new System.Drawing.Size(82, 17);
			this.uxDebugLabel.TabIndex = 1;
			this.uxDebugLabel.Text = "Debug Info:";
			// 
			// uxViewport
			// 
			this.uxViewport.Location = new System.Drawing.Point(15, 56);
			this.uxViewport.Name = "uxViewport";
			this.uxViewport.Size = new System.Drawing.Size(300, 300);
			this.uxViewport.TabIndex = 3;
			this.uxViewport.TabStop = false;
			this.uxViewport.Paint += new System.Windows.Forms.PaintEventHandler(this.uxViewport_Paint);
			// 
			// uxColor
			// 
			this.uxColor.BackColor = System.Drawing.Color.Black;
			this.uxColor.Location = new System.Drawing.Point(355, 56);
			this.uxColor.Name = "uxColor";
			this.uxColor.Size = new System.Drawing.Size(100, 50);
			this.uxColor.TabIndex = 4;
			this.uxColor.TabStop = false;
			// 
			// uxRgbHex
			// 
			this.uxRgbHex.AutoSize = true;
			this.uxRgbHex.Location = new System.Drawing.Point(362, 109);
			this.uxRgbHex.Name = "uxRgbHex";
			this.uxRgbHex.Size = new System.Drawing.Size(50, 13);
			this.uxRgbHex.TabIndex = 5;
			this.uxRgbHex.Text = "#000000";
			// 
			// uxRgb
			// 
			this.uxRgb.AutoSize = true;
			this.uxRgb.Location = new System.Drawing.Point(362, 125);
			this.uxRgb.Name = "uxRgb";
			this.uxRgb.Size = new System.Drawing.Size(61, 13);
			this.uxRgb.TabIndex = 6;
			this.uxRgb.Text = "rgb(0, 0, 0)";
			// 
			// uxHsl
			// 
			this.uxHsl.AutoSize = true;
			this.uxHsl.Location = new System.Drawing.Point(362, 143);
			this.uxHsl.Name = "uxHsl";
			this.uxHsl.Size = new System.Drawing.Size(58, 13);
			this.uxHsl.TabIndex = 7;
			this.uxHsl.Text = "hsl(0, 0, 0)";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(493, 372);
			this.Controls.Add(this.uxHsl);
			this.Controls.Add(this.uxRgb);
			this.Controls.Add(this.uxRgbHex);
			this.Controls.Add(this.uxColor);
			this.Controls.Add(this.uxViewport);
			this.Controls.Add(this.uxDebugLabel);
			this.Controls.Add(this.uxDebugText);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Main";
			this.Text = "Clarified";
			this.Load += new System.EventHandler(this.Main_Load);
			((System.ComponentModel.ISupportInitialize)(this.uxViewport)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxColor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label uxDebugText;
		private System.Windows.Forms.Label uxDebugLabel;
		private System.Windows.Forms.PictureBox uxViewport;
		private System.Windows.Forms.PictureBox uxColor;
		private System.Windows.Forms.Label uxRgbHex;
		private System.Windows.Forms.Label uxRgb;
		private System.Windows.Forms.Label uxHsl;
	}
}

