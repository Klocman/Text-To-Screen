namespace TextToScreen.Controls
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contentAlignmentBox1 = new Klocman.Controls.ContentAlignmentBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.checkBoxFontSizeFlex = new System.Windows.Forms.CheckBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.underlineToggle = new System.Windows.Forms.ToolStripButton();
            this.italicToggle = new System.Windows.Forms.ToolStripButton();
            this.boldToggle = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFontFamily = new System.Windows.Forms.ComboBox();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonClearImage = new System.Windows.Forms.Button();
            this.pathSelectBoxImage = new Klocman.Controls.PathSelectBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxVertical = new System.Windows.Forms.CheckBox();
            this.checkBoxHorizontal = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFadeDuration)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.contentAlignmentBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            // 
            // contentAlignmentBox1
            // 
            resources.ApplyResources(this.contentAlignmentBox1, "contentAlignmentBox1");
            this.contentAlignmentBox1.Name = "contentAlignmentBox1";
            this.contentAlignmentBox1.SelectedContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxFontFamily, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownFontSize);
            this.panel1.Controls.Add(this.checkBoxFontSizeFlex);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownFontSize, "numericUpDownFontSize");
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxFontSizeFlex
            // 
            resources.ApplyResources(this.checkBoxFontSizeFlex, "checkBoxFontSizeFlex");
            this.checkBoxFontSizeFlex.Name = "checkBoxFontSizeFlex";
            this.checkBoxFontSizeFlex.UseVisualStyleBackColor = true;
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
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.TabStop = true;
            // 
            // underlineToggle
            // 
            this.underlineToggle.CheckOnClick = true;
            this.underlineToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.underlineToggle, "underlineToggle");
            this.underlineToggle.Name = "underlineToggle";
            // 
            // italicToggle
            // 
            this.italicToggle.CheckOnClick = true;
            this.italicToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.italicToggle, "italicToggle");
            this.italicToggle.Name = "italicToggle";
            // 
            // boldToggle
            // 
            this.boldToggle.CheckOnClick = true;
            this.boldToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.boldToggle, "boldToggle");
            this.boldToggle.Name = "boldToggle";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // comboBoxFontFamily
            // 
            this.comboBoxFontFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxFontFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.comboBoxFontFamily, "comboBoxFontFamily");
            this.comboBoxFontFamily.Name = "comboBoxFontFamily";
            this.comboBoxFontFamily.SelectedIndexChanged += new System.EventHandler(this.comboBoxFontFamily_SelectedIndexChanged);
            // 
            // numericUpDownFadeDuration
            // 
            resources.ApplyResources(this.numericUpDownFadeDuration, "numericUpDownFadeDuration");
            this.numericUpDownFadeDuration.DecimalPlaces = 1;
            this.numericUpDownFadeDuration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownFadeDuration.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownFadeDuration.Name = "numericUpDownFadeDuration";
            this.numericUpDownFadeDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // secondary_out_labelSpeed
            // 
            resources.ApplyResources(this.secondary_out_labelSpeed, "secondary_out_labelSpeed");
            this.secondary_out_labelSpeed.Name = "secondary_out_labelSpeed";
            // 
            // backgroundColorPreview
            // 
            resources.ApplyResources(this.backgroundColorPreview, "backgroundColorPreview");
            this.backgroundColorPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.backgroundColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.backgroundColorPreview.Name = "backgroundColorPreview";
            this.backgroundColorPreview.Click += new System.EventHandler(this.BackColor_Click);
            // 
            // secondary_out_labelBacCol
            // 
            resources.ApplyResources(this.secondary_out_labelBacCol, "secondary_out_labelBacCol");
            this.secondary_out_labelBacCol.Name = "secondary_out_labelBacCol";
            // 
            // buttonBackColor
            // 
            resources.ApplyResources(this.buttonBackColor, "buttonBackColor");
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.UseVisualStyleBackColor = true;
            this.buttonBackColor.Click += new System.EventHandler(this.BackColor_Click);
            // 
            // foregroundColorPreview
            // 
            resources.ApplyResources(this.foregroundColorPreview, "foregroundColorPreview");
            this.foregroundColorPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.foregroundColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.foregroundColorPreview.Name = "foregroundColorPreview";
            this.foregroundColorPreview.Click += new System.EventHandler(this.ForeColor_Click);
            // 
            // secondary_out_labelTexCol
            // 
            resources.ApplyResources(this.secondary_out_labelTexCol, "secondary_out_labelTexCol");
            this.secondary_out_labelTexCol.Name = "secondary_out_labelTexCol";
            // 
            // buttonForeColor
            // 
            resources.ApplyResources(this.buttonForeColor, "buttonForeColor");
            this.buttonForeColor.Name = "buttonForeColor";
            this.buttonForeColor.UseVisualStyleBackColor = true;
            this.buttonForeColor.Click += new System.EventHandler(this.ForeColor_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.secondary_out_labelSpeed, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.secondary_out_labelTexCol, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonBackColor, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonForeColor, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.secondary_out_labelBacCol, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.backgroundColorPreview, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.foregroundColorPreview, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownFadeDuration, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flowLayoutPanel1);
            this.tabPage3.Controls.Add(this.pathSelectBoxImage);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.buttonClearImage);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // buttonClearImage
            // 
            resources.ApplyResources(this.buttonClearImage, "buttonClearImage");
            this.buttonClearImage.Name = "buttonClearImage";
            this.buttonClearImage.UseVisualStyleBackColor = true;
            this.buttonClearImage.Click += new System.EventHandler(this.buttonClearImage_Click);
            // 
            // pathSelectBoxImage
            // 
            resources.ApplyResources(this.pathSelectBoxImage, "pathSelectBoxImage");
            this.pathSelectBoxImage.FileName = "";
            this.pathSelectBoxImage.Filter = "Image Files|*.BMP;*.JPG;*.GIF;*.PNG|All files|*.*";
            this.pathSelectBoxImage.Name = "pathSelectBoxImage";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.flowLayoutPanel2);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.checkBoxVertical);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxHorizontal);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // checkBoxVertical
            // 
            resources.ApplyResources(this.checkBoxVertical, "checkBoxVertical");
            this.checkBoxVertical.Name = "checkBoxVertical";
            this.checkBoxVertical.UseVisualStyleBackColor = true;
            // 
            // checkBoxHorizontal
            // 
            resources.ApplyResources(this.checkBoxHorizontal, "checkBoxHorizontal");
            this.checkBoxHorizontal.Name = "checkBoxHorizontal";
            this.checkBoxHorizontal.UseVisualStyleBackColor = true;
            // 
            // OutputAppearanceControls
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(99999, 117);
            this.MinimumSize = new System.Drawing.Size(240, 117);
            this.Name = "OutputAppearanceControls";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFadeDuration)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonClearImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxFontSizeFlex;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBoxVertical;
        private System.Windows.Forms.CheckBox checkBoxHorizontal;
    }
}
