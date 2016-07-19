using System;
using System.IO;
using Klocman.Binding.Settings;

namespace TextToScreen.Properties
{
    public sealed partial class Ustawienia
    {
        public Ustawienia()
        {
            Binder = new SettingBinder<Ustawienia>(this);
        }
        
        public static Ustawienia DefaultValues { get; } = ((Ustawienia)(Synchronized(new Ustawienia())));

        public SettingBinder<Ustawienia> Binder { get; }

        /// <summary>
        ///     Add file to recent items if it exists
        /// </summary>
        public static void AddRecentItem(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                if (Default.AutoRecentItems.Contains(path))
                    Default.AutoRecentItems.Remove(path);
                Default.AutoRecentItems.Add(path);
            }

            TrimRecentItems();
        }

        /// <summary>
        ///     Remove recent items that are no longer needed
        /// </summary>
        public static void TrimRecentItems()
        {
            while (Default.AutoRecentItems.Count > Default.GeneralHistoryPoints && Default.GeneralHistoryPoints > 0)
                Default.AutoRecentItems.RemoveAt(0);
        }
    }
}