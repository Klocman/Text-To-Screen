using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TextToScreen.Properties;
using Timer = System.Timers.Timer;

namespace TextToScreen.Controls.Screens
{
    public partial class OutputCluster : UserControl
    {
        private readonly Timer _callbackTimer;
        private Action<int> _progressCallback;

        public OutputCluster()
        {
            InitializeComponent();

            FinalField = (OutputField) elementHost2.Child;
            PreviewField = (OutputField) elementHost1.Child;

            PreviewField.AnimationLength = TimeSpan.Zero;
            PreviewField.NextText = Localisation.PreviewScreenInfo;

            var binder = Ustawienia.Default.Binder;

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextFontFamily = new FontFamily(args.NewValue);
                PreviewField.BeginAnimation(true);
            }, ustawienia => ustawienia.ScreenFontFamily, this);

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextFontSize = new FontSizeExtra(Convert.ToDouble(args.NewValue), binder.Settings.ScreenFontSizeFlexible);
                PreviewField.BeginAnimation(true);
            }, ustawienia => ustawienia.ScreenFontSize, this);

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextFontSize = new FontSizeExtra(Convert.ToDouble(binder.Settings.ScreenFontSize), args.NewValue);
                PreviewField.BeginAnimation(true);
            }, ustawienia => ustawienia.ScreenFontSizeFlexible, this);

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

            binder.Subscribe((obj, args) =>
            {
                PreviewField.SNextTextDecorations = args.NewValue ? TextDecorations.Underline : TextDecorations.OverLine;
                PreviewField.BeginAnimation(true);
            }, ustawienia => ustawienia.ScreenFontUnderline, this);

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextFontWeight = args.NewValue ? FontWeights.Bold : FontWeights.Normal;
                PreviewField.BeginAnimation(true);
            }, ustawienia => ustawienia.ScreenFontBold, this);

            binder.Subscribe((obj, args) =>
            {
                PreviewField.NextFontStyle = args.NewValue ? FontStyles.Italic : FontStyles.Normal;
                PreviewField.BeginAnimation(true);
            }, ustawienia => ustawienia.ScreenFontItalic, this);

            binder.Subscribe((x, y) => FinalField.AnimationLength = TimeSpan.FromSeconds(Convert.ToDouble(y.NewValue)),
                ustawienia => ustawienia.ScreenFadeSpeed, this);

            binder.SendUpdates(this);

            _callbackTimer = new Timer {AutoReset = true, Interval = 160};
            _callbackTimer.Elapsed +=
                (sender, args) => _progressCallback?.Invoke((int) Math.Round(FinalField.GetAnimationProgress()*100));
            FinalField.AnimationCompleted += (sender, args) =>
            {
                _callbackTimer.Stop();
                _progressCallback?.Invoke(100);
            };
        }

        public OutputField FinalField { get; }
        public OutputField PreviewField { get; }

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
    }
}