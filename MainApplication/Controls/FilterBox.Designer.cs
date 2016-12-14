namespace TextToScreen.Controls
{
    partial class FilterBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterBox));
            this.label1 = new System.Windows.Forms.Label();
            this.searchInsideFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupFilterComboBox = new System.Windows.Forms.ComboBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.checkBoxInvert = new System.Windows.Forms.CheckBox();
            this.comboBoxCompareMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkBoxExact = new System.Windows.Forms.CheckBox();
            this.searchBox1 = new Klocman.Controls.SearchBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // searchInsideFilesCheckBox
            // 
            resources.ApplyResources(this.searchInsideFilesCheckBox, "searchInsideFilesCheckBox");
            this.searchInsideFilesCheckBox.Name = "searchInsideFilesCheckBox";
            this.searchInsideFilesCheckBox.UseVisualStyleBackColor = true;
            this.searchInsideFilesCheckBox.CheckedChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // groupFilterComboBox
            // 
            resources.ApplyResources(this.groupFilterComboBox, "groupFilterComboBox");
            this.groupFilterComboBox.DropDownHeight = 200;
            this.groupFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupFilterComboBox.DropDownWidth = 300;
            this.groupFilterComboBox.FormattingEnabled = true;
            this.groupFilterComboBox.Name = "groupFilterComboBox";
            this.groupFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.groupFilterComboBox_SelectedIndexChanged);
            // 
            // buttonClear
            // 
            resources.ApplyResources(this.buttonClear, "buttonClear");
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxInvert
            // 
            resources.ApplyResources(this.checkBoxInvert, "checkBoxInvert");
            this.checkBoxInvert.Name = "checkBoxInvert";
            this.checkBoxInvert.UseVisualStyleBackColor = true;
            this.checkBoxInvert.CheckedChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // comboBoxCompareMethod
            // 
            resources.ApplyResources(this.comboBoxCompareMethod, "comboBoxCompareMethod");
            this.comboBoxCompareMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompareMethod.Name = "comboBoxCompareMethod";
            this.comboBoxCompareMethod.Sorted = true;
            this.comboBoxCompareMethod.SelectedIndexChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonClear);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxInvert);
            this.splitContainer1.Panel1.Controls.Add(this.searchInsideFilesCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxExact);
            this.splitContainer1.Panel1.Controls.Add(this.searchBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupFilterComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxCompareMethod);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            // 
            // checkBoxExact
            // 
            resources.ApplyResources(this.checkBoxExact, "checkBoxExact");
            this.checkBoxExact.Name = "checkBoxExact";
            this.checkBoxExact.UseVisualStyleBackColor = true;
            this.checkBoxExact.CheckedChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // searchBox1
            // 
            this.searchBox1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.searchBox1, "searchBox1");
            this.searchBox1.Name = "searchBox1";
            this.searchBox1.SearchTextChanged += new System.Action<Klocman.Controls.SearchBox, System.EventArgs>(this.searchBox1_SearchTextChanged);
            // 
            // FilterBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FilterBox";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Klocman.Controls.SearchBox searchBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox searchInsideFilesCheckBox;
        private System.Windows.Forms.ComboBox groupFilterComboBox;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.CheckBox checkBoxInvert;
        private System.Windows.Forms.ComboBox comboBoxCompareMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBoxExact;
    }
}
