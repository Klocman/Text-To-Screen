﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextToScreen.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    public sealed partial class Ustawienia : global::System.Configuration.ApplicationSettingsBase {
        
        private static Ustawienia defaultInstance = ((Ustawienia)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Ustawienia())));
        
        public static Ustawienia Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MiddleCenter")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public global::System.Drawing.ContentAlignment ScreenFontAlignment {
            get {
                return ((global::System.Drawing.ContentAlignment)(this["ScreenFontAlignment"]));
            }
            set {
                this["ScreenFontAlignment"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Arial")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string ScreenFontFamily {
            get {
                return ((string)(this["ScreenFontFamily"]));
            }
            set {
                this["ScreenFontFamily"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public decimal ScreenFontSize {
            get {
                return ((decimal)(this["ScreenFontSize"]));
            }
            set {
                this["ScreenFontSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point AutoOknoGlownePozycja {
            get {
                return ((global::System.Drawing.Point)(this["AutoOknoGlownePozycja"]));
            }
            set {
                this["AutoOknoGlownePozycja"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point AutoOknoDocelowePozycja {
            get {
                return ((global::System.Drawing.Point)(this["AutoOknoDocelowePozycja"]));
            }
            set {
                this["AutoOknoDocelowePozycja"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool OknoGlowneFull {
            get {
                return ((bool)(this["OknoGlowneFull"]));
            }
            set {
                this["OknoGlowneFull"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool OknoGlowneTop {
            get {
                return ((bool)(this["OknoGlowneTop"]));
            }
            set {
                this["OknoGlowneTop"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool OknoDoceloweFull {
            get {
                return ((bool)(this["OknoDoceloweFull"]));
            }
            set {
                this["OknoDoceloweFull"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool OknoDoceloweTop {
            get {
                return ((bool)(this["OknoDoceloweTop"]));
            }
            set {
                this["OknoDoceloweTop"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool OknoGlowneKeysNumbers {
            get {
                return ((bool)(this["OknoGlowneKeysNumbers"]));
            }
            set {
                this["OknoGlowneKeysNumbers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool OknoGlowneKeysArrows {
            get {
                return ((bool)(this["OknoGlowneKeysArrows"]));
            }
            set {
                this["OknoGlowneKeysArrows"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool OknoDoceloweHideCursor {
            get {
                return ((bool)(this["OknoDoceloweHideCursor"]));
            }
            set {
                this["OknoDoceloweHideCursor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.5")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public decimal ScreenFadeSpeed {
            get {
                return ((decimal)(this["ScreenFadeSpeed"]));
            }
            set {
                this["ScreenFadeSpeed"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("White")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public global::System.Drawing.Color ScreenForegroundColor {
            get {
                return ((global::System.Drawing.Color)(this["ScreenForegroundColor"]));
            }
            set {
                this["ScreenForegroundColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Black")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public global::System.Drawing.Color ScreenBackgroundColor {
            get {
                return ((global::System.Drawing.Color)(this["ScreenBackgroundColor"]));
            }
            set {
                this["ScreenBackgroundColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("OpenRecent")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public global::TextToScreen.Misc.StartupAction GeneralStartAction {
            get {
                return ((global::TextToScreen.Misc.StartupAction)(this["GeneralStartAction"]));
            }
            set {
                this["GeneralStartAction"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string GeneralStartPath {
            get {
                return ((string)(this["GeneralStartPath"]));
            }
            set {
                this["GeneralStartPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool GeneralHistoryEnabled {
            get {
                return ((bool)(this["GeneralHistoryEnabled"]));
            }
            set {
                this["GeneralHistoryEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public int GeneralHistoryPoints {
            get {
                return ((int)(this["GeneralHistoryPoints"]));
            }
            set {
                this["GeneralHistoryPoints"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Size AutoOknoDoceloweRozmiar {
            get {
                return ((global::System.Drawing.Size)(this["AutoOknoDoceloweRozmiar"]));
            }
            set {
                this["AutoOknoDoceloweRozmiar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Size AutoOknoGlowneRozmiar {
            get {
                return ((global::System.Drawing.Size)(this["AutoOknoGlowneRozmiar"]));
            }
            set {
                this["AutoOknoGlowneRozmiar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoOknoGlowneMaximized {
            get {
                return ((bool)(this["AutoOknoGlowneMaximized"]));
            }
            set {
                this["AutoOknoGlowneMaximized"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoOknoDoceloweMaximized {
            get {
                return ((bool)(this["AutoOknoDoceloweMaximized"]));
            }
            set {
                this["AutoOknoDoceloweMaximized"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool OknoGlowneInnePokazujPelnaSciezkeArchiwum {
            get {
                return ((bool)(this["OknoGlowneInnePokazujPelnaSciezkeArchiwum"]));
            }
            set {
                this["OknoGlowneInnePokazujPelnaSciezkeArchiwum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool OknoGlowneInnePokazujPasekPostepuPrzejscia {
            get {
                return ((bool)(this["OknoGlowneInnePokazujPasekPostepuPrzejscia"]));
            }
            set {
                this["OknoGlowneInnePokazujPasekPostepuPrzejscia"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool GeneralInneDostepZewnetrznyDoArchiwum {
            get {
                return ((bool)(this["GeneralInneDostepZewnetrznyDoArchiwum"]));
            }
            set {
                this["GeneralInneDostepZewnetrznyDoArchiwum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool GeneralInneSprawdzajZewnetrzneZmiany {
            get {
                return ((bool)(this["GeneralInneSprawdzajZewnetrzneZmiany"]));
            }
            set {
                this["GeneralInneSprawdzajZewnetrzneZmiany"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool _FirstStartCompleted {
            get {
                return ((bool)(this["_FirstStartCompleted"]));
            }
            set {
                this["_FirstStartCompleted"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string OtwarteArchiwum {
            get {
                return ((string)(this["OtwarteArchiwum"]));
            }
            set {
                this["OtwarteArchiwum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ScreenFontBold {
            get {
                return ((bool)(this["ScreenFontBold"]));
            }
            set {
                this["ScreenFontBold"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ScreenFontItalic {
            get {
                return ((bool)(this["ScreenFontItalic"]));
            }
            set {
                this["ScreenFontItalic"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ScreenFontUnderline {
            get {
                return ((bool)(this["ScreenFontUnderline"]));
            }
            set {
                this["ScreenFontUnderline"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ScreenImagePath {
            get {
                return ((string)(this["ScreenImagePath"]));
            }
            set {
                this["ScreenImagePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LanguageOverride {
            get {
                return ((string)(this["LanguageOverride"]));
            }
            set {
                this["LanguageOverride"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider.PortableSettingsProvider))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>Example Song Archive.zip</string>\r\n</ArrayOfString>")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public global::System.Collections.Specialized.StringCollection AutoRecentItems {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["AutoRecentItems"]));
            }
            set {
                this["AutoRecentItems"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool GeneralCheckForUpdates {
            get {
                return ((bool)(this["GeneralCheckForUpdates"]));
            }
            set {
                this["GeneralCheckForUpdates"] = value;
            }
        }
    }
}
