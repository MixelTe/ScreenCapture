namespace ScreenCapture
{
	partial class FormSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
			this.label1 = new System.Windows.Forms.Label();
			this.Inp_hotkey = new System.Windows.Forms.TextBox();
			this.Btn_reset = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 11);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hotkey";
			// 
			// Inp_hotkey
			// 
			this.Inp_hotkey.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Inp_hotkey.Location = new System.Drawing.Point(76, 8);
			this.Inp_hotkey.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Inp_hotkey.Name = "Inp_hotkey";
			this.Inp_hotkey.Size = new System.Drawing.Size(111, 20);
			this.Inp_hotkey.TabIndex = 2;
			this.Inp_hotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inp_hotkey_KeyDown);
			this.Inp_hotkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Inp_hotkey_KeyPress);
			// 
			// Btn_reset
			// 
			this.Btn_reset.Location = new System.Drawing.Point(9, 35);
			this.Btn_reset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Btn_reset.Name = "Btn_reset";
			this.Btn_reset.Size = new System.Drawing.Size(54, 21);
			this.Btn_reset.TabIndex = 1;
			this.Btn_reset.Text = "Reset";
			this.Btn_reset.UseVisualStyleBackColor = true;
			this.Btn_reset.Click += new System.EventHandler(this.Btn_reset_Click);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(198, 66);
			this.Controls.Add(this.Btn_reset);
			this.Controls.Add(this.Inp_hotkey);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Screen Capture: Settings";
			this.Click += new System.EventHandler(this.FormSettings_Click);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Inp_hotkey;
		private System.Windows.Forms.Button Btn_reset;
	}
}