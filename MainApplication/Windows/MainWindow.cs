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
        private SongFileArchive _openedSongArchive;
        private SecondaryWindow _remoteDisplayWindow;
        private bool _skipSaveOnExit;

        public MainWindow()
        {
            InitializeComponent();

            Opacity = 0;

            // Needs to be called after the generated code because of a bug with generated code ordering
            // (minsize gets placed before splitter distance is set, resulting in exception)
            splitContainer1.Panel1MinSize = 300;
            splitContainer1.Panel2MinSize = 100;
            splitContainer3.Panel1MinSize = 150;
            splitContainer3.Panel2MinSize = 150;

            PremadeDialogs.DefaultOwner = this;

            fileListView.Enabled = false;
            fileEditor.UnloadFile(false);

            SetupRemoteDisplayWindow();

            previewScreens.ButtonClickSend += x => SendSelectedToOutput();
            previewScreens.ButtonClickClear += x => ClearOutput();

            ReadStartupSettings();
            ReadSettings();
            BindSettings();
            Ustawienia.Default.Binder.SendUpdates(this);

            SetupHotkeys();

            SystemEvents.SessionEnding += (x, y) =>
            {
                if (!AskAndSaveIfNeeded())
                    y.Cancel = true;
            };

            SystemEvents.DisplaySettingsChanged += (sender, args) => { EnsureWindowsAreVisible(); };
        }


        private SongFileArchive OpenedSongArchive
        {
            get { return _openedSongArchive; }
            set
            {
                if (_openedSongArchive == value)
                    return;

                _openedSongArchive?.Dispose();

                fileListView.ClearAllItems(true);
                fileListView.Enabled = false;
                fileEditor.UnloadFile(false);

                _openedSongArchive = value;

                if (value != null)
                {
                    fileListView.Enabled = true;
                    fileListView.PopulateItems(_openedSongArchive.LoadedFiles);
                }

                UpdateMainWindowTitlebar();
            }
        }

        private void EnsureWindowsAreVisible()
        {
            var mscr = Screen.FromControl(this);

            if (!mscr.WorkingArea.Contains(Location))
            {
                WindowState = FormWindowState.Normal;
                Location = mscr.WorkingArea.Location;
            }

            var rscr = Screen.FromControl(_remoteDisplayWindow);

            if (!rscr.WorkingArea.Contains(_remoteDisplayWindow.Location))
            {
                _remoteDisplayWindow.WindowState = FormWindowState.Normal;
                _remoteDisplayWindow.Location = rscr.WorkingArea.Location;
            }
        }

        private void BindSettings()
        {
            var binder = Ustawienia.Default.Binder;
            binder.BindControl(alwaysOnTopToolStripMenuItem, ustawienia => ustawienia.OknoGlowneTop, this);
            binder.Subscribe(this, mainWindow => mainWindow.TopMost, ustawienia => ustawienia.OknoGlowneTop, this);

            binder.BindControl(fullScreenToolStripMenuItem, ustawienia => ustawienia.OknoGlowneFull, this);
            binder.Subscribe((sender, args) =>
            {
                if (args.NewValue)
                {
                    //Going fullscreen
                    SuspendLayout();
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    ResumeLayout();
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    //WindowState = FormWindowState.Normal;
                }
            }, ustawienia => ustawienia.OknoGlowneFull, this);
        }

        /// <summary>
        ///     Returns false if user cancels the operation
        /// </summary>
        private bool AskAndSaveIfNeeded()
        {
            if (OpenedSongArchive != null && (fileEditor.FileWasChanged || !OpenedSongArchive.AllSavedToDisk))
            {
                if (!fileEditor.AskAndSaveIfNeeded().HasValue)
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

        private static bool CheckDraggedItems(out IEnumerable<string> filenames, DragEventArgs e)
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
            _remoteDisplayWindow.OutputCluster.ClearPreviewDisplay();
            _remoteDisplayWindow.OutputCluster.PushPreviewToOutput();
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.Text_Undo();
        }

        private void coNowegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"http://klocmansoftware.weebly.com/texttoscreen.html");
        }

        private void CreateNewArchive()
        {
            SetupNewArchive(string.Empty);
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
            {
                OpenedSongArchive.LoadedFiles.Add(newFile);
                fileListView.SelectedFile = newFile;
            }
            else
                newFile.Dispose();
        }

        private void dodajZwrotkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileEditor.Text_AddVerse();
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"http://klocmansoftware.weebly.com/about.html");
        }

        private void duplikujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListView.DuplicateSelected();
        }

        private void edycjaElementowToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var enableArchiveManipulation = fileListView.FileListFocused;
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
        }

        private void fileEditor_LoadedFileChanged(FileEditor arg1, SongFileEntry arg2)
        {
            UpdateMainWindowTitlebar();
        }

        private void fileEditor_SelectedStringAccepted(FileEditor x, string y)
        {
            fileEditor_SelectedStringChanged(x, y);

            _remoteDisplayWindow.OutputCluster.PushPreviewToOutput();
        }

        private void fileEditor_SelectedStringChanged(FileEditor x, string y)
        {
            _remoteDisplayWindow.OutputCluster.SendToPreviewField(y);
        }

        private void fileEditor_SelectedStringCleared(FileEditor obj)
        {
            _remoteDisplayWindow.OutputCluster.ClearPreviewDisplay();
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

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"http://klocmansoftware.weebly.com/texttoscreen.html");
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

            ShowImportFileResultBox(result);
        }

        private void ShowImportFileResultBox(FileImporterResult result)
        {
            var successfulCountString = string.Format(Localisation.FileImportSuccessfulCount, result.Results.Count());
            if (result.Errors.Any())
            {
                var unsuccessfulString = new StringBuilder();
                unsuccessfulString.AppendLine(Localisation.FileImportProblemsHeader);
                foreach (var group in result.Errors.GroupBy(el => el.Value))
                {
                    unsuccessfulString.AppendLine();
                    unsuccessfulString.Append("Błąd: ");
                    unsuccessfulString.AppendLine(group.Key);
                    foreach (var element in group)
                    {
                        unsuccessfulString.Append("->");
                        unsuccessfulString.AppendLine(element.Key);
                    }
                }

                MessageBox.Show(this, $"{successfulCountString}\n{unsuccessfulString}", Localisation.FileImportTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(this, successfulCountString, Localisation.FileImportTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            Ustawienia.Default._FirstStartCompleted = true;
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

            Ustawienia.AddRecentItem(fullPath);
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

            var histEn = Ustawienia.Default.GeneralHistoryEnabled &&
                         Ustawienia.Default.AutoRecentItems.Count > 0;
            ostatnioOtwarteToolStripMenuItem.Enabled = histEn;
            if (histEn)
            {
                Ustawienia.TrimRecentItems();
                for (var i = Ustawienia.Default.AutoRecentItems.Count - 1; i >= 0; i--)
                {
                    var path = Ustawienia.Default.AutoRecentItems[i];
                    var newChild = new ToolStripMenuItem {Text = path};
                    newChild.Click += RecentItem_Click;
                    ostatnioOtwarteToolStripMenuItem.DropDownItems.Add(newChild);
                }
            }
        }

        private void preferencjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxes.ShowSettingsDialog(this, Ustawienia.Default, Ustawienia.DefaultValues);
            ReadSettings();
        }

        private void ReadSettings()
        {
            if (Ustawienia.Default.AutoRecentItems == null)
                Ustawienia.Default.AutoRecentItems = new StringCollection();

            if (_remoteDisplayWindow != null)
            {
                _remoteDisplayWindow.IsAlwaysOnTop = Ustawienia.Default.OknoDoceloweTop;
                _remoteDisplayWindow.IsCursorHidden = Ustawienia.Default.OknoDoceloweHideCursor;
                _remoteDisplayWindow.IsFullScreen = Ustawienia.Default.OknoDoceloweFull;
            }

            if (OpenedSongArchive != null)
            {
                OpenedSongArchive.LockArchiveFile = !Ustawienia.Default.GeneralInneDostepZewnetrznyDoArchiwum;
                OpenedSongArchive.MonitorExternalChanges = Ustawienia.Default.GeneralInneSprawdzajZewnetrzneZmiany;
            }

            UpdateMainWindowTitlebar();

            if (!Ustawienia.Default._FirstStartCompleted)
                new Thread(() =>
                {
                    while (!Visible)
                        Thread.Sleep(200);
                    Invoke(new Action(OnFirstStart));
                }).Start();
        }

        private void ReadStartupSettings()
        {
            if (Ustawienia.Default.AutoOknoGlownePozycja == Point.Empty
                && Ustawienia.Default.AutoOknoDocelowePozycja == Point.Empty)
            {
                StartPosition = FormStartPosition.WindowsDefaultLocation;
                _remoteDisplayWindow.StartPosition = FormStartPosition.WindowsDefaultLocation;
                return;
            }

            Location = Ustawienia.Default.AutoOknoGlownePozycja;
            Size = Ustawienia.Default.AutoOknoGlowneRozmiar;
            WindowState = Ustawienia.Default.AutoOknoGlowneMaximized
                ? FormWindowState.Maximized
                : FormWindowState.Normal;

            _remoteDisplayWindow.Location = Ustawienia.Default.AutoOknoDocelowePozycja;
            _remoteDisplayWindow.Size = Ustawienia.Default.AutoOknoDoceloweRozmiar;
            _remoteDisplayWindow.WindowState = Ustawienia.Default.AutoOknoDoceloweMaximized
                ? FormWindowState.Maximized
                : FormWindowState.Normal;

            EnsureWindowsAreVisible();
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
            if (Ustawienia.Default == null || Ustawienia.Default.OknoGlowneFull) return;

            var glMax = WindowState == FormWindowState.Maximized;
            Ustawienia.Default.AutoOknoGlowneMaximized = glMax;
            if (!glMax)
            {
                Ustawienia.Default.AutoOknoGlownePozycja = Location;
                Ustawienia.Default.AutoOknoGlowneRozmiar = Size;
            }
        }

        private void SaveSecondaryWindowPosition()
        {
            if (_remoteDisplayWindow == null || Ustawienia.Default == null || _remoteDisplayWindow.IsFullScreen) return;

            var docMax = _remoteDisplayWindow.WindowState == FormWindowState.Maximized;
            Ustawienia.Default.AutoOknoDoceloweMaximized = docMax;
            if (!docMax)
            {
                Ustawienia.Default.AutoOknoDocelowePozycja = _remoteDisplayWindow.Location;
                Ustawienia.Default.AutoOknoDoceloweRozmiar = _remoteDisplayWindow.Size;
            }
        }

        private void SaveSettings()
        {
            if (!Ustawienia.Default.GeneralHistoryEnabled)
                Ustawienia.Default.AutoRecentItems.Clear();

            // Window positions and stuff
            SaveMainWindowPosition();
            SaveSecondaryWindowPosition();

            Ustawienia.Default.Save();
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
            globalHotkeys.Add(new HotkeyEntry(Keys.S, true, true, true, zapiszJakoToolStripMenuItem_Click,
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
            globalHotkeys.Add(new HotkeyEntry(Keys.F11,
                (x, y) => Ustawienia.Default.OknoGlowneFull = !Ustawienia.Default.OknoGlowneFull,
                fullScreenToolStripMenuItem));
            globalHotkeys.Add(new HotkeyEntry(Keys.P, false, true, false, preferencjeToolStripMenuItem_Click,
                preferencjeToolStripMenuItem));

            // Help
            globalHotkeys.Add(new HotkeyEntry(Keys.F1, otworzPomocToolStripMenuItem_Click, otworzPomocToolStripMenuItem));

            // Output formatting
            globalHotkeys.Add(new HotkeyEntry(Keys.Add, (x, y) => Ustawienia.Default.ScreenFontSize += 3, null));
            globalHotkeys.Add(new HotkeyEntry(Keys.Subtract, (x, y) => Ustawienia.Default.ScreenFontSize -= 3, null));
            globalHotkeys.Add(new HotkeyEntry(Keys.U, false, true, false, 
                (x, y) => Ustawienia.Default.ScreenFontUnderline = !Ustawienia.Default.ScreenFontUnderline, null));
            globalHotkeys.Add(new HotkeyEntry(Keys.B, false, true, false,
                (x, y) => Ustawienia.Default.ScreenFontBold = !Ustawienia.Default.ScreenFontBold, null));
            globalHotkeys.Add(new HotkeyEntry(Keys.I, false, true, false,
                (x, y) => Ustawienia.Default.ScreenFontItalic = !Ustawienia.Default.ScreenFontItalic, null));
            
            // Navigation between panels
            globalHotkeys.Add(new HotkeyEntry(Keys.Q, false, true, false, 
                (x, y) => fileListView.FocusFileList(), null));
            globalHotkeys.Add(new HotkeyEntry(Keys.W, false, true, false,
                (x, y) => fileEditor.FocusTab(FileEditorTabs.VerseList), null));
            globalHotkeys.Add(new HotkeyEntry(Keys.E, false, true, false,
                (x, y) => fileEditor.FocusTab(FileEditorTabs.ContentEditor), null));
            globalHotkeys.Add(new HotkeyEntry(Keys.R, false, true, false,
                (x, y) => fileEditor.FocusTab(FileEditorTabs.Properties), null));
            globalHotkeys.Add(new HotkeyEntry(Keys.Left, false, false, false,
                (x, y) => fileListView.FocusFileList(), null, 
                () => Ustawienia.Default.OknoGlowneKeysArrows && fileEditor.VerseListFocused));
            globalHotkeys.Add(new HotkeyEntry(Keys.Right, false, false, false,
                (x, y) => fileEditor.FocusTab(FileEditorTabs.VerseList), null, 
                () => Ustawienia.Default.OknoGlowneKeysArrows && fileListView.FileListFocused));
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
                    LockArchiveFile = !Ustawienia.Default.GeneralInneDostepZewnetrznyDoArchiwum,
                    MonitorExternalChanges = Ustawienia.Default.GeneralInneSprawdzajZewnetrzneZmiany
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
                tempArchive.FullNameChanged += x => Ustawienia.AddRecentItem(x.FullName);
                tempArchive.ArchiveContentsChangedExternally += OnArchiveContentsChangedExternally;
                tempArchive.ArchiveNameChangedExternally += OnArchiveNameChangedExternally;

                OpenedSongArchive = tempArchive;
            }
            catch (ArgumentException)
            {
                MessageBoxes.InvalidArchiveInfo(this);
                return false;
            }
            catch (IOException e)
            {
                PremadeDialogs.GenericError(e);
                return false;
            }

            return true;
        }

        private void SetupRemoteDisplayWindow()
        {
            if (_remoteDisplayWindow != null && !_remoteDisplayWindow.IsDisposed)
                _remoteDisplayWindow.Dispose();

            _remoteDisplayWindow = new SecondaryWindow {Opacity = 0};

            _remoteDisplayWindow.Show();
            _remoteDisplayWindow.OutputCluster.RegisterPreviewFields(previewScreens);

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

        private void UpdateMainWindowTitlebar()
        {
            var builder = new StringBuilder();
            if (OpenedSongArchive != null)
            {
                builder.Append(OpenedSongArchive.IsWrittenToDisk
                    ? (Ustawienia.Default.OknoGlowneInnePokazujPelnaSciezkeArchiwum
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
            fileEditor.SelectAll();
        }

        private void zmieńNazwęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListView.RenameSelected();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            Opacity = 1;
            _remoteDisplayWindow.Opacity = 1;

            switch (Ustawienia.Default.GeneralStartAction)
            {
                case StartupAction.OpenRecent:
                    if (Ustawienia.Default.AutoRecentItems.Count > 0)
                        OpenArchive(
                            Ustawienia.Default.AutoRecentItems[
                                Ustawienia.Default.AutoRecentItems.Count - 1]);
                    break;

                case StartupAction.OpenSelected:
                    if (File.Exists(Ustawienia.Default.GeneralStartPath))
                        OpenArchive(Ustawienia.Default.GeneralStartPath);
                    break;
            }
        }

        private void changeLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LanguageChangeWindow.ShowLanguageChangeDialog(this))
            {
                MessageBox.Show(this, Localisation.Message_RestartNeeded_Text, Localisation.Message_RestartNeeded_Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}