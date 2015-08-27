﻿using System;
using System.Collections.Generic;

namespace TextToScreen.SpecialClasses
{
    public struct FileImporterResult
    {
        public readonly IDictionary<string, string> Errors;
        public readonly IEnumerable<SongFileEntry> Results;

        public FileImporterResult(IEnumerable<SongFileEntry> results, IDictionary<string, string> errors)
        {
            if (results == null || errors == null)
                throw new ArgumentNullException();
            Results = results;
            Errors = errors;
        }
    }
}