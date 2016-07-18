using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Klocman.Binding.Settings;
using TextToScreen.Properties;

namespace TextToScreen.Controls.Screens
{
    public partial class OutputCluster : UserControl
    {
        private readonly System.Timers.Timer _callbackTimer;
        private readonly bool _inDesignMode;
        private Action<int> _progressCallback;

        public OutputCluster()
        {
            InitializeComponent();

            FinalField = (OutputField)elementHost2.Child;
            PreviewField = (OutputField)elementHost1.Child;

            PreviewField.AnimationLength = TimeSpan.Zero;
            PreviewField.NextText = Localisation.PreviewScreenInfo;

            _inDesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

            var binder = Ustawienia.Default.Binder;

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextFontFamily = new FontFamily(args.NewValue);
                PreviewField.BeginAnimation(true);
            }, ustawienia => ustawienia.ScreenFontFamily, this);

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextFontSize = Convert.ToDouble(args.NewValue);
                PreviewField.BeginAnimation(true);
            }, ustawienia => ustawienia.ScreenFontSize, this);

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

            _callbackTimer = new System.Timers.Timer { AutoReset = true, Interval = 160 };
            _callbackTimer.Elapsed +=
                (sender, args) => _progressCallback?.Invoke((int)Math.Round(FinalField.GetAnimationProgress() * 100));
            FinalField.AnimationCompleted += (sender, args) => { _callbackTimer.Stop(); _progressCallback?.Invoke(100); };
        }

        public OutputField FinalField { get; }
        public OutputField PreviewField { get; }

        private void FontStyleChanged(object sender, SettingChangedEventArgs<bool> args)
        {
            PreviewField.TextBlock.FontStyle = Ustawienia.Default.ScreenFontItalic
                ? FontStyles.Italic
                : FontStyles.Normal;
            PreviewField.TextBlock.FontWeight = Ustawienia.Default.ScreenFontBold
                ? FontWeights.Bold
                : FontWeights.Normal;
            PreviewField.TextBlock.TextDecorations = Ustawienia.Default.ScreenFontUnderline
                ? TextDecorations.Underline
                : null;
            PreviewField.BeginAnimation(true);
        }

        public void SendToPreviewField(string newText)
        {
            PreviewField.NextText = newText;
            PreviewField.BeginAnimation(true);
        }

        public void ClearPreviewDisplay()
        {
            SendToPreviewField(string.Empty);
        }

        public void PushPreviewToOutput()
        {
            _callbackTimer.Start();

            FinalField.ChangeWithAnimation(PreviewField);
        }

        public void RegisterPreviewFields(PreviewScreens previewScreens)
        {
            previewScreens.TopDisplayBox.SetPreviewTarget(PreviewField);
            previewScreens.BottomDisplayBox.SetPreviewTarget(FinalField);
            _progressCallback = previewScreens.SetProgressBar;
        }

        //Pass through mouse events
        protected override void WndProc(ref Message m)
        {
            if (_inDesignMode)
                return;

            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = -1;

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