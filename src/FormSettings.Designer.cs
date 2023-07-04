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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
			this.Lbl_hotkey = new System.Windows.Forms.Label();
			this.Inp_hotkey = new System.Windows.Forms.TextBox();
			this.Btn_reset = new System.Windows.Forms.Button();
			this.CB_shadow = new System.Windows.Forms.CheckBox();
			this.CB_border = new System.Windows.Forms.CheckBox();
			this.Lbl_pColor = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TextBoxHelp = new System.Windows.Forms.TextBox();
			this.CB_vignette = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.Panel_vignette = new System.Windows.Forms.FlowLayoutPanel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.ColorInp_vignette = new ColorInput.ColorInput();
			this.Lbl_vColor = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.Inp_vignette = new System.Windows.Forms.NumericUpDown();
			this.Lbl_vSize = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ColorInp_pen = new ColorInput.ColorInput();
			this.panel6 = new System.Windows.Forms.Panel();
			this.Inp_zoomStep = new System.Windows.Forms.NumericUpDown();
			this.Lbl_zoom = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.Panel_palette = new System.Windows.Forms.FlowLayoutPanel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.Lbl_pHotkey = new System.Windows.Forms.Label();
			this.Inp_paletteHotkey = new System.Windows.Forms.TextBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.Inp_paletteSize = new System.Windows.Forms.NumericUpDown();
			this.Lbl_pSize = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.ColorInp_highlight = new ColorInput.ColorInput();
			this.Lbl_highlight = new System.Windows.Forms.Label();
			this.CB_palette = new System.Windows.Forms.CheckBox();
			this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
			this.panel11 = new System.Windows.Forms.Panel();
			this.Lbl_lang = new System.Windows.Forms.Label();
			this.Inp_lang = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.Panel_vignette.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Inp_vignette)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Inp_zoomStep)).BeginInit();
			this.panel7.SuspendLayout();
			this.Panel_palette.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Inp_paletteSize)).BeginInit();
			this.panel8.SuspendLayout();
			this.panel11.SuspendLayout();
			this.SuspendLayout();
			// 
			// Lbl_hotkey
			// 
			this.Lbl_hotkey.AutoSize = true;
			this.Lbl_hotkey.Location = new System.Drawing.Point(0, 5);
			this.Lbl_hotkey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Lbl_hotkey.Name = "Lbl_hotkey";
			this.Lbl_hotkey.Size = new System.Drawing.Size(41, 13);
			this.Lbl_hotkey.TabIndex = 0;
			this.Lbl_hotkey.Text = "Hotkey";
			// 
			// Inp_hotkey
			// 
			this.Inp_hotkey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Inp_hotkey.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Inp_hotkey.Location = new System.Drawing.Point(79, 3);
			this.Inp_hotkey.Margin = new System.Windows.Forms.Padding(2);
			this.Inp_hotkey.Name = "Inp_hotkey";
			this.Inp_hotkey.Size = new System.Drawing.Size(118, 20);
			this.Inp_hotkey.TabIndex = 2;
			this.Inp_hotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inp_hotkey_KeyDown);
			this.Inp_hotkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Inp_hotkey_KeyPress);
			// 
			// Btn_reset
			// 
			this.Btn_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Btn_reset.Location = new System.Drawing.Point(9, 350);
			this.Btn_reset.Margin = new System.Windows.Forms.Padding(2);
			this.Btn_reset.Name = "Btn_reset";
			this.Btn_reset.Size = new System.Drawing.Size(77, 21);
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
			// Lbl_pColor
			// 
			this.Lbl_pColor.AutoSize = true;
			this.Lbl_pColor.Location = new System.Drawing.Point(0, 6);
			this.Lbl_pColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Lbl_pColor.Name = "Lbl_pColor";
			this.Lbl_pColor.Size = new System.Drawing.Size(52, 13);
			this.Lbl_pColor.TabIndex = 5;
			this.Lbl_pColor.Text = "Pen color";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(214, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(2, 371);
			this.label3.TabIndex = 7;
			// 
			// TextBoxHelp
			// 
			this.TextBoxHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TextBoxHelp.Cursor = System.Windows.Forms.Cursors.Default;
			this.TextBoxHelp.Location = new System.Drawing.Point(222, 12);
			this.TextBoxHelp.Multiline = true;
			this.TextBoxHelp.Name = "TextBoxHelp";
			this.TextBoxHelp.ReadOnly = true;
			this.TextBoxHelp.Size = new System.Drawing.Size(251, 357);
			this.TextBoxHelp.TabIndex = 9;
			this.TextBoxHelp.Text = resources.GetString("TextBoxHelp.Text");
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
			this.flowLayoutPanel1.Controls.Add(this.panel2);
			this.flowLayoutPanel1.Controls.Add(this.panel3);
			this.flowLayoutPanel1.Controls.Add(this.CB_shadow);
			this.flowLayoutPanel1.Controls.Add(this.CB_border);
			this.flowLayoutPanel1.Controls.Add(this.panel1);
			this.flowLayoutPanel1.Controls.Add(this.panel6);
			this.flowLayoutPanel1.Controls.Add(this.panel7);
			this.flowLayoutPanel1.Controls.Add(this.panel11);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 6);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(199, 339);
			this.flowLayoutPanel1.TabIndex = 11;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.Lbl_hotkey);
			this.panel2.Controls.Add(this.Inp_hotkey);
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(199, 25);
			this.panel2.TabIndex = 12;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.Panel_vignette);
			this.panel3.Controls.Add(this.CB_vignette);
			this.panel3.Location = new System.Drawing.Point(0, 25);
			this.panel3.Margin = new System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(199, 81);
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
			this.Panel_vignette.Location = new System.Drawing.Point(27, 23);
			this.Panel_vignette.Name = "Panel_vignette";
			this.Panel_vignette.Size = new System.Drawing.Size(171, 58);
			this.Panel_vignette.TabIndex = 11;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.ColorInp_vignette);
			this.panel4.Controls.Add(this.Lbl_vColor);
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Margin = new System.Windows.Forms.Padding(0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(172, 25);
			this.panel4.TabIndex = 13;
			// 
			// ColorInp_vignette
			// 
			this.ColorInp_vignette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ColorInp_vignette.Color = System.Drawing.Color.Empty;
			this.ColorInp_vignette.Location = new System.Drawing.Point(98, 2);
			this.ColorInp_vignette.Name = "ColorInp_vignette";
			this.ColorInp_vignette.Size = new System.Drawing.Size(72, 20);
			this.ColorInp_vignette.TabIndex = 6;
			this.ColorInp_vignette.ColorChanged += new System.EventHandler(this.ColorInp_vignette_ColorChanged);
			// 
			// Lbl_vColor
			// 
			this.Lbl_vColor.AutoSize = true;
			this.Lbl_vColor.Location = new System.Drawing.Point(0, 6);
			this.Lbl_vColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Lbl_vColor.Name = "Lbl_vColor";
			this.Lbl_vColor.Size = new System.Drawing.Size(31, 13);
			this.Lbl_vColor.TabIndex = 5;
			this.Lbl_vColor.Text = "Color";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.Inp_vignette);
			this.panel5.Controls.Add(this.Lbl_vSize);
			this.panel5.Location = new System.Drawing.Point(0, 25);
			this.panel5.Margin = new System.Windows.Forms.Padding(0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(172, 28);
			this.panel5.TabIndex = 13;
			// 
			// Inp_vignette
			// 
			this.Inp_vignette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Inp_vignette.Location = new System.Drawing.Point(98, 5);
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
			this.Inp_vignette.Size = new System.Drawing.Size(72, 20);
			this.Inp_vignette.TabIndex = 1;
			this.Inp_vignette.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Inp_vignette.ValueChanged += new System.EventHandler(this.Inp_vignette_ValueChanged);
			// 
			// Lbl_vSize
			// 
			this.Lbl_vSize.AutoSize = true;
			this.Lbl_vSize.Location = new System.Drawing.Point(0, 7);
			this.Lbl_vSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Lbl_vSize.Name = "Lbl_vSize";
			this.Lbl_vSize.Size = new System.Drawing.Size(27, 13);
			this.Lbl_vSize.TabIndex = 0;
			this.Lbl_vSize.Text = "Size";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ColorInp_pen);
			this.panel1.Controls.Add(this.Lbl_pColor);
			this.panel1.Location = new System.Drawing.Point(0, 152);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(199, 25);
			this.panel1.TabIndex = 12;
			// 
			// ColorInp_pen
			// 
			this.ColorInp_pen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ColorInp_pen.Color = System.Drawing.Color.Empty;
			this.ColorInp_pen.Location = new System.Drawing.Point(79, 2);
			this.ColorInp_pen.Name = "ColorInp_pen";
			this.ColorInp_pen.Size = new System.Drawing.Size(118, 20);
			this.ColorInp_pen.TabIndex = 6;
			this.ColorInp_pen.ColorChanged += new System.EventHandler(this.ColorInp_pen_ColorChanged);
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.Inp_zoomStep);
			this.panel6.Controls.Add(this.Lbl_zoom);
			this.panel6.Location = new System.Drawing.Point(0, 177);
			this.panel6.Margin = new System.Windows.Forms.Padding(0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(198, 28);
			this.panel6.TabIndex = 14;
			// 
			// Inp_zoomStep
			// 
			this.Inp_zoomStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Inp_zoomStep.Location = new System.Drawing.Point(79, 5);
			this.Inp_zoomStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Inp_zoomStep.Name = "Inp_zoomStep";
			this.Inp_zoomStep.Size = new System.Drawing.Size(118, 20);
			this.Inp_zoomStep.TabIndex = 1;
			this.Inp_zoomStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Inp_zoomStep.ValueChanged += new System.EventHandler(this.Inp_zoomStep_ValueChanged);
			// 
			// Lbl_zoom
			// 
			this.Lbl_zoom.AutoSize = true;
			this.Lbl_zoom.Location = new System.Drawing.Point(0, 7);
			this.Lbl_zoom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Lbl_zoom.Name = "Lbl_zoom";
			this.Lbl_zoom.Size = new System.Drawing.Size(68, 13);
			this.Lbl_zoom.TabIndex = 0;
			this.Lbl_zoom.Text = "Zoom step %";
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.label2);
			this.panel7.Controls.Add(this.Panel_palette);
			this.panel7.Controls.Add(this.CB_palette);
			this.panel7.Location = new System.Drawing.Point(0, 205);
			this.panel7.Margin = new System.Windows.Forms.Padding(0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(199, 105);
			this.panel7.TabIndex = 15;
			// 
			// Panel_palette
			// 
			this.Panel_palette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Panel_palette.Controls.Add(this.panel10);
			this.Panel_palette.Controls.Add(this.panel9);
			this.Panel_palette.Controls.Add(this.panel8);
			this.Panel_palette.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.Panel_palette.Location = new System.Drawing.Point(27, 23);
			this.Panel_palette.Name = "Panel_palette";
			this.Panel_palette.Size = new System.Drawing.Size(172, 82);
			this.Panel_palette.TabIndex = 11;
			// 
			// panel10
			// 
			this.panel10.AutoSize = true;
			this.panel10.Controls.Add(this.Lbl_pHotkey);
			this.panel10.Controls.Add(this.Inp_paletteHotkey);
			this.panel10.Location = new System.Drawing.Point(0, 0);
			this.panel10.Margin = new System.Windows.Forms.Padding(0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(191, 25);
			this.panel10.TabIndex = 14;
			// 
			// Lbl_pHotkey
			// 
			this.Lbl_pHotkey.AutoSize = true;
			this.Lbl_pHotkey.Location = new System.Drawing.Point(0, 5);
			this.Lbl_pHotkey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Lbl_pHotkey.Name = "Lbl_pHotkey";
			this.Lbl_pHotkey.Size = new System.Drawing.Size(41, 13);
			this.Lbl_pHotkey.TabIndex = 0;
			this.Lbl_pHotkey.Text = "Hotkey";
			// 
			// Inp_paletteHotkey
			// 
			this.Inp_paletteHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Inp_paletteHotkey.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Inp_paletteHotkey.Location = new System.Drawing.Point(52, 3);
			this.Inp_paletteHotkey.Margin = new System.Windows.Forms.Padding(2);
			this.Inp_paletteHotkey.Name = "Inp_paletteHotkey";
			this.Inp_paletteHotkey.Size = new System.Drawing.Size(118, 20);
			this.Inp_paletteHotkey.TabIndex = 2;
			this.Inp_paletteHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inp_paletteHotkey_KeyDown);
			this.Inp_paletteHotkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Inp_paletteHotkey_KeyPress);
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.Inp_paletteSize);
			this.panel9.Controls.Add(this.Lbl_pSize);
			this.panel9.Location = new System.Drawing.Point(0, 25);
			this.panel9.Margin = new System.Windows.Forms.Padding(0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(172, 28);
			this.panel9.TabIndex = 13;
			// 
			// Inp_paletteSize
			// 
			this.Inp_paletteSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Inp_paletteSize.Location = new System.Drawing.Point(98, 5);
			this.Inp_paletteSize.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
			this.Inp_paletteSize.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.Inp_paletteSize.Name = "Inp_paletteSize";
			this.Inp_paletteSize.Size = new System.Drawing.Size(72, 20);
			this.Inp_paletteSize.TabIndex = 1;
			this.Inp_paletteSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.Inp_paletteSize.ValueChanged += new System.EventHandler(this.Inp_paletteSize_ValueChanged);
			// 
			// Lbl_pSize
			// 
			this.Lbl_pSize.AutoSize = true;
			this.Lbl_pSize.Location = new System.Drawing.Point(0, 7);
			this.Lbl_pSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Lbl_pSize.Name = "Lbl_pSize";
			this.Lbl_pSize.Size = new System.Drawing.Size(27, 13);
			this.Lbl_pSize.TabIndex = 0;
			this.Lbl_pSize.Text = "Size";
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.ColorInp_highlight);
			this.panel8.Controls.Add(this.Lbl_highlight);
			this.panel8.Location = new System.Drawing.Point(0, 53);
			this.panel8.Margin = new System.Windows.Forms.Padding(0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(172, 25);
			this.panel8.TabIndex = 13;
			// 
			// ColorInp_highlight
			// 
			this.ColorInp_highlight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ColorInp_highlight.Color = System.Drawing.Color.Empty;
			this.ColorInp_highlight.Location = new System.Drawing.Point(98, 2);
			this.ColorInp_highlight.Name = "ColorInp_highlight";
			this.ColorInp_highlight.Size = new System.Drawing.Size(72, 20);
			this.ColorInp_highlight.TabIndex = 6;
			this.ColorInp_highlight.ColorChanged += new System.EventHandler(this.ColorInp_highlight_ColorChanged);
			// 
			// Lbl_highlight
			// 
			this.Lbl_highlight.AutoSize = true;
			this.Lbl_highlight.Location = new System.Drawing.Point(0, 6);
			this.Lbl_highlight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Lbl_highlight.Name = "Lbl_highlight";
			this.Lbl_highlight.Size = new System.Drawing.Size(48, 13);
			this.Lbl_highlight.TabIndex = 5;
			this.Lbl_highlight.Text = "Highlight";
			// 
			// CB_palette
			// 
			this.CB_palette.AutoSize = true;
			this.CB_palette.Location = new System.Drawing.Point(3, 5);
			this.CB_palette.Name = "CB_palette";
			this.CB_palette.Size = new System.Drawing.Size(59, 17);
			this.CB_palette.TabIndex = 10;
			this.CB_palette.Text = "Palette";
			this.CB_palette.UseVisualStyleBackColor = true;
			this.CB_palette.CheckedChanged += new System.EventHandler(this.CB_palette_CheckedChanged);
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.Inp_lang);
			this.panel11.Controls.Add(this.Lbl_lang);
			this.panel11.Location = new System.Drawing.Point(0, 310);
			this.panel11.Margin = new System.Windows.Forms.Padding(0);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(199, 28);
			this.panel11.TabIndex = 16;
			// 
			// Lbl_lang
			// 
			this.Lbl_lang.AutoSize = true;
			this.Lbl_lang.Location = new System.Drawing.Point(0, 7);
			this.Lbl_lang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Lbl_lang.Name = "Lbl_lang";
			this.Lbl_lang.Size = new System.Drawing.Size(55, 13);
			this.Lbl_lang.TabIndex = 0;
			this.Lbl_lang.Text = "Language";
			// 
			// Inp_lang
			// 
			this.Inp_lang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Inp_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Inp_lang.FormattingEnabled = true;
			this.Inp_lang.Items.AddRange(new object[] {
            "en",
            "ru"});
			this.Inp_lang.Location = new System.Drawing.Point(79, 5);
			this.Inp_lang.Name = "Inp_lang";
			this.Inp_lang.Size = new System.Drawing.Size(118, 21);
			this.Inp_lang.TabIndex = 1;
			this.Inp_lang.SelectedIndexChanged += new System.EventHandler(this.Inp_lang_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(23, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(2, 56);
			this.label1.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(23, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(2, 80);
			this.label2.TabIndex = 13;
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 381);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.TextBoxHelp);
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
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.Panel_vignette.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Inp_vignette)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Inp_zoomStep)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.Panel_palette.ResumeLayout(false);
			this.Panel_palette.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Inp_paletteSize)).EndInit();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Lbl_hotkey;
		private System.Windows.Forms.TextBox Inp_hotkey;
		private System.Windows.Forms.Button Btn_reset;
		private System.Windows.Forms.CheckBox CB_shadow;
		private System.Windows.Forms.CheckBox CB_border;
		private System.Windows.Forms.Label Lbl_pColor;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TextBoxHelp;
		private System.Windows.Forms.CheckBox CB_vignette;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.FlowLayoutPanel Panel_vignette;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label Lbl_vColor;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.NumericUpDown Inp_vignette;
		private System.Windows.Forms.Label Lbl_vSize;
		private System.Windows.Forms.ColorDialog ColorDialog1;
		private ColorInput.ColorInput ColorInp_vignette;
		private ColorInput.ColorInput ColorInp_pen;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.NumericUpDown Inp_zoomStep;
		private System.Windows.Forms.Label Lbl_zoom;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.FlowLayoutPanel Panel_palette;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label Lbl_pHotkey;
		private System.Windows.Forms.TextBox Inp_paletteHotkey;
		private System.Windows.Forms.Panel panel8;
		private ColorInput.ColorInput ColorInp_highlight;
		private System.Windows.Forms.Label Lbl_highlight;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.NumericUpDown Inp_paletteSize;
		private System.Windows.Forms.Label Lbl_pSize;
		private System.Windows.Forms.CheckBox CB_palette;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.ComboBox Inp_lang;
		private System.Windows.Forms.Label Lbl_lang;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}