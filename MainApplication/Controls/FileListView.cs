using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Klocman.Extensions;
using Klocman.Tools;
using TextToScreen.Misc;
using TextToScreen.Properties;
using TextToScreen.SongFile;
using TextToScreen.Windows;

namespace TextToScreen.Controls
{
    public sealed partial class FileListView : UserControl
    {
        private bool _stopRefreshingList;

        public FileListView()
        {
            InitializeComponent();

            objectListView1.ClearObjects();
            objectListView1.ShowGroups = true;
            objectListView1.AlwaysGroupByColumn = groupColumn;
            objectListView1.AlwaysGroupBySortOrder = SortOrder.Ascending;
            groupColumn.GroupKeyToTitleConverter = x =>
            {
                var groupName = (string)x;
                if (string.IsNullOrEmpty(groupName))
                {
                    return Localisation.DefaultGroupName;
                }
                return groupName;
            };
            nameColumn.AspectPutter = (x, y) =>
            {
                var sfe = (SongFileEntry)x;
                var newname = (string)y;
                if (sfe.CheckName(newname) == NameChangeResult.Ok)
                    sfe.Name = newname;
                objectListView1.RefreshObject(x);
            };
            createdColumn.AspectToStringConverter = x => ((DateTime)x).ToFuzzyTimeSinceString();
            modifiedColumn.AspectToStringConverter = x => ((DateTime)x).ToFuzzyTimeSinceString();

            foreach (var control in searchBox1.GetAllChildren().Concat(new[] { searchBox1 }))
            {
                control.KeyDown += searchBox1_KeyDown;
            }

            objectListView1.AdditionalFilter = new ModelFilter(x => ListViewFilter(x as SongFileEntry));
            objectListView1.UseFiltering = true;
        }

        private bool ListViewFilter(SongFileEntry sfe)
        {
            if (sfe == null) throw new ArgumentNullException();
            return CheckGroupMatch(sfe) && CheckStringMatch(sfe, searchBox1.SearchString);
        }

        public bool FileListFocused => objectListView1.Focused;
        public IEnumerable<SongFileEntry> LastFileSource { get; private set; }

        public bool SaveButtonEnabled
        {
            get { return toolStripButton_save.Enabled; }
            set { toolStripButton_save.Enabled = value; }
        }

        public SongFileEntry SelectedFile
        {
            get { return objectListView1.SelectedObject as SongFileEntry; }
            set
            {
                var index = objectListView1.IndexOf(value);
                if (index < 0) return;
                objectListView1.EnsureVisible(index);
                objectListView1.SelectObject(value);
            }
        }

        public IEnumerable<SongFileEntry> SelectedFiles => objectListView1.SelectedObjects.Cast<SongFileEntry>();

        [Category("Appearance")]
        [Description("Toggles display of the bottom search box")]
        [DefaultValue(true)]
        public bool ShowSearchbox
        {
            get { return !splitContainer1.Panel2Collapsed; }
            set
            {
                searchSubsection.Visible = value;
                splitContainer1.Panel2Collapsed = !value;
                if (value)
                    splitContainer1.Panel2.Show();
                else
                    splitContainer1.Panel2.Hide();
            }
        }

        [Category("Appearance")]
        [Description("Toggles display of the top toolbar")]
        [DefaultValue(true)]
        public bool ShowToolbar
        {
            get { return toolStrip.Visible; }
            set { toolStrip.Visible = value; }
        }

        public bool StopRefreshingList
        {
            get { return _stopRefreshingList; }
            set
            {
                if (_stopRefreshingList != value)
                {
                    _stopRefreshingList = value;
                    if (!value)
                        RepopulateItems();
                }
            }
        }

        public IEnumerable<SongFileEntry> VisibleFiles => objectListView1.Objects.Cast<SongFileEntry>();
        public event Action<FileListView> ButtonClickDelete;
        public event Action<FileListView> ButtonClickNew;
        public event Action<FileListView> ButtonClickRefresh;
        public event Action<FileListView> ButtonClickSave;
        public event Action<FileListView, SongFileEntry> FileOpened;

        public void ClearAllItems(bool clearLastSource)
        {
            if (clearLastSource)
                LastFileSource = null;

            objectListView1.ClearObjects();
        }

        public void DuplicateSelected()
        {
            StopRefreshingList = true;
            foreach (var file in SelectedFiles)
            {
                file.ParentCollection?.Add(new SongFileEntry(file)
                {
                    Name = StringTools.GetUniqueName(file.Name, file.ParentCollection.Names),
                    SavedToDisk = false
                });
            }
            StopRefreshingList = false;
        }

        public void FocusFileList()
        {
            Focus();
            objectListView1.Focus();
        }

        public void FocusSearchBox()
        {
            Focus();
            searchBox1.FocusSearchBox();
        }

        public void PopulateItems(IEnumerable<SongFileEntry> source)
        {
            var songFileEntries = source as IList<SongFileEntry> ?? source.ToList();
            LastFileSource = songFileEntries;

            groupFilterComboBox.Items.Clear();
            groupFilterComboBox.Items.Add(string.Empty);

            var query = songFileEntries.GroupBy(x => x.Group)
                .Select(group => string.IsNullOrEmpty(group.Key) ? Localisation.DefaultGroupName : group.Key)
                .OrderBy(x => x);

            groupFilterComboBox.Items.AddRange(query.Cast<object>().ToArray());

            if (StopRefreshingList)
                return;

            objectListView1.SetObjects(songFileEntries);
            objectListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public void RefreshListElement(SongFileEntry element)
        {
            if (StopRefreshingList)
                return;
            objectListView1.UpdateObject(element);
        }

        public void RenameSelected()
        {
            if (objectListView1.SelectedObjects.Count != 1)
                return;

            var sf = SelectedFile;
            if (sf != null)
            {
                MessageBoxes.ShowFileNameChangeDialog(this, sf, false);
                objectListView1.UpdateObject(sf);
            }
        }

        public void RepopulateItems()
        {
            if (StopRefreshingList)
                return;
            if (LastFileSource != null)
                PopulateItems(LastFileSource);
        }

        /// <summary>
        ///     Select all items in the list view
        /// </summary>
        public void SelectAll()
        {
            objectListView1.SelectAll();
            //SelectFiles(true);
        }

        /// <summary>
        ///     Deselect all items in the list view
        /// </summary>
        public void SelectNone()
        {
            objectListView1.DeselectAll();
            //SelectFiles(false);
        }

        public void ShowProperties()
        {
            if (SelectedFiles.Any())
            {
                StopRefreshingList = true;
                MessageBoxes.ShowPropertiesDialog(this, SelectedFiles, true);
                StopRefreshingList = false;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            groupFilterComboBox.SelectedIndex = 0;
            searchBox1.ClearSearchBox();
        }

        private bool CheckGroupMatch(SongFileEntry entry)
        {
            if (groupFilterComboBox.SelectedIndex <= 0) return true;

            var filter = groupFilterComboBox.SelectedItem as string;
            if (filter == null || filter.Equals(Localisation.DefaultGroupName))
                filter = string.Empty;
            return entry.Group.Equals(filter);
        }

        private bool CheckStringMatch(SongFileEntry entry, string searchString)
        {
            if (StringTools.StringContainsFilter(entry.Name, searchString))
                return true;

            if (StringTools.StringContainsFilter(entry.Comment, searchString))
                return true;

            if (searchInsideFilesCheckBox.CheckState.ToBool())
            {
                if (StringTools.StringContainsFilter(entry.Contents, searchString))
                    return true;
            }

            return false;
        }

        private void duplikujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuplicateSelected();
        }

        private void groupFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListFilter();
        }

        private void kopiujDoSchowkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            Eksport.ExportSongsToString(SelectedFiles, sb);
            Clipboard.SetText(sb.ToString());
        }

        private void listViewContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            var selFileCount = SelectedFiles.Count();
            if (selFileCount < 1)
            {
                listViewContextMenuStrip.Enabled = false;
            }
            else
            {
                listViewContextMenuStrip.Enabled = true;

                var enableSingleFileItems = selFileCount == 1;
                otwórzToolStripMenuItem.Enabled = enableSingleFileItems;
                zmieńNazwęToolStripMenuItem.Enabled = enableSingleFileItems;
            }
        }

        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            var sf = SelectedFile;
            if (sf != null)
                OnFileOpened(sf);
        }

        private void objectListView1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true; // Stop ding sound
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (SelectedFile == null)
                            return;

                        if (e.Control)
                        {
                            ShowProperties();
                        }
                        else
                        {
                            OnFileOpened(SelectedFile);
                        }
                    }
                    break;

                case Keys.Apps:
                    {
                        OpenFileContextMenu();
                    }
                    break;

                case Keys.F10:
                    {
                        if (e.Shift)
                        {
                            OpenFileContextMenu();
                        }
                        else
                        {
                            e.Handled = false;
                            e.SuppressKeyPress = false;
                        }
                    }
                    break;

                default:
                    {
                        e.Handled = false;
                        e.SuppressKeyPress = false;
                    }
                    break;
            }
        }

        private void objectListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (objectListView1.FocusedItem != null && objectListView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    OpenFileContextMenu();
                }
            }
        }

        private void OnDeleteButton()
        {
            ButtonClickDelete?.Invoke(this);
        }

        private void OnFileOpened(SongFileEntry file)
        {
            FileOpened?.Invoke(this, file);
        }

        private void OpenFileContextMenu()
        {
            if (SelectedFiles.Any())
            {
                listViewContextMenuStrip.Show(Cursor.Position);
                zmieńNazwęToolStripMenuItem.Enabled = (objectListView1.SelectedObjects.Count == 1);
            }
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnFileOpened(SelectedFile);
        }

        private void propertiesToolStripButton_Click(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void RefreshListFilter()
        {
            objectListView1.UpdateColumnFiltering();
            objectListView1.EmptyListMsg = string.IsNullOrEmpty(searchBox1.SearchString) ? null : Localisation.FileListView_NothingMatched;
        }

        private void searchBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
                return;

            e.Handled = true;
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    objectListView1.Focus();
                    searchBox1.ClearSearchBox();
                    break;

                case Keys.Down:
                    objectListView1.Focus();
                    break;

                case Keys.Up:
                    objectListView1.Focus();
                    SelectNone();
                    break;

                default:
                    e.Handled = false;
                    break;
            }
        }

        private void searchBox1_SearchTextChanged(Klocman.Controls.SearchBox arg1, EventArgs arg2)
        {
            RefreshListFilter();
        }

        private void searchInsideFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshListFilter();
        }

        private void toolStripButton_del_Click(object sender, EventArgs e)
        {
            OnDeleteButton();
        }

        private void toolStripButton_new_Click(object sender, EventArgs e)
        {
            ButtonClickNew?.Invoke(this);
        }

        private void toolStripButton_ref_Click(object sender, EventArgs e)
        {
            ButtonClickRefresh?.Invoke(this);
        }

        private void toolStripButton_ren_Click(object sender, EventArgs e)
        {
            RenameSelected();
        }

        private void toolStripButton_save_Click(object sender, EventArgs e)
        {
            ButtonClickSave?.Invoke(this);
        }

        // Context strip part
        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnDeleteButton();
        }

        private void właściwościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void zmieńNazwęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameSelected();
        }
    }
}