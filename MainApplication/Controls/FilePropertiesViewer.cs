using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Klocman.Extensions;
using TextToScreen.Misc;
using TextToScreen.Properties;
using TextToScreen.SongFile;

namespace TextToScreen.Controls
{
    public partial class FilePropertiesViewer : UserControl
    {
        private readonly List<SongFileEntry> _loadedFiles = new List<SongFileEntry>();
        private readonly TimeSpan _minTimeDifference = TimeSpan.FromSeconds(2);
        private bool _dataWasEdited;
        private string _originalComment;
        private string _originalGroup;
        private string _originalName;

        public FilePropertiesViewer()
        {
            InitializeComponent();
            Clear();
        }

        public bool CommentChanged => !commentTextBox.Text.Equals(_originalComment);

        public bool DataWasEdited
        {
            get { return _dataWasEdited; }
            set
            {
                _dataWasEdited = value;
                if (value)
                {
                    OnFileWasEdited();
                }
            }
        }

        public bool GroupChanged => !groupTextBox.Text.Equals(_originalGroup);
        public bool NameChanged => _loadedFiles.Count == 1 && !nameTextBox.Text.Equals(_originalName);
        public string NewComment => commentTextBox.Text;
        public string NewGroup => groupTextBox.Text;
        public string NewName => nameTextBox.Text;
        public event Action<FilePropertiesViewer, FilePropertiesViewerEventArgs> FileWasEdited;

        public void Clear()
        {
            _loadedFiles.Clear();
            nameTextBox.Text = string.Empty;
            commentTextBox.Text = string.Empty;
            fileCreatedLabel.Text = string.Empty;
            fileModifiedLabel.Text = string.Empty;

            _originalGroup = null;
            _originalName = null;
            _originalComment = null;

            DataWasEdited = false;
            Enabled = false;
        }

        public IEnumerable<FilePropertiesViewerEventArgs> GetAllChanges()
        {
            var nc = NameChanged;
            var gc = GroupChanged;
            var cc = CommentChanged;
            if (nc || gc || cc)
            {
                return _loadedFiles.Select(file => new FilePropertiesViewerEventArgs(
                    file,
                    nc ? nameTextBox.Text : file.Name,
                    gc ? groupTextBox.Text : file.Group,
                    cc ? commentTextBox.Text : file.Comment
                    )).ToList();
            }
            return Enumerable.Empty<FilePropertiesViewerEventArgs>();
        }

        public void Populate(SongFileEntry target, bool allowEditing)
        {
            _loadedFiles.Clear();
            if (target == null)
            {
                Clear();
            }
            else
            {
                _loadedFiles.Add(target);

                nameTextBox.Enabled = true;
                _originalName = target.Name;
                nameTextBox.Text = _originalName;

                _originalComment = target.Comment;
                commentTextBox.Text = _originalComment;

                _originalGroup = target.Group;
                groupTextBox.Text = _originalGroup;

                fileCreatedLabel.Text = target.CreationTime.ToString(CultureInfo.CurrentCulture);
                fileModifiedLabel.Text = target.LastModified.ToString(CultureInfo.CurrentCulture);

                DataWasEdited = false;
                Enabled = allowEditing;
            }
        }

        public void Populate(IEnumerable<SongFileEntry> targets, bool allowEditing)
        {
            if (targets != null)
            {
                var songFileEntries = targets as IList<SongFileEntry> ?? targets.ToList();
                var count = songFileEntries.Count();
                if (count > 0)
                {
                    var firstElement = songFileEntries.First();
                    if (count == 1)
                        Populate(firstElement, allowEditing);
                    else
                    {
                        _loadedFiles.Clear();
                        _loadedFiles.AddRange(songFileEntries);

                        var names = new List<string>();
                        var groups = new List<string>();
                        var comments = new List<string>();

                        var modTime = firstElement.LastModified;
                        var creTime = firstElement.CreationTime;

                        foreach (var file in songFileEntries)
                        {
                            names.Add(file.Name);
                            if (!groups.Contains(file.Group))
                                groups.Add(file.Group);
                            if (!comments.Contains(file.Comment))
                                comments.Add(file.Comment);

                            if ((file.CreationTime - creTime).Duration() >= _minTimeDifference)
                                creTime = DateTime.MinValue;

                            if ((file.LastModified - modTime).Duration() >= _minTimeDifference)
                                modTime = DateTime.MinValue;
                        }

                        _originalName = string.Join("; ", names.ToArray());
                        nameTextBox.Text = _originalName;
                        nameTextBox.Enabled = false;

                        _originalGroup = string.Join("; ", groups.ToArray());
                        groupTextBox.Text = _originalGroup;

                        _originalComment = string.Join("; ", comments.ToArray());
                        commentTextBox.Text = _originalComment;

                        fileCreatedLabel.Text = creTime == DateTime.MinValue
                            ? Localisation.FilePropertiesViewer_DifferentValues
                            : creTime.ToString(CultureInfo.CurrentCulture);
                        fileModifiedLabel.Text = modTime == DateTime.MinValue
                            ? Localisation.FilePropertiesViewer_DifferentValues
                            : modTime.ToString(CultureInfo.CurrentCulture);

                        DataWasEdited = false;
                        Enabled = allowEditing;
                    }

                    // Successfully populated, prevent clearing
                    return;
                }
            }
            Clear();
        }

        public void Repopulate()
        {
            Populate(_loadedFiles.ToList(), Enabled);
        }

        private void commentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void commentTextBox_Leave(object sender, EventArgs e)
        {
            commentTextBox.Text = commentTextBox.Text.RemoveNewLines();
            if (CommentChanged)
            {
                DataWasEdited = true;
            }
        }

        private void groupTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void groupTextBox_Leave(object sender, EventArgs e)
        {
            if (GroupChanged)
            {
                if (groupTextBox.Text.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                {
                    // Group contains invalid characters
                    MessageBoxes.GroupIsInvalidInfo(this);
                    groupTextBox.Text = _originalGroup;
                }
                else
                {
                    DataWasEdited = true;
                }
            }
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            if (NameChanged) // Should never return true if there are more than 1 elements in the loaded files array
            {
                switch (_loadedFiles[0].CheckName(nameTextBox.Text))
                {
                    case NameChangeResult.InvalidChars:
                    case NameChangeResult.Empty:
                        nameTextBox.Text = _originalName;
                        MessageBoxes.NameIsInvalidInfo(this);
                        break;

                    case NameChangeResult.AlreadyTaken:
                        nameTextBox.Text = _originalName;
                        MessageBoxes.NameIsTakenInfo(this);
                        break;

                    default:
                        DataWasEdited = true;
                        break;
                }
            }
        }

        private void OnFileWasEdited()
        {
            if (FileWasEdited != null)
            {
                foreach (var change in GetAllChanges())
                    FileWasEdited(this, change);
            }
        }
    }
}