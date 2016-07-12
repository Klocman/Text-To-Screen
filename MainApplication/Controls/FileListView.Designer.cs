namespace TextToScreen.Controls
{
    partial class FileListView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.modifiedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.createdColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.commentColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_new = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ren = new System.Windows.Forms.ToolStripButton();
            this.propertiesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ref = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_save = new System.Windows.Forms.ToolStripButton();
            this.searchSubsection = new System.Windows.Forms.GroupBox();
            this.searchBox1 = new Klocman.Controls.SearchBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchInsideFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupFilterComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.usuńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplikujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmieńNazwęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.kopiujDoSchowkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.właściwościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.searchSubsection.SuspendLayout();
            this.listViewContextMenuStrip.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.objectListView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.searchSubsection);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.nameColumn);
            this.objectListView1.AllColumns.Add(this.modifiedColumn);
            this.objectListView1.AllColumns.Add(this.createdColumn);
            this.objectListView1.AllColumns.Add(this.commentColumn);
            this.objectListView1.AllColumns.Add(this.groupColumn);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.modifiedColumn,
            this.createdColumn,
            this.commentColumn});
            this.objectListView1.CopySelectionOnControlC = false;
            this.objectListView1.CopySelectionOnControlCUsesDragSource = false;
            resources.ApplyResources(this.objectListView1, "objectListView1");
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.SortGroupItemsByPrimaryColumn = false;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.DoubleClick += new System.EventHandler(this.objectListView1_DoubleClick);
            this.objectListView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.objectListView1_KeyDown);
            this.objectListView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.objectListView1_MouseClick);
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "Name";
            this.nameColumn.Hideable = false;
            this.nameColumn.IsEditable = false;
            this.nameColumn.MinimumWidth = 60;
            resources.ApplyResources(this.nameColumn, "nameColumn");
            // 
            // modifiedColumn
            // 
            this.modifiedColumn.AspectName = "LastModified";
            this.modifiedColumn.IsEditable = false;
            this.modifiedColumn.MinimumWidth = 60;
            resources.ApplyResources(this.modifiedColumn, "modifiedColumn");
            // 
            // createdColumn
            // 
            this.createdColumn.AspectName = "CreationTime";
            this.createdColumn.IsEditable = false;
            this.createdColumn.MinimumWidth = 60;
            resources.ApplyResources(this.createdColumn, "createdColumn");
            // 
            // commentColumn
            // 
            this.commentColumn.AspectName = "Comment";
            this.commentColumn.Groupable = false;
            this.commentColumn.IsEditable = false;
            this.commentColumn.MinimumWidth = 80;
            resources.ApplyResources(this.commentColumn, "commentColumn");
            // 
            // groupColumn
            // 
            this.groupColumn.AspectName = "Group";
            resources.ApplyResources(this.groupColumn, "groupColumn");
            this.groupColumn.IsEditable = false;
            this.groupColumn.IsVisible = false;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_new,
            this.toolStripButton_del,
            this.toolStripButton_ren,
            this.propertiesToolStripButton,
            this.toolStripSeparator3,
            this.toolStripButton_ref,
            this.toolStripButton_save});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.TabStop = true;
            // 
            // toolStripButton_new
            // 
            this.toolStripButton_new.Image = global::TextToScreen.Properties.Resources.NewDocumentHS;
            resources.ApplyResources(this.toolStripButton_new, "toolStripButton_new");
            this.toolStripButton_new.Name = "toolStripButton_new";
            this.toolStripButton_new.Click += new System.EventHandler(this.toolStripButton_new_Click);
            // 
            // toolStripButton_del
            // 
            this.toolStripButton_del.Image = global::TextToScreen.Properties.Resources.DeleteHS;
            resources.ApplyResources(this.toolStripButton_del, "toolStripButton_del");
            this.toolStripButton_del.Name = "toolStripButton_del";
            this.toolStripButton_del.Click += new System.EventHandler(this.toolStripButton_del_Click);
            // 
            // toolStripButton_ren
            // 
            this.toolStripButton_ren.Image = global::TextToScreen.Properties.Resources.RenameFolderHS;
            resources.ApplyResources(this.toolStripButton_ren, "toolStripButton_ren");
            this.toolStripButton_ren.Name = "toolStripButton_ren";
            this.toolStripButton_ren.Click += new System.EventHandler(this.toolStripButton_ren_Click);
            // 
            // propertiesToolStripButton
            // 
            this.propertiesToolStripButton.Image = global::TextToScreen.Properties.Resources.Properties;
            resources.ApplyResources(this.propertiesToolStripButton, "propertiesToolStripButton");
            this.propertiesToolStripButton.Name = "propertiesToolStripButton";
            this.propertiesToolStripButton.Click += new System.EventHandler(this.propertiesToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButton_ref
            // 
            this.toolStripButton_ref.Image = global::TextToScreen.Properties.Resources.RepeatHS;
            resources.ApplyResources(this.toolStripButton_ref, "toolStripButton_ref");
            this.toolStripButton_ref.Name = "toolStripButton_ref";
            this.toolStripButton_ref.Click += new System.EventHandler(this.toolStripButton_ref_Click);
            // 
            // toolStripButton_save
            // 
            this.toolStripButton_save.Image = global::TextToScreen.Properties.Resources.saveHS;
            resources.ApplyResources(this.toolStripButton_save, "toolStripButton_save");
            this.toolStripButton_save.Name = "toolStripButton_save";
            this.toolStripButton_save.Click += new System.EventHandler(this.toolStripButton_save_Click);
            // 
            // searchSubsection
            // 
            this.searchSubsection.Controls.Add(this.searchBox1);
            this.searchSubsection.Controls.Add(this.label1);
            this.searchSubsection.Controls.Add(this.searchInsideFilesCheckBox);
            this.searchSubsection.Controls.Add(this.groupFilterComboBox);
            this.searchSubsection.Controls.Add(this.button1);
            resources.ApplyResources(this.searchSubsection, "searchSubsection");
            this.searchSubsection.Name = "searchSubsection";
            this.searchSubsection.TabStop = false;
            // 
            // searchBox1
            // 
            resources.ApplyResources(this.searchBox1, "searchBox1");
            this.searchBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchBox1.Name = "searchBox1";
            this.searchBox1.SearchTextChanged += new System.Action<Klocman.Controls.SearchBox, System.EventArgs>(this.searchBox1_SearchTextChanged);
            this.searchBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox1_KeyDown);
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
            this.toolTip.SetToolTip(this.searchInsideFilesCheckBox, resources.GetString("searchInsideFilesCheckBox.ToolTip"));
            this.searchInsideFilesCheckBox.UseVisualStyleBackColor = true;
            this.searchInsideFilesCheckBox.CheckedChanged += new System.EventHandler(this.searchInsideFilesCheckBox_CheckedChanged);
            // 
            // groupFilterComboBox
            // 
            resources.ApplyResources(this.groupFilterComboBox, "groupFilterComboBox");
            this.groupFilterComboBox.DropDownHeight = 200;
            this.groupFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupFilterComboBox.DropDownWidth = 300;
            this.groupFilterComboBox.FormattingEnabled = true;
            this.groupFilterComboBox.Name = "groupFilterComboBox";
            this.toolTip.SetToolTip(this.groupFilterComboBox, resources.GetString("groupFilterComboBox.ToolTip"));
            this.groupFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.groupFilterComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.toolTip.SetToolTip(this.button1, resources.GetString("button1.ToolTip"));
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // listViewContextMenuStrip
            // 
            this.listViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.toolStripSeparator1,
            this.usuńToolStripMenuItem,
            this.duplikujToolStripMenuItem,
            this.zmieńNazwęToolStripMenuItem,
            this.toolStripSeparator2,
            this.kopiujDoSchowkaToolStripMenuItem,
            this.właściwościToolStripMenuItem});
            this.listViewContextMenuStrip.Name = "listViewContextMenuStrip";
            resources.ApplyResources(this.listViewContextMenuStrip, "listViewContextMenuStrip");
            this.listViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.listViewContextMenuStrip_Opening);
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            resources.ApplyResources(this.otwórzToolStripMenuItem, "otwórzToolStripMenuItem");
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // usuńToolStripMenuItem
            // 
            this.usuńToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.DeleteHS;
            this.usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            resources.ApplyResources(this.usuńToolStripMenuItem, "usuńToolStripMenuItem");
            this.usuńToolStripMenuItem.Click += new System.EventHandler(this.usuńToolStripMenuItem_Click);
            // 
            // duplikujToolStripMenuItem
            // 
            this.duplikujToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.CopyHS;
            this.duplikujToolStripMenuItem.Name = "duplikujToolStripMenuItem";
            resources.ApplyResources(this.duplikujToolStripMenuItem, "duplikujToolStripMenuItem");
            this.duplikujToolStripMenuItem.Click += new System.EventHandler(this.duplikujToolStripMenuItem_Click);
            // 
            // zmieńNazwęToolStripMenuItem
            // 
            this.zmieńNazwęToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.RenameFolderHS;
            this.zmieńNazwęToolStripMenuItem.Name = "zmieńNazwęToolStripMenuItem";
            resources.ApplyResources(this.zmieńNazwęToolStripMenuItem, "zmieńNazwęToolStripMenuItem");
            this.zmieńNazwęToolStripMenuItem.Click += new System.EventHandler(this.zmieńNazwęToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // kopiujDoSchowkaToolStripMenuItem
            // 
            this.kopiujDoSchowkaToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.CopyHS;
            this.kopiujDoSchowkaToolStripMenuItem.Name = "kopiujDoSchowkaToolStripMenuItem";
            resources.ApplyResources(this.kopiujDoSchowkaToolStripMenuItem, "kopiujDoSchowkaToolStripMenuItem");
            this.kopiujDoSchowkaToolStripMenuItem.Click += new System.EventHandler(this.kopiujDoSchowkaToolStripMenuItem_Click);
            // 
            // właściwościToolStripMenuItem
            // 
            this.właściwościToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.Properties;
            this.właściwościToolStripMenuItem.Name = "właściwościToolStripMenuItem";
            resources.ApplyResources(this.właściwościToolStripMenuItem, "właściwościToolStripMenuItem");
            this.właściwościToolStripMenuItem.Click += new System.EventHandler(this.właściwościToolStripMenuItem_Click);
            // 
            // FileListView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FileListView";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.searchSubsection.ResumeLayout(false);
            this.listViewContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_new;
        private System.Windows.Forms.ToolStripButton toolStripButton_del;
        private System.Windows.Forms.ToolStripButton toolStripButton_ren;
        private System.Windows.Forms.ToolStripButton toolStripButton_ref;
        private System.Windows.Forms.GroupBox searchSubsection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_save;
        private System.Windows.Forms.ContextMenuStrip listViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmieńNazwęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem właściwościToolStripMenuItem;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn modifiedColumn;
        private BrightIdeasSoftware.OLVColumn createdColumn;
        private BrightIdeasSoftware.OLVColumn commentColumn;
        private BrightIdeasSoftware.OLVColumn groupColumn;
        private System.Windows.Forms.ToolStripButton propertiesToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox searchInsideFilesCheckBox;
        private System.Windows.Forms.ComboBox groupFilterComboBox;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem duplikujToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem kopiujDoSchowkaToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private Klocman.Controls.SearchBox searchBox1;
    }
}
