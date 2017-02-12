﻿/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Klocman.Extensions;
using Klocman.Forms.Tools;
using TextToScreen.Misc;
using TextToScreen.Properties;

namespace TextToScreen.Windows
{
    public partial class LanguageChangeWindow : Form
    {
        private LanguageChangeWindow()
        {
            Opacity = 0;

            InitializeComponent();

            comboBoxLanguage.Items.Add(Localisation.DefaultLanguage);
            foreach (var languageCode in CultureConfigurator.SupportedLanguages.OrderBy(x => x.DisplayName))
            {
                comboBoxLanguage.Items.Add(new ComboBoxWrapper<CultureInfo>(languageCode, x => x.DisplayName));
            }

            var selectedItem = comboBoxLanguage.Items.OfType<ComboBoxWrapper<CultureInfo>>()
                .FirstOrDefault(x => x.WrappedObject.Name.Equals(Ustawienia.Default.LanguageOverride));
            if (selectedItem != null)
            {
                comboBoxLanguage.SelectedItem = selectedItem;
            }
            else
            {
                comboBoxLanguage.SelectedIndex = 0;
            }
        }

        public static bool ShowLanguageChangeDialog(Form owner)
        {
            using (var window = new LanguageChangeWindow())
            {
                window.StartPosition = FormStartPosition.CenterParent;
                return window.ShowDialog(owner) != DialogResult.Cancel;
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Ustawienia.Default.LanguageOverride = comboBoxLanguage.SelectedIndex == 0
                ? string.Empty
                : ((ComboBoxWrapper<CultureInfo>) comboBoxLanguage.SelectedItem).WrappedObject.Name;

            Ustawienia.Default.Save();

            DialogResult = DialogResult.OK;
        }

        private void LanguageChangeWindow_Shown(object sender, EventArgs e)
        {
            // Autosize the form
            Height = this.GetBorderHeight() + panelButtons.Location.Y + panelButtons.Height + Padding.Bottom +
                     this.GetBorderWidth();
            Opacity = 1;
        }
    }
}