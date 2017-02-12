/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System;

namespace TextToScreen.Misc
{
    [Serializable]
    public enum StartupAction
    {
        DoNothing = 0,
        OpenRecent = 1,
        OpenSelected = 2
    }
}