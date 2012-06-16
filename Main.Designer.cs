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
			this.uxControlPanel = new System.Windows.Forms.Panel();
			this.uxColorPalette = new System.Windows.Forms.Panel();
			this.uxClipboardHsl = new System.Windows.Forms.PictureBox();
			this.uxClipboardRgb = new System.Windows.Forms.PictureBox();
			this.uxClipboardRgbHex = new System.Windows.Forms.PictureBox();
			this.uxGrabColor = new System.Windows.Forms.Button();
			this.uxHsl = new System.Windows.Forms.Label();
			this.uxRgb = new System.Windows.Forms.Label();
			this.uxRgbHex = new System.Windows.Forms.Label();
			this.uxColor = new System.Windows.Forms.PictureBox();
			this.uxColorEditor = new System.Windows.Forms.Panel();
			this.uxHueSlider = new Clarified.GradientSlider();
			this.uxLightnessSlider = new Clarified.GradientSlider();
			this.uxSaturationSlider = new Clarified.GradientSlider();
			this.uxClose = new System.Windows.Forms.PictureBox();
			this.uxLightnessLabel = new System.Windows.Forms.Label();
			this.uxSaturationLabel = new System.Windows.Forms.Label();
			this.uxHueLabel = new System.Windows.Forms.Label();
			this.uxLightnessNumber = new System.Windows.Forms.TextBox();
			this.uxSaturationNumber = new System.Windows.Forms.TextBox();
			this.uxHueNumber = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.uxViewport)).BeginInit();
			this.uxControlPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardHsl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardRgb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardRgbHex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxColor)).BeginInit();
			this.uxColorEditor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uxClose)).BeginInit();
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
			// uxControlPanel
			// 
			this.uxControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.uxControlPanel.Controls.Add(this.uxColorPalette);
			this.uxControlPanel.Controls.Add(this.uxClipboardHsl);
			this.uxControlPanel.Controls.Add(this.uxClipboardRgb);
			this.uxControlPanel.Controls.Add(this.uxClipboardRgbHex);
			this.uxControlPanel.Controls.Add(this.uxGrabColor);
			this.uxControlPanel.Controls.Add(this.uxHsl);
			this.uxControlPanel.Controls.Add(this.uxRgb);
			this.uxControlPanel.Controls.Add(this.uxRgbHex);
			this.uxControlPanel.Controls.Add(this.uxColor);
			this.uxControlPanel.Location = new System.Drawing.Point(299, 9);
			this.uxControlPanel.Name = "uxControlPanel";
			this.uxControlPanel.Padding = new System.Windows.Forms.Padding(10);
			this.uxControlPanel.Size = new System.Drawing.Size(148, 291);
			this.uxControlPanel.TabIndex = 9;
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
			this.uxClipboardHsl.Cursor = System.Windows.Forms.Cursors.Hand;
			this.uxClipboardHsl.Image = global::Clarified.Properties.Resources.Clipboard;
			this.uxClipboardHsl.Location = new System.Drawing.Point(13, 113);
			this.uxClipboardHsl.Name = "uxClipboardHsl";
			this.uxClipboardHsl.Size = new System.Drawing.Size(19, 19);
			this.uxClipboardHsl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.uxClipboardHsl.TabIndex = 16;
			this.uxClipboardHsl.TabStop = false;
			this.uxClipboardHsl.Click += new System.EventHandler(this.uxClipboardHsl_Click);
			this.uxClipboardHsl.MouseEnter += new System.EventHandler(this.uxClipboard_MouseEnter);
			this.uxClipboardHsl.MouseLeave += new System.EventHandler(this.uxClipboard_MouseLeave);
			// 
			// uxClipboardRgb
			// 
			this.uxClipboardRgb.BackColor = System.Drawing.Color.Transparent;
			this.uxClipboardRgb.Cursor = System.Windows.Forms.Cursors.Hand;
			this.uxClipboardRgb.Image = global::Clarified.Properties.Resources.Clipboard;
			this.uxClipboardRgb.Location = new System.Drawing.Point(13, 91);
			this.uxClipboardRgb.Name = "uxClipboardRgb";
			this.uxClipboardRgb.Size = new System.Drawing.Size(19, 19);
			this.uxClipboardRgb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.uxClipboardRgb.TabIndex = 15;
			this.uxClipboardRgb.TabStop = false;
			this.uxClipboardRgb.Click += new System.EventHandler(this.uxClipboardRgb_Click);
			this.uxClipboardRgb.MouseEnter += new System.EventHandler(this.uxClipboard_MouseEnter);
			this.uxClipboardRgb.MouseLeave += new System.EventHandler(this.uxClipboard_MouseLeave);
			// 
			// uxClipboardRgbHex
			// 
			this.uxClipboardRgbHex.BackColor = System.Drawing.Color.Transparent;
			this.uxClipboardRgbHex.Cursor = System.Windows.Forms.Cursors.Hand;
			this.uxClipboardRgbHex.Image = global::Clarified.Properties.Resources.Clipboard;
			this.uxClipboardRgbHex.Location = new System.Drawing.Point(13, 69);
			this.uxClipboardRgbHex.Name = "uxClipboardRgbHex";
			this.uxClipboardRgbHex.Size = new System.Drawing.Size(19, 19);
			this.uxClipboardRgbHex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.uxClipboardRgbHex.TabIndex = 14;
			this.uxClipboardRgbHex.TabStop = false;
			this.uxClipboardRgbHex.Click += new System.EventHandler(this.uxClipboardRgbHex_Click);
			this.uxClipboardRgbHex.MouseEnter += new System.EventHandler(this.uxClipboard_MouseEnter);
			this.uxClipboardRgbHex.MouseLeave += new System.EventHandler(this.uxClipboard_MouseLeave);
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
			this.uxGrabColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
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
			this.uxRgb.Location = new System.Drawing.Point(35, 94);
			this.uxRgb.Name = "uxRgb";
			this.uxRgb.Size = new System.Drawing.Size(61, 13);
			this.uxRgb.TabIndex = 11;
			this.uxRgb.Text = "rgb(0, 0, 0)";
			// 
			// uxRgbHex
			// 
			this.uxRgbHex.AutoSize = true;
			this.uxRgbHex.ForeColor = System.Drawing.Color.White;
			this.uxRgbHex.Location = new System.Drawing.Point(35, 72);
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
			this.uxColor.Click += new System.EventHandler(this.uxColor_Click);
			this.uxColor.Paint += new System.Windows.Forms.PaintEventHandler(this.uxColor_Paint);
			// 
			// uxColorEditor
			// 
			this.uxColorEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.uxColorEditor.Controls.Add(this.uxHueSlider);
			this.uxColorEditor.Controls.Add(this.uxLightnessSlider);
			this.uxColorEditor.Controls.Add(this.uxSaturationSlider);
			this.uxColorEditor.Controls.Add(this.uxClose);
			this.uxColorEditor.Controls.Add(this.uxLightnessLabel);
			this.uxColorEditor.Controls.Add(this.uxSaturationLabel);
			this.uxColorEditor.Controls.Add(this.uxHueLabel);
			this.uxColorEditor.Controls.Add(this.uxLightnessNumber);
			this.uxColorEditor.Controls.Add(this.uxSaturationNumber);
			this.uxColorEditor.Controls.Add(this.uxHueNumber);
			this.uxColorEditor.ForeColor = System.Drawing.Color.White;
			this.uxColorEditor.Location = new System.Drawing.Point(10, 10);
			this.uxColorEditor.Name = "uxColorEditor";
			this.uxColorEditor.Size = new System.Drawing.Size(290, 290);
			this.uxColorEditor.TabIndex = 10;
			this.uxColorEditor.Visible = false;
			// 
			// uxHueSlider
			// 
			this.uxHueSlider.BackColor = System.Drawing.Color.Transparent;
			this.uxHueSlider.Location = new System.Drawing.Point(16, 40);
			this.uxHueSlider.Name = "uxHueSlider";
			this.uxHueSlider.Size = new System.Drawing.Size(227, 22);
			this.uxHueSlider.TabIndex = 33;
			this.uxHueSlider.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.uxHueSlider.ValueChanged += new System.EventHandler(this.Slider_Changed);
			// 
			// uxLightnessSlider
			// 
			this.uxLightnessSlider.BackColor = System.Drawing.Color.Transparent;
			this.uxLightnessSlider.Location = new System.Drawing.Point(16, 125);
			this.uxLightnessSlider.Name = "uxLightnessSlider";
			this.uxLightnessSlider.Size = new System.Drawing.Size(227, 22);
			this.uxLightnessSlider.TabIndex = 32;
			this.uxLightnessSlider.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.uxLightnessSlider.ValueChanged += new System.EventHandler(this.Slider_Changed);
			// 
			// uxSaturationSlider
			// 
			this.uxSaturationSlider.BackColor = System.Drawing.Color.Transparent;
			this.uxSaturationSlider.Location = new System.Drawing.Point(16, 81);
			this.uxSaturationSlider.Name = "uxSaturationSlider";
			this.uxSaturationSlider.Size = new System.Drawing.Size(227, 22);
			this.uxSaturationSlider.TabIndex = 31;
			this.uxSaturationSlider.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.uxSaturationSlider.ValueChanged += new System.EventHandler(this.Slider_Changed);
			// 
			// uxClose
			// 
			this.uxClose.Image = global::Clarified.Properties.Resources.close;
			this.uxClose.Location = new System.Drawing.Point(261, 11);
			this.uxClose.Name = "uxClose";
			this.uxClose.Size = new System.Drawing.Size(14, 14);
			this.uxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.uxClose.TabIndex = 29;
			this.uxClose.TabStop = false;
			this.uxClose.Click += new System.EventHandler(this.uxClose_Click);
			// 
			// uxLightnessLabel
			// 
			this.uxLightnessLabel.AutoSize = true;
			this.uxLightnessLabel.ForeColor = System.Drawing.Color.White;
			this.uxLightnessLabel.Location = new System.Drawing.Point(13, 109);
			this.uxLightnessLabel.Name = "uxLightnessLabel";
			this.uxLightnessLabel.Size = new System.Drawing.Size(56, 13);
			this.uxLightnessLabel.TabIndex = 28;
			this.uxLightnessLabel.Text = "Lightness";
			// 
			// uxSaturationLabel
			// 
			this.uxSaturationLabel.AutoSize = true;
			this.uxSaturationLabel.ForeColor = System.Drawing.Color.White;
			this.uxSaturationLabel.Location = new System.Drawing.Point(13, 65);
			this.uxSaturationLabel.Name = "uxSaturationLabel";
			this.uxSaturationLabel.Size = new System.Drawing.Size(61, 13);
			this.uxSaturationLabel.TabIndex = 27;
			this.uxSaturationLabel.Text = "Saturation";
			// 
			// uxHueLabel
			// 
			this.uxHueLabel.AutoSize = true;
			this.uxHueLabel.ForeColor = System.Drawing.Color.White;
			this.uxHueLabel.Location = new System.Drawing.Point(13, 21);
			this.uxHueLabel.Name = "uxHueLabel";
			this.uxHueLabel.Size = new System.Drawing.Size(28, 13);
			this.uxHueLabel.TabIndex = 26;
			this.uxHueLabel.Text = "Hue";
			// 
			// uxLightnessNumber
			// 
			this.uxLightnessNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.uxLightnessNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uxLightnessNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxLightnessNumber.ForeColor = System.Drawing.Color.White;
			this.uxLightnessNumber.Location = new System.Drawing.Point(249, 125);
			this.uxLightnessNumber.Name = "uxLightnessNumber";
			this.uxLightnessNumber.Size = new System.Drawing.Size(33, 25);
			this.uxLightnessNumber.TabIndex = 25;
			this.uxLightnessNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.uxLightnessNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SliderNumber_KeyUp);
			// 
			// uxSaturationNumber
			// 
			this.uxSaturationNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.uxSaturationNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uxSaturationNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxSaturationNumber.ForeColor = System.Drawing.Color.White;
			this.uxSaturationNumber.Location = new System.Drawing.Point(249, 81);
			this.uxSaturationNumber.Name = "uxSaturationNumber";
			this.uxSaturationNumber.Size = new System.Drawing.Size(33, 25);
			this.uxSaturationNumber.TabIndex = 24;
			this.uxSaturationNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.uxSaturationNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SliderNumber_KeyUp);
			// 
			// uxHueNumber
			// 
			this.uxHueNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.uxHueNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uxHueNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxHueNumber.ForeColor = System.Drawing.Color.White;
			this.uxHueNumber.Location = new System.Drawing.Point(249, 41);
			this.uxHueNumber.Name = "uxHueNumber";
			this.uxHueNumber.Size = new System.Drawing.Size(33, 25);
			this.uxHueNumber.TabIndex = 23;
			this.uxHueNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.uxHueNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SliderNumber_KeyUp);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Clarified.Properties.Resources.Background;
			this.ClientSize = new System.Drawing.Size(459, 310);
			this.Controls.Add(this.uxViewport);
			this.Controls.Add(this.uxControlPanel);
			this.Controls.Add(this.uxColorEditor);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Main";
			this.ShowInTaskbar = false;
			this.Text = "Clarified";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Main_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
			((System.ComponentModel.ISupportInitialize)(this.uxViewport)).EndInit();
			this.uxControlPanel.ResumeLayout(false);
			this.uxControlPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardHsl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardRgb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxClipboardRgbHex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxColor)).EndInit();
			this.uxColorEditor.ResumeLayout(false);
			this.uxColorEditor.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uxClose)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox uxViewport;
		private System.Windows.Forms.Panel uxControlPanel;
		private System.Windows.Forms.Button uxGrabColor;
		private System.Windows.Forms.Label uxHsl;
		private System.Windows.Forms.Label uxRgb;
		private System.Windows.Forms.Label uxRgbHex;
		private System.Windows.Forms.PictureBox uxColor;
		private System.Windows.Forms.PictureBox uxClipboardRgbHex;
		private System.Windows.Forms.PictureBox uxClipboardHsl;
		private System.Windows.Forms.PictureBox uxClipboardRgb;
		private System.Windows.Forms.Panel uxColorPalette;
		private System.Windows.Forms.Panel uxColorEditor;
		private System.Windows.Forms.PictureBox uxClose;
		private System.Windows.Forms.Label uxLightnessLabel;
		private System.Windows.Forms.Label uxSaturationLabel;
		private System.Windows.Forms.Label uxHueLabel;
		private System.Windows.Forms.TextBox uxLightnessNumber;
		private System.Windows.Forms.TextBox uxSaturationNumber;
		private System.Windows.Forms.TextBox uxHueNumber;
		private GradientSlider uxSaturationSlider;
		private GradientSlider uxLightnessSlider;
		private GradientSlider uxHueSlider;
	}
}

