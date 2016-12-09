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
            this.searchBox1 = new Klocman.Controls.SearchBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchInsideFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupFilterComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxInvert = new System.Windows.Forms.CheckBox();
            this.comboBoxCompareMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBox1
            // 
            this.searchBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBox1.Location = new System.Drawing.Point(0, 0);
            this.searchBox1.Name = "searchBox1";
            this.searchBox1.Size = new System.Drawing.Size(225, 20);
            this.searchBox1.TabIndex = 0;
            this.searchBox1.SearchTextChanged += new System.Action<Klocman.Controls.SearchBox, System.EventArgs>(this.searchBox1_SearchTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group filter:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchInsideFilesCheckBox
            // 
            this.searchInsideFilesCheckBox.AutoSize = true;
            this.searchInsideFilesCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchInsideFilesCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.searchInsideFilesCheckBox.Location = new System.Drawing.Point(0, 0);
            this.searchInsideFilesCheckBox.Name = "searchInsideFilesCheckBox";
            this.searchInsideFilesCheckBox.Padding = new System.Windows.Forms.Padding(2);
            this.searchInsideFilesCheckBox.Size = new System.Drawing.Size(225, 21);
            this.searchInsideFilesCheckBox.TabIndex = 0;
            this.searchInsideFilesCheckBox.Text = "Search inside files";
            this.searchInsideFilesCheckBox.UseVisualStyleBackColor = true;
            this.searchInsideFilesCheckBox.CheckedChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // groupFilterComboBox
            // 
            this.groupFilterComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupFilterComboBox.DropDownHeight = 200;
            this.groupFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupFilterComboBox.DropDownWidth = 300;
            this.groupFilterComboBox.FormattingEnabled = true;
            this.groupFilterComboBox.IntegralHeight = false;
            this.groupFilterComboBox.Location = new System.Drawing.Point(0, 14);
            this.groupFilterComboBox.Name = "groupFilterComboBox";
            this.groupFilterComboBox.Size = new System.Drawing.Size(225, 21);
            this.groupFilterComboBox.TabIndex = 1;
            this.groupFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.groupFilterComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(0, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxInvert
            // 
            this.checkBoxInvert.AutoSize = true;
            this.checkBoxInvert.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxInvert.Location = new System.Drawing.Point(0, 21);
            this.checkBoxInvert.Name = "checkBoxInvert";
            this.checkBoxInvert.Padding = new System.Windows.Forms.Padding(2);
            this.checkBoxInvert.Size = new System.Drawing.Size(225, 21);
            this.checkBoxInvert.TabIndex = 1;
            this.checkBoxInvert.Text = "Invert results";
            this.checkBoxInvert.UseVisualStyleBackColor = true;
            this.checkBoxInvert.CheckedChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // comboBoxCompareMethod
            // 
            this.comboBoxCompareMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCompareMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompareMethod.Location = new System.Drawing.Point(0, 14);
            this.comboBoxCompareMethod.Name = "comboBoxCompareMethod";
            this.comboBoxCompareMethod.Size = new System.Drawing.Size(225, 21);
            this.comboBoxCompareMethod.Sorted = true;
            this.comboBoxCompareMethod.TabIndex = 1;
            this.comboBoxCompareMethod.SelectedIndexChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Comparison method:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.95833F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.04167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 96);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupFilterComboBox);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(234, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 44);
            this.panel4.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBoxCompareMethod);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 44);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxInvert);
            this.panel2.Controls.Add(this.searchInsideFilesCheckBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(234, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 40);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.searchBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 40);
            this.panel1.TabIndex = 0;
            // 
            // FilterBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FilterBox";
            this.Size = new System.Drawing.Size(462, 216);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Klocman.Controls.SearchBox searchBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox searchInsideFilesCheckBox;
        private System.Windows.Forms.ComboBox groupFilterComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxInvert;
        private System.Windows.Forms.ComboBox comboBoxCompareMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
