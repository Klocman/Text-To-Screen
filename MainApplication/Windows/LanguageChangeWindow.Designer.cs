namespace TextToScreen.Windows
{
    partial class LanguageChangeWindow
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
            this.p1languageHeading = new System.Windows.Forms.Label();
            this.p1languageDesc = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelButtons.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1languageHeading
            // 
            this.p1languageHeading.AutoSize = true;
            this.p1languageHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.p1languageHeading.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.p1languageHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.p1languageHeading.Location = new System.Drawing.Point(6, 6);
            this.p1languageHeading.Name = "p1languageHeading";
            this.p1languageHeading.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.p1languageHeading.Size = new System.Drawing.Size(176, 27);
            this.p1languageHeading.TabIndex = 7;
            this.p1languageHeading.Text = "Selected language";
            // 
            // p1languageDesc
            // 
            this.p1languageDesc.AutoSize = true;
            this.p1languageDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.p1languageDesc.Location = new System.Drawing.Point(3, 0);
            this.p1languageDesc.Name = "p1languageDesc";
            this.p1languageDesc.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.p1languageDesc.Size = new System.Drawing.Size(394, 30);
            this.p1languageDesc.TabIndex = 8;
            this.p1languageDesc.Text = "You can force Text To Screen to use a specific localization if the default langua" +
    "ge is incorrect. A restart will be performed to apply the new language.";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.comboBoxLanguage);
            this.panelButtons.Controls.Add(this.buttonAccept);
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(6, 63);
            this.panelButtons.MinimumSize = new System.Drawing.Size(401, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(401, 27);
            this.panelButtons.TabIndex = 9;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(8, 3);
            this.comboBoxLanguage.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(221, 21);
            this.comboBoxLanguage.TabIndex = 8;
            this.comboBoxLanguage.TabStop = false;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccept.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonAccept.Location = new System.Drawing.Point(238, 2);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 9;
            this.buttonAccept.TabStop = false;
            this.buttonAccept.Text = "Apply";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(319, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.p1languageDesc);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 33);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(401, 30);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // LanguageChangeWindow
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(413, 210);
            this.ControlBox = false;
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.p1languageHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(429, 9999);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(429, 100);
            this.Name = "LanguageChangeWindow";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change program language";
            this.Shown += new System.EventHandler(this.LanguageChangeWindow_Shown);
            this.panelButtons.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label p1languageHeading;
        private System.Windows.Forms.Label p1languageDesc;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}