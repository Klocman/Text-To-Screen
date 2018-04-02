﻿/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Klocman.Extensions;
using ScintillaNET;
using TextToScreen.Misc;
using TextToScreen.Properties;
using TextToScreen.SongFile;

namespace TextToScreen.Controls
{
    public sealed partial class FileEditor : UserControl
    {
        private bool _fileWasChanged;
        private SongFileEntry _loadedFile;

        public FileEditor()
        {
            InitializeComponent();

            scintilla1.Styles[Style.LineNumber].BackColor = Color.DarkGray;
            scintilla1.Styles[Style.LineNumber].ForeColor = Color.White;
            var nums = scintilla1.Margins[1];
            nums.Type = MarginType.Number;
            nums.Mask = 0;
            scintilla1.Styles[Style.Default].Font = Font.Name;
            scintilla1.Styles[Style.Default].SizeF = Font.Size;
        }

        public bool EditBoxFocused => scintilla1.Focused;

        public bool FileWasChanged
        {
            get { return _fileWasChanged; }
            private set
            {
                _fileWasChanged = value;
                OnFileContentsChanged();
            }
        }

        public SongFileEntry LoadedFile
        {
            get { return _loadedFile; }
            private set
            {
                if (_loadedFile != value)
                {
                    _loadedFile = value;
                    filePropertiesViewer1.Populate(value, true);
                    OnLoadedFileChanged();
                }
            }
        }

        public string SelectedString => (multiLineListBox1.SelectedItem as string)
            ?.Replace("\r", string.Empty) ?? string.Empty;

        public bool VerseListFocused => multiLineListBox1.Focused;
        //IEnumerable<string> VerseList { get { return multiLineListBox1.Items.Cast<string>(); } }
        private int SelectedVerseIndex
        {
            get { return multiLineListBox1.SelectedIndex; }
            set { if (multiLineListBox1.Items.Count > value) multiLineListBox1.SelectedIndex = value; }
        }

        public event Action<FileEditor, SongFileEntry> FileContentsChanged;
        public event Action<FileEditor, SongFileEntry> FileSaved;
        public event Action<FileEditor, SongFileEntry> LoadedFileChanged;
        public event Action<FileEditor, string> SelectedStringAccepted;
        public event Action<FileEditor, string> SelectedStringChanged;
        public event Action<FileEditor> SelectedStringCleared;

        /// <summary>
        ///     Returns false if user doesn't save, Null if user cancels the operation
        /// </summary>
        public bool? AskAndSaveIfNeeded()
        {
            if (!FileWasChanged) return true;

            switch (MessageBoxes.SaveChangesToOpenedFile(this))
            {
                case DialogResult.Yes:
                    SaveChanges();
                    return true;

                case DialogResult.No:
                    return false;

                default:
                    return null;
            }
        }

        public void FocusTab(FileEditorTabs tab)
        {
            Focus();
            tabControl1.SelectedIndex = (int) tab;

            switch (tab)
            {
                case FileEditorTabs.VerseList:
                    if (SelectedVerseIndex < 0)
                        SelectedVerseIndex = 0;
                    multiLineListBox1.Focus();
                    break;

                case FileEditorTabs.ContentEditor:
                    scintilla1.Focus();
                    break;

                case FileEditorTabs.Properties:
                    filePropertiesViewer1.Focus();
                    break;

                default:
                    throw new InvalidEnumArgumentException(nameof(tab), (int) tab, typeof (FileEditorTabs));
            }
        }

        public bool LoadFile(SongFileEntry file)
        {
            if (!UnloadFile())
                return false;

            LoadedFile = file;

            if (file != null)
            {
                //Populate stuff
                scintilla1.Text = file.Contents;
                scintilla1.EmptyUndoBuffer();
                PopulateListBox();
                Enabled = true;
            }
            else
                Enabled = false;

            FileWasChanged = false;
            return true;
        }

        public void SaveChanges()
        {
            if (LoadedFile == null)
                return;
            LoadedFile.Contents = scintilla1.Text;
            LoadedFile.SavedToDisk = false;
            FileWasChanged = false;

            OnFileSaved();
        }

        public void SelectAll()
        {
            if (tabControl1.SelectedIndex != 1) return;
            scintilla1.SelectAll();
        }

        public void SelectNone()
        {
            if (tabControl1.SelectedIndex != 1) return;
            scintilla1.SetEmptySelection(scintilla1.CurrentPosition);
        }

        public void Text_AddVerse()
        {
            if (tabControl1.SelectedIndex != 1) return;

            var selectIndex = scintilla1.SelectionStart;
            if (selectIndex >= 0)
            {
                scintilla1.Text = scintilla1.Text.Insert(selectIndex, SongFileEntry.NewVerse);
                scintilla1.SetEmptySelection(selectIndex + SongFileEntry.NewVerse.Length);
                scintilla1.ScrollCaret();
            }
        }

        public void Text_Copy()
        {
            if (tabControl1.SelectedIndex != 1) return;
            // Ensure that text is selected in the text box.
            if (!string.IsNullOrEmpty(scintilla1.SelectedText))
                // Copy the selected text to the Clipboard.
                scintilla1.Copy();
        }

