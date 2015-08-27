﻿using TextToScreen.CustomControls;

namespace TextToScreen.Windows
{
    partial class SecondaryWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondaryWindow));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideCursorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteTextDisplayBox = new TextDisplayBox();
            this.previewTextDisplayBox = new TextDisplayBox();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem,
            this.hideCursorToolStripMenuItem1,
            this.alwaysOnTopToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowCheckMargin = true;
            this.contextMenuStrip.ShowImageMargin = false;
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Checked = true;
            this.fullScreenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            resources.ApplyResources(this.fullScreenToolStripMenuItem, "fullScreenToolStripMenuItem");
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // hideCursorToolStripMenuItem1
            // 
            this.hideCursorToolStripMenuItem1.Checked = true;
            this.hideCursorToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideCursorToolStripMenuItem1.Name = "hideCursorToolStripMenuItem1";
            resources.ApplyResources(this.hideCursorToolStripMenuItem1, "hideCursorToolStripMenuItem1");
            this.hideCursorToolStripMenuItem1.Click += new System.EventHandler(this.hideCursorToolStripMenuItem1_Click);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Checked = true;
            this.alwaysOnTopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            resources.ApplyResources(this.alwaysOnTopToolStripMenuItem, "alwaysOnTopToolStripMenuItem");
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // remoteTextDisplayBox
            // 
            resources.ApplyResources(this.remoteTextDisplayBox, "remoteTextDisplayBox");
            this.remoteTextDisplayBox.LabelBackColor = System.Drawing.Color.Black;
            this.remoteTextDisplayBox.LabelForeColor = System.Drawing.Color.White;
            this.remoteTextDisplayBox.Name = "remoteTextDisplayBox";
            this.remoteTextDisplayBox.PreviewDisplayBox = null;
            // 
            // previewTextDisplayBox
            // 
            resources.ApplyResources(this.previewTextDisplayBox, "previewTextDisplayBox");
            this.previewTextDisplayBox.LabelBackColor = System.Drawing.Color.Black;
            this.previewTextDisplayBox.LabelForeColor = System.Drawing.Color.White;
            this.previewTextDisplayBox.Name = "previewTextDisplayBox";
            this.previewTextDisplayBox.PreviewDisplayBox = null;
            // 
            // SecondaryWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.ControlBox = false;
            this.Controls.Add(this.previewTextDisplayBox);
            this.Controls.Add(this.remoteTextDisplayBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SecondaryWindow";
            this.TopMost = true;
            this.DoubleClick += new System.EventHandler(this.SecondaryWindow_DoubleClick);
            this.MouseEnter += new System.EventHandler(this.Form_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form_MouseLeave);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextDisplayBox remoteTextDisplayBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideCursorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private TextDisplayBox previewTextDisplayBox;

    }
}