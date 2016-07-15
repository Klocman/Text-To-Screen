﻿namespace TextToScreen.Controls
{
    partial class OutputAppearanceControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputAppearanceControls));
            this.numericUpDownFadeDuration = new System.Windows.Forms.NumericUpDown();
            this.secondary_out_labelSpeed = new System.Windows.Forms.Label();
            this.backgroundColorPreview = new System.Windows.Forms.Panel();
            this.secondary_out_labelBacCol = new System.Windows.Forms.Label();
            this.buttonBackColor = new System.Windows.Forms.Button();
            this.foregroundColorPreview = new System.Windows.Forms.Panel();
            this.secondary_out_labelTexCol = new System.Windows.Forms.Label();
            this.buttonForeColor = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contentAlignmentBox1 = new Klocman.Controls.ContentAlignmentBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.underlineToggle = new System.Windows.Forms.ToolStripButton();
            this.italicToggle = new System.Windows.Forms.ToolStripButton();
            this.boldToggle = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFontFamily = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pathSelectBoxImage = new Klocman.Controls.PathSelectBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFadeDuration)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDownFadeDuration
            // 
            this.numericUpDownFadeDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFadeDuration.DecimalPlaces = 1;
            this.numericUpDownFadeDuration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownFadeDuration.Location = new System.Drawing.Point(291, 3);
            this.numericUpDownFadeDuration.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownFadeDuration.Name = "numericUpDownFadeDuration";
            this.numericUpDownFadeDuration.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownFadeDuration.TabIndex = 1;
            this.numericUpDownFadeDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownFadeDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // secondary_out_labelSpeed
            // 
            this.secondary_out_labelSpeed.AutoSize = true;
            this.secondary_out_labelSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.secondary_out_labelSpeed.Location = new System.Drawing.Point(3, 0);
            this.secondary_out_labelSpeed.Name = "secondary_out_labelSpeed";
            this.secondary_out_labelSpeed.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.secondary_out_labelSpeed.Size = new System.Drawing.Size(72, 19);
            this.secondary_out_labelSpeed.TabIndex = 0;
            this.secondary_out_labelSpeed.Text = "Fade duration";
            // 
            // backgroundColorPreview
            // 
            this.backgroundColorPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundColorPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.backgroundColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.backgroundColorPreview.Location = new System.Drawing.Point(100, 58);
            this.backgroundColorPreview.Name = "backgroundColorPreview";
            this.backgroundColorPreview.Size = new System.Drawing.Size(185, 23);
            this.backgroundColorPreview.TabIndex = 6;
            this.backgroundColorPreview.Click += new System.EventHandler(this.BackColor_Click);
            // 
            // secondary_out_labelBacCol
            // 
            this.secondary_out_labelBacCol.AutoSize = true;
            this.secondary_out_labelBacCol.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.secondary_out_labelBacCol.Location = new System.Drawing.Point(3, 55);
            this.secondary_out_labelBacCol.Name = "secondary_out_labelBacCol";
            this.secondary_out_labelBacCol.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.secondary_out_labelBacCol.Size = new System.Drawing.Size(91, 19);
            this.secondary_out_labelBacCol.TabIndex = 5;
            this.secondary_out_labelBacCol.Text = "Background color";
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBackColor.Location = new System.Drawing.Point(291, 58);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(75, 23);
            this.buttonBackColor.TabIndex = 7;
            this.buttonBackColor.Text = "Change...";
            this.buttonBackColor.UseVisualStyleBackColor = true;
            this.buttonBackColor.Click += new System.EventHandler(this.BackColor_Click);
            // 
            // foregroundColorPreview
            // 
            this.foregroundColorPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foregroundColorPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.foregroundColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.foregroundColorPreview.Location = new System.Drawing.Point(100, 29);
            this.foregroundColorPreview.Name = "foregroundColorPreview";
            this.foregroundColorPreview.Size = new System.Drawing.Size(185, 23);
            this.foregroundColorPreview.TabIndex = 3;
            this.foregroundColorPreview.Click += new System.EventHandler(this.ForeColor_Click);
            // 
            // secondary_out_labelTexCol
            // 
            this.secondary_out_labelTexCol.AutoSize = true;
            this.secondary_out_labelTexCol.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.secondary_out_labelTexCol.Location = new System.Drawing.Point(3, 26);
            this.secondary_out_labelTexCol.Name = "secondary_out_labelTexCol";
            this.secondary_out_labelTexCol.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.secondary_out_labelTexCol.Size = new System.Drawing.Size(54, 19);
            this.secondary_out_labelTexCol.TabIndex = 2;
            this.secondary_out_labelTexCol.Text = "Text color";
            // 
            // buttonForeColor
            // 
            this.buttonForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonForeColor.Location = new System.Drawing.Point(291, 29);
            this.buttonForeColor.Name = "buttonForeColor";
            this.buttonForeColor.Size = new System.Drawing.Size(75, 23);
            this.buttonForeColor.TabIndex = 4;
            this.buttonForeColor.Text = "Change...";
            this.buttonForeColor.UseVisualStyleBackColor = true;
            this.buttonForeColor.Click += new System.EventHandler(this.ForeColor_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.secondary_out_labelSpeed, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.secondary_out_labelTexCol, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonBackColor, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonForeColor, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.secondary_out_labelBacCol, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.backgroundColorPreview, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.foregroundColorPreview, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownFadeDuration, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 85);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(383, 117);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(375, 91);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Font and position";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.contentAlignmentBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(369, 85);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.TabIndex = 12;
            // 
            // contentAlignmentBox1
            // 
            this.contentAlignmentBox1.Location = new System.Drawing.Point(3, 3);
            this.contentAlignmentBox1.MaximumSize = new System.Drawing.Size(78, 78);
            this.contentAlignmentBox1.MinimumSize = new System.Drawing.Size(78, 78);
            this.contentAlignmentBox1.Name = "contentAlignmentBox1";
            this.contentAlignmentBox1.SelectedContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.contentAlignmentBox1.Size = new System.Drawing.Size(78, 78);
            this.contentAlignmentBox1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownFontSize, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxFontFamily, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(277, 83);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Window;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.underlineToggle,
            this.italicToggle,
            this.boldToggle});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(58, 53);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip.Size = new System.Drawing.Size(219, 25);
            this.toolStrip.TabIndex = 10;
            this.toolStrip.TabStop = true;
            // 
            // underlineToggle
            // 
            this.underlineToggle.CheckOnClick = true;
            this.underlineToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.underlineToggle.Image = ((System.Drawing.Image)(resources.GetObject("underlineToggle.Image")));
            this.underlineToggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.underlineToggle.Name = "underlineToggle";
            this.underlineToggle.Size = new System.Drawing.Size(23, 22);
            this.underlineToggle.Text = "Underline";
            this.underlineToggle.ToolTipText = "Underline";
            // 
            // italicToggle
            // 
            this.italicToggle.CheckOnClick = true;
            this.italicToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italicToggle.Image = ((System.Drawing.Image)(resources.GetObject("italicToggle.Image")));
            this.italicToggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicToggle.Name = "italicToggle";
            this.italicToggle.Size = new System.Drawing.Size(23, 22);
            this.italicToggle.Text = "Italic";
            this.italicToggle.ToolTipText = "Italic";
            // 
            // boldToggle
            // 
            this.boldToggle.CheckOnClick = true;
            this.boldToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boldToggle.Image = ((System.Drawing.Image)(resources.GetObject("boldToggle.Image")));
            this.boldToggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldToggle.Name = "boldToggle";
            this.boldToggle.Size = new System.Drawing.Size(23, 22);
            this.boldToggle.Text = "Bold";
            this.boldToggle.ToolTipText = "Bold";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Font style";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label1.Size = new System.Drawing.Size(28, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Font";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Font size";
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.DecimalPlaces = 1;
            this.numericUpDownFontSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownFontSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownFontSize.Location = new System.Drawing.Point(61, 30);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(213, 20);
            this.numericUpDownFontSize.TabIndex = 3;
            this.numericUpDownFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxFontFamily
            // 
            this.comboBoxFontFamily.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxFontFamily.FormattingEnabled = true;
            this.comboBoxFontFamily.Location = new System.Drawing.Point(61, 3);
            this.comboBoxFontFamily.Name = "comboBoxFontFamily";
            this.comboBoxFontFamily.Size = new System.Drawing.Size(213, 21);
            this.comboBoxFontFamily.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(375, 91);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Duration and color";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pathSelectBoxImage);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(375, 91);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Background image";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pathSelectBoxImage
            // 
            this.pathSelectBoxImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pathSelectBoxImage.FileName = "";
            this.pathSelectBoxImage.Location = new System.Drawing.Point(3, 3);
            this.pathSelectBoxImage.Name = "pathSelectBoxImage";
            this.pathSelectBoxImage.Size = new System.Drawing.Size(369, 28);
            this.pathSelectBoxImage.TabIndex = 0;
            // 
            // OutputAppearanceControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(99999, 117);
            this.MinimumSize = new System.Drawing.Size(240, 117);
            this.Name = "OutputAppearanceControls";
            this.Size = new System.Drawing.Size(383, 117);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFadeDuration)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownFadeDuration;
        private System.Windows.Forms.Label secondary_out_labelSpeed;
        private System.Windows.Forms.Panel backgroundColorPreview;
        private System.Windows.Forms.Label secondary_out_labelBacCol;
        private System.Windows.Forms.Button buttonBackColor;
        private System.Windows.Forms.Panel foregroundColorPreview;
        private System.Windows.Forms.Label secondary_out_labelTexCol;
        private System.Windows.Forms.Button buttonForeColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Klocman.Controls.ContentAlignmentBox contentAlignmentBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton underlineToggle;
        private System.Windows.Forms.ToolStripButton italicToggle;
        private System.Windows.Forms.ToolStripButton boldToggle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.ComboBox comboBoxFontFamily;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private Klocman.Controls.PathSelectBox pathSelectBoxImage;
    }
}
