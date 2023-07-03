namespace ColorInput
{
	partial class AlphaInput
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
			this.Inp_range = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.Inp = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.Inp_range)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Inp)).BeginInit();
			this.SuspendLayout();
			// 
			// Inp_range
			// 
			this.Inp_range.LargeChange = 32;
			this.Inp_range.Location = new System.Drawing.Point(0, 0);
			this.Inp_range.Maximum = 255;
			this.Inp_range.Name = "Inp_range";
			this.Inp_range.Size = new System.Drawing.Size(210, 45);
			this.Inp_range.SmallChange = 8;
			this.Inp_range.TabIndex = 0;
			this.Inp_range.TickFrequency = 16;
			this.Inp_range.Scroll += new System.EventHandler(this.Inp_range_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(98, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Alpha";
			// 
			// Inp
			// 
			this.Inp.Location = new System.Drawing.Point(148, 51);
			this.Inp.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.Inp.Name = "Inp";
			this.Inp.Size = new System.Drawing.Size(62, 20);
			this.Inp.TabIndex = 3;
			this.Inp.ValueChanged += new System.EventHandler(this.Inp_ValueChanged);
			// 
			// AlphaInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Inp);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Inp_range);
			this.Name = "AlphaInput";
			this.Size = new System.Drawing.Size(210, 105);
			((System.ComponentModel.ISupportInitialize)(this.Inp_range)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Inp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar Inp_range;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown Inp;
	}
}
