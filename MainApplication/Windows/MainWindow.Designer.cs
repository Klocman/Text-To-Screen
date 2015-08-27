using TextToScreen.CustomControls;
using TextToScreen.SpecialClasses;

namespace TextToScreen.Windows
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.fileListView = new TextToScreen.CustomControls.FileListView();
            this.fileEditor = new TextToScreen.CustomControls.FileEditor();
            this.previewScreens = new TextToScreen.CustomControls.PreviewScreens();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noweArchiwumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzArchiwumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzFolderArchiwumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszJakoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijArchiwumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eksportujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ostatnioOtwarteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaElementowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowyplikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmieńNazwęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńWybranePlikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplikujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.szukajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaznaczWszystkiePlikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.odświeżListęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.właściwościWybranychPiosenekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaTekstuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cofnijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.wytnijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wklejToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kopiujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.dodajZwrotkęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaznaczWszystkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.zapiszZmianyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyślijDoOknaDocelowegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyczyśćOknoDoceloweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otworzPomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.homepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coNowegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.oProgramieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDialog = new System.Windows.Forms.OpenFileDialog();
            this.openArchiveFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveArchiveDialog = new System.Windows.Forms.SaveFileDialog();
            this.globalHotkeys = new Klocman.Subsystems.GlobalHotkeys();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.previewScreens);
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.fileListView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.fileEditor);
            this.splitContainer3.TabStop = false;
            // 
            // fileListView
            // 
            this.fileListView.AllowDrop = true;
            resources.ApplyResources(this.fileListView, "fileListView");
            this.fileListView.Name = "fileListView";
            this.fileListView.SaveButtonEnabled = true;
            this.fileListView.StopRefreshingList = false;
            this.fileListView.ButtonClickDelete += new System.Action<TextToScreen.CustomControls.FileListView>(this.fileListView_ButtonClick_Delete);
            this.fileListView.ButtonClickNew += new System.Action<TextToScreen.CustomControls.FileListView>(this.fileListView_ButtonClick_New);
            this.fileListView.ButtonClickRefresh += new System.Action<TextToScreen.CustomControls.FileListView>(this.fileListView_ButtonClick_Refresh);
            this.fileListView.ButtonClickSave += new System.Action<TextToScreen.CustomControls.FileListView>(this.fileListView_ButtonClick_Save);
            this.fileListView.FileOpened += new System.Action<TextToScreen.CustomControls.FileListView, TextToScreen.SpecialClasses.SongFileEntry>(this.fileListView_FileOpened);
            this.fileListView.EnabledChanged += new System.EventHandler(this.fileListView_EnabledChanged);
            this.fileListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileListView_DragDrop);
            this.fileListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileListView_DragEnter);
            // 
            // fileEditor
            // 
            resources.ApplyResources(this.fileEditor, "fileEditor");
            this.fileEditor.Name = "fileEditor";
            this.fileEditor.SelectedAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.fileEditor.SelectedFontFamily = null;
            this.fileEditor.SelectedFontSize = 1;
            this.fileEditor.SelectedFontStyle = System.Drawing.FontStyle.Regular;
            this.fileEditor.FileContentsChanged += new System.Action<TextToScreen.CustomControls.FileEditor, TextToScreen.SpecialClasses.SongFileEntry>(this.fileEditor_LoadedFileChanged);
            this.fileEditor.FileSaved += new System.Action<TextToScreen.CustomControls.FileEditor, TextToScreen.SpecialClasses.SongFileEntry>(this.fileEditor_FileSaved);
            this.fileEditor.LoadedFileChanged += new System.Action<TextToScreen.CustomControls.FileEditor, TextToScreen.SpecialClasses.SongFileEntry>(this.fileEditor_LoadedFileChanged);
            this.fileEditor.SelectedFontChanged += new System.Action<TextToScreen.CustomControls.FileEditor>(this.fileEditor_SelectedFontChanged);
            this.fileEditor.SelectedStringAccepted += new System.Action<TextToScreen.CustomControls.FileEditor, string>(this.fileEditor_SelectedStringAccepted);
            this.fileEditor.SelectedStringChanged += new System.Action<TextToScreen.CustomControls.FileEditor, string>(this.fileEditor_SelectedStringChanged);
            this.fileEditor.SelectedStringCleared += new System.Action<TextToScreen.CustomControls.FileEditor>(this.fileEditor_SelectedStringCleared);
            this.fileEditor.EnabledChanged += new System.EventHandler(this.fileEditor_EnabledChanged);
            // 
            // previewScreens
            // 
            this.previewScreens.ButtonsEnabled = true;
            resources.ApplyResources(this.previewScreens, "previewScreens");
            this.previewScreens.Name = "previewScreens";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.edycjaElementowToolStripMenuItem,
            this.edycjaTekstuToolStripMenuItem,
            this.ustawieniaToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noweArchiwumToolStripMenuItem,
            this.otwórzArchiwumToolStripMenuItem,
            this.otwórzFolderArchiwumToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.zapiszJakoToolStripMenuItem,
            this.zamknijArchiwumToolStripMenuItem,
            this.toolStripSeparator1,
            this.eksportujToolStripMenuItem,
            this.importujToolStripMenuItem,
            this.toolStripSeparator2,
            this.ostatnioOtwarteToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            resources.ApplyResources(this.plikToolStripMenuItem, "plikToolStripMenuItem");
            this.plikToolStripMenuItem.DropDownOpening += new System.EventHandler(this.plikToolStripMenuItem_DropDownOpening);
            // 
            // noweArchiwumToolStripMenuItem
            // 
            this.noweArchiwumToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.NewFolderHS;
            this.noweArchiwumToolStripMenuItem.Name = "noweArchiwumToolStripMenuItem";
            resources.ApplyResources(this.noweArchiwumToolStripMenuItem, "noweArchiwumToolStripMenuItem");
            this.noweArchiwumToolStripMenuItem.Click += new System.EventHandler(this.noweArchiwumToolStripMenuItem_Click);
            // 
            // otwórzArchiwumToolStripMenuItem
            // 
            this.otwórzArchiwumToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.openfolderHS;
            this.otwórzArchiwumToolStripMenuItem.Name = "otwórzArchiwumToolStripMenuItem";
            resources.ApplyResources(this.otwórzArchiwumToolStripMenuItem, "otwórzArchiwumToolStripMenuItem");
            this.otwórzArchiwumToolStripMenuItem.Click += new System.EventHandler(this.otwórzArchiwumToolStripMenuItem_Click);
            // 
            // otwórzFolderArchiwumToolStripMenuItem
            // 
            this.otwórzFolderArchiwumToolStripMenuItem.Name = "otwórzFolderArchiwumToolStripMenuItem";
            resources.ApplyResources(this.otwórzFolderArchiwumToolStripMenuItem, "otwórzFolderArchiwumToolStripMenuItem");
            this.otwórzFolderArchiwumToolStripMenuItem.Click += new System.EventHandler(this.otwórzFolderArchiwumToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.SaveAllHS;
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            resources.ApplyResources(this.zapiszToolStripMenuItem, "zapiszToolStripMenuItem");
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // zapiszJakoToolStripMenuItem
            // 
            this.zapiszJakoToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.SaveAllHS;
            this.zapiszJakoToolStripMenuItem.Name = "zapiszJakoToolStripMenuItem";
            resources.ApplyResources(this.zapiszJakoToolStripMenuItem, "zapiszJakoToolStripMenuItem");
            this.zapiszJakoToolStripMenuItem.Click += new System.EventHandler(this.zapiszJakoToolStripMenuItem_Click);
            // 
            // zamknijArchiwumToolStripMenuItem
            // 
            this.zamknijArchiwumToolStripMenuItem.Name = "zamknijArchiwumToolStripMenuItem";
            resources.ApplyResources(this.zamknijArchiwumToolStripMenuItem, "zamknijArchiwumToolStripMenuItem");
            this.zamknijArchiwumToolStripMenuItem.Click += new System.EventHandler(this.zamknijArchiwumToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // eksportujToolStripMenuItem
            // 
            this.eksportujToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.DoubleRightArrowHS;
            this.eksportujToolStripMenuItem.Name = "eksportujToolStripMenuItem";
            resources.ApplyResources(this.eksportujToolStripMenuItem, "eksportujToolStripMenuItem");
            this.eksportujToolStripMenuItem.Click += new System.EventHandler(this.eksportujToolStripMenuItem_Click);
            // 
            // importujToolStripMenuItem
            // 
            this.importujToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.DoubleLeftArrowHS;
            this.importujToolStripMenuItem.Name = "importujToolStripMenuItem";
            resources.ApplyResources(this.importujToolStripMenuItem, "importujToolStripMenuItem");
            this.importujToolStripMenuItem.Click += new System.EventHandler(this.importujToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // ostatnioOtwarteToolStripMenuItem
            // 
            resources.ApplyResources(this.ostatnioOtwarteToolStripMenuItem, "ostatnioOtwarteToolStripMenuItem");
            this.ostatnioOtwarteToolStripMenuItem.Name = "ostatnioOtwarteToolStripMenuItem";
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            resources.ApplyResources(this.zamknijToolStripMenuItem, "zamknijToolStripMenuItem");
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // edycjaElementowToolStripMenuItem
            // 
            this.edycjaElementowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowyplikToolStripMenuItem,
            this.zmieńNazwęToolStripMenuItem,
            this.usuńWybranePlikiToolStripMenuItem,
            this.duplikujToolStripMenuItem,
            this.toolStripSeparator6,
            this.szukajToolStripMenuItem,
            this.zaznaczWszystkiePlikiToolStripMenuItem,
            this.toolStripSeparator7,
            this.odświeżListęToolStripMenuItem,
            this.właściwościWybranychPiosenekToolStripMenuItem});
            this.edycjaElementowToolStripMenuItem.Name = "edycjaElementowToolStripMenuItem";
            resources.ApplyResources(this.edycjaElementowToolStripMenuItem, "edycjaElementowToolStripMenuItem");
            this.edycjaElementowToolStripMenuItem.DropDownOpening += new System.EventHandler(this.edycjaElementowToolStripMenuItem_DropDownOpening);
            // 
            // nowyplikToolStripMenuItem
            // 
            this.nowyplikToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.NewDocumentHS;
            this.nowyplikToolStripMenuItem.Name = "nowyplikToolStripMenuItem";
            resources.ApplyResources(this.nowyplikToolStripMenuItem, "nowyplikToolStripMenuItem");
            this.nowyplikToolStripMenuItem.Click += new System.EventHandler(this.nowyplikToolStripMenuItem_Click);
            // 
            // zmieńNazwęToolStripMenuItem
            // 
            this.zmieńNazwęToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.RenameFolderHS;
            this.zmieńNazwęToolStripMenuItem.Name = "zmieńNazwęToolStripMenuItem";
            resources.ApplyResources(this.zmieńNazwęToolStripMenuItem, "zmieńNazwęToolStripMenuItem");
            this.zmieńNazwęToolStripMenuItem.Click += new System.EventHandler(this.zmieńNazwęToolStripMenuItem_Click);
            // 
            // usuńWybranePlikiToolStripMenuItem
            // 
            this.usuńWybranePlikiToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.DeleteHS;
            this.usuńWybranePlikiToolStripMenuItem.Name = "usuńWybranePlikiToolStripMenuItem";
            resources.ApplyResources(this.usuńWybranePlikiToolStripMenuItem, "usuńWybranePlikiToolStripMenuItem");
            this.usuńWybranePlikiToolStripMenuItem.Click += new System.EventHandler(this.usuńWybranePlikiToolStripMenuItem_Click);
            // 
            // duplikujToolStripMenuItem
            // 
            this.duplikujToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.CopyHS;
            this.duplikujToolStripMenuItem.Name = "duplikujToolStripMenuItem";
            resources.ApplyResources(this.duplikujToolStripMenuItem, "duplikujToolStripMenuItem");
            this.duplikujToolStripMenuItem.Click += new System.EventHandler(this.duplikujToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // szukajToolStripMenuItem
            // 
            this.szukajToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.FindHS;
            this.szukajToolStripMenuItem.Name = "szukajToolStripMenuItem";
            resources.ApplyResources(this.szukajToolStripMenuItem, "szukajToolStripMenuItem");
            this.szukajToolStripMenuItem.Click += new System.EventHandler(this.szukajToolStripMenuItem_Click);
            // 
            // zaznaczWszystkiePlikiToolStripMenuItem
            // 
            this.zaznaczWszystkiePlikiToolStripMenuItem.Name = "zaznaczWszystkiePlikiToolStripMenuItem";
            resources.ApplyResources(this.zaznaczWszystkiePlikiToolStripMenuItem, "zaznaczWszystkiePlikiToolStripMenuItem");
            this.zaznaczWszystkiePlikiToolStripMenuItem.Click += new System.EventHandler(this.zaznaczWszystkiePlikiToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // odświeżListęToolStripMenuItem
            // 
            this.odświeżListęToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.RepeatHS;
            this.odświeżListęToolStripMenuItem.Name = "odświeżListęToolStripMenuItem";
            resources.ApplyResources(this.odświeżListęToolStripMenuItem, "odświeżListęToolStripMenuItem");
            this.odświeżListęToolStripMenuItem.Click += new System.EventHandler(this.odświeżListęToolStripMenuItem_Click);
            // 
            // właściwościWybranychPiosenekToolStripMenuItem
            // 
            this.właściwościWybranychPiosenekToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.Properties;
            this.właściwościWybranychPiosenekToolStripMenuItem.Name = "właściwościWybranychPiosenekToolStripMenuItem";
            resources.ApplyResources(this.właściwościWybranychPiosenekToolStripMenuItem, "właściwościWybranychPiosenekToolStripMenuItem");
            this.właściwościWybranychPiosenekToolStripMenuItem.Click += new System.EventHandler(this.właściwościWybranychPiosenekToolStripMenuItem_Click);
            // 
            // edycjaTekstuToolStripMenuItem
            // 
            this.edycjaTekstuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cofnijToolStripMenuItem,
            this.toolStripSeparator4,
            this.wytnijToolStripMenuItem,
            this.wklejToolStripMenuItem,
            this.kopiujToolStripMenuItem,
            this.usuńToolStripMenuItem,
            this.toolStripSeparator5,
            this.dodajZwrotkęToolStripMenuItem,
            this.zaznaczWszystkoToolStripMenuItem,
            this.toolStripSeparator8,
            this.zapiszZmianyToolStripMenuItem,
            this.zamknijElementToolStripMenuItem});
            this.edycjaTekstuToolStripMenuItem.Name = "edycjaTekstuToolStripMenuItem";
            resources.ApplyResources(this.edycjaTekstuToolStripMenuItem, "edycjaTekstuToolStripMenuItem");
            this.edycjaTekstuToolStripMenuItem.DropDownOpening += new System.EventHandler(this.edycjaTekstuToolStripMenuItem_DropDownOpening);
            // 
            // cofnijToolStripMenuItem
            // 
            this.cofnijToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.Edit_UndoHS;
            this.cofnijToolStripMenuItem.Name = "cofnijToolStripMenuItem";
            resources.ApplyResources(this.cofnijToolStripMenuItem, "cofnijToolStripMenuItem");
            this.cofnijToolStripMenuItem.Click += new System.EventHandler(this.cofnijToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // wytnijToolStripMenuItem
            // 
            this.wytnijToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.CutHS;
            this.wytnijToolStripMenuItem.Name = "wytnijToolStripMenuItem";
            resources.ApplyResources(this.wytnijToolStripMenuItem, "wytnijToolStripMenuItem");
            this.wytnijToolStripMenuItem.Click += new System.EventHandler(this.wytnijToolStripMenuItem_Click);
            // 
            // wklejToolStripMenuItem
            // 
            this.wklejToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.PasteHS;
            this.wklejToolStripMenuItem.Name = "wklejToolStripMenuItem";
            resources.ApplyResources(this.wklejToolStripMenuItem, "wklejToolStripMenuItem");
            this.wklejToolStripMenuItem.Click += new System.EventHandler(this.wklejToolStripMenuItem_Click);
            // 
            // kopiujToolStripMenuItem
            // 
            this.kopiujToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.CopyHS;
            this.kopiujToolStripMenuItem.Name = "kopiujToolStripMenuItem";
            resources.ApplyResources(this.kopiujToolStripMenuItem, "kopiujToolStripMenuItem");
            this.kopiujToolStripMenuItem.Click += new System.EventHandler(this.kopiujToolStripMenuItem_Click);
            // 
            // usuńToolStripMenuItem
            // 
            this.usuńToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.DeleteHS;
            this.usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            resources.ApplyResources(this.usuńToolStripMenuItem, "usuńToolStripMenuItem");
            this.usuńToolStripMenuItem.Click += new System.EventHandler(this.usuńToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // dodajZwrotkęToolStripMenuItem
            // 
            this.dodajZwrotkęToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.IndentHS;
            this.dodajZwrotkęToolStripMenuItem.Name = "dodajZwrotkęToolStripMenuItem";
            resources.ApplyResources(this.dodajZwrotkęToolStripMenuItem, "dodajZwrotkęToolStripMenuItem");
            this.dodajZwrotkęToolStripMenuItem.Click += new System.EventHandler(this.dodajZwrotkęToolStripMenuItem_Click);
            // 
            // zaznaczWszystkoToolStripMenuItem
            // 
            this.zaznaczWszystkoToolStripMenuItem.Name = "zaznaczWszystkoToolStripMenuItem";
            resources.ApplyResources(this.zaznaczWszystkoToolStripMenuItem, "zaznaczWszystkoToolStripMenuItem");
            this.zaznaczWszystkoToolStripMenuItem.Click += new System.EventHandler(this.zaznaczWszystkoToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // zapiszZmianyToolStripMenuItem
            // 
            this.zapiszZmianyToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.saveHS;
            this.zapiszZmianyToolStripMenuItem.Name = "zapiszZmianyToolStripMenuItem";
            resources.ApplyResources(this.zapiszZmianyToolStripMenuItem, "zapiszZmianyToolStripMenuItem");
            this.zapiszZmianyToolStripMenuItem.Click += new System.EventHandler(this.zapiszZmianyToolStripMenuItem_Click);
            // 
            // zamknijElementToolStripMenuItem
            // 
            this.zamknijElementToolStripMenuItem.Name = "zamknijElementToolStripMenuItem";
            resources.ApplyResources(this.zamknijElementToolStripMenuItem, "zamknijElementToolStripMenuItem");
            this.zamknijElementToolStripMenuItem.Click += new System.EventHandler(this.zamknijElementToolStripMenuItem_Click);
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyślijDoOknaDocelowegoToolStripMenuItem,
            this.wyczyśćOknoDoceloweToolStripMenuItem,
            this.toolStripSeparator9,
            this.alwaysOnTopToolStripMenuItem,
            this.fullScreenToolStripMenuItem,
            this.toolStripSeparator3,
            this.preferencjeToolStripMenuItem});
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            resources.ApplyResources(this.ustawieniaToolStripMenuItem, "ustawieniaToolStripMenuItem");
            this.ustawieniaToolStripMenuItem.DropDownOpening += new System.EventHandler(this.ustawieniaToolStripMenuItem_DropDownOpening);
            // 
            // wyślijDoOknaDocelowegoToolStripMenuItem
            // 
            this.wyślijDoOknaDocelowegoToolStripMenuItem.Name = "wyślijDoOknaDocelowegoToolStripMenuItem";
            resources.ApplyResources(this.wyślijDoOknaDocelowegoToolStripMenuItem, "wyślijDoOknaDocelowegoToolStripMenuItem");
            this.wyślijDoOknaDocelowegoToolStripMenuItem.Click += new System.EventHandler(this.wyślijDoOknaDocelowegoToolStripMenuItem_Click);
            // 
            // wyczyśćOknoDoceloweToolStripMenuItem
            // 
            this.wyczyśćOknoDoceloweToolStripMenuItem.Name = "wyczyśćOknoDoceloweToolStripMenuItem";
            resources.ApplyResources(this.wyczyśćOknoDoceloweToolStripMenuItem, "wyczyśćOknoDoceloweToolStripMenuItem");
            this.wyczyśćOknoDoceloweToolStripMenuItem.Click += new System.EventHandler(this.wyczyśćOknoDoceloweToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Checked = true;
            this.alwaysOnTopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            resources.ApplyResources(this.alwaysOnTopToolStripMenuItem, "alwaysOnTopToolStripMenuItem");
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Checked = true;
            this.fullScreenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            resources.ApplyResources(this.fullScreenToolStripMenuItem, "fullScreenToolStripMenuItem");
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // preferencjeToolStripMenuItem
            // 
            this.preferencjeToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.LegendHS;
            this.preferencjeToolStripMenuItem.Name = "preferencjeToolStripMenuItem";
            resources.ApplyResources(this.preferencjeToolStripMenuItem, "preferencjeToolStripMenuItem");
            this.preferencjeToolStripMenuItem.Click += new System.EventHandler(this.preferencjeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otworzPomocToolStripMenuItem,
            this.toolStripSeparator11,
            this.homepageToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.coNowegoToolStripMenuItem,
            this.toolStripSeparator10,
            this.oProgramieToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // otworzPomocToolStripMenuItem
            // 
            this.otworzPomocToolStripMenuItem.Image = global::TextToScreen.Properties.Resources.Help;
            this.otworzPomocToolStripMenuItem.Name = "otworzPomocToolStripMenuItem";
            resources.ApplyResources(this.otworzPomocToolStripMenuItem, "otworzPomocToolStripMenuItem");
            this.otworzPomocToolStripMenuItem.Click += new System.EventHandler(this.otworzPomocToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // homepageToolStripMenuItem
            // 
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            resources.ApplyResources(this.homepageToolStripMenuItem, "homepageToolStripMenuItem");
            this.homepageToolStripMenuItem.Click += new System.EventHandler(this.homepageToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            resources.ApplyResources(this.donateToolStripMenuItem, "donateToolStripMenuItem");
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // coNowegoToolStripMenuItem
            // 
            this.coNowegoToolStripMenuItem.Name = "coNowegoToolStripMenuItem";
            resources.ApplyResources(this.coNowegoToolStripMenuItem, "coNowegoToolStripMenuItem");
            this.coNowegoToolStripMenuItem.Click += new System.EventHandler(this.coNowegoToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // oProgramieToolStripMenuItem
            // 
            this.oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            resources.ApplyResources(this.oProgramieToolStripMenuItem, "oProgramieToolStripMenuItem");
            this.oProgramieToolStripMenuItem.Click += new System.EventHandler(this.oProgramieToolStripMenuItem_Click);
            // 
            // importDialog
            // 
            resources.ApplyResources(this.importDialog, "importDialog");
            this.importDialog.Multiselect = true;
            this.importDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.importDialog_FileOk);
            // 
            // openArchiveFileDialog
            // 
            this.openArchiveFileDialog.DefaultExt = "zip";
            resources.ApplyResources(this.openArchiveFileDialog, "openArchiveFileDialog");
            this.openArchiveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openArchiveFileDialog_FileOk);
            // 
            // saveArchiveDialog
            // 
            this.saveArchiveDialog.DefaultExt = "zip";
            resources.ApplyResources(this.saveArchiveDialog, "saveArchiveDialog");
            this.saveArchiveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveArchiveDialog_FileOk);
            // 
            // globalHotkeys
            // 
            this.globalHotkeys.ContainerControl = this;
            this.globalHotkeys.StopWhenFormIsDisabled = false;
            this.globalHotkeys.SuppressKeyPresses = true;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_PositionDataChanged);
            this.LocationChanged += new System.EventHandler(this.MainWindow_PositionDataChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripMenuItem importujToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog importDialog;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otworzPomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eksportujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzArchiwumToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openArchiveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem coNowegoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noweArchiwumToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveArchiveDialog;
        private FileListView fileListView;
        private FileEditor fileEditor;
        private PreviewScreens previewScreens;
        private System.Windows.Forms.ToolStripMenuItem otwórzFolderArchiwumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszJakoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem preferencjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ostatnioOtwarteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edycjaElementowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowyplikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmieńNazwęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńWybranePlikiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplikujToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem zaznaczWszystkiePlikiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edycjaTekstuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cofnijToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem wytnijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wklejToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kopiujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem zaznaczWszystkoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem odświeżListęToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem zapiszZmianyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijArchiwumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajZwrotkęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem właściwościWybranychPiosenekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szukajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyślijDoOknaDocelowegoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyczyśćOknoDoceloweToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private Klocman.Subsystems.GlobalHotkeys globalHotkeys;
    }
}

