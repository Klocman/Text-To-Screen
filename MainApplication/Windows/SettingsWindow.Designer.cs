namespace TextToScreen.Windows
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.general_other_groupBox1 = new System.Windows.Forms.GroupBox();
            this.general_other_checkForExternalChanges = new System.Windows.Forms.CheckBox();
            this.general_other_allowExternalArchiveAcces = new System.Windows.Forms.CheckBox();
            this.general_history_groupBox1 = new System.Windows.Forms.GroupBox();
            this.general_history_numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.general_history_label2 = new System.Windows.Forms.Label();
            this.general_history_checkBox3 = new System.Windows.Forms.CheckBox();
            this.general_button_factorySettings = new System.Windows.Forms.Button();
            this.general_appstart_groupBox = new System.Windows.Forms.GroupBox();
            this.general_appstart_pathSelectBox1 = new Klocman.Controls.PathSelectBox();
            this.label1 = new System.Windows.Forms.Label();
            this.general_appstart_radioButton3 = new System.Windows.Forms.RadioButton();
            this.general_appstart_radioButton2 = new System.Windows.Forms.RadioButton();
            this.general_appstart_radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.main_other_groupBox = new System.Windows.Forms.GroupBox();
            this.main_other_showFullPath = new System.Windows.Forms.CheckBox();
            this.main_other_showProgressBar = new System.Windows.Forms.CheckBox();
            this.main_button_factorySettings = new System.Windows.Forms.Button();
            this.main_keys_groupBox3 = new System.Windows.Forms.GroupBox();
            this.main_keys_checkBox2 = new System.Windows.Forms.CheckBox();
            this.main_keys_listButton = new System.Windows.Forms.Button();
            this.main_keys_checkBox1 = new System.Windows.Forms.CheckBox();
            this.main_window_groupBox2 = new System.Windows.Forms.GroupBox();
            this.main_window_checkBoxFull = new System.Windows.Forms.CheckBox();
            this.main_window_checkBoxTop = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.secondary_out_groupBox1 = new System.Windows.Forms.GroupBox();
            this.secondary_out_labelPreview = new System.Windows.Forms.Label();
            this.secondary_out_numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.secondary_out_labelSpeed = new System.Windows.Forms.Label();
            this.secondary_out_panelBacCol = new System.Windows.Forms.Panel();
            this.secondary_out_labelBacCol = new System.Windows.Forms.Label();
            this.secondary_out_buttonBacCol = new System.Windows.Forms.Button();
            this.secondary_out_panelTexCol = new System.Windows.Forms.Panel();
            this.secondary_out_labelTexCol = new System.Windows.Forms.Label();
            this.secondary_out_buttonTexCol = new System.Windows.Forms.Button();
            this.secondary_window_groupBox = new System.Windows.Forms.GroupBox();
            this.secondary_window_checkBoxPointer = new System.Windows.Forms.CheckBox();
            this.secondary_window_checkBoxFull = new System.Windows.Forms.CheckBox();
            this.secondary_window_checkBoxTop = new System.Windows.Forms.CheckBox();
            this.secondary_button_factorySettings = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.general_other_groupBox1.SuspendLayout();
            this.general_history_groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.general_history_numericUpDown1)).BeginInit();
            this.general_appstart_groupBox.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.main_other_groupBox.SuspendLayout();
            this.main_keys_groupBox3.SuspendLayout();
            this.main_window_groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.secondary_out_groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondary_out_numericUpDownSpeed)).BeginInit();
            this.secondary_window_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            resources.ApplyResources(this.buttonAccept, "buttonAccept");
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.general_other_groupBox1);
            this.tabPage1.Controls.Add(this.general_history_groupBox1);
            this.tabPage1.Controls.Add(this.general_button_factorySettings);
            this.tabPage1.Controls.Add(this.general_appstart_groupBox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // general_other_groupBox1
            // 
            this.general_other_groupBox1.Controls.Add(this.general_other_checkForExternalChanges);
            this.general_other_groupBox1.Controls.Add(this.general_other_allowExternalArchiveAcces);
            resources.ApplyResources(this.general_other_groupBox1, "general_other_groupBox1");
            this.general_other_groupBox1.Name = "general_other_groupBox1";
            this.general_other_groupBox1.TabStop = false;
            // 
            // general_other_checkForExternalChanges
            // 
            resources.ApplyResources(this.general_other_checkForExternalChanges, "general_other_checkForExternalChanges");
            this.general_other_checkForExternalChanges.Name = "general_other_checkForExternalChanges";
            this.general_other_checkForExternalChanges.UseVisualStyleBackColor = true;
            // 
            // general_other_allowExternalArchiveAcces
            // 
            resources.ApplyResources(this.general_other_allowExternalArchiveAcces, "general_other_allowExternalArchiveAcces");
            this.general_other_allowExternalArchiveAcces.Checked = true;
            this.general_other_allowExternalArchiveAcces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.general_other_allowExternalArchiveAcces.Name = "general_other_allowExternalArchiveAcces";
            this.general_other_allowExternalArchiveAcces.UseVisualStyleBackColor = true;
            this.general_other_allowExternalArchiveAcces.CheckedChanged += new System.EventHandler(this.general_other_allowExternalArchiveAcces_CheckedChanged);
            // 
            // general_history_groupBox1
            // 
            this.general_history_groupBox1.Controls.Add(this.general_history_numericUpDown1);
            this.general_history_groupBox1.Controls.Add(this.general_history_label2);
            this.general_history_groupBox1.Controls.Add(this.general_history_checkBox3);
            resources.ApplyResources(this.general_history_groupBox1, "general_history_groupBox1");
            this.general_history_groupBox1.Name = "general_history_groupBox1";
            this.general_history_groupBox1.TabStop = false;
            // 
            // general_history_numericUpDown1
            // 
            resources.ApplyResources(this.general_history_numericUpDown1, "general_history_numericUpDown1");
            this.general_history_numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.general_history_numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.general_history_numericUpDown1.Name = "general_history_numericUpDown1";
            this.general_history_numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // general_history_label2
            // 
            resources.ApplyResources(this.general_history_label2, "general_history_label2");
            this.general_history_label2.Name = "general_history_label2";
            // 
            // general_history_checkBox3
            // 
            resources.ApplyResources(this.general_history_checkBox3, "general_history_checkBox3");
            this.general_history_checkBox3.Checked = true;
            this.general_history_checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.general_history_checkBox3.Name = "general_history_checkBox3";
            this.general_history_checkBox3.UseVisualStyleBackColor = true;
            this.general_history_checkBox3.CheckedChanged += new System.EventHandler(this.general_history_checkBox3_CheckedChanged);
            // 
            // general_button_factorySettings
            // 
            resources.ApplyResources(this.general_button_factorySettings, "general_button_factorySettings");
            this.general_button_factorySettings.Name = "general_button_factorySettings";
            this.general_button_factorySettings.UseVisualStyleBackColor = true;
            this.general_button_factorySettings.Click += new System.EventHandler(this.general_button_factorySettings_Click);
            // 
            // general_appstart_groupBox
            // 
            this.general_appstart_groupBox.Controls.Add(this.general_appstart_pathSelectBox1);
            this.general_appstart_groupBox.Controls.Add(this.label1);
            this.general_appstart_groupBox.Controls.Add(this.general_appstart_radioButton3);
            this.general_appstart_groupBox.Controls.Add(this.general_appstart_radioButton2);
            this.general_appstart_groupBox.Controls.Add(this.general_appstart_radioButton1);
            resources.ApplyResources(this.general_appstart_groupBox, "general_appstart_groupBox");
            this.general_appstart_groupBox.Name = "general_appstart_groupBox";
            this.general_appstart_groupBox.TabStop = false;
            // 
            // general_appstart_pathSelectBox1
            // 
            resources.ApplyResources(this.general_appstart_pathSelectBox1, "general_appstart_pathSelectBox1");
            this.general_appstart_pathSelectBox1.FileName = "";
            this.general_appstart_pathSelectBox1.Name = "general_appstart_pathSelectBox1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // general_appstart_radioButton3
            // 
            resources.ApplyResources(this.general_appstart_radioButton3, "general_appstart_radioButton3");
            this.general_appstart_radioButton3.Name = "general_appstart_radioButton3";
            this.general_appstart_radioButton3.TabStop = true;
            this.general_appstart_radioButton3.UseVisualStyleBackColor = true;
            this.general_appstart_radioButton3.CheckedChanged += new System.EventHandler(this.general_appstart_radioButton3_CheckedChanged);
            // 
            // general_appstart_radioButton2
            // 
            resources.ApplyResources(this.general_appstart_radioButton2, "general_appstart_radioButton2");
            this.general_appstart_radioButton2.Name = "general_appstart_radioButton2";
            this.general_appstart_radioButton2.TabStop = true;
            this.general_appstart_radioButton2.UseVisualStyleBackColor = true;
            this.general_appstart_radioButton2.CheckedChanged += new System.EventHandler(this.general_appstart_radioButton2_CheckedChanged);
            // 
            // general_appstart_radioButton1
            // 
            resources.ApplyResources(this.general_appstart_radioButton1, "general_appstart_radioButton1");
            this.general_appstart_radioButton1.Name = "general_appstart_radioButton1";
            this.general_appstart_radioButton1.TabStop = true;
            this.general_appstart_radioButton1.UseVisualStyleBackColor = true;
            this.general_appstart_radioButton1.CheckedChanged += new System.EventHandler(this.general_appstart_radioButton1_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.main_other_groupBox);
            this.tabPage3.Controls.Add(this.main_button_factorySettings);
            this.tabPage3.Controls.Add(this.main_keys_groupBox3);
            this.tabPage3.Controls.Add(this.main_window_groupBox2);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // main_other_groupBox
            // 
            this.main_other_groupBox.Controls.Add(this.main_other_showFullPath);
            this.main_other_groupBox.Controls.Add(this.main_other_showProgressBar);
            resources.ApplyResources(this.main_other_groupBox, "main_other_groupBox");
            this.main_other_groupBox.Name = "main_other_groupBox";
            this.main_other_groupBox.TabStop = false;
            // 
            // main_other_showFullPath
            // 
            resources.ApplyResources(this.main_other_showFullPath, "main_other_showFullPath");
            this.main_other_showFullPath.Name = "main_other_showFullPath";
            this.main_other_showFullPath.UseVisualStyleBackColor = true;
            // 
            // main_other_showProgressBar
            // 
            resources.ApplyResources(this.main_other_showProgressBar, "main_other_showProgressBar");
            this.main_other_showProgressBar.Name = "main_other_showProgressBar";
            this.main_other_showProgressBar.UseVisualStyleBackColor = true;
            // 
            // main_button_factorySettings
            // 
            resources.ApplyResources(this.main_button_factorySettings, "main_button_factorySettings");
            this.main_button_factorySettings.Name = "main_button_factorySettings";
            this.main_button_factorySettings.UseVisualStyleBackColor = true;
            this.main_button_factorySettings.Click += new System.EventHandler(this.main_button_factorySettings_Click);
            // 
            // main_keys_groupBox3
            // 
            this.main_keys_groupBox3.Controls.Add(this.main_keys_checkBox2);
            this.main_keys_groupBox3.Controls.Add(this.main_keys_listButton);
            this.main_keys_groupBox3.Controls.Add(this.main_keys_checkBox1);
            resources.ApplyResources(this.main_keys_groupBox3, "main_keys_groupBox3");
            this.main_keys_groupBox3.Name = "main_keys_groupBox3";
            this.main_keys_groupBox3.TabStop = false;
            // 
            // main_keys_checkBox2
            // 
            resources.ApplyResources(this.main_keys_checkBox2, "main_keys_checkBox2");
            this.main_keys_checkBox2.Name = "main_keys_checkBox2";
            this.main_keys_checkBox2.UseVisualStyleBackColor = true;
            // 
            // main_keys_listButton
            // 
            resources.ApplyResources(this.main_keys_listButton, "main_keys_listButton");
            this.main_keys_listButton.Name = "main_keys_listButton";
            this.main_keys_listButton.UseVisualStyleBackColor = true;
            this.main_keys_listButton.Click += new System.EventHandler(this.main_keys_listButton_Click);
            // 
            // main_keys_checkBox1
            // 
            resources.ApplyResources(this.main_keys_checkBox1, "main_keys_checkBox1");
            this.main_keys_checkBox1.Name = "main_keys_checkBox1";
            this.main_keys_checkBox1.UseVisualStyleBackColor = true;
            // 
            // main_window_groupBox2
            // 
            this.main_window_groupBox2.Controls.Add(this.main_window_checkBoxFull);
            this.main_window_groupBox2.Controls.Add(this.main_window_checkBoxTop);
            resources.ApplyResources(this.main_window_groupBox2, "main_window_groupBox2");
            this.main_window_groupBox2.Name = "main_window_groupBox2";
            this.main_window_groupBox2.TabStop = false;
            // 
            // main_window_checkBoxFull
            // 
            resources.ApplyResources(this.main_window_checkBoxFull, "main_window_checkBoxFull");
            this.main_window_checkBoxFull.Name = "main_window_checkBoxFull";
            this.main_window_checkBoxFull.UseVisualStyleBackColor = true;
            // 
            // main_window_checkBoxTop
            // 
            resources.ApplyResources(this.main_window_checkBoxTop, "main_window_checkBoxTop");
            this.main_window_checkBoxTop.Name = "main_window_checkBoxTop";
            this.main_window_checkBoxTop.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.secondary_out_groupBox1);
            this.tabPage2.Controls.Add(this.secondary_window_groupBox);
            this.tabPage2.Controls.Add(this.secondary_button_factorySettings);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // secondary_out_groupBox1
            // 
            this.secondary_out_groupBox1.Controls.Add(this.secondary_out_labelPreview);
            this.secondary_out_groupBox1.Controls.Add(this.secondary_out_numericUpDownSpeed);
            this.secondary_out_groupBox1.Controls.Add(this.secondary_out_labelSpeed);
            this.secondary_out_groupBox1.Controls.Add(this.secondary_out_panelBacCol);
            this.secondary_out_groupBox1.Controls.Add(this.secondary_out_labelBacCol);
            this.secondary_out_groupBox1.Controls.Add(this.secondary_out_buttonBacCol);
            this.secondary_out_groupBox1.Controls.Add(this.secondary_out_panelTexCol);
            this.secondary_out_groupBox1.Controls.Add(this.secondary_out_labelTexCol);
            this.secondary_out_groupBox1.Controls.Add(this.secondary_out_buttonTexCol);
            resources.ApplyResources(this.secondary_out_groupBox1, "secondary_out_groupBox1");
            this.secondary_out_groupBox1.Name = "secondary_out_groupBox1";
            this.secondary_out_groupBox1.TabStop = false;
            // 
            // secondary_out_labelPreview
            // 
            resources.ApplyResources(this.secondary_out_labelPreview, "secondary_out_labelPreview");
            this.secondary_out_labelPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.secondary_out_labelPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.secondary_out_labelPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.secondary_out_labelPreview.Name = "secondary_out_labelPreview";
            // 
            // secondary_out_numericUpDownSpeed
            // 
            resources.ApplyResources(this.secondary_out_numericUpDownSpeed, "secondary_out_numericUpDownSpeed");
            this.secondary_out_numericUpDownSpeed.DecimalPlaces = 1;
            this.secondary_out_numericUpDownSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.secondary_out_numericUpDownSpeed.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.secondary_out_numericUpDownSpeed.Name = "secondary_out_numericUpDownSpeed";
            this.secondary_out_numericUpDownSpeed.Value = new decimal(new int[] {
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
            // secondary_out_panelBacCol
            // 
            resources.ApplyResources(this.secondary_out_panelBacCol, "secondary_out_panelBacCol");
            this.secondary_out_panelBacCol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.secondary_out_panelBacCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.secondary_out_panelBacCol.Name = "secondary_out_panelBacCol";
            this.secondary_out_panelBacCol.BackColorChanged += new System.EventHandler(this.secondary_out_panelBacCol_BackColorChanged);
            // 
            // secondary_out_labelBacCol
            // 
            resources.ApplyResources(this.secondary_out_labelBacCol, "secondary_out_labelBacCol");
            this.secondary_out_labelBacCol.Name = "secondary_out_labelBacCol";
            // 
            // secondary_out_buttonBacCol
            // 
            resources.ApplyResources(this.secondary_out_buttonBacCol, "secondary_out_buttonBacCol");
            this.secondary_out_buttonBacCol.Name = "secondary_out_buttonBacCol";
            this.secondary_out_buttonBacCol.UseVisualStyleBackColor = true;
            this.secondary_out_buttonBacCol.Click += new System.EventHandler(this.secondary_out_buttonBacCol_Click);
            // 
            // secondary_out_panelTexCol
            // 
            resources.ApplyResources(this.secondary_out_panelTexCol, "secondary_out_panelTexCol");
            this.secondary_out_panelTexCol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.secondary_out_panelTexCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.secondary_out_panelTexCol.Name = "secondary_out_panelTexCol";
            this.secondary_out_panelTexCol.BackColorChanged += new System.EventHandler(this.secondary_out_panelTexCol_BackColorChanged);
            // 
            // secondary_out_labelTexCol
            // 
            resources.ApplyResources(this.secondary_out_labelTexCol, "secondary_out_labelTexCol");
            this.secondary_out_labelTexCol.Name = "secondary_out_labelTexCol";
            // 
            // secondary_out_buttonTexCol
            // 
            resources.ApplyResources(this.secondary_out_buttonTexCol, "secondary_out_buttonTexCol");
            this.secondary_out_buttonTexCol.Name = "secondary_out_buttonTexCol";
            this.secondary_out_buttonTexCol.UseVisualStyleBackColor = true;
            this.secondary_out_buttonTexCol.Click += new System.EventHandler(this.secondary_out_buttonTexCol_Click);
            // 
            // secondary_window_groupBox
            // 
            this.secondary_window_groupBox.Controls.Add(this.secondary_window_checkBoxPointer);
            this.secondary_window_groupBox.Controls.Add(this.secondary_window_checkBoxFull);
            this.secondary_window_groupBox.Controls.Add(this.secondary_window_checkBoxTop);
            resources.ApplyResources(this.secondary_window_groupBox, "secondary_window_groupBox");
            this.secondary_window_groupBox.Name = "secondary_window_groupBox";
            this.secondary_window_groupBox.TabStop = false;
            // 
            // secondary_window_checkBoxPointer
            // 
            resources.ApplyResources(this.secondary_window_checkBoxPointer, "secondary_window_checkBoxPointer");
            this.secondary_window_checkBoxPointer.Name = "secondary_window_checkBoxPointer";
            this.secondary_window_checkBoxPointer.UseVisualStyleBackColor = true;
            // 
            // secondary_window_checkBoxFull
            // 
            resources.ApplyResources(this.secondary_window_checkBoxFull, "secondary_window_checkBoxFull");
            this.secondary_window_checkBoxFull.Name = "secondary_window_checkBoxFull";
            this.secondary_window_checkBoxFull.UseVisualStyleBackColor = true;
            // 
            // secondary_window_checkBoxTop
            // 
            resources.ApplyResources(this.secondary_window_checkBoxTop, "secondary_window_checkBoxTop");
            this.secondary_window_checkBoxTop.Name = "secondary_window_checkBoxTop";
            this.secondary_window_checkBoxTop.UseVisualStyleBackColor = true;
            // 
            // secondary_button_factorySettings
            // 
            resources.ApplyResources(this.secondary_button_factorySettings, "secondary_button_factorySettings");
            this.secondary_button_factorySettings.Name = "secondary_button_factorySettings";
            this.secondary_button_factorySettings.UseVisualStyleBackColor = true;
            this.secondary_button_factorySettings.Click += new System.EventHandler(this.secondary_button_factorySettings_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.SolidColorOnly = true;
            // 
            // SettingsWindow
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.general_other_groupBox1.ResumeLayout(false);
            this.general_other_groupBox1.PerformLayout();
            this.general_history_groupBox1.ResumeLayout(false);
            this.general_history_groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.general_history_numericUpDown1)).EndInit();
            this.general_appstart_groupBox.ResumeLayout(false);
            this.general_appstart_groupBox.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.main_other_groupBox.ResumeLayout(false);
            this.main_other_groupBox.PerformLayout();
            this.main_keys_groupBox3.ResumeLayout(false);
            this.main_window_groupBox2.ResumeLayout(false);
            this.main_window_groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.secondary_out_groupBox1.ResumeLayout(false);
            this.secondary_out_groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondary_out_numericUpDownSpeed)).EndInit();
            this.secondary_window_groupBox.ResumeLayout(false);
            this.secondary_window_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox general_appstart_groupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton general_appstart_radioButton3;
        private System.Windows.Forms.RadioButton general_appstart_radioButton2;
        private System.Windows.Forms.RadioButton general_appstart_radioButton1;
        private System.Windows.Forms.TabPage tabPage3;
        private Klocman.Controls.PathSelectBox general_appstart_pathSelectBox1;
        private System.Windows.Forms.Button general_button_factorySettings;
        private System.Windows.Forms.GroupBox main_window_groupBox2;
        private System.Windows.Forms.CheckBox main_window_checkBoxFull;
        private System.Windows.Forms.CheckBox main_window_checkBoxTop;
        private System.Windows.Forms.GroupBox general_history_groupBox1;
        private System.Windows.Forms.NumericUpDown general_history_numericUpDown1;
        private System.Windows.Forms.Label general_history_label2;
        private System.Windows.Forms.CheckBox general_history_checkBox3;
        private System.Windows.Forms.GroupBox general_other_groupBox1;
        private System.Windows.Forms.Button main_button_factorySettings;
        private System.Windows.Forms.GroupBox main_keys_groupBox3;
        private System.Windows.Forms.CheckBox main_keys_checkBox2;
        private System.Windows.Forms.CheckBox main_keys_checkBox1;
        private System.Windows.Forms.Button secondary_button_factorySettings;
        private System.Windows.Forms.GroupBox secondary_window_groupBox;
        private System.Windows.Forms.CheckBox secondary_window_checkBoxPointer;
        private System.Windows.Forms.CheckBox secondary_window_checkBoxFull;
        private System.Windows.Forms.CheckBox secondary_window_checkBoxTop;
        private System.Windows.Forms.GroupBox secondary_out_groupBox1;
        private System.Windows.Forms.Label secondary_out_labelPreview;
        private System.Windows.Forms.NumericUpDown secondary_out_numericUpDownSpeed;
        private System.Windows.Forms.Label secondary_out_labelSpeed;
        private System.Windows.Forms.Panel secondary_out_panelBacCol;
        private System.Windows.Forms.Label secondary_out_labelBacCol;
        private System.Windows.Forms.Button secondary_out_buttonBacCol;
        private System.Windows.Forms.Panel secondary_out_panelTexCol;
        private System.Windows.Forms.Label secondary_out_labelTexCol;
        private System.Windows.Forms.Button secondary_out_buttonTexCol;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.CheckBox general_other_checkForExternalChanges;
        private System.Windows.Forms.CheckBox general_other_allowExternalArchiveAcces;
        private System.Windows.Forms.GroupBox main_other_groupBox;
        private System.Windows.Forms.CheckBox main_other_showFullPath;
        private System.Windows.Forms.CheckBox main_other_showProgressBar;
        private System.Windows.Forms.Button main_keys_listButton;
    }
}