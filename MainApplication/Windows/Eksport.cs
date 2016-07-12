using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextToScreen.Misc;
using TextToScreen.SongFile;

namespace TextToScreen.Windows
{
    public sealed partial class Eksport : Form
    {
        private SongFileArchive _tempSource;

        public Eksport()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(IWin32Window owner, SongFileArchive source)
        {
            if (owner == null || source == null)
                throw new ArgumentNullException();

            Owner = (Form) owner;
            _tempSource = source;
            fileListView.PopulateItems(source.LoadedFiles);
            return base.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileListView.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileListView.SelectNone();
        }

        private void eksportbut_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedFiles.Any())
                eksportujDialog.ShowDialog();
            else
                MessageBoxes.NothingToExportInfo(this);
        }

        private void eksportujDialog_FileOk(object sender, CancelEventArgs e)
        {
            var str = new StringBuilder();

            str.AppendFormat("Eksport {0} plików z archiwum \"{1}\". Data wykonania eksportu: {2}",
                fileListView.SelectedFiles.Count(), _tempSource.FullName, DateTime.Now);

            ExportSongsToString(fileListView.SelectedFiles, str);

            File.WriteAllText(eksportujDialog.FileName, str.ToString());

            Close();
        }

        public static void ExportSongsToString(IEnumerable<SongFileEntry> items, StringBuilder target)
        {
            var i = 0;
            foreach (var file in items)
            {
                i++;
                target.Append(string.Format("{0}{0}{0}#{1} - ", i == 1 ? string.Empty : Environment.NewLine, i));
                target.Append(file);
            }
        }

        private void Eksport_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tempSource = null;
            fileListView.ClearAllItems(true);
            Owner = null;
        }
    }
}