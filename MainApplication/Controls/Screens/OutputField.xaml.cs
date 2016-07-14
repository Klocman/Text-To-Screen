﻿using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TextToScreen.Misc;
using Color = System.Drawing.Color;
using FontFamily = System.Windows.Media.FontFamily;

namespace TextToScreen.Controls.Screens
{
    /// <summary>
    /// Interaction logic for OutputField.xaml
    /// </summary>
    public partial class OutputField : UserControl
    {
        public OutputField()
        {
            InitializeComponent();

            _fadeIn = (Storyboard)Resources["FadeIn"];
            _fadeOut = (Storyboard)Resources["FadeOut"];

            _fadeOut.Completed += AfterFadeOut;
            _fadeIn.Completed += (sender, args) => AnimationCompleted?.Invoke(sender, args);
        }

        public event EventHandler AnimationCompleted;

        private readonly Storyboard _fadeIn;
        private readonly Storyboard _fadeOut;

        public TimeSpan AnimationLength
        {
            get { return ((Duration)Resources["Duration"]).TimeSpan; }
            set { Resources["Duration"] = new Duration(value); }
        }

        public string CurrentText => TextBlock.Text;
        public ImageSource CurrentImage => Image.Source;
        public Color CurrentTextColor => ((SolidColorBrush)TextBlock.Foreground).Color.ToDrawingColor();
        public Color CurrentBackgroundColor => ((SolidColorBrush)Background).Color.ToDrawingColor();

        public FontFamily CurrentFontFamily => TextBlock.FontFamily;
        public double CurrentFontSize => TextBlock.FontSize;
        public TextAlignment CurrentFontAlignment => TextBlock.TextAlignment;

        string NextText { get; set; }
        Color? NextTextColor { get; set; }
        Color? NextBackgroundColor { get; set; }
        ImageSource NextImage { get; set; }
        FontFamily NextFontFamily { get; set; }
        double? NextFontSize { get; set; }
        TextAlignment? NextFontAlignment { get; set; }

        /// <summary>
        /// Overall progress of the animation. 0 at start, 1 when completed.
        /// </summary>
        public double GetAnimationProgress()
        {
            var outStopped = _fadeOut.GetCurrentState() == ClockState.Stopped;
            var inStopped = _fadeIn.GetCurrentState() == ClockState.Stopped;

            if (outStopped && inStopped)
                return 1;

            var outProgress = outStopped ? 0.5 : _fadeOut.GetCurrentProgress() / 2;
            var inProgress = _fadeIn.GetCurrentProgress() / 2;

            return Math.Round(outProgress + inProgress, 2, MidpointRounding.AwayFromZero);
        }

        public void ChangeWithAnimation(string newText)
        {
            NextText = newText;
            _fadeOut.Begin(this, true);
        }

        public void ChangeWithAnimation(string newText, Color nextTextColor, Color nextBackgroundColor)
        {
            NextTextColor = nextTextColor;
            NextBackgroundColor = nextBackgroundColor;
            ChangeWithAnimation(newText);
        }

        internal void ChangeWithAnimation(string newText, Font font, ContentAlignment selectedAlignment)
        {
            if (font != null)
            {
                NextFontFamily = new FontFamily(font.FontFamily.Name);
                FontSize = font.Size;
            }

            //TODO NextContentAlignment = selectedAlignment;
            ChangeWithAnimation(newText);
        }

        public void ChangeWithAnimation(string newText,
            Color nextTextColor, Color nextBackgroundColor, ImageSource nextImage)
        {
            if (!ReferenceEquals(CurrentImage, nextImage))
                NextImage = nextImage;
            ChangeWithAnimation(newText, nextTextColor, nextBackgroundColor);
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
                Background = new SolidColorBrush(NextBackgroundColor.Value.ToMediaColor());
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
                TextBlock.TextAlignment = NextFontAlignment.Value;
                NextFontAlignment = null;
            }

            if (!ReferenceEquals(CurrentImage, NextImage))
                Image.Source = NextImage;

            _fadeIn.Begin(this, true);
        }

        public void ChangeWithAnimation(OutputField originField)
        {
            NextTextColor = originField.CurrentTextColor;
            NextBackgroundColor = originField.CurrentBackgroundColor;
            NextImage = originField.CurrentImage;
            NextFontFamily = originField.CurrentFontFamily;
            NextFontSize = originField.CurrentFontSize;
            NextFontAlignment = originField.CurrentFontAlignment;
            ChangeWithAnimation(originField.CurrentText);
        }
    }
}
