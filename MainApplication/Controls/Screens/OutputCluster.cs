using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using TextToScreen.Misc;
using Color = System.Drawing.Color;
using UserControl = System.Windows.Forms.UserControl;

namespace TextToScreen.Controls.Screens
{
    public partial class OutputCluster : UserControl
    {
        private readonly bool _inDesignMode;
        
        public OutputCluster()
        {
            InitializeComponent();

            FrontOutputField = (OutputField)elementHost2.Child;
            BackOutputField = (OutputField)elementHost1.Child;

            BackOutputField.AnimationLength = TimeSpan.Zero;

            _inDesignMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }

        public OutputField FrontOutputField { get; }
        public OutputField BackOutputField { get; }
        
        public void SendToPreviewField(string newText)
        {
            BackOutputField.ChangeWithAnimation(newText);
        }

        public void SendToPreviewField(string newText,
            Color nextTextColor, Color nextBackgroundColor, ImageSource nextImage)
        {
            BackOutputField.ChangeWithAnimation(newText, nextTextColor, nextBackgroundColor, nextImage);
        }

        public void PushPreviewToOutput()
        {
            FrontOutputField.ChangeWithAnimation(BackOutputField);
        }

        public void RegisterPreviewFields(PreviewField preview, PreviewField output)
        {
            preview.SetPreviewTarget(BackOutputField);
            output.SetPreviewTarget(FrontOutputField);
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

        public void ClearPreviewDisplay()
        {
            throw new NotImplementedException();
        }

        internal void SendToPreviewField(string y, Font font, ContentAlignment selectedAlignment)
        {
            BackOutputField.ChangeWithAnimation(y, font, selectedAlignment);
        }
    }
}
