using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Klocman.Extensions;
using TextToScreen.Misc;
using TextToScreen.Properties;

namespace TextToScreen.Windows
{
    public sealed partial class SettingsWindow : Form
    {
        private Ustawienia _defaultSettings;
        private Ustawienia _targetSettings;

        public SettingsWindow()
        {
            InitializeComponent();

            SetupCheckBoxes(Controls.Cast<Control>());
        }

        public DialogResult ShowDialog(IWin32Window owner, Ustawienia target, Ustawienia defaults)
        {
            Owner = (Form) owner;
            _targetSettings = target;
            _defaultSettings = defaults;
            PopulateControls();
            tabControl1.SelectedIndex = 0;
            return ShowDialog(owner);
        }

        protected override void OnHelpButtonClicked(CancelEventArgs e)
        {
            MessageBoxes.HelpSettings(this);
            e.Cancel = true;
        }

        private void ApplySettings()
        {
            // General
            if (general_appstart_radioButton1.Checked)
                _targetSettings.GeneralStartAction = StartupAction.DoNothing;
            else if (general_appstart_radioButton2.Checked)
                _targetSettings.GeneralStartAction = StartupAction.OpenRecent;
            else if (general_appstart_radioButton3.Checked)
                _targetSettings.GeneralStartAction = StartupAction.OpenSelected;

            _targetSettings.GeneralStartPath = general_appstart_pathSelectBox1.FileName;
            _targetSettings.GeneralHistoryEnabled = general_history_checkBox3.CheckState.ToBool();
            _targetSettings.GeneralHistoryPoints = (int) general_history_numericUpDown1.Value;

            _targetSettings.GeneralInneDostepZewnetrznyDoArchiwum =
                general_other_allowExternalArchiveAcces.CheckState.ToBool();
            _targetSettings.GeneralInneSprawdzajZewnetrzneZmiany =
                general_other_checkForExternalChanges.CheckState.ToBool();
            _targetSettings.GeneralCheckForUpdates = 
                checkBoxAutoUpdates.CheckState.ToBool();

            // Okno główne
            _targetSettings.OknoGlowneFull = main_window_checkBoxFull.CheckState.ToBool();
            _targetSettings.OknoGlowneTop = main_window_checkBoxTop.CheckState.ToBool();

            _targetSettings.OknoGlowneKeysNumbers = main_keys_checkBox1.CheckState.ToBool();
            _targetSettings.OknoGlowneKeysArrows = main_keys_checkBox2.CheckState.ToBool();

            _targetSettings.OknoGlowneInnePokazujPasekPostepuPrzejscia = main_other_showProgressBar.CheckState.ToBool();
            _targetSettings.OknoGlowneInnePokazujPelnaSciezkeArchiwum = main_other_showFullPath.CheckState.ToBool();

            // Okno wyjściowe
            _targetSettings.OknoDoceloweFull = secondary_window_checkBoxFull.CheckState.ToBool();
            _targetSettings.OknoDoceloweTop = secondary_window_checkBoxTop.CheckState.ToBool();
            _targetSettings.OknoDoceloweHideCursor = secondary_window_checkBoxPointer.CheckState.ToBool();

            buttonAccept.Enabled = false;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void general_appstart_radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (general_appstart_radioButton1.Checked)
            {
                general_appstart_pathSelectBox1.Enabled = false;
            }
        }

        private void general_appstart_radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (general_appstart_radioButton2.Checked)
            {
                general_appstart_pathSelectBox1.Enabled = false;
            }
        }

        private void general_appstart_radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (general_appstart_radioButton3.Checked)
            {
                general_appstart_pathSelectBox1.Enabled = true;
            }
        }

        private void general_button_factorySettings_Click(object sender, EventArgs e)
        {
            SetupTabGeneral(_defaultSettings);
        }

        private void general_history_checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            var r = general_history_checkBox3.CheckState == CheckState.Checked;
            general_history_numericUpDown1.Enabled = r;
            general_history_label2.Enabled = r;
            general_appstart_radioButton2.Enabled = r;
            if (general_appstart_radioButton2.Checked)
                general_appstart_radioButton1.Checked = true;
        }

        private void general_other_allowExternalArchiveAcces_CheckedChanged(object sender, EventArgs e)
        {
            general_other_checkForExternalChanges.Enabled = general_other_allowExternalArchiveAcces.CheckState.ToBool();
        }

        private void main_button_factorySettings_Click(object sender, EventArgs e)
        {
            SetupTabMain(_defaultSettings);
        }

        private void main_keys_listButton_Click(object sender, EventArgs e)
        {
            MessageBoxes.HelpHotkeys(this);
        }

        private void PopulateControls()
        {
            SetupTabGeneral(_targetSettings);
            SetupTabMain(_targetSettings);
            SetupTabSecondary(_targetSettings);

            buttonAccept.Enabled = false;
        }

        private void secondary_button_factorySettings_Click(object sender, EventArgs e)
        {
            SetupTabSecondary(_defaultSettings);
            buttonAccept.Enabled = true;
        }

        // Events ---------------------------------------------------------------------------------------
        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _targetSettings = null;
            _defaultSettings = null;
            Owner = null;
        }

        private void SettingWasChanged(object sender, EventArgs e)
        {
            buttonAccept.Enabled = true;
        }

        private void SetupCheckBoxes(IEnumerable<Control> controls)
        {
            foreach (var control in controls)
            {
                var cb = control as CheckBox;
                if (cb != null)
                    cb.CheckedChanged += SettingWasChanged;
                if (control.Controls.Count > 0)
                    SetupCheckBoxes(control.Controls.Cast<Control>());
            }
        }

        private void SetupTabGeneral(Ustawienia settingSet)
        {
            switch (settingSet.GeneralStartAction)
            {
                case StartupAction.DoNothing:
                    general_appstart_radioButton1.Checked = true;
                    break;
                case StartupAction.OpenRecent:
                    general_appstart_radioButton2.Checked = true;
                    break;
                case StartupAction.OpenSelected:
                    general_appstart_radioButton3.Checked = true;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            general_appstart_pathSelectBox1.FileName = settingSet.GeneralStartPath;
            general_history_checkBox3.CheckState = settingSet.GeneralHistoryEnabled.ToCheckState();
            //general_history_checkBox3_CheckedChanged(null, null); // Needed in case old and new CheckState are the same (event wont fire)
            general_history_numericUpDown1.Value = settingSet.GeneralHistoryPoints;

            general_other_allowExternalArchiveAcces.CheckState =
                settingSet.GeneralInneDostepZewnetrznyDoArchiwum.ToCheckState();
            general_other_checkForExternalChanges.CheckState =
                settingSet.GeneralInneSprawdzajZewnetrzneZmiany.ToCheckState();
            checkBoxAutoUpdates.CheckState = 
                _targetSettings.GeneralCheckForUpdates.ToCheckState();
        }

        private void SetupTabMain(Ustawienia settingSet)
        {
            main_window_checkBoxTop.CheckState = settingSet.OknoGlowneFull.ToCheckState();
            main_window_checkBoxFull.CheckState = settingSet.OknoGlowneTop.ToCheckState();

            //main_keys_checkBoxEnabled_CheckedChanged(null, null); // Needed in case old and new CheckState are the same (event wont fire)
            main_keys_checkBox1.CheckState = settingSet.OknoGlowneKeysNumbers.ToCheckState();
            main_keys_checkBox2.CheckState = settingSet.OknoGlowneKeysArrows.ToCheckState();

            main_other_showProgressBar.CheckState = settingSet.OknoGlowneInnePokazujPasekPostepuPrzejscia.ToCheckState();
            main_other_showFullPath.CheckState = settingSet.OknoGlowneInnePokazujPelnaSciezkeArchiwum.ToCheckState();
        }

        private void SetupTabSecondary(Ustawienia settingSet)
        {
            secondary_window_checkBoxTop.CheckState = settingSet.OknoDoceloweTop.ToCheckState();
            secondary_window_checkBoxFull.CheckState = settingSet.OknoDoceloweFull.ToCheckState();
            secondary_window_checkBoxPointer.CheckState = settingSet.OknoDoceloweHideCursor.ToCheckState();
        }
    }
}