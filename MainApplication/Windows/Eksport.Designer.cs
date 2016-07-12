using TextToScreen.Controls;

namespace TextToScreen.Windows
{
    partial class Eksport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eksport));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fileListView = new FileListView();
            this.label1 = new System.Windows.Forms.Label();
            this.anulujbut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.eksportbut = new System.Windows.Forms.Button();
            this.eksportujDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fileListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.anulujbut);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.eksportbut);
            // 
            // fileListView
            // 
            resources.ApplyResources(this.fileListView, "fileListView");
            this.fileListView.Name = "fileListView";
            this.fileListView.SaveButtonEnabled = true;
            this.fileListView.ShowToolbar = false;
            this.fileListView.StopRefreshingList = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // anulujbut
            // 
            resources.ApplyResources(this.anulujbut, "anulujbut");
            this.anulujbut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.anulujbut.Name = "anulujbut";
            this.anulujbut.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // eksportbut
            // 
            resources.ApplyResources(this.eksportbut, "eksportbut");
            this.eksportbut.Name = "eksportbut";
            this.eksportbut.UseVisualStyleBackColor = true;
            this.eksportbut.Click += new System.EventHandler(this.eksportbut_Click);
            // 
            // eksportujDialog
            // 
            this.eksportujDialog.AutoUpgradeEnabled = false;
            this.eksportujDialog.DefaultExt = "txt";
            resources.ApplyResources(this.eksportujDialog, "eksportujDialog");
            this.eksportujDialog.RestoreDirectory = true;
            this.eksportujDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.eksportujDialog_FileOk);
            // 
            // Eksport
            // 
            this.AcceptButton = this.eksportbut;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.anulujbut;
            this.Controls.Add(this.splitContainer1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Eksport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Eksport_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button anulujbut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button eksportbut;
        private System.Windows.Forms.SaveFileDialog eksportujDialog;
        private System.Windows.Forms.Label label1;
        private FileListView fileListView;

    }
}