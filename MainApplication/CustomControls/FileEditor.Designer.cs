namespace TextToScreen.CustomControls
{
    partial class FileEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileEditor));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxAlignment = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxFont = new System.Windows.Forms.ToolStripComboBox();
            this.fontSize = new Klocman.Controls.ToolStripNumberControl();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.boldToggle = new System.Windows.Forms.ToolStripButton();
            this.italicToggle = new System.Windows.Forms.ToolStripButton();
            this.underlineToggle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_save = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.multiLineListBox1 = new TextToScreen.CustomControls.MultilineListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.filePropertiesViewer1 = new TextToScreen.CustomControls.FilePropertiesViewer();
            this.toolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxAlignment,
            this.toolStripSeparator1,
            this.toolStripComboBoxFont,
            this.fontSize,
            this.toolStripSeparator2,
            this.boldToggle,
            this.italicToggle,
            this.underlineToggle,
            this.toolStripSeparator3,
            this.toolStripButton_save});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.TabStop = true;
            // 
            // toolStripComboBoxAlignment
            // 
            this.toolStripComboBoxAlignment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolStripComboBoxAlignment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolStripComboBoxAlignment.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxAlignment.Items"),
            resources.GetString("toolStripComboBoxAlignment.Items1"),
            resources.GetString("toolStripComboBoxAlignment.Items2"),
            resources.GetString("toolStripComboBoxAlignment.Items3"),
            resources.GetString("toolStripComboBoxAlignment.Items4"),
            resources.GetString("toolStripComboBoxAlignment.Items5"),
            resources.GetString("toolStripComboBoxAlignment.Items6"),
            resources.GetString("toolStripComboBoxAlignment.Items7"),
            resources.GetString("toolStripComboBoxAlignment.Items8")});
            resources.ApplyResources(this.toolStripComboBoxAlignment, "toolStripComboBoxAlignment");
            this.toolStripComboBoxAlignment.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolStripComboBoxAlignment.Name = "toolStripComboBoxAlignment";
            this.toolStripComboBoxAlignment.SelectedIndexChanged += new System.EventHandler(this.ToolstripFontSettingChanged);
            this.toolStripComboBoxAlignment.Leave += new System.EventHandler(this.toolStripComboBoxAlignment_Leave);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripComboBoxFont
            // 
            this.toolStripComboBoxFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolStripComboBoxFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolStripComboBoxFont.DropDownHeight = 200;
            this.toolStripComboBoxFont.DropDownWidth = 140;
            resources.ApplyResources(this.toolStripComboBoxFont, "toolStripComboBoxFont");
            this.toolStripComboBoxFont.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolStripComboBoxFont.Name = "toolStripComboBoxFont";
            this.toolStripComboBoxFont.Sorted = true;
            this.toolStripComboBoxFont.SelectedIndexChanged += new System.EventHandler(this.ToolstripFontSettingChanged);
            this.toolStripComboBoxFont.Leave += new System.EventHandler(this.toolStripComboBoxFont_Leave);
            // 
            // fontSize
            // 
            this.fontSize.Name = "fontSize";
            resources.ApplyResources(this.fontSize, "fontSize");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // boldToggle
            // 
            this.boldToggle.CheckOnClick = true;
            this.boldToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.boldToggle, "boldToggle");
            this.boldToggle.Name = "boldToggle";
            this.boldToggle.CheckStateChanged += new System.EventHandler(this.ToolstripFontSettingChanged);
            // 
            // italicToggle
            // 
            this.italicToggle.CheckOnClick = true;
            this.italicToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.italicToggle, "italicToggle");
            this.italicToggle.Name = "italicToggle";
            this.italicToggle.CheckStateChanged += new System.EventHandler(this.ToolstripFontSettingChanged);
            // 
            // underlineToggle
            // 
            this.underlineToggle.CheckOnClick = true;
            this.underlineToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.underlineToggle, "underlineToggle");
            this.underlineToggle.Name = "underlineToggle";
            this.underlineToggle.CheckStateChanged += new System.EventHandler(this.ToolstripFontSettingChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButton_save
            // 
            resources.ApplyResources(this.toolStripButton_save, "toolStripButton_save");
            this.toolStripButton_save.Image = global::TextToScreen.Properties.Resources.saveHS;
            this.toolStripButton_save.Name = "toolStripButton_save";
            this.toolStripButton_save.Click += new System.EventHandler(this.toolStripButton_save_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.multiLineListBox1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // multiLineListBox1
            // 
            resources.ApplyResources(this.multiLineListBox1, "multiLineListBox1");
            this.multiLineListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.multiLineListBox1.FormattingEnabled = true;
            this.multiLineListBox1.Name = "multiLineListBox1";
            this.multiLineListBox1.Click += new System.EventHandler(this.multiLineListBox_Click);
            this.multiLineListBox1.SelectedIndexChanged += new System.EventHandler(this.multiLineListBox1_SelectedIndexChanged);
            this.multiLineListBox1.DoubleClick += new System.EventHandler(this.multiLineListBox_DoubleClick);
            this.multiLineListBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.multiLineListBox1_KeyDown);
            this.multiLineListBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.multiLineListBox1_KeyPress);
            this.multiLineListBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.multiLineListBox1_KeyUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.filePropertiesViewer1);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // filePropertiesViewer1
            // 
            this.filePropertiesViewer1.DataWasEdited = false;
            resources.ApplyResources(this.filePropertiesViewer1, "filePropertiesViewer1");
            this.filePropertiesViewer1.Name = "filePropertiesViewer1";
            this.filePropertiesViewer1.FileWasEdited += new System.Action<TextToScreen.CustomControls.FilePropertiesViewer, TextToScreen.CustomControls.FilePropertiesViewerEventArgs>(this.filePropertiesViewer1_DataWasEditedChanged);
            // 
            // FileEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip);
            this.Name = "FileEditor";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxAlignment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton boldToggle;
        private System.Windows.Forms.ToolStripButton italicToggle;
        private System.Windows.Forms.ToolStripButton underlineToggle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_save;
        private Klocman.Controls.ToolStripNumberControl fontSize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private TextToScreen.CustomControls.MultilineListBox multiLineListBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private CustomControls.FilePropertiesViewer filePropertiesViewer1;
    }
}
