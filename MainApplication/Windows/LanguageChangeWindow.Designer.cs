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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageChangeWindow));
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
            resources.ApplyResources(this.p1languageHeading, "p1languageHeading");
            this.p1languageHeading.Name = "p1languageHeading";
            // 
            // p1languageDesc
            // 
            resources.ApplyResources(this.p1languageDesc, "p1languageDesc");
            this.p1languageDesc.Name = "p1languageDesc";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.comboBoxLanguage);
            this.panelButtons.Controls.Add(this.buttonAccept);
            this.panelButtons.Controls.Add(this.buttonCancel);
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.panelButtons.Name = "panelButtons";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.TabStop = false;
            // 
            // buttonAccept
            // 
            resources.ApplyResources(this.buttonAccept, "buttonAccept");
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.TabStop = false;
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.TabStop = false;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.p1languageDesc);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // LanguageChangeWindow
            // 
            this.AcceptButton = this.buttonAccept;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ControlBox = false;
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.p1languageHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LanguageChangeWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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