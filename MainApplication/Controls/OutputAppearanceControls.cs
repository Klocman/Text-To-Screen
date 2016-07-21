using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Klocman.Binding.Settings;
using Klocman.Controls;
using Klocman.Subsystems;
using TextToScreen.Properties;

namespace TextToScreen.Controls
{
    public partial class OutputAppearanceControls : UserControl
    {
        private readonly ColorDialog _colorDialog = new ColorDialog();

        public OutputAppearanceControls()
        {
            InitializeComponent();

            var binder = Ustawienia.Default.Binder;

            binder.BindControl(boldToggle, ustawienia => ustawienia.ScreenFontBold, this);
            binder.BindControl(italicToggle, ustawienia => ustawienia.ScreenFontItalic, this);
            binder.BindControl(underlineToggle, ustawienia => ustawienia.ScreenFontUnderline, this);

            binder.BindControl(numericUpDownFontSize, ustawienia => ustawienia.ScreenFontSize, this);
            binder.BindControl(numericUpDownFadeDuration, ustawienia => ustawienia.ScreenFadeSpeed, this);

            binder.BindProperty(foregroundColorPreview, panel => panel.BackColor, nameof(BackColorChanged),
                ustawienia => ustawienia.ScreenForegroundColor, this);
            binder.BindProperty(backgroundColorPreview, panel => panel.BackColor, nameof(BackColorChanged),
                ustawienia => ustawienia.ScreenBackgroundColor, this);

            binder.BindProperty(pathSelectBoxImage, box => box.FileName, nameof(PathSelectBox.FileNameChanged),
                ustawienia => ustawienia.ScreenImagePath, this);

            binder.BindProperty(contentAlignmentBox1, box => box.SelectedContentAlignment,
                nameof(ContentAlignmentBox.SelectedContentAlignmentChanged),
                ustawienia => ustawienia.ScreenFontAlignment, this);

            comboBoxFontFamily.Items.Clear();
            comboBoxFontFamily.Items.AddRange(new FontGrabber().ValidFontFamilyNames.Cast<object>().ToArray());
            binder.Subscribe(OnFontFamilyChanged, ustawienia => ustawienia.ScreenFontFamily, this);

            binder.SendUpdates(this);
        }

        private void ForeColor_Click(object sender, EventArgs e)
        {
            _colorDialog.Color = foregroundColorPreview.BackColor;
            if (_colorDialog.ShowDialog(this) == DialogResult.OK)
                foregroundColorPreview.BackColor = _colorDialog.Color;
        }

        private void BackColor_Click(object sender, EventArgs e)
        {
            _colorDialog.Color = backgroundColorPreview.BackColor;
            if (_colorDialog.ShowDialog(this) == DialogResult.OK)
                backgroundColorPreview.BackColor = _colorDialog.Color;
        }

        private void OnFontFamilyChanged(object sender, SettingChangedEventArgs<string> args)
        {
            var item = comboBoxFontFamily.Items.Cast<string>().FirstOrDefault(x => x.Equals(args.NewValue));
            if (item != null)
                comboBoxFontFamily.SelectedItem = item;
            else
                comboBoxFontFamily.SelectedIndex = 0;
        }

        private void comboBoxFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = comboBoxFontFamily.SelectedItem as string;
            if (!string.IsNullOrEmpty(sel))
                Ustawienia.Default.ScreenFontFamily = sel;
            else
                comboBoxFontFamily.SelectedIndex = 0;

            var tempFontFamily = new FontFamily((string) comboBoxFontFamily.SelectedItem);
            boldToggle.Enabled = tempFontFamily.IsStyleAvailable(FontStyle.Bold);
            italicToggle.Enabled = tempFontFamily.IsStyleAvailable(FontStyle.Italic);
            underlineToggle.Enabled = tempFontFamily.IsStyleAvailable(FontStyle.Underline);
        }

        private void buttonClearImage_Click(object sender, EventArgs e)
        {
            pathSelectBoxImage.FileName = string.Empty;
        }
    }
}