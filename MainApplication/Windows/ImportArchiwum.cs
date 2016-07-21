using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Ionic.Zip;
using TextToScreen.Misc;
using TextToScreen.Properties;
using TextToScreen.SongFile;

namespace TextToScreen.Windows
{
    public sealed partial class ImportArchiwum : Form
    {
        private readonly Dictionary<string, ZipEntry> _filesInsideArchive = new Dictionary<string, ZipEntry>();

        private ImportArchiwum()
        {
            InitializeComponent();
        }

        public static IEnumerable<SongFileEntry> ShowDialog(string sourceFile)
        {
            if (!File.Exists(sourceFile))
                return Enumerable.Empty<SongFileEntry>();

            using (var importDialog = new ImportArchiwum())
            {
                importDialog.Text += Ustawienia.Default.OknoGlowneInnePokazujPelnaSciezkeArchiwum
                    ? sourceFile
                    : Path.GetFileName(sourceFile);

                using (var zip = ZipFile.Read(sourceFile))
                {
                    foreach (var item in zip)
                    {
                        var extension = Path.GetExtension(item.FileName);
                        if (extension == null || !extension.ToLower().Contains("txt"))
                            continue;

                        importDialog._filesInsideArchive.Add(Path.GetFileNameWithoutExtension(item.FileName ?? string.Empty), item);
                    }
                }

                importDialog.listBox1.Items.AddRange(importDialog._filesInsideArchive.Keys.Cast<object>().ToArray());

                if (importDialog.ShowDialog() != DialogResult.OK)
                    return Enumerable.Empty<SongFileEntry>();

                var importComment = $"{Localisation.ImportCommentZip} ({Path.GetFileName(sourceFile)})";

                return (from file in importDialog._filesInsideArchive
                    where importDialog.listBox1.SelectedItems.Contains(file.Key)
                    select new SongFileEntry(file.Value) {Comment = importComment, Group = Localisation.ImportGroupName})
                    .ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SetSelected(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SetSelected(i, false);
            }
        }

        private void importbut_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBoxes.NothingToImportInfo(this);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}