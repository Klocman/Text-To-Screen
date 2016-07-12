using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Klocman.Extensions;
using Klocman.Forms.Tools;
using Klocman.Subsystems;
using Klocman.Tools;
using Microsoft.Win32;
using TextToScreen.Controls;
using TextToScreen.ImportExport;
using TextToScreen.Misc;
using TextToScreen.Properties;
using TextToScreen.SongFile;

namespace TextToScreen.Windows
{
    public sealed partial class MainWindow : Form
    {
        private readonly FontGrabber _fontCollections;
        private SongFileArchive _openedSongArchive;
        private SecondaryWindow _remoteDisplayWindow;
        private bool _skipSaveOnExit;

        public MainWindow()
        {
            InitializeComponent();

            SuspendLayout();
            // Needs to be called after the generated code because of a bug with generated code ordering
            // (minsize gets placed before splitter distance is set, resulting in exception)
            splitContainer1.Panel1MinSize = 300;
            splitContainer1.Panel2MinSize = 100;
            splitContainer3.Panel1MinSize = 150;
            splitContainer3.Panel2MinSize = 150;

            Ustawienia.SelectedSettingSet = Ustawienia.MainSettingSet;
            PremadeDialogs.DefaultOwner = this;

            _fontCollections = new FontGrabber();
            OpenedSongArchive = null; // Fires the property setter for initial setup

            SetupRemoteDisplayWindow();

            fileEditor.SetupToolstrip(_fontCollections.ValidFontFamilies.ToArray());

            previewScreens.ButtonClickSend += x => SendSelectedToOutput();
            previewScreens.ButtonClickClear += x => ClearOutput();

            ReadStartupSettings();
            ReadSettings();

            SetupHotkeys();

            switch (Ustawienia.SelectedSettingSet.GeneralStartAction)
            {
                case StartupAction.OpenRecent:
                    if (Ustawienia.SelectedSettingSet.AutoRecentItems.Count > 0)
                        OpenArchive(
                            Ustawienia.SelectedSettingSet.AutoRecentItems[
                                Ustawienia.SelectedSettingSet.AutoRecentItems.Count - 1]);
                    break;

                case StartupAction.OpenSelected:
                    if (File.Exists(Ustawienia.SelectedSettingSet.GeneralStartPath))
                        OpenArchive(Ustawienia.SelectedSettingSet.GeneralStartPath);
                    break;
            }
            ResumeLayout();

            SystemEvents.SessionEnding += (x, y) =>
            {
                if (!AskAndSaveIfNeeded())
                    y.Cancel = true;
            };
        }

        private bool IsAlwaysOnTop
        {
            get { return TopMost; }
            set
            {
                TopMost = value;
                Ustawienia.SelectedSettingSet.OknoGlowneTop = value;
            }
        }

        private bool IsFullScreen
        {
            get { return FormBorderStyle == FormBorderStyle.None; }
            set
            {
                if (value) //Going fullscreen now
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    //WindowState = FormWindowState.Normal;
                }
                Ustawienia.SelectedSettingSet.OknoGlowneFull = value;
            }
        }

        private SongFileArchive OpenedSongArchive
        {
            get { return _openedSongArchive; }
            set
            {
                _openedSongArchive = value;
                if (value == null)
                {
                    fileListView.ClearAllItems(true);
                    fileListView.Enabled = false;
                    fileEditor.UnloadFile(false);
                }
                else
                    fileListView.Enabled = true;

                UpdateMainWindowTitlebar();
            }
        }

        /// <summary>
        ///     Add file to recent items if it is valid
        /// </summary>
        private void AddRecentItem(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                if (Ustawienia.SelectedSettingSet.AutoRecentItems.Contains(path))
                    Ustawienia.SelectedSettingSet.AutoRecentItems.Remove(path);
                Ustawienia.SelectedSettingSet.AutoRecentItems.Add(path);
            }

            TrimRecentItems();
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsAlwaysOnTop = !IsAlwaysOnTop;
        }

        /// <summary>
        ///     Returns false if user cancels the operation
        /// </summary>
        private bool AskAndSaveIfNeeded()
        {
            if (OpenedSongArchive != null && (fileEditor.FileWasChanged || !OpenedSongArchive.AllSavedToDisk))
            {
                if (!fileEditor.AskAndSaveIfNeeded())
                    return false;

                switch (MessageBoxes.SaveChangesToOpenedArchive(this))
                {
                    case DialogResult.Yes:
                        SaveArchive();
                        break;

                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        private bool CheckDraggedItems(out IEnumerable<string> filenames, DragEventArgs e)
        {
            var filenamelist = new List<string>();

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                var data = e.Data.GetData("FileName") as Array;
                if (data != null)
                {
                    filenamelist.AddRange(data.OfType<string>().Where(FileImporter.CanImport));
                }
            }
            filenames = filenamelist;
            return filenamelist.Count > 0;
        }

        private void ClearOutput()
        {
            _remoteDisplayWindow.ClearPreviewDisplay();
            _remoteDisplayWindow.PushToRemoteDisplay();
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.Text_Undo();
        }

        private void coNowegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"http://klocmansoftware.weebly.com/texttoscreen.html");
            }
            catch (Exception ex)
            {
                PremadeDialogs.GenericError(ex);
            }
        }

        private void CreateNewArchive()
        {
            fileEditor.UnloadFile();
            SetupNewArchive(string.Empty);
            fileListView.PopulateItems(OpenedSongArchive.LoadedFiles);
        }

        private void CreateNewFile()
        {
            if (OpenedSongArchive == null)
                return;

            var uniqueName = StringTools.GetUniqueName(Localisation.NewFileDefaultName,
                OpenedSongArchive.LoadedFiles.Names);
            var newFile = new SongFileEntry(uniqueName, string.Empty, string.Empty, string.Empty, DateTime.Now,
                DateTime.Now)
            {
                ParentCollection = OpenedSongArchive.LoadedFiles
            };

            if (ShowNameChangeDialog(newFile, true))
                OpenedSongArchive.LoadedFiles.Add(newFile);
            else
                newFile.Dispose();
        }

        private void dodajZwrotkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.Text_AddVerse();
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"http://klocmansoftware.weebly.com/about.html");
            }
            catch (Exception ex)
            {
                PremadeDialogs.GenericError(ex);
            }
        }

        private void duplikujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListView.DuplicateSelected();
        }

        private void edycjaElementowToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var enableArchiveManipulation = fileListView.FileListFocused;
            //nowyplikToolStripMenuItem.Enabled = enableArchiveManipulation;
            zmieńNazwęToolStripMenuItem.Enabled = enableArchiveManipulation;
            usuńWybranePlikiToolStripMenuItem.Enabled = enableArchiveManipulation;
            duplikujToolStripMenuItem.Enabled = enableArchiveManipulation;
            zaznaczWszystkiePlikiToolStripMenuItem.Enabled = enableArchiveManipulation;
        }

        private void edycjaTekstuToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var enableEditing = fileEditor.EditBoxFocused;
            cofnijToolStripMenuItem.Enabled = enableEditing;
            wytnijToolStripMenuItem.Enabled = enableEditing;
            wklejToolStripMenuItem.Enabled = enableEditing;
            kopiujToolStripMenuItem.Enabled = enableEditing;
            usuńToolStripMenuItem.Enabled = enableEditing;
            dodajZwrotkęToolStripMenuItem.Enabled = enableEditing;
            zaznaczWszystkoToolStripMenuItem.Enabled = enableEditing;

            zapiszZmianyToolStripMenuItem.Enabled = fileEditor.FileWasChanged;
        }

        private void eksportujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxes.ShowExportDialog(this, OpenedSongArchive);
        }

        private void fileEditor_EnabledChanged(object sender, EventArgs e)
        {
            edycjaTekstuToolStripMenuItem.Enabled = fileEditor.Enabled;
        }

        private void fileEditor_FileSaved(FileEditor arg1, SongFileEntry arg2)
        {
            fileListView.RefreshListElement(arg2);
            //fileListView.RepopulateItems();
        }

        private void fileEditor_LoadedFileChanged(FileEditor arg1, SongFileEntry arg2)
        {
            UpdateMainWindowTitlebar();
        }

        private void fileEditor_SelectedFontChanged(FileEditor obj)
        {
            fileEditor_SelectedStringChanged(obj, obj.SelectedString);
        }

        private void fileEditor_SelectedStringAccepted(FileEditor x, string y)
        {
            fileEditor_SelectedStringChanged(x, y);

            _remoteDisplayWindow.PushToRemoteDisplay();
        }

        private void fileEditor_SelectedStringChanged(FileEditor x, string y)
        {
            _remoteDisplayWindow.ShowPreviewText(y, x.GetSelectedFont(), x.SelectedAlignment);
        }

        private void fileEditor_SelectedStringCleared(FileEditor obj)
        {
            _remoteDisplayWindow.ClearPreviewDisplay();
            //previewScreens.PushToOutputDisplay();
        }

        private void fileListView_ButtonClick_Delete(FileListView obj)
        {
            RemoveSelectedFiles();
        }

        private void fileListView_ButtonClick_New(FileListView obj)
        {
            CreateNewFile();
        }

        private void fileListView_ButtonClick_Refresh(FileListView obj)
        {
            RefreshLoadedArchive();
        }

        private void fileListView_ButtonClick_Save(FileListView obj)
        {
            SaveArchive();
        }

        private void fileListView_DragDrop(object sender, DragEventArgs e)
        {
            IEnumerable<string> draggedFiles;
            if (CheckDraggedItems(out draggedFiles, e))
            {
                //Path.GetFullPath is used because filename given by DragEventArgs is in short format (it converts it to full path format)
                ImportFilesToOpenedArchive(draggedFiles.Select(Path.GetFullPath));
            }
        }

        private void fileListView_DragEnter(object sender, DragEventArgs e)
        {
            IEnumerable<string> draggedFiles;
            e.Effect = CheckDraggedItems(out draggedFiles, e) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void fileListView_EnabledChanged(object sender, EventArgs e)
        {
            edycjaElementowToolStripMenuItem.Enabled = fileListView.Enabled;
        }

        private void fileListView_FileOpened(FileListView arg1, SongFileEntry arg2)
        {
            fileEditor.LoadFile(arg2);
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFullScreen = !IsFullScreen;
        }

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"http://klocmansoftware.weebly.com/texttoscreen.html");
            }
            catch (Exception ex)
            {
                PremadeDialogs.GenericError(ex);
            }
        }

        private void importDialog_FileOk(object sender, CancelEventArgs e)
        {
            ImportFilesToOpenedArchive(importDialog.FileNames);
        }

        private void ImportFilesToOpenedArchive(IEnumerable<string> filenames)
        {
            if (OpenedSongArchive == null)
                return;

            var result = FileImporter.AutoImport(filenames);
            OpenedSongArchive.LoadedFiles.AddRangeSafe(result.Results);

            if (result.Errors.Any())
            {
                var sb = new StringBuilder();
                sb.AppendLine(Localisation.FileImportProblemsHeader);
                foreach (var group in result.Errors.GroupBy(el => el.Value))
                {
                    sb.AppendLine();
                    sb.Append("Błąd: ");
                    sb.AppendLine(group.Key);
                    foreach (var element in group)
                    {
                        sb.Append("->");
                        sb.AppendLine(element.Key);
                    }
                }

                MessageBox.Show(this, sb.ToString(), Localisation.FileImportProblemsTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void importujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importDialog.ShowDialog();
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.Text_Copy();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_skipSaveOnExit && !AskAndSaveIfNeeded())
            {
                e.Cancel = true;
                return;
            }
            SaveSettings();
            SaveStartupSettings();
        }

        private void MainWindow_PositionDataChanged(object sender, EventArgs e)
        {
            SaveMainWindowPosition();
        }

        private void noweArchiwumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewArchive();
        }

        private void nowyplikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFile();
        }

        private void odświeżListęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshLoadedArchive();
        }

        private void OnArchiveContentsChangedExternally(SongFileArchive source, FileSystemEventArgs args)
        {
            this.SafeInvoke(() =>
            {
                if (MessageBoxes.ArchiveContentsChangedExternally(this))
                    OpenedSongArchive.ReadAllFromDisk();
            });
        }

        private void OnArchiveNameChangedExternally(SongFileArchive source, RenamedEventArgs args)
        {
            this.SafeInvoke(() =>
            {
                if (MessageBoxes.ArchiveNameChangedExternally(this))
                {
                    OpenedSongArchive.FullName = args.FullPath;
                    UpdateMainWindowTitlebar();
                }
            });
        }

        /// <summary>
        ///     Fired on first application start (when settings are reset). Runs in same thread as main window.
        /// </summary>
        private void OnFirstStart()
        {
            if (MessageBoxes.FirstStartQuestion(this))
                MessageBoxes.HelpDefault(this);
            //TODO
            Ustawienia.SelectedSettingSet._FirstStartCompleted = true;
        }

        private void OpenArchive(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                MessageBoxes.ArchiveDoesNotExist(this, fullPath);
                return;
            }
            if (!SetupNewArchive(fullPath))
                return;

            OpenedSongArchive.ReadAllFromDisk(); // Will fire the archive reloaded event

            AddRecentItem(fullPath);
        }

        private void openArchiveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenArchive(openArchiveFileDialog.FileName);
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox {Owner = this};
            aboutBox.ShowDialog();
        }

        private void otworzPomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxes.HelpDefault(this);
        }

        private void otwórzArchiwumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOpenArchiveDialog();
        }

        private void otwórzFolderArchiwumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenedSongArchive != null && OpenedSongArchive.IsWrittenToDisk)
                Process.Start(OpenedSongArchive.Directory);
        }

        private void plikToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var isNotNull = OpenedSongArchive != null;
            otwórzFolderArchiwumToolStripMenuItem.Enabled = isNotNull && OpenedSongArchive.IsWrittenToDisk;

            zapiszToolStripMenuItem.Enabled = isNotNull;
            zapiszJakoToolStripMenuItem.Enabled = isNotNull;
            importujToolStripMenuItem.Enabled = isNotNull;
            eksportujToolStripMenuItem.Enabled = isNotNull;
            zamknijArchiwumToolStripMenuItem.Enabled = isNotNull;

            PopulateRecentItems();
        }

        private void PopulateRecentItems()
        {
            ostatnioOtwarteToolStripMenuItem.DropDownItems.Clear();

            var histEn = Ustawienia.SelectedSettingSet.GeneralHistoryEnabled &&
                         Ustawienia.SelectedSettingSet.AutoRecentItems.Count > 0;
            ostatnioOtwarteToolStripMenuItem.Enabled = histEn;
            if (histEn)
            {
                TrimRecentItems();
                for (var i = Ustawienia.SelectedSettingSet.AutoRecentItems.Count - 1; i >= 0; i--)
                {
                    var path = Ustawienia.SelectedSettingSet.AutoRecentItems[i];
                    var newChild = new ToolStripMenuItem {Text = path};
                    newChild.Click += RecentItem_Click;
                    ostatnioOtwarteToolStripMenuItem.DropDownItems.Add(newChild);
                }
            }
        }

        private void preferencjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxes.ShowSettingsDialog(this, Ustawienia.SelectedSettingSet, Ustawienia.Default);
            ReadSettings();
        }

        private void ReadSettings()
        {
            if (Ustawienia.SelectedSettingSet.AutoRecentItems == null)
                Ustawienia.SelectedSettingSet.AutoRecentItems = new StringCollection();

            IsFullScreen = Ustawienia.SelectedSettingSet.OknoGlowneFull;
            IsAlwaysOnTop = Ustawienia.SelectedSettingSet.OknoGlowneTop;

            if (_remoteDisplayWindow != null)
            {
                _remoteDisplayWindow.IsAlwaysOnTop = Ustawienia.SelectedSettingSet.OknoDoceloweTop;
                _remoteDisplayWindow.IsCursorHidden = Ustawienia.SelectedSettingSet.OknoDoceloweHideCursor;
                _remoteDisplayWindow.IsFullScreen = Ustawienia.SelectedSettingSet.OknoDoceloweFull;

                _remoteDisplayWindow.DisplayBackgroudColor = Ustawienia.SelectedSettingSet.OutputBackgroundColor;
                _remoteDisplayWindow.DisplayTextColor = Ustawienia.SelectedSettingSet.OutputTextColor;
            }

            if (OpenedSongArchive != null)
            {
                OpenedSongArchive.LockArchiveFile = !Ustawienia.SelectedSettingSet.GeneralInneDostepZewnetrznyDoArchiwum;
                OpenedSongArchive.MonitorExternalChanges =
                    Ustawienia.SelectedSettingSet.GeneralInneSprawdzajZewnetrzneZmiany;
            }

            UpdateMainWindowTitlebar();

            if (!Ustawienia.SelectedSettingSet._FirstStartCompleted)
                new Thread(() =>
                {
                    while(!Visible)
                        Thread.Sleep(200);
                    Invoke(new Action(OnFirstStart));
                }).Start();
        }

        private void ReadStartupSettings()
        {
            fileEditor.SelectedFontFamily = _fontCollections.GetFontFamily(Ustawienia.SelectedSettingSet.AutoCzcionka);
            fileEditor.SelectedFontSize = Ustawienia.SelectedSettingSet.AutoRozmiarTekstu;
            fileEditor.SelectedAlignment = Ustawienia.SelectedSettingSet.AutoWyrownanieTekstu;
            fileEditor.SelectedFontStyle = Ustawienia.SelectedSettingSet.AutoStylCzcionki;

            if (Ustawienia.SelectedSettingSet.AutoOknoGlownePozycja == Point.Empty
                && Ustawienia.SelectedSettingSet.AutoOknoDocelowePozycja == Point.Empty)
            {
                StartPosition = FormStartPosition.WindowsDefaultLocation;
                _remoteDisplayWindow.StartPosition = FormStartPosition.WindowsDefaultLocation;
                return;
            }

            Location = Ustawienia.SelectedSettingSet.AutoOknoGlownePozycja;
            Size = Ustawienia.SelectedSettingSet.AutoOknoGlowneRozmiar;
            WindowState = Ustawienia.SelectedSettingSet.AutoOknoGlowneMaximized
                ? FormWindowState.Maximized
                : FormWindowState.Normal;

            _remoteDisplayWindow.Location = Ustawienia.SelectedSettingSet.AutoOknoDocelowePozycja;
            _remoteDisplayWindow.Size = Ustawienia.SelectedSettingSet.AutoOknoDoceloweRozmiar;
            _remoteDisplayWindow.WindowState = Ustawienia.SelectedSettingSet.AutoOknoDoceloweMaximized
                ? FormWindowState.Maximized
                : FormWindowState.Normal;
        }

        private void RecentItem_Click(object sender, EventArgs e)
        {
            var target = ((ToolStripMenuItem) sender).Text;
            OpenArchive(target);
        }

        private void RefreshLoadedArchive()
        {
            if (OpenedSongArchive == null || !AskAndSaveIfNeeded())
                return;
            OpenedSongArchive.ReadAllFromDisk();
        }

        private void RemoveSelectedFiles()
        {
            if (fileListView.SelectedFiles.Any() && MessageBoxes.RemoveSelectedFiles(this))
            {
                fileListView.StopRefreshingList = true;
                foreach (var item in fileListView.SelectedFiles)
                {
                    OpenedSongArchive.LoadedFiles.Remove(item);
                }
                //openedSongArchive.LoadedFiles.CollectionWasModified = true;
                fileListView.StopRefreshingList = false;
            }
        }

        private void SaveArchive()
        {
            if (OpenedSongArchive == null)
                return;

            if (!OpenedSongArchive.IsWrittenToDisk)
                SaveArchiveAs();
            else
                OpenedSongArchive.WriteAllToDisk();
        }

        private void SaveArchiveAs()
        {
            if (OpenedSongArchive == null)
                return;

            if (OpenedSongArchive.IsWrittenToDisk)
                saveArchiveDialog.InitialDirectory = OpenedSongArchive.Directory;

            saveArchiveDialog.ShowDialog();
        }

        private void saveArchiveDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenedSongArchive.FullName = saveArchiveDialog.FileName;
            OpenedSongArchive.WriteAllToDisk();

            UpdateMainWindowTitlebar();
        }

        private void SaveMainWindowPosition()
        {
            if (Ustawienia.SelectedSettingSet != null && !IsFullScreen)
            {
                var glMax = WindowState == FormWindowState.Maximized;
                Ustawienia.SelectedSettingSet.AutoOknoGlowneMaximized = glMax;
                if (!glMax)
                {
                    Ustawienia.SelectedSettingSet.AutoOknoGlownePozycja = Location;
                    Ustawienia.SelectedSettingSet.AutoOknoGlowneRozmiar = Size;
                }
            }
        }

        private void SaveSecondaryWindowPosition()
        {
            if (_remoteDisplayWindow != null && Ustawienia.SelectedSettingSet != null &&
                !_remoteDisplayWindow.IsFullScreen)
            {
                var docMax = _remoteDisplayWindow.WindowState == FormWindowState.Maximized;
                Ustawienia.SelectedSettingSet.AutoOknoDoceloweMaximized = docMax;
                if (!docMax)
                {
                    Ustawienia.SelectedSettingSet.AutoOknoDocelowePozycja = _remoteDisplayWindow.Location;
                    Ustawienia.SelectedSettingSet.AutoOknoDoceloweRozmiar = _remoteDisplayWindow.Size;
                }
            }
        }

        private void SaveSettings()
        {
            Ustawienia.SelectedSettingSet.Save();
        }

        private void SaveStartupSettings()
        {
            // Editor settings
            var f = fileEditor.SelectedFontFamily;
            if (f != null)
                Ustawienia.SelectedSettingSet.AutoCzcionka = f.Name;
            Ustawienia.SelectedSettingSet.AutoRozmiarTekstu = fileEditor.SelectedFontSize;
            Ustawienia.SelectedSettingSet.AutoWyrownanieTekstu = fileEditor.SelectedAlignment;
            Ustawienia.SelectedSettingSet.AutoStylCzcionki = fileEditor.SelectedFontStyle;

            if (!Ustawienia.SelectedSettingSet.GeneralHistoryEnabled)
                Ustawienia.SelectedSettingSet.AutoRecentItems.Clear();

            // Window positions and stuff
            SaveMainWindowPosition();
            SaveSecondaryWindowPosition();

            Ustawienia.SelectedSettingSet.Save();
        }

        private void SecondaryWindow_PositionDataChanged(object sender, EventArgs e)
        {
            SaveSecondaryWindowPosition();
        }

        private void SendSelectedToOutput()
        {
            fileEditor_SelectedStringAccepted(fileEditor, fileEditor.SelectedString);
        }

        private void SetupHotkeys()
        {
            // File
            globalHotkeys.Add(new HotkeyEntry(Keys.N, false, true, true, noweArchiwumToolStripMenuItem_Click,
                noweArchiwumToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.O, false, true, false, otwórzArchiwumToolStripMenuItem_Click,
                otwórzArchiwumToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.D, false, true, false, otwórzFolderArchiwumToolStripMenuItem_Click,
                otwórzFolderArchiwumToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.S, false, true, true, zapiszToolStripMenuItem_Click,
                zapiszToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.S, true, true, false, zapiszJakoToolStripMenuItem_Click,
                zapiszJakoToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.F4, true, false, false, zamknijToolStripMenuItem_Click,
                zamknijToolStripMenuItem));

            // Archive edit
            globalHotkeys.Add(new HotkeyEntry(Keys.N, false, true, false, nowyplikToolStripMenuItem_Click,
                nowyplikToolStripMenuItem, () => fileListView.FileListFocused));
            globalHotkeys.Add(new HotkeyEntry(Keys.F2, zmieńNazwęToolStripMenuItem_Click, zmieńNazwęToolStripMenuItem,
                () => fileListView.FileListFocused));
            globalHotkeys.Add(new HotkeyEntry(Keys.Delete, usuńWybranePlikiToolStripMenuItem_Click,
                usuńWybranePlikiToolStripMenuItem, () => fileListView.FileListFocused));
            globalHotkeys.Add(new HotkeyEntry(Keys.F, false, true, false, szukajToolStripMenuItem_Click,
                szukajToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.A, false, true, false, zaznaczWszystkiePlikiToolStripMenuItem_Click,
                zaznaczWszystkiePlikiToolStripMenuItem, () => fileListView.FileListFocused));
            globalHotkeys.Add(new HotkeyEntry(Keys.F5, odświeżListęToolStripMenuItem_Click,
                odświeżListęToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.F3, właściwościWybranychPiosenekToolStripMenuItem_Click,
                właściwościWybranychPiosenekToolStripMenuItem, () => fileListView.FileListFocused));

            // File edit
            globalHotkeys.Add(new HotkeyEntry(Keys.Z, false, true, false, null, cofnijToolStripMenuItem, () => false));
            globalHotkeys.Add(new HotkeyEntry(Keys.X, false, true, false, null, wytnijToolStripMenuItem, () => false));
            globalHotkeys.Add(new HotkeyEntry(Keys.V, false, true, false, null, wklejToolStripMenuItem, () => false));
            globalHotkeys.Add(new HotkeyEntry(Keys.C, false, true, false, null, kopiujToolStripMenuItem, () => false));
            globalHotkeys.Add(new HotkeyEntry(Keys.Delete, null, usuńToolStripMenuItem, () => false));
            globalHotkeys.Add(new HotkeyEntry(Keys.A, false, true, false, (x, y) => fileEditor.SelectAll(),
                zaznaczWszystkoToolStripMenuItem, () => fileEditor.EditBoxFocused));
            globalHotkeys.Add(new HotkeyEntry(Keys.S, false, true, false, zapiszZmianyToolStripMenuItem_Click,
                zapiszZmianyToolStripMenuItem, () => fileEditor.EditBoxFocused));
            globalHotkeys.Add(new HotkeyEntry(Keys.N, false, true, false, dodajZwrotkęToolStripMenuItem_Click,
                dodajZwrotkęToolStripMenuItem, () => fileEditor.EditBoxFocused));

            // View
            globalHotkeys.Add(new HotkeyEntry(Keys.F7, wyślijDoOknaDocelowegoToolStripMenuItem_Click,
                wyślijDoOknaDocelowegoToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.F8, wyczyśćOknoDoceloweToolStripMenuItem_Click,
                wyczyśćOknoDoceloweToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.F11, fullScreenToolStripMenuItem_Click, fullScreenToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.P, false, true, false, preferencjeToolStripMenuItem_Click,
                preferencjeToolStripMenuItem));

            // Help
            globalHotkeys.Add(new HotkeyEntry(Keys.F1, otworzPomocToolStripMenuItem_Click, otworzPomocToolStripMenuItem));

            // Other
            globalHotkeys.Add(new HotkeyEntry(Keys.Left, false, false, false,
                (x, y) => fileListView.FocusFileList(),
                null, () => Ustawienia.SelectedSettingSet.OknoGlowneKeysArrows && fileEditor.VerseListFocused));
            globalHotkeys.Add(new HotkeyEntry(Keys.Right, false, false, false,
                (x, y) => fileEditor.FocusTab(FileEditorTabs.VerseList), 
                null, () => Ustawienia.SelectedSettingSet.OknoGlowneKeysArrows && fileListView.FileListFocused));

            // Shortcuts
            globalHotkeys.Add(new HotkeyEntry(Keys.Q, false, true, false, (x, y) => fileListView.FocusFileList(),
                null));
            globalHotkeys.Add(new HotkeyEntry(Keys.W, false, true, false,
                (x, y) => fileEditor.FocusTab(FileEditorTabs.VerseList), null));
            globalHotkeys.Add(new HotkeyEntry(Keys.E, false, true, false,
                (x, y) => fileEditor.FocusTab(FileEditorTabs.ContentEditor), null));
            globalHotkeys.Add(new HotkeyEntry(Keys.R, false, true, false,
                (x, y) => fileEditor.FocusTab(FileEditorTabs.Properties), null));
        }

        /// <summary>
        ///     Does not load from the archive, only checks if everything is fine with existing archive (if it exists)
        /// </summary>
        private bool SetupNewArchive(string fullPath)
        {
            if (!AskAndSaveIfNeeded())
                return false;

            try
            {
                var tempArchive = new SongFileArchive(fullPath)
                {
                    LockArchiveFile = !Ustawienia.SelectedSettingSet.GeneralInneDostepZewnetrznyDoArchiwum,
                    MonitorExternalChanges = Ustawienia.SelectedSettingSet.GeneralInneSprawdzajZewnetrzneZmiany
                };

                tempArchive.ArchiveLoaded += x =>
                {
                    fileListView.PopulateItems(x.LoadedFiles);
                    UpdateMainWindowTitlebar();
                    fileListView.SaveButtonEnabled = false;
                };
                tempArchive.ArchiveSaved += x =>
                {
                    UpdateMainWindowTitlebar();
                    fileListView.SaveButtonEnabled = false;
                };
                tempArchive.LoadedFiles.CollectionModified += x =>
                {
                    fileListView.PopulateItems(x);
                    UpdateMainWindowTitlebar();
                    fileListView.SaveButtonEnabled = true;
                };
                tempArchive.LoadedFiles.ItemModified += (x, y) =>
                {
                    fileListView.RefreshListElement(y);
                    UpdateMainWindowTitlebar();
                    fileListView.SaveButtonEnabled = true;
                };
                tempArchive.LoadedFiles.ItemRemoved +=
                    (x, y) => { if (y.Equals(fileEditor.LoadedFile)) fileEditor.UnloadFile(false); };
                tempArchive.FullNameChanged += x => AddRecentItem(x.FullName);
                tempArchive.ArchiveContentsChangedExternally += OnArchiveContentsChangedExternally;
                tempArchive.ArchiveNameChangedExternally += OnArchiveNameChangedExternally;

                OpenedSongArchive?.Dispose(); //Clears out previously assigned event handlers
                OpenedSongArchive = tempArchive;
            }
            catch (ArgumentException)
            {
                MessageBoxes.InvalidArchiveInfo(this);
                return false;
            }

            return true;
        }

        private void SetupRemoteDisplayWindow()
        {
            if (_remoteDisplayWindow != null && !_remoteDisplayWindow.IsDisposed)
                _remoteDisplayWindow.Dispose();

            _remoteDisplayWindow = new SecondaryWindow();
            
            _remoteDisplayWindow.Show();
            _remoteDisplayWindow.SetupTextDisplayBoxes(previewScreens.TopDisplayBox, previewScreens.BottomDisplayBox);

            _remoteDisplayWindow.ResizeEnd += SecondaryWindow_PositionDataChanged;
            _remoteDisplayWindow.LocationChanged += SecondaryWindow_PositionDataChanged;

            _remoteDisplayWindow.FormClosing += (x, y) =>
            {
                if (!AskAndSaveIfNeeded())
                    y.Cancel = true;
                else
                {
                    _skipSaveOnExit = true;
                    Application.Exit();
                }
            };

            _remoteDisplayWindow.TextChanger.CanChangeChanged += x => previewScreens.ButtonsEnabled = x.CanChange;
            _remoteDisplayWindow.TextChanger.PushProgressChanged += (x, y) =>
                previewScreens.SetProgressBar(Ustawienia.SelectedSettingSet.OknoGlowneInnePokazujPasekPostepuPrzejscia
                    ? y
                    : -1);
        }

        private bool ShowNameChangeDialog(SongFileEntry target, bool isNewFile)
        {
            return MessageBoxes.ShowFileNameChangeDialog(this, target, isNewFile)
                   != DialogResult.Cancel;
        }

        private void ShowOpenArchiveDialog()
        {
            if (!AskAndSaveIfNeeded())
                return;
            openArchiveFileDialog.ShowDialog();
        }

        private void szukajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListView.FocusSearchBox();
        }

        private static void TrimRecentItems()
        {
            while (Ustawienia.SelectedSettingSet.AutoRecentItems.Count >
                   Ustawienia.SelectedSettingSet.GeneralHistoryPoints)
                Ustawienia.SelectedSettingSet.AutoRecentItems.RemoveAt(0);
        }

        private void UpdateMainWindowTitlebar()
        {
            var builder = new StringBuilder();
            if (OpenedSongArchive != null)
            {
                builder.Append(OpenedSongArchive.IsWrittenToDisk
                    ? (Ustawienia.SelectedSettingSet.OknoGlowneInnePokazujPelnaSciezkeArchiwum
                        ? OpenedSongArchive.FullName
                        : OpenedSongArchive.FilenameWithExtension)
                    : Localisation.NewArchiveDefaultName);
                builder.AppendIf(!OpenedSongArchive.AllSavedToDisk, Resources.TitlebarFileChangedMark);
                builder.Append(" - ");

                if (fileEditor.LoadedFile != null)
                {
                    builder.Append(fileEditor.LoadedFile.Name);
                    builder.AppendIf(fileEditor.FileWasChanged, Resources.TitlebarFileChangedMark);
                    builder.Append(" - ");
                }
            }

            builder.AppendFormat("{0} v{1}", Resources.ApplicationName,
                Assembly.GetExecutingAssembly().GetName().Version.ToString(2));

            Text = builder.ToString();
        }

        private void ustawieniaToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            alwaysOnTopToolStripMenuItem.CheckState = IsAlwaysOnTop ? CheckState.Checked : CheckState.Unchecked;
            fullScreenToolStripMenuItem.CheckState = IsFullScreen ? CheckState.Checked : CheckState.Unchecked;
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.Text_Delete();
        }

        private void usuńWybranePlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedFiles();
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.Text_Paste();
        }

        private void wyczyśćOknoDoceloweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearOutput();
        }

        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.Text_Cut();
        }

        private void wyślijDoOknaDocelowegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendSelectedToOutput();
        }

        private void właściwościWybranychPiosenekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListView.ShowProperties();
        }

        private void zamknijArchiwumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AskAndSaveIfNeeded())
                return;
            OpenedSongArchive = null;
        }

        private void zamknijElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.UnloadFile();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveArchiveAs();
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveArchive();
        }

        private void zapiszZmianyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.SaveChanges();
        }

        private void zaznaczWszystkiePlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListView.Focus();
            fileListView.SelectAll();
        }

        private void zaznaczWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fileEditor.Focus();
            fileEditor.SelectAll();
        }

        private void zmieńNazwęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListView.RenameSelected();
        }
    }
}