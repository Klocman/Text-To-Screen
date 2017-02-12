/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TextToScreen.Properties;
using TextToScreen.SongFile;
using TextToScreen.Windows;

namespace TextToScreen.Misc
{
    public static class MessageBoxes
    {
        private static readonly Eksport EksportWindow = new Eksport();
        private static readonly DodajPlik FileNameEditWindow = new DodajPlik();
        private static readonly PropertiesWindow PropertiesWindow = new PropertiesWindow();
        private static readonly SettingsWindow SettingsWindow = new SettingsWindow();

        public static void ApplicationAlreadyRunningInfo()
        {
            MessageBox.Show(Localisation.MessageBoxes_ApplicationAlreadyRunningInfo_Message,
                Localisation.MessageBoxes_ApplicationAlreadyRunningInfo_Title, MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        public static bool ArchiveContentsChangedExternally(IWin32Window owner)
        {
            return MessageBox.Show(owner, Localisation.MessageBoxes_ArchiveContentsChangedExternally_Message,
                Localisation.MessageBoxes_ArchiveContentsChangedExternally_Title, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void ArchiveDoesNotExist(IWin32Window owner, string fileName)
        {
            MessageBox.Show(owner, string.Format(Localisation.MessageBoxes_ArchiveDoesNotExist_Message, fileName),
                Localisation.MessageBoxes_ArchiveDoesNotExist_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ArchiveNameChangedExternally(IWin32Window owner)
        {
            return MessageBox.Show(owner, Localisation.MessageBoxes_ArchiveNameChangedExternally_Message,
                Localisation.MessageBoxes_ArchiveNameChangedExternally_Title, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static bool FirstStartQuestion(IWin32Window owner)
        {
            return MessageBox.Show(owner, Localisation.MessageBoxes_FirstStartQuestion_Message,
                Localisation.MessageBoxes_FirstStartQuestion_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                   DialogResult.Yes;
        }

        public static void GroupIsInvalidInfo(IWin32Window owner)
        {
            MessageBox.Show(owner,
                Localisation.MessageBoxes_GroupIsInvalidInfo_Message + new string(Path.GetInvalidPathChars()),
                Localisation.MessageBoxes_GroupIsInvalidInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void HelpDefault(Control owner)
        {
            Help.ShowHelp(owner, Localisation.HelpFilePath, HelpNavigator.Topic, "1_InfoOgolne.html");
        }

        public static void HelpHotkeys(Control owner)
        {
            Help.ShowHelp(owner, Localisation.HelpFilePath, HelpNavigator.Topic, "5_Hotkeys.html");
        }

        public static void HelpSettings(Control owner)
        {
            Help.ShowHelp(owner, Localisation.HelpFilePath, HelpNavigator.Topic, "6_Ustawienia.html");
        }

        public static void HelpWhatsNew(Control owner)
        {
            Help.ShowHelp(owner, Localisation.HelpFilePath, HelpNavigator.Topic, "2_CoNowego.html");
        }

        public static void InvalidArchiveInfo(IWin32Window owner)
        {
            MessageBox.Show(owner,
                Localisation.MessageBoxes_InvalidArchiveInfo_Message,
                Localisation.MessageBoxes_InvalidArchiveInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void NameIsInvalidInfo(IWin32Window owner)
        {
            MessageBox.Show(owner,
                Localisation.MessageBoxes_NameIsInvalidInfo_Message + new string(Path.GetInvalidFileNameChars()),
                Localisation.MessageBoxes_NameIsInvalidInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void NameIsTakenInfo(IWin32Window owner)
        {
            MessageBox.Show(owner, Localisation.MessageBoxes_NameIsTakenInfo_Message,
                Localisation.MessageBoxes_NameIsTakenInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void NothingToExportInfo(IWin32Window owner)
        {
            MessageBox.Show(owner, Localisation.MessageBoxes_NothingToExportInfo_Message,
                Localisation.MessageBoxes_NothingToExportInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void NothingToImportInfo(IWin32Window owner)
        {
            MessageBox.Show(owner,
                Localisation.MessageBoxes_NothingToImportInfo_Message,
                Localisation.MessageBoxes_NothingToImportInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool RemoveSelectedFiles(IWin32Window owner)
        {
            return MessageBox.Show(owner, Localisation.MessageBoxes_RemoveSelectedFiles_Message,
                Localisation.MessageBoxes_RemoveSelectedFiles_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                   DialogResult.Yes;
        }

        /// <summary>
        ///     MessageBoxButtons.YesNoCancel
        /// </summary>
        public static DialogResult SaveChangesToOpenedArchive(IWin32Window owner)
        {
            return MessageBox.Show(owner, Localisation.MessageBoxes_SaveChangesToOpenedArchive_Message,
                Localisation.MessageBoxes_SaveChangesToOpenedArchive_Title, MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
        }

        /// <summary>
        ///     MessageBoxButtons.YesNoCancel
        /// </summary>
        public static DialogResult SaveChangesToOpenedFile(IWin32Window owner)
        {
            return MessageBox.Show(owner, Localisation.MessageBoxes_SaveChangesToOpenedFile_Message,
                Localisation.MessageBoxes_SaveChangesToOpenedFile_Message, MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
        }

        public static IEnumerable<SongFileEntry> ShowArchiveImportDialog(string sourceFile)
        {
            return ImportArchiwum.ShowDialog(sourceFile);
        }

        public static DialogResult ShowExportDialog(IWin32Window owner, SongFileArchive source)
        {
            return EksportWindow.ShowDialog(owner, source);
        }

        public static DialogResult ShowFileNameChangeDialog(IWin32Window owner, SongFileEntry target, bool creatingNew)
        {
            return FileNameEditWindow.ShowDialog(owner, target, creatingNew);
        }

        public static DialogResult ShowPropertiesDialog(IWin32Window owner, IEnumerable<SongFileEntry> targets,
            bool allowEditing)
        {
            return PropertiesWindow.ShowPropertiesDialog(owner, targets, allowEditing);
        }

        public static DialogResult ShowSettingsDialog(IWin32Window owner, Ustawienia targetSettings,
            Ustawienia defaultSettings)
        {
            return SettingsWindow.ShowDialog(owner, targetSettings, defaultSettings);
        }
    }
}