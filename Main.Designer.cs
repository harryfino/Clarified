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
			this.uxDebugCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// uxDebugText
			// 
			this.uxDebugText.AutoSize = true;
			this.uxDebugText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxDebugText.Location = new System.Drawing.Point(29, 55);
			this.uxDebugText.Name = "uxDebugText";
			this.uxDebugText.Size = new System.Drawing.Size(137, 17);
			this.uxDebugText.TabIndex = 0;
			this.uxDebugText.Text = "x={0:0000}; y={1:0000}";
			// 
			// uxDebugLabel
			// 
			this.uxDebugLabel.AutoSize = true;
			this.uxDebugLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uxDebugLabel.Location = new System.Drawing.Point(29, 38);
			this.uxDebugLabel.Name = "uxDebugLabel";
			this.uxDebugLabel.Size = new System.Drawing.Size(82, 17);
			this.uxDebugLabel.TabIndex = 1;
			this.uxDebugLabel.Text = "Debug Info:";
			// 
			// uxDebugCheckBox
			// 
			this.uxDebugCheckBox.AutoSize = true;
			this.uxDebugCheckBox.Location = new System.Drawing.Point(32, 12);
			this.uxDebugCheckBox.Name = "uxDebugCheckBox";
			this.uxDebugCheckBox.Size = new System.Drawing.Size(175, 17);
			this.uxDebugCheckBox.TabIndex = 2;
			this.uxDebugCheckBox.Text = "Check to debug mouse move";
			this.uxDebugCheckBox.UseVisualStyleBackColor = true;
			this.uxDebugCheckBox.CheckedChanged += new System.EventHandler(this.uxDebugCheckBox_CheckedChanged);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 413);
			this.Controls.Add(this.uxDebugCheckBox);
			this.Controls.Add(this.uxDebugLabel);
			this.Controls.Add(this.uxDebugText);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Main";
			this.Text = "Clarified";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label uxDebugText;
		private System.Windows.Forms.Label uxDebugLabel;
		private System.Windows.Forms.CheckBox uxDebugCheckBox;
	}
}

