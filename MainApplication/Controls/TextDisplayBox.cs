using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Klocman.Extensions;

namespace TextToScreen.Controls
{
    public sealed partial class TextDisplayBox : UserControl
    {
        public static readonly int PreviewScreenRefreshInterval = 65;
        // *3 = 100 ms - 0.1s from settings. Need small intervals to update transparency
        public static readonly int OutputScreenRefreshInterval = 25;
        private volatile TextDisplayBox _previewDisplayBox;
        private volatile bool _redrawQueued;
        private Thread _redrawThread;

        public TextDisplayBox()
        {
            InitializeComponent();
        }

        public Color LabelBackColor
        {
            get { return label.BackColor; }
            set
            {
                label.BackColor = value;
                RedrawPreview();
            }
        }

        public Font LabelFont => label.Font;

        public Color LabelForeColor
        {
            get { return label.ForeColor; }
            set
            {
                label.ForeColor = value;
                RedrawPreview();
            }
        }

        public string LabelText => label.Text;

        public TextDisplayBox PreviewDisplayBox
        {
            get { return _previewDisplayBox; }
            set
            {
                if (_previewDisplayBox != null)
                    _previewDisplayBox.Resize -= OnResize;
                _previewDisplayBox = value;
                if (value != null)
                    _previewDisplayBox.Resize += OnResize;

                OnResize(this, EventArgs.Empty); // Will update size, redraw previews and stuff
            }
        }

        public ContentAlignment TextAlign => label.TextAlign;

        public void ClearDisplay()
        {
            label.Text = string.Empty;
            RedrawPreview();
        }

        public void ShowText(string text, Font font, ContentAlignment alignment)
        {
            label.SuspendLayout();

            label.Font = font;
            label.Text = text;
            label.TextAlign = alignment;

            label.ResumeLayout();

            RedrawPreview();
        }

        public void ShowText(string text)
        {
            label.Text = text;
            RedrawPreview();
        }

        //Pass through mouse events
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr) HTTRANSPARENT;
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (PreviewDisplayBox != null)
                label.Size = Size;

            UpdatePreviewLabelSize();

            RedrawPreview();
        }

        private void RedrawPreview()
        {
            if (_redrawThread == null || !_redrawThread.IsAlive)
            {
                _redrawThread = new Thread(RedrawPreviewThread)
                {
                    Name = "DisplayPreviewRefresher",
                    IsBackground = true
                };
                _redrawThread.Start();
            }
            _redrawQueued = true;
        }

        private void RedrawPreviewThread()
        {
            while (true)
            {
                if (_redrawQueued && _previewDisplayBox != null)
                {
                    var previewLabel = _previewDisplayBox.label;
                    /*
                    //Draw output box to a bitmap and show it in the preview box
                    this.Invoke(new Action(() =>
                    {
                        if (resultBitmap == null)
                            resultBitmap = new Bitmap(label.Width, label.Height);
                        label.DrawToBitmap(resultBitmap, new Rectangle(0, 0, label.Width, label.Height));
                    }));

                    var prevIm = previewLabel.Image;
                    var newIm = DrawingTools.ResizeBitmap(resultBitmap, previewLabel.Width, previewLabel.Height);
                    */
                    var prevIm = previewLabel.Image;
                    var newIm = new Bitmap(previewLabel.Width, previewLabel.Height);
                    using (var gr = Graphics.FromImage(newIm))
                    {
                        var scale = previewLabel.Width/(float) label.Width;
                        var fullRect = new Rectangle(new Point(0, 0), label.Size);

                        gr.ScaleTransform(scale, scale);
                        gr.FillRectangle(new SolidBrush(label.BackColor), fullRect);
                        gr.DrawString(label.Text, label.Font, new SolidBrush(label.ForeColor),
                            fullRect, label.TextAlign.ToStringFormat());
                    }

                    Invoke(new Action(() => previewLabel.Image = newIm));

                    prevIm?.Dispose();

                    //Collect only gen 0, fast and removes all unused bitmaps left in this function
                    GC.Collect(0, GCCollectionMode.Forced);
                    _redrawQueued = false;
                }

                Thread.Sleep(PreviewScreenRefreshInterval);
            }
        }

        private void UpdatePreviewLabelSize()
        {
            if (PreviewDisplayBox == null)
                return;

            //Size change
            var targetSize = Size;
            var previewBox = PreviewDisplayBox;
            if (targetSize.Height <= 0 || targetSize.Width <= 0)
                return;

            var containerRatio = previewBox.Size.Width/(float) previewBox.Size.Height;
            var targetRatio = targetSize.Width/(float) targetSize.Height;
            var newSize = new Size();
            if (containerRatio > targetRatio)
            {
                newSize.Height = previewBox.Size.Height;
                newSize.Width = (int) (previewBox.Size.Height*targetRatio);
            }
            else
            {
                newSize.Width = previewBox.Size.Width;
                newSize.Height = (int) (previewBox.Size.Width*(targetSize.Height/(float) targetSize.Width));
            }

            PreviewDisplayBox.label.Size = newSize;
        }
    }
}