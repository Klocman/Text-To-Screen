namespace TextToScreen.CustomControls
{
    partial class PreviewScreens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewScreens));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.fadeProgressBar = new System.Windows.Forms.ProgressBar();
            this.topPreviewScreen = new TextDisplayBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.button_send = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.bottomPreviewScreen = new TextDisplayBox();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.fadeProgressBar);
            this.splitContainer2.Panel1.Controls.Add(this.topPreviewScreen);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer2.TabStop = false;
            // 
            // fadeProgressBar
            // 
            this.fadeProgressBar.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.fadeProgressBar, "fadeProgressBar");
            this.fadeProgressBar.Name = "fadeProgressBar";
            this.fadeProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.fadeProgressBar.Value = 45;
            // 
            // topPreviewScreen
            // 
            resources.ApplyResources(this.topPreviewScreen, "topPreviewScreen");
            this.topPreviewScreen.LabelBackColor = System.Drawing.Color.Black;
            this.topPreviewScreen.LabelForeColor = System.Drawing.Color.White;
            this.topPreviewScreen.Name = "topPreviewScreen";
            this.topPreviewScreen.PreviewDisplayBox = null;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitContainer5, "splitContainer5");
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.button_send);
            this.splitContainer5.Panel1.Controls.Add(this.button_clear);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.bottomPreviewScreen);
            this.splitContainer5.TabStop = false;
            // 
            // button_send
            // 
            this.button_send.BackColor = System.Drawing.Color.LightCoral;
            resources.ApplyResources(this.button_send, "button_send");
            this.button_send.Name = "button_send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_clear
            // 
            resources.ApplyResources(this.button_clear, "button_clear");
            this.button_clear.Name = "button_clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // bottomPreviewScreen
            // 
            resources.ApplyResources(this.bottomPreviewScreen, "bottomPreviewScreen");
            this.bottomPreviewScreen.LabelBackColor = System.Drawing.Color.Black;
            this.bottomPreviewScreen.LabelForeColor = System.Drawing.Color.White;
            this.bottomPreviewScreen.Name = "bottomPreviewScreen";
            this.bottomPreviewScreen.PreviewDisplayBox = null;
            // 
            // PreviewScreens
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "PreviewScreens";
            this.Resize += new System.EventHandler(this.PreviewScreens_Resize);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_clear;
        private TextDisplayBox topPreviewScreen;
        private TextDisplayBox bottomPreviewScreen;
        private System.Windows.Forms.ProgressBar fadeProgressBar;
    }
}