        public void Text_Cut()
        {
            if (tabControl1.SelectedIndex != 1) return;
            // Ensure that text is currently selected in the text box.
            if (scintilla1.SelectedText.Length > 0)
                // Cut the selected text in the control and paste it into the Clipboard.
                scintilla1.Cut();
        }

        public void Text_Delete()
        {
            if (tabControl1.SelectedIndex != 1) return;
            // Determine if last operation can be undone in text box.
            if (!string.IsNullOrEmpty(scintilla1.SelectedText))
                scintilla1.ReplaceSelection(string.Empty);
        }

        public void Text_Paste()
        {
            if (tabControl1.SelectedIndex != 1) return;
            // Determine if there is any text in the Clipboard to paste into the text box.
            var clipboardContent = Clipboard.GetDataObject();
            if (clipboardContent != null && clipboardContent.GetDataPresent(DataFormats.Text))
                scintilla1.Paste();
        }

        public void Text_Undo()
        {
            if (tabControl1.SelectedIndex != 1) return;
            // Determine if last operation can be undone in text box.
            if (scintilla1.CanUndo)
            {
                // Undo the last operation.
                scintilla1.Undo();
            }
        }

        public bool UnloadFile()
        {
            return UnloadFile(true);
        }

        public bool UnloadFile(bool askSaveChanges)
        {
            if (askSaveChanges && !AskAndSaveIfNeeded().HasValue)
                return false;

            LoadedFile = null;
            multiLineListBox1.Items.Clear();
            scintilla1.Text = string.Empty;
            FileWasChanged = false;
            Enabled = false;
            return true;
        }

        private void filePropertiesViewer1_DataWasEditedChanged(FilePropertiesViewer arg1,
            FilePropertiesViewerEventArgs arg2)
        {
            if (_loadedFile != null)
            {
                if (_loadedFile.Name != arg2.NewName)
                    _loadedFile.Name = arg2.NewName;
                _loadedFile.Comment = arg2.NewComment;
                _loadedFile.Group = arg2.NewGroup;
                filePropertiesViewer1.Populate(_loadedFile, true);
            }
            //FileWasChanged = true;
        }

        private void multiLineListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OnSelectedStringAccepted();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Let those go so that the list can go up and down by itself
                return;
            }
            else
            {
                var result = e.KeyCode.ToNumber();
                if (result >= 0)
                {
                    if (result == 0)
                        result = 9;
                    else
                        result--;

                    if (SelectVerseById(result) && Ustawienia.Default.OknoGlowneKeysNumbers)
                        OnSelectedStringAccepted();
                }
            }

            e.Handled = true;
        }

        private void multiLineListBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void multiLineListBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.Left && e.KeyCode <= Keys.Down)
                return;
            e.Handled = true;
        }

        private void multiLineListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedStringChanged();
        }

        private void multiLineListBox_Click(object sender, EventArgs e)
        {
            SelectLineInEditor(multiLineListBox1.SelectedIndex);

            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                multiLineListBox1.ClearSelected();
                OnSelectedStringCleared();
            }
            else
                OnSelectedStringChanged();
        }

        private void SelectLineInEditor(int lineNumber)
        {
            if (lineNumber >= 0)
            {
                int startIndex = 0;
                for (var i = 0; i < lineNumber; i++)
                {
                    var result = scintilla1.Text.IndexOf(SongFileEntry.NewVerse, startIndex + SongFileEntry.NewVerse.Length,
                        StringComparison.OrdinalIgnoreCase);
                    if (result < 0)
                        break;
                    startIndex = result;
                }

                if (startIndex >= 0)
                {
                    var endIndex = scintilla1.Text.IndexOf(SongFileEntry.NewVerse, startIndex + SongFileEntry.NewVerse.Length,
                            StringComparison.OrdinalIgnoreCase);
                    scintilla1.SetSelection(endIndex >= 0 ? endIndex : scintilla1.Text.Length - 1, startIndex);
                }
            }
        }

        //Event handlers ---------------------------------------------------------
        private void multiLineListBox_DoubleClick(object sender, EventArgs e)
        {
            OnSelectedStringAccepted();
        }

        private void OnFileContentsChanged()
        {
            FileContentsChanged?.Invoke(this, LoadedFile);
        }

        private void OnFileSaved()
        {
            FileSaved?.Invoke(this, LoadedFile);
        }

        private void OnLoadedFileChanged()
        {
            LoadedFileChanged?.Invoke(this, LoadedFile);
        }

        private void OnSelectedStringAccepted()
        {
            SelectedStringAccepted?.Invoke(this, SelectedString);
        }

        private void OnSelectedStringChanged()
        {
            SelectedStringChanged?.Invoke(this, SelectedString);
        }

        private void OnSelectedStringCleared()
        {
            SelectedStringCleared?.Invoke(this);
        }

        private void PopulateListBox()
        {
            multiLineListBox1.Items.Clear();
            multiLineListBox1.Items.AddRange(
                scintilla1.Text.Split(new[] {SongFileEntry.NewVerse}, StringSplitOptions.None)
                    .Cast<object>().ToArray());
        }

        private bool SelectVerseById(int id)
        {
            if (multiLineListBox1.Items.Count <= id)
                return false;
            SelectedVerseIndex = id;
            return true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateListBox();
        }

        private void scintilla1_TextChanged(object sender, EventArgs e)
        {
            FileWasChanged = true;
        }
    }
}