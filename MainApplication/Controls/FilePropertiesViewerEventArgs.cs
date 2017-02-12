/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System;
using TextToScreen.SongFile;

namespace TextToScreen.Controls
{
    public sealed class FilePropertiesViewerEventArgs : EventArgs, IDisposable
    {
        public FilePropertiesViewerEventArgs(SongFileEntry target, string name, string group, string comment)
        {
            TargetSongFileEntry = target;
            NewName = name;
            NewGroup = group;
            NewComment = comment;
        }

        public string NewComment { get; private set; }
        public string NewGroup { get; private set; }
        public string NewName { get; private set; }
        public SongFileEntry TargetSongFileEntry { get; private set; }

        public void Dispose()
        {
            TargetSongFileEntry = null;
        }
    }
}