using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

        private static IEnumerable<PropertyInfo> NextSettingPropertyInfos { get; }

        static OutputField()
        {
            NextSettingPropertyInfos = typeof(OutputField).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.Name.Contains("Next")).ToList().AsEnumerable();
        }

        public OutputField()
        {
            InitializeComponent();

            _fadeIn = (Storyboard)Resources["FadeIn"];
            _fadeOut = (Storyboard)Resources["FadeOut"];

            _fadeOut.Completed += AfterFadeOut;
            _fadeIn.Completed += (sender, args) => AnimationCompleted?.Invoke(sender, args);

            SizeChanged += (sender, args) => UpdateFontSize();
        }

        public TimeSpan AnimationLength
        {
            get { return ((Duration)Resources["Duration"]).TimeSpan; }
            set { Resources["Duration"] = new Duration(value); }
        }

        public string CurrentText => TextBlock.Text;
        public ImageSource CurrentImage => Image.Source;
        public Color CurrentTextColor => ((SolidColorBrush)TextBlock.Foreground).Color.ToDrawingColor();
        public Color CurrentBackgroundColor => ((SolidColorBrush)Canvas.Background).Color.ToDrawingColor();

        public FontFamily CurrentFontFamily => TextBlock.FontFamily;
        public FontSizeExtra CurrentFontSize { get; private set; }

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
        public FontSizeExtra NextFontSize { get; set; }
        public ContentAlignment? NextFontAlignment { get; set; }

        public FontStyle? NextFontStyle { get; set; }
        public FontWeight? NextFontWeight { get; set; }
        public TextDecorationCollection SNextTextDecorations { get; set; }

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

                var outProgress = outStopped ? 0.5 : _fadeOut.GetCurrentProgress(this) / 2 ?? 0.5;
                var inProgress = inStopped ? 0 : _fadeIn.GetCurrentProgress(this) / 2 ?? 0.5;

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
            bool dirty = false;

            if (NextText != null)
            {
                TextBlock.Text = NextText;
                NextText = null;
                dirty = true;
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
                dirty = true;
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
                dirty = true;
            }

            if (NextFontWeight != null)
            {
                TextBlock.FontWeight = NextFontWeight.Value;
                NextFontWeight = null;
                dirty = true;
            }

            if (SNextTextDecorations != null)
            {
                TextBlock.TextDecorations = ReferenceEquals(SNextTextDecorations, TextDecorations.OverLine) ? null : SNextTextDecorations;
                SNextTextDecorations = null;
                dirty = true;
            }

            if (NextFontSize != null)
            {
                CurrentFontSize = NextFontSize;
                NextFontSize = null;
                dirty = true;
            }

            if (dirty)
                UpdateFontSize();

            if (!ReferenceEquals(CurrentImage, NextImage))
                Image.Source = NextImage;

            AnimationHalfPoint?.Invoke(sender, eventArgs);

            _fadeIn.Begin(this, true);
        }

        private void UpdateFontSize()
        {
            if (!IsVisible || TextBlock == null || CurrentFontSize == null)
                return;

            TextBlock.SetFontSize(TextBlock, CurrentFontSize.Size);
            TextBlock.UpdateLayout();
            if (CurrentFontSize.Flexible && TextBlock.IsVisible && TextBlock.ActualHeight > 0 && TextBlock.ActualWidth > 0)
            {
                var textBlock = TextBlock;
                var typeface = new Typeface(
                    textBlock.FontFamily,
                    textBlock.FontStyle,
                    textBlock.FontWeight,
                    textBlock.FontStretch);

                // FormattedText is used to measure the whole width of the text held up by TextBlock container
                var formattedText = new FormattedText(
                    textBlock.Text,
                    System.Threading.Thread.CurrentThread.CurrentCulture,
                    textBlock.FlowDirection,
                    typeface,
                    CurrentFontSize.Size,
                    textBlock.Foreground)
                { MaxTextWidth = textBlock.ActualWidth };

                double tempFontSize = CurrentFontSize.Size;

                while (true)
                {
                    // When the maximum text width of the FormattedText instance is set to the actual
                    // width of the textBlock, if the textBlock is being trimmed to fit then the formatted
                    // text will report a larger height than the textBlock. Should work whether the
                    // textBlock is single or multi-line.
                    // The width check detects if any single line is too long to fit within the text area, 
                    // this can only happen if there is a long span of text with no spaces.
                    if (formattedText.Height > textBlock.ActualHeight ||
                        formattedText.MinWidth > formattedText.MaxTextWidth)
                    {
                        // Doesn't fit, lower the font size
                        tempFontSize = Math.Max(tempFontSize - 1, 0.1);

                        // Can't lower the size any more, break out to prevent an infinite loop
                        if (tempFontSize < 0.2)
                            break;

                        // Recalculate the FormattedText for smaller font size
                        formattedText.SetFontSize(tempFontSize);
                    }
                    else
                    {
                        // Text fits just fine
                        break;
                    }
                }

                TextBlock.SetFontSize(TextBlock, tempFontSize);
            }
        }

        public void ChangeWithAnimation(OutputField originField)
        {
            /*foreach (var propertyInfo in NextSettingPropertyInfos)
            {
                propertyInfo.SetValue(this, propertyInfo.GetValue(originField, null), null);
            }*/

            NextText = originField.CurrentText;
            NextTextColor = originField.CurrentTextColor;
            NextBackgroundColor = originField.CurrentBackgroundColor;
            NextImage = originField.CurrentImage;
            NextFontFamily = originField.CurrentFontFamily;
            NextFontSize = originField.CurrentFontSize;
            NextFontAlignment = originField.CurrentFontAlignment;
            NextFontStyle = originField.TextBlock.FontStyle;
            NextFontWeight = originField.TextBlock.FontWeight;

            SNextTextDecorations = originField.TextBlock.TextDecorations ?? TextDecorations.OverLine;

            if (GetAnimationProgress() >= 1)
                BeginAnimation();
        }
    }
}