namespace ScreenCapture
{
	partial class FormCapture
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCapture));
			this.SuspendLayout();
			// 
			// FormCapture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormCapture";
			this.Text = "ScreenCapture";
			this.TopMost = true;
			this.Click += new System.EventHandler(this.FormCapture_Click);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormCapture_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormCapture_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormCapture_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormCapture_MouseUp);
			this.ResumeLayout(false);

		}

		#endregion
	}
}

