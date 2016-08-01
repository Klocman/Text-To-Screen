﻿using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TextToScreen.Misc;
using Color = System.Drawing.Color;
using FontFamily = System.Windows.Media.FontFamily;
using FontStyle = System.Windows.FontStyle;

namespace TextToScreen.Controls.Screens
{
    /// <summary>
    ///     Interaction logic for OutputField.xaml
    /// </summary>
    public partial class OutputField : UserControl
    {
        private readonly Storyboard _fadeIn;
        private readonly Storyboard _fadeOut;
        private string _nextText;

        public OutputField()
        {
            InitializeComponent();

            _fadeIn = (Storyboard) Resources["FadeIn"];
            _fadeOut = (Storyboard) Resources["FadeOut"];

            _fadeOut.Completed += AfterFadeOut;
            _fadeIn.Completed += (sender, args) => AnimationCompleted?.Invoke(sender, args);
        }

        public TimeSpan AnimationLength
        {
            get { return ((Duration) Resources["Duration"]).TimeSpan; }
            set { Resources["Duration"] = new Duration(value); }
        }

        public string CurrentText => TextBlock.Text;
        public ImageSource CurrentImage => Image.Source;
        public Color CurrentTextColor => ((SolidColorBrush) TextBlock.Foreground).Color.ToDrawingColor();
        public Color CurrentBackgroundColor => ((SolidColorBrush) Canvas.Background).Color.ToDrawingColor();

        public FontFamily CurrentFontFamily => TextBlock.FontFamily;
        public double CurrentFontSize => TextBlock.FontSize;

        public ContentAlignment CurrentFontAlignment
            => FormsToWpf.ToContentAlignment(TextBlock.TextAlignment, TextBlock.VerticalAlignment);

        public string NextText
        {
            get { return _nextText; }
            set { _nextText = value?.Replace("\r\n", "\n").TrimEnd('\n'); }
        }

        public Color? NextTextColor { get; set; }
        public Color? NextBackgroundColor { get; set; }
        public ImageSource NextImage { get; set; }
        public FontFamily NextFontFamily { get; set; }
        public double? NextFontSize { get; set; }
        public ContentAlignment? NextFontAlignment { get; set; }

        public FontStyle? NextFontStyle { get; set; }
        public FontWeight? NextFontWeight { get; set; }
        public TextDecorationCollection NextTextDecorations { get; set; }

        public event EventHandler AnimationHalfPoint;
        public event EventHandler AnimationCompleted;

        /// <summary>
        ///     Overall progress of the animation. 0 at start, 1 when completed.
        /// </summary>
        public double GetAnimationProgress()
        {
            try
            {
                var outStopped = _fadeOut.GetCurrentState(this) == ClockState.Stopped;
                var inStopped = _fadeIn.GetCurrentState(this) == ClockState.Stopped;

                if (outStopped && inStopped)
                    return 1;

                var outProgress = outStopped ? 0.5 : _fadeOut.GetCurrentProgress(this)/2 ?? 0.5;
                var inProgress = inStopped ? 0 : _fadeIn.GetCurrentProgress(this)/2 ?? 0.5;

                return Math.Round(outProgress + inProgress, 3, MidpointRounding.AwayFromZero);
            }
            catch (InvalidOperationException)
            {
                return 1;
            }
        }

        public void BeginAnimation(bool skipFadeout = false)
        {
            if (skipFadeout)
                AfterFadeOut(this, EventArgs.Empty);
            else
                _fadeOut.Begin(this, true);
        }

        private void AfterFadeOut(object sender, EventArgs eventArgs)
        {
            if (NextText != null)
            {
                TextBlock.Text = NextText;
                NextText = null;
            }

            if (NextBackgroundColor != null)
            {
                Canvas.Background = new SolidColorBrush(NextBackgroundColor.Value.ToMediaColor());
                NextBackgroundColor = null;
            }

            if (NextTextColor != null)
            {
                TextBlock.Foreground = new SolidColorBrush(NextTextColor.Value.ToMediaColor());
                NextTextColor = null;
            }

            if (NextFontFamily != null)
            {
                TextBlock.SetFontFamily(TextBlock, NextFontFamily);
                NextFontFamily = null;
            }

            if (NextFontSize != null)
            {
                TextBlock.SetFontSize(TextBlock, NextFontSize.Value);
                NextFontSize = null;
            }

            if (NextFontAlignment != null)
            {
                var ta = FormsToWpf.ToTextAlignment(NextFontAlignment.Value);
                TextBlock.TextAlignment = ta.Key;
                TextBlock.VerticalAlignment = ta.Value;
                TextBlock.HorizontalAlignment = FormsToWpf.ToHorizontalAlignment(ta.Key);
                NextFontAlignment = null;
            }

            if (NextFontStyle != null)
            {
                TextBlock.FontStyle = NextFontStyle.Value;
                NextFontStyle = null;
            }

            if (NextFontWeight != null)
            {
                TextBlock.FontWeight = NextFontWeight.Value;
                NextFontWeight = null;
            }

            if (NextTextDecorations != null)
            {
                TextBlock.TextDecorations = ReferenceEquals(NextTextDecorations, TextDecorations.OverLine) ? null : NextTextDecorations;
                NextTextDecorations = null;
            }

            if (!ReferenceEquals(CurrentImage, NextImage))
                Image.Source = NextImage;

            AnimationHalfPoint?.Invoke(sender, eventArgs);

            _fadeIn.Begin(this, true);
        }

        public void ChangeWithAnimation(OutputField originField)
        {
            NextText = originField.CurrentText;
            NextTextColor = originField.CurrentTextColor;
            NextBackgroundColor = originField.CurrentBackgroundColor;
            NextImage = originField.CurrentImage;
            NextFontFamily = originField.CurrentFontFamily;
            NextFontSize = originField.CurrentFontSize;
            NextFontAlignment = originField.CurrentFontAlignment;
            NextFontStyle = originField.TextBlock.FontStyle;
            NextFontWeight = originField.TextBlock.FontWeight;
            NextTextDecorations = originField.TextBlock.TextDecorations ?? TextDecorations.OverLine;

            if (GetAnimationProgress() >= 1)
                BeginAnimation();
        }
    }
}