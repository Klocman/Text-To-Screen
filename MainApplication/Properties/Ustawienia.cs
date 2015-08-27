namespace TextToScreen.Properties
{
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    public sealed partial class Ustawienia
    {
        public static Ustawienia MainSettingSet { get; } = ((Ustawienia) (Synchronized(new Ustawienia())));
        public static Ustawienia SelectedSettingSet { get; set; }
    }
}