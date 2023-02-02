namespace ScreenCapture
{
	partial class FormPicture
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPicture));
			this.SuspendLayout();
			// 
			// FormPicture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormPicture";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ScreenCapture";
			this.Click += new System.EventHandler(this.FormPicture_Click);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormPicture_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormPicture_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormPicture_MouseUp);
			this.ResumeLayout(false);

		}

		#endregion
	}
}