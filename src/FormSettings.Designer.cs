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
			this.CB_shadow = new System.Windows.Forms.CheckBox();
			this.CB_border = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Btn_penColor = new System.Windows.Forms.Button();
			this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
			this.label3 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.CB_vignette = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.Panel_vignette = new System.Windows.Forms.FlowLayoutPanel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.Btn_vignette = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.Inp_vignette = new System.Windows.Forms.NumericUpDown();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.Panel_vignette.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Inp_vignette)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 5);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hotkey";
			// 
			// Inp_hotkey
			// 
			this.Inp_hotkey.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Inp_hotkey.Location = new System.Drawing.Point(59, 3);
			this.Inp_hotkey.Margin = new System.Windows.Forms.Padding(2);
			this.Inp_hotkey.Name = "Inp_hotkey";
			this.Inp_hotkey.Size = new System.Drawing.Size(111, 20);
			this.Inp_hotkey.TabIndex = 2;
			this.Inp_hotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inp_hotkey_KeyDown);
			this.Inp_hotkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Inp_hotkey_KeyPress);
			// 
			// Btn_reset
			// 
			this.Btn_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Btn_reset.Location = new System.Drawing.Point(9, 215);
			this.Btn_reset.Margin = new System.Windows.Forms.Padding(2);
			this.Btn_reset.Name = "Btn_reset";
			this.Btn_reset.Size = new System.Drawing.Size(54, 21);
			this.Btn_reset.TabIndex = 1;
			this.Btn_reset.Text = "Reset";
			this.Btn_reset.UseVisualStyleBackColor = true;
			this.Btn_reset.Click += new System.EventHandler(this.Btn_reset_Click);
			// 
			// CB_shadow
			// 
			this.CB_shadow.AutoSize = true;
			this.CB_shadow.Location = new System.Drawing.Point(3, 109);
			this.CB_shadow.Name = "CB_shadow";
			this.CB_shadow.Size = new System.Drawing.Size(91, 17);
			this.CB_shadow.TabIndex = 3;
			this.CB_shadow.Text = "Draw shadow";
			this.CB_shadow.UseVisualStyleBackColor = true;
			this.CB_shadow.CheckedChanged += new System.EventHandler(this.CB_shadow_CheckedChanged);
			// 
			// CB_border
			// 
			this.CB_border.AutoSize = true;
			this.CB_border.Location = new System.Drawing.Point(3, 132);
			this.CB_border.Name = "CB_border";
			this.CB_border.Size = new System.Drawing.Size(84, 17);
			this.CB_border.TabIndex = 4;
			this.CB_border.Text = "Draw border";
			this.CB_border.UseVisualStyleBackColor = true;
			this.CB_border.CheckedChanged += new System.EventHandler(this.CB_border_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(0, 6);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Pen color";
			// 
			// Btn_penColor
			// 
			this.Btn_penColor.Location = new System.Drawing.Point(59, 2);
			this.Btn_penColor.Name = "Btn_penColor";
			this.Btn_penColor.Size = new System.Drawing.Size(111, 20);
			this.Btn_penColor.TabIndex = 6;
			this.Btn_penColor.UseVisualStyleBackColor = true;
			this.Btn_penColor.Click += new System.EventHandler(this.Btn_penColor_Click);
			// 
			// ColorDialog1
			// 
			this.ColorDialog1.FullOpen = true;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(186, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(2, 236);
			this.label3.TabIndex = 7;
			// 
			// TextBox1
			// 
			this.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TextBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.TextBox1.Location = new System.Drawing.Point(194, 12);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ReadOnly = true;
			this.TextBox1.Size = new System.Drawing.Size(197, 222);
			this.TextBox1.TabIndex = 9;
			this.TextBox1.Text = resources.GetString("TextBox1.Text");
			// 
			// CB_vignette
			// 
			this.CB_vignette.AutoSize = true;
			this.CB_vignette.Location = new System.Drawing.Point(3, 5);
			this.CB_vignette.Name = "CB_vignette";
			this.CB_vignette.Size = new System.Drawing.Size(92, 17);
			this.CB_vignette.TabIndex = 10;
			this.CB_vignette.Text = "Draw vignette";
			this.CB_vignette.UseVisualStyleBackColor = true;
			this.CB_vignette.CheckedChanged += new System.EventHandler(this.CB_vignette_CheckedChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.panel2);
			this.flowLayoutPanel1.Controls.Add(this.panel3);
			this.flowLayoutPanel1.Controls.Add(this.CB_shadow);
			this.flowLayoutPanel1.Controls.Add(this.CB_border);
			this.flowLayoutPanel1.Controls.Add(this.panel1);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 6);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(175, 204);
			this.flowLayoutPanel1.TabIndex = 11;
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.Btn_penColor);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(0, 152);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(173, 25);
			this.panel1.TabIndex = 12;
			// 
			// panel2
			// 
			this.panel2.AutoSize = true;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.Inp_hotkey);
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(172, 25);
			this.panel2.TabIndex = 12;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.Panel_vignette);
			this.panel3.Controls.Add(this.CB_vignette);
			this.panel3.Location = new System.Drawing.Point(0, 25);
			this.panel3.Margin = new System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(172, 81);
			this.panel3.TabIndex = 13;
			// 
			// Panel_vignette
			// 
			this.Panel_vignette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Panel_vignette.Controls.Add(this.panel4);
			this.Panel_vignette.Controls.Add(this.panel5);
			this.Panel_vignette.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.Panel_vignette.Location = new System.Drawing.Point(20, 23);
			this.Panel_vignette.Name = "Panel_vignette";
			this.Panel_vignette.Size = new System.Drawing.Size(149, 58);
			this.Panel_vignette.TabIndex = 11;
			// 
			// panel4
			// 
			this.panel4.AutoSize = true;
			this.panel4.Controls.Add(this.Btn_vignette);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Margin = new System.Windows.Forms.Padding(0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(152, 25);
			this.panel4.TabIndex = 13;
			// 
			// Btn_vignette
			// 
			this.Btn_vignette.Location = new System.Drawing.Point(56, 2);
			this.Btn_vignette.Name = "Btn_vignette";
			this.Btn_vignette.Size = new System.Drawing.Size(93, 20);
			this.Btn_vignette.TabIndex = 6;
			this.Btn_vignette.UseVisualStyleBackColor = true;
			this.Btn_vignette.Click += new System.EventHandler(this.Btn_vignette_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(0, 6);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Color";
			// 
			// panel5
			// 
			this.panel5.AutoSize = true;
			this.panel5.Controls.Add(this.Inp_vignette);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Location = new System.Drawing.Point(0, 25);
			this.panel5.Margin = new System.Windows.Forms.Padding(0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(152, 28);
			this.panel5.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(0, 7);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(27, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Size";
			// 
			// Inp_vignette
			// 
			this.Inp_vignette.Location = new System.Drawing.Point(56, 5);
			this.Inp_vignette.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.Inp_vignette.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Inp_vignette.Name = "Inp_vignette";
			this.Inp_vignette.Size = new System.Drawing.Size(93, 20);
			this.Inp_vignette.TabIndex = 1;
			this.Inp_vignette.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Inp_vignette.ValueChanged += new System.EventHandler(this.Inp_vignette_ValueChanged);
			this.Inp_vignette.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Inp_vignette_KeyPress);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 246);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.TextBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Btn_reset);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Screen Capture: Settings";
			this.TopMost = true;
			this.Click += new System.EventHandler(this.FormSettings_Click);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.Panel_vignette.ResumeLayout(false);
			this.Panel_vignette.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Inp_vignette)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Inp_hotkey;
		private System.Windows.Forms.Button Btn_reset;
		private System.Windows.Forms.CheckBox CB_shadow;
		private System.Windows.Forms.CheckBox CB_border;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Btn_penColor;
		private System.Windows.Forms.ColorDialog ColorDialog1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.CheckBox CB_vignette;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.FlowLayoutPanel Panel_vignette;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button Btn_vignette;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.NumericUpDown Inp_vignette;
		private System.Windows.Forms.Label label5;
	}
}