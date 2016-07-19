using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Klocman.Tools;
using TextToScreen.Misc;
using TextToScreen.Properties;
using TextToScreen.SongFile;
using TextToScreen.Windows;

namespace TextToScreen.ImportExport
{
    public static class FileImporter
    {
        public static FileImporterResult AutoImport(IEnumerable<string> fileNames)
        {
            if (fileNames == null)
                throw new ArgumentNullException();

            var completed = new List<SongFileEntry>();
            var failed = new Dictionary<string, string>();
            foreach (var fileName in fileNames)
            {
                try
                {
                    if (!File.Exists(fileName))
                        throw new FileNotFoundException(Localisation.FileNotFoundOnDisk);

                    SongFileEntry result;
                    var extension = Path.GetExtension(fileName)?.ToLower();
                    switch (extension)
                    {
                        case ".sng":
                            result = ImportUtorokSong(fileName);
                            break;

                        case ".txt":
                            result = ImportTextFile(fileName);
                            break;

                        case ".zip":
                            var archiveResult = ImportFromArchive(fileName);
                            if (archiveResult != null)
                                completed.AddRange(archiveResult);
                            continue;

                        default:
                            if (Resources.SongFileExtension.Equals(extension))
                                result = ImportTextFile(fileName);
                            else
                                throw new FormatException(Localisation.UnsupportedFileFormat);
                            break;
                    }
                    if (result != null)
                        completed.Add(result);
                    else
                        throw new InvalidDataException(Localisation.InvalidFileFormat);
                }
                catch (Exception ex)
                {
                    failed.Add(fileName, ex.Message);
                }
            }

            return new FileImporterResult(completed, failed);
        }

        public static bool CanImport(string fileName)
        {
            return
                new[] {".sng", ".txt", ".zip", Resources.SongFileExtension}.Contains(
                    Path.GetExtension(fileName)?.ToLower());
        }

        public static IEnumerable<SongFileEntry> ImportFromArchive(string from)
        {
            return MessageBoxes.ShowArchiveImportDialog(from);
        }

        public static SongFileEntry ImportTextFile(string from)
        {
            var allText = File.ReadAllText(from);

            string outputString;
            if (allText.Contains(SongFileEntry.NewVerse))
            {
                // File doesn't need to be converted since it seems to be in a correct fomat already
                outputString = allText;
            }
            else
            {
                var output = new StringBuilder();

                foreach (var line in allText.Split(StringTools.NewLineChars.ToArray(), StringSplitOptions.None))
                {
                    output.Append(string.IsNullOrEmpty(line) ? SongFileEntry.NewVerse : line.Trim());
                }

                outputString = output.ToString();
            }

            if (string.IsNullOrEmpty(outputString))
                return null;

            return new SongFileEntry(Path.GetFileNameWithoutExtension(from), Localisation.ImportGroupName,
                outputString, Localisation.ImportCommentTxt, DateTime.Now, File.GetCreationTime(from));
        }

        public static SongFileEntry ImportUtorokSong(string from)
        {
            var text = new List<string>(File.ReadAllLines(from));
            while (!text[0].Contains("\0\0xp\0\0\0") && text.Count > 1)
            {
                text[0] += "\x00" + text[1];
                text.Remove(text[1]);
            }
            var filename = Regex.Match(text[0], @"\x00\x00\x74\x00.+?\x74\x00");
            var targetName = string.Empty;
            if (filename.Success)
                targetName = Regex.Replace(filename.Value.Substring(5, filename.Value.Length - 7), @"[^\w ]",
                    string.Empty);

            if (!filename.Success || string.IsNullOrEmpty(targetName))
                targetName = Path.GetFileNameWithoutExtension(from);

            var output = new List<string>();
            var outText = text[0].Split(new[] {"\0\0xp\0\0\0"}, StringSplitOptions.RemoveEmptyEntries);

            if (outText.Length == 0 || text.Count <= 1)
                return null;

            if (outText.Length > 1)
                text[0] = outText[1];
            else
                text.RemoveAt(0);
            var fullText = string.Join("\r\n", text.ToArray());

            output.AddRange(fullText.Split(new[] {"t\0"}, StringSplitOptions.RemoveEmptyEntries));

            if (output.Count == 0)
                return null;

            for (var i = 0; i < output.Count; i++)
            {
                output[i] = output[i].Substring(1, output[i].Length - 1);
            }

            output[output.Count - 1] = output[output.Count - 1].TrimEnd('\x70', '\x78', '\0');
            output.RemoveAll(string.IsNullOrEmpty);

            return new SongFileEntry(targetName, Localisation.ImportGroupName,
                string.Join(SongFileEntry.NewVerse, output.ToArray()),
                Localisation.ImportCommentSng, DateTime.Now, File.GetCreationTime(from));
        }
    }
}