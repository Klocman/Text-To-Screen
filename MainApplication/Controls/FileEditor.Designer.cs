namespace TextToScreen.Controls
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.multiLineListBox1 = new TextToScreen.Controls.MultilineListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.filePropertiesViewer1 = new TextToScreen.Controls.FilePropertiesViewer();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
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
            this.filePropertiesViewer1.FileWasEdited += new System.Action<TextToScreen.Controls.FilePropertiesViewer, TextToScreen.Controls.FilePropertiesViewerEventArgs>(this.filePropertiesViewer1_DataWasEditedChanged);
            // 
            // FileEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "FileEditor";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MultilineListBox multiLineListBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private FilePropertiesViewer filePropertiesViewer1;
    }
}
