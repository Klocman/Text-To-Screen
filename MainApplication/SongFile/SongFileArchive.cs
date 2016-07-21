using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zip;
using Klocman.IO;
using TextToScreen.Properties;

namespace TextToScreen.SongFile
{
    public sealed class SongFileArchive : IDisposable
    {
        private readonly FileSystemTools _fsTools;
        private string _fullName;

        /// <summary>
        ///     Will throw ArgumentException if selected archive contains unsupported files (basically not *.txt).
        /// </summary>
        public SongFileArchive(string fullArchivePath)
        {
            if (File.Exists(fullArchivePath))
            {
                using (var zip = ZipFile.Read(fullArchivePath))
                {
                    if (!CheckArchiveForBadEntries(zip))
                        throw new ArgumentException(Localisation.ArchiveContainsUnsupportedFiles);
                }
            }

            FullName = fullArchivePath;

            if (!IsWrittenToDisk)
                LoadedFiles.CollectionWasModified = true;

            _fsTools = new FileSystemTools(fullArchivePath)
            {
                ContentsChangedExternally = x => OnArchiveContentsChangedExternally(x),
                NameChangedExternally = x => OnArchiveNameChangedExternally(x)
            };
            _fsTools.SetEnabled(true);
        }

        /// <summary>
        ///     Check if all entries are saved to disk
        /// </summary>
        public bool AllSavedToDisk
        {
            get { return !LoadedFiles.CollectionWasModified && LoadedFiles.All(x => x.SavedToDisk); }
            private set
            {
                if (value)
                {
                    foreach (var item in LoadedFiles)
                        item.SavedToDisk = true;
                    LoadedFiles.CollectionWasModified = false;
                }
                else
                    LoadedFiles.CollectionWasModified = true;
            }
        }

        /// <summary>
        ///     Directory the archive file is in.
        /// </summary>
        public string Directory => Path.GetDirectoryName(_fullName);

        /// <summary>
        ///     Name of the loaded archive
        /// </summary>
        public string FilenameWithExtension => Path.GetFileName(_fullName);

        /// <summary>
        ///     Full path to the archive file.
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set
            {
                value = string.IsNullOrEmpty(value) ? string.Empty : Path.GetFullPath(value);
                if (_fullName == value) return;
                _fullName = value;
                OnFullNameChanged();
            }
        }

        /// <summary>
        ///     Check if the archive has a file system representation.
        /// </summary>
        public bool IsWrittenToDisk => !string.IsNullOrEmpty(_fullName) && File.Exists(_fullName);

        /// <summary>
        ///     Elements inside of the archive
        /// </summary>
        public SongFileCollection LoadedFiles { get; } = new SongFileCollection();

        /// <summary>
        ///     Should the file be locked from opening by external applications
        /// </summary>
        public bool LockArchiveFile
        {
            get { return _fsTools.LockFile; }
            set { _fsTools.LockFile = value; }
        }

        /// <summary>
        ///     Monitors archive file on hdd for any changes, and fires respective events if they happen.
        ///     Takes effect only if LockFile is disabled.
        /// </summary>
        public bool MonitorExternalChanges
        {
            get { return _fsTools.MonitorExternalChanges; }
            set { _fsTools.MonitorExternalChanges = value; }
        }

        public void Dispose()
        {
            ArchiveLoaded = null;
            ArchiveSaved = null;
            LoadedFiles.Dispose();
            _fsTools.Dispose();
        }

        public event Action<SongFileArchive, FileSystemEventArgs> ArchiveContentsChangedExternally;
        public event Action<SongFileArchive> ArchiveLoaded;
        public event Action<SongFileArchive, RenamedEventArgs> ArchiveNameChangedExternally;
        public event Action<SongFileArchive> ArchiveSaved;
        public event Action<SongFileArchive> FullNameChanged;

        /// <summary>
        ///     Read archive from hdd. Will throw if supplied archive path is going nowhere or if the file is in any way
        ///     inaccessible or corrupted.
        /// </summary>
        public void ReadAllFromDisk()
        {
            if (string.IsNullOrEmpty(_fullName))
                throw new InvalidOperationException(Localisation.ArchivePathNullException);

            _fsTools.SetEnabled(false);
            if (!File.Exists(_fullName))
            {
                using (var zip = new ZipFile())
                {
                    zip.Save(_fullName);
                }
                LoadedFiles.Clear();
            }
            else
            {
                using (var zip = ZipFile.Read(_fullName))
                {
                    if (!CheckArchiveForBadEntries(zip))
                        throw new ArgumentException(Localisation.ArchiveContainsUnsupportedFiles);

                    LoadedFiles.Clear();
                    LoadedFiles.AddRange(zip.Where(x => !x.IsDirectory).Select(item => new SongFileEntry(item)));
                }
            }

            AllSavedToDisk = true;
            _fsTools.SetEnabled(true);
            OnArchiveLoaded();
        }

        /// <summary>
        ///     Read archive from hdd. Will throw if supplied archive path is invalid or taken by locked/inaccessible/whatever
        ///     archive.
        ///     Will throw FormatException if any of the entries could not be saved.
        /// </summary>
        public void WriteAllToDisk()
        {
            if (string.IsNullOrEmpty(_fullName))
                throw new InvalidOperationException(Localisation.ArchivePathNullException);

            _fsTools.SetEnabled(false);

            var badItems = new List<string>();
            using (var zip = new ZipFile(Encoding.UTF8))
            {
                foreach (var item in LoadedFiles)
                {
                    try
                    {
                        item.AddToArchive(zip);
                    }
                    catch (ArgumentException)
                    {
                        badItems.Add(item.Name);
                    }
                }

                //File.Delete(songArchivePath);
                zip.Save(_fullName);
            }

            //TODO check for bad items
            // Set saved to disk flags after the archive has been confirmed to be saved
            AllSavedToDisk = true;
            OnArchiveSaved();

            if (badItems.Count > 0)
            {
                var sb = new StringBuilder();
                sb.AppendLine(Localisation.ArchiveFilesFailedToSaveHeader);
                foreach (var item in badItems)
                {
                    sb.AppendLine(item);
                }
                throw new FormatException(sb.ToString());
            }

            _fsTools.SetEnabled(true);
        }

        private bool CheckArchiveForBadEntries(IEnumerable<ZipEntry> archive)
        {
            return !archive.Any(x => !x.IsDirectory &&
                                     !string.Equals(Path.GetExtension(x.FileName), Resources.SongFileExtension,
                                         StringComparison.OrdinalIgnoreCase));
        }

        private void OnArchiveContentsChangedExternally(FileSystemEventArgs e)
        {
            ArchiveContentsChangedExternally?.Invoke(this, e);
        }

        private void OnArchiveLoaded()
        {
            ArchiveLoaded?.Invoke(this);
        }

        private void OnArchiveNameChangedExternally(RenamedEventArgs e)
        {
            ArchiveNameChangedExternally?.Invoke(this, e);
        }

        private void OnArchiveSaved()
        {
            _fsTools?.UpdateLastWriteTime();

            ArchiveSaved?.Invoke(this);
        }

        private void OnFullNameChanged()
        {
            _fsTools?.SetupNewPath(FullName);

            FullNameChanged?.Invoke(this);
        }
    }
}