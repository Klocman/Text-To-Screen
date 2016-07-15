using System;
using System.Windows.Forms;
using Klocman.Controls;
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
    }
}