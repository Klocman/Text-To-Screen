using System;
using System.Windows.Forms;

namespace TextToScreen.Controls
{
    public sealed partial class PreviewScreens : UserControl
    {
        public PreviewScreens()
        {
            InitializeComponent();
            PreviewScreens_Resize(null, null);
        }

        public TextDisplayBox BottomDisplayBox => bottomPreviewScreen;

        public bool ButtonsEnabled
        {
            get { return button_send.Enabled; }
            set
            {
                button_send.Enabled = value;
                button_clear.Enabled = value;
            }
        }

        public TextDisplayBox TopDisplayBox => topPreviewScreen;
        public event Action<PreviewScreens> ButtonClickClear;
        public event Action<PreviewScreens> ButtonClickSend;

        /// <summary>
        ///     Range 0-100 (%). Pass value out of range to hide the progressbar.
        /// </summary>
        public void SetProgressBar(int position)
        {
            if (position >= 100 || position < 0)
            {
                fadeProgressBar.Visible = false;
                fadeProgressBar.Value = 0;
            }
            else
            {
                fadeProgressBar.Visible = true;
                fadeProgressBar.Value = position;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            ButtonClickClear?.Invoke(this);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            ButtonClickSend?.Invoke(this);
        }

        private void PreviewScreens_Resize(object sender, EventArgs e)
        {
            var topPart = splitContainer2.Panel1.Height;
            var botPart = splitContainer5.Panel2.Height;
            var total = splitContainer2.Height;
            var deadHeight = total - topPart - botPart;
            splitContainer2.SplitterDistance = (total - deadHeight + 1)/2;
        }
    }
}