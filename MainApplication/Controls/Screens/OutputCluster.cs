using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Klocman.Events;
using TextToScreen.Properties;
using FontFamily = System.Windows.Media.FontFamily;

namespace TextToScreen.Controls.Screens
{
    public partial class OutputCluster : UserControl
    {
        private readonly bool _inDesignMode;

        public OutputCluster()
        {
            InitializeComponent();

            FinalField = (OutputField)elementHost2.Child;
            PreviewField = (OutputField)elementHost1.Child;

            PreviewField.AnimationLength = TimeSpan.Zero;
            PreviewField.NextText = Localisation.PreviewScreenInfo;

            _inDesignMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);

            var binder = Ustawienia.Default.Binder;

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextFontFamily = new FontFamily(args.NewValue);
                PreviewField.BeginAnimation(true);

            }, ustawienia => ustawienia.ScreenFontFamily, this);

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextTextColor = args.NewValue;
                PreviewField.BeginAnimation(true);

            }, ustawienia => ustawienia.ScreenForegroundColor, this);

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextBackgroundColor = args.NewValue;
                PreviewField.BeginAnimation(true);

            }, ustawienia => ustawienia.ScreenBackgroundColor, this);

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextFontAlignment = args.NewValue;
                PreviewField.BeginAnimation(true);

            }, ustawienia => ustawienia.ScreenFontAlignment, this);

            var imageConverter = new ImageSourceConverter();

            binder.Subscribe((obj, args) =>
            {
                if (File.Exists(args.NewValue))
                {
                    try
                    {
                        PreviewField.NextImage = new BitmapImage(new Uri(args.NewValue));
                    }
                    catch
                    {
                        PreviewField.NextImage = null;
                    }
                }
                else
                {
                    PreviewField.NextImage = null;
                }
                PreviewField.BeginAnimation(true);
            }, ustawienia => ustawienia.ScreenImagePath, this);

            binder.Subscribe(FontStyleChanged, ustawienia => ustawienia.ScreenFontUnderline, this);
            binder.Subscribe(FontStyleChanged, ustawienia => ustawienia.ScreenFontBold, this);
            binder.Subscribe(FontStyleChanged, ustawienia => ustawienia.ScreenFontItalic, this);

            binder.Subscribe((x, y) => FinalField.AnimationLength = TimeSpan.FromSeconds(Convert.ToDouble(y.NewValue)),
                ustawienia => ustawienia.ScreenFadeSpeed, this);

            binder.SendUpdates(this);
        }

        private void FontStyleChanged(object sender, SettingChangedEventArgs<bool> args)
        {
            PreviewField.TextBlock.FontStyle = Ustawienia.Default.ScreenFontItalic ? FontStyles.Italic : FontStyles.Normal;
            PreviewField.TextBlock.FontWeight = Ustawienia.Default.ScreenFontBold ? FontWeights.Bold : FontWeights.Normal;
            PreviewField.TextBlock.TextDecorations = Ustawienia.Default.ScreenFontUnderline ? TextDecorations.Underline : null;
            PreviewField.BeginAnimation(true);
        }

        public OutputField FinalField { get; }
        public OutputField PreviewField { get; }

        public void SendToPreviewField(string newText)
        {
            PreviewField.NextText = newText;
        }

        public void ClearPreviewDisplay()
        {
            SendToPreviewField(string.Empty);
        }

        public void PushPreviewToOutput()
        {
            FinalField.ChangeWithAnimation(PreviewField);
        }

        public void RegisterPreviewFields(PreviewField preview, PreviewField output)
        {
            preview.SetPreviewTarget(PreviewField);
            output.SetPreviewTarget(FinalField);
        }

        //Pass through mouse events
        protected override void WndProc(ref Message m)
        {
            if (_inDesignMode)
                return;

            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)HTTRANSPARENT;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
