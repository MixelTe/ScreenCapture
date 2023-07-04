namespace ColorInput
{
	partial class ColorInput
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
			this.components = new System.ComponentModel.Container();
			this.Btn = new System.Windows.Forms.Button();
			this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolStripMenuItem_copy = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_paste = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Btn
			// 
			this.Btn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Btn.Location = new System.Drawing.Point(0, 0);
			this.Btn.Margin = new System.Windows.Forms.Padding(0);
			this.Btn.Name = "Btn";
			this.Btn.Size = new System.Drawing.Size(75, 20);
			this.Btn.TabIndex = 0;
			this.Btn.UseVisualStyleBackColor = false;
			this.Btn.Click += new System.EventHandler(this.Btn_Click);
			// 
			// ContextMenuStrip1
			// 
			this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_copy,
            this.ToolStripMenuItem_paste});
			this.ContextMenuStrip1.Name = "contextMenuStrip1";
			this.ContextMenuStrip1.ShowImageMargin = false;
			this.ContextMenuStrip1.Size = new System.Drawing.Size(78, 48);
			// 
			// ToolStripMenuItem_copy
			// 
			this.ToolStripMenuItem_copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolStripMenuItem_copy.Name = "ToolStripMenuItem_copy";
			this.ToolStripMenuItem_copy.Size = new System.Drawing.Size(77, 22);
			this.ToolStripMenuItem_copy.Text = "Copy";
			// 
			// ToolStripMenuItem_paste
			// 
			this.ToolStripMenuItem_paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolStripMenuItem_paste.Name = "ToolStripMenuItem_paste";
			this.ToolStripMenuItem_paste.Size = new System.Drawing.Size(77, 22);
			this.ToolStripMenuItem_paste.Text = "Paste";
			// 
			// ColorInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ContextMenuStrip = this.ContextMenuStrip1;
			this.Controls.Add(this.Btn);
			this.Name = "ColorInput";
			this.Size = new System.Drawing.Size(75, 20);
			this.ContextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Btn;
		private System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_copy;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_paste;
	}
}
