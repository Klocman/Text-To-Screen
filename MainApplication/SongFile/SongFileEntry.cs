using System;
using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zip;
using Klocman.Tools;
using TextToScreen.Misc;
using TextToScreen.Properties;

namespace TextToScreen.SongFile
{
    public sealed class SongFileEntry : IDisposable
    {
        private string _comment;
        private string _contents;
        private string _group;
        private string _name;
        private bool _savedToDisk;
        internal SongFileCollection ParentCollection;

        public SongFileEntry(string filename, string fileGroup, string fileContents, string fileComment,
            DateTime lastModifiedDate, DateTime creationDate)
        {
            _name = filename;
            _group = fileGroup;
            _contents = fileContents;
            _comment = fileComment ?? string.Empty;
            LastModified = lastModifiedDate;
            CreationTime = creationDate;

            SavedToDisk = true;
        }

        /// <summary>
        ///     Copy constructor
        /// </summary>
        public SongFileEntry(SongFileEntry source)
        {
            CopyValuesFromSource(source);
        }

        public SongFileEntry(ZipEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException();

            var fn = entry.FileName;
            _name = Path.GetFileNameWithoutExtension(fn);
            _group = Path.GetDirectoryName(fn);

            using (var memoryStream = new MemoryStream())
            {
                entry.Extract(memoryStream);
                using (var reader = new StreamReader(memoryStream))
                {
                    memoryStream.Position = 0;
                    _contents = reader.ReadToEnd();
                }
            }

            _comment = entry.Comment ?? string.Empty;
            LastModified = entry.LastModified;
            CreationTime = entry.CreationTime;

            SavedToDisk = true;
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (!_comment.Equals(value))
                {
                    _comment = value;
                    SavedToDisk = false;
                }
            }
        }

        public string Contents
        {
            get { return _contents; }
            set
            {
                if (!ReferenceEquals(_contents, value))
                {
                    _contents = value;
                    SavedToDisk = false;
                }
            }
        }

        public DateTime CreationTime { get; private set; }

        public string Group
        {
            get { return _group; }
            set
            {
                if (!_group.Equals(value))
                {
                    _group = value;
                    SavedToDisk = false;
                }
            }
        }

        public DateTime LastModified { get; private set; }

        /// <summary>
        ///     Will throw ArgumentExceptions if name contains invalid filename chars
        ///     or if it's already taken in the parent collection (if its set).
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (!_name.Equals(value))
                {
                    switch (CheckName(value))
                    {
                        case NameChangeResult.Empty:
                            throw new ArgumentException(Localisation.NameIsEmpty);
                        case NameChangeResult.AlreadyTaken:
                            throw new ArgumentException(Localisation.NameIsAlreadyTaken);
                        case NameChangeResult.InvalidChars:
                            throw new ArgumentException(Localisation.NameContainsInvalidChars);
                    }
                    _name = value;
                    SavedToDisk = false;
                }
            }
        }

        public bool SavedToDisk
        {
            get { return _savedToDisk; }
            set
            {
                _savedToDisk = value;
                if (value) return;
                LastModified = DateTime.Now;
                ParentCollection?.OnItemModified(this);
            }
        }

        public void Dispose()
        {
            ParentCollection = null;
        }

        public void AddToArchive(ZipFile archive)
        {
            if (archive == null)
                throw new ArgumentNullException();

            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(_group))
            {
                sb.Append(_group);
                sb.Append(Path.DirectorySeparatorChar);
            }
            sb.Append(_name);
            sb.Append(Resources.SongFileExtension);

            var ze = archive.AddEntry(sb.ToString(), _contents, Encoding.UTF8);
            ze.Comment = _comment;
            ze.CreationTime = CreationTime;
            ze.LastModified = LastModified;
        }

        public NameChangeResult CheckName(string nameToCheck)
        {
            if (string.IsNullOrEmpty(nameToCheck))
                return NameChangeResult.Empty;
            if (nameToCheck.Any(x => StringTools.InvalidFileNameChars.Contains(x)))
                return NameChangeResult.InvalidChars;
            if (ParentCollection != null && ParentCollection.Names.Contains(nameToCheck))
                return NameChangeResult.AlreadyTaken;
            return NameChangeResult.Ok;
        }

        public void CopyValuesFromSource(SongFileEntry source)
        {
            if (source == null)
                throw new ArgumentNullException();

            _name = source.Name;
            _group = source.Group;
            _contents = source.Contents;
            _comment = source.Comment ?? string.Empty;
            LastModified = source.LastModified;
            CreationTime = source.CreationTime;

            SavedToDisk = source.SavedToDisk;
        }

        public override string ToString()
        {
            return string.Format(Localisation.SongFileArchive_ToString_Format,
                Name, LastModified, CreationTime,
                string.IsNullOrEmpty(Comment) ? Localisation.SongFileArchive_ToString_MissingComment : Comment)
                   + Environment.NewLine + Environment.NewLine
                   + Contents.Trim().Replace(Resources.NewVerse, Environment.NewLine + Environment.NewLine);
        }
    }
}