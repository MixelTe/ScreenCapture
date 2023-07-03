namespace ScreenCapture
{
	partial class FormPicturePalette
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPicturePalette));
			this.Timer_checkCursor = new System.Windows.Forms.Timer(this.components);
			this.PB_selection = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.PB_selection)).BeginInit();
			this.SuspendLayout();
			// 
			// Timer_checkCursor
			// 
			this.Timer_checkCursor.Enabled = true;
			this.Timer_checkCursor.Tick += new System.EventHandler(this.Timer_checkCursor_Tick);
			// 
			// PB_selection
			// 
			this.PB_selection.BackColor = System.Drawing.Color.Transparent;
			this.PB_selection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PB_selection.Enabled = false;
			this.PB_selection.Location = new System.Drawing.Point(0, 0);
			this.PB_selection.Name = "PB_selection";
			this.PB_selection.Size = new System.Drawing.Size(300, 100);
			this.PB_selection.TabIndex = 0;
			this.PB_selection.TabStop = false;
			// 
			// FormPicturePalette
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 100);
			this.Controls.Add(this.PB_selection);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormPicturePalette";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ScreenCapture: PicturePalette";
			this.TopMost = true;
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormPicturePalette_KeyUp);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormPicturePalette_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.PB_selection)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer Timer_checkCursor;
		private System.Windows.Forms.PictureBox PB_selection;
	}
}