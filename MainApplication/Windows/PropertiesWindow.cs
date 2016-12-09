using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TextToScreen.SongFile;

namespace TextToScreen.Windows
{
    public sealed partial class PropertiesWindow : Form
    {
        private readonly string _originalTitle;

        public PropertiesWindow()
        {
            InitializeComponent();
            _originalTitle = Text;
        }

        public DialogResult ShowPropertiesDialog(IWin32Window owner, IEnumerable<SongFileEntry> targets,
            bool allowEditing)
        {
            var songFileEntries = targets as IList<SongFileEntry> ?? targets.ToList();

            filePropertiesViewer1.Populate(songFileEntries, allowEditing);
            var count = songFileEntries.Count;

            Text = count > 4
                ? $"{_originalTitle} ({count} items)"
                : $"{_originalTitle} ({string.Join(", ", songFileEntries.Select(x => x.Name).ToArray())})";

            return ShowDialog(owner);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            AcceptChanges();
            filePropertiesViewer1.Repopulate();
        }

        private void AcceptChanges()
        {
            foreach (var change in filePropertiesViewer1.GetAllChanges())
            {
                change.TargetSongFileEntry.Name = change.NewName;
                change.TargetSongFileEntry.Group = change.NewGroup;
                change.TargetSongFileEntry.Comment = change.NewComment;
            }
        }

        private void PropertiesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.Cancel)
                AcceptChanges();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}