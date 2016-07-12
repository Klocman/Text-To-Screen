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