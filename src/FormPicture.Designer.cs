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
			this.PictureDraw = new System.Windows.Forms.PictureBox();
			this.PB_highlight = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.PictureDraw)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PB_highlight)).BeginInit();
			this.SuspendLayout();
			// 
			// PictureDraw
			// 
			this.PictureDraw.BackColor = System.Drawing.Color.Transparent;
			this.PictureDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.PictureDraw.Enabled = false;
			this.PictureDraw.Location = new System.Drawing.Point(191, 94);
			this.PictureDraw.Name = "PictureDraw";
			this.PictureDraw.Size = new System.Drawing.Size(366, 170);
			this.PictureDraw.TabIndex = 0;
			this.PictureDraw.TabStop = false;
			// 
			// PB_highlight
			// 
			this.PB_highlight.Enabled = false;
			this.PB_highlight.Location = new System.Drawing.Point(445, 338);
			this.PB_highlight.Name = "PB_highlight";
			this.PB_highlight.Size = new System.Drawing.Size(100, 50);
			this.PB_highlight.TabIndex = 1;
			this.PB_highlight.TabStop = false;
			// 
			// FormPicture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.PB_highlight);
			this.Controls.Add(this.PictureDraw);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormPicture";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ScreenCapture";
			this.TopMost = true;
			this.Click += new System.EventHandler(this.FormPicture_Click);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPicture_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPicture_Key);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPicture_KeyPress);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormPicture_Key);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormPicture_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormPicture_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormPicture_MouseUp);
			((System.ComponentModel.ISupportInitialize)(this.PictureDraw)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PB_highlight)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox PictureDraw;
		private System.Windows.Forms.PictureBox PB_highlight;
	}
}