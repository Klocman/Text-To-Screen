/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System;
using System.Windows.Forms;
using Klocman.Extensions;

namespace TextToScreen.Controls.Screens
{
    public sealed partial class PreviewScreens : UserControl
    {
        public PreviewScreens()
        {
            InitializeComponent();

            TopDisplayBox = (PreviewField) elementHost1.Child;
            BottomDisplayBox = (PreviewField) elementHost2.Child;
        }

        public PreviewField BottomDisplayBox { get; }
        public PreviewField TopDisplayBox { get; }

        public bool ButtonsEnabled
        {
            get { return button_send.Enabled; }
            set
            {
                button_send.Enabled = value;
                button_clear.Enabled = value;
            }
        }

        public event Action<PreviewScreens> ButtonClickClear;
        public event Action<PreviewScreens> ButtonClickSend;

        /// <summary>
        ///     Range 0-100 (%). Pass value out of range to hide the progressbar.
        /// </summary>
        public void SetProgressBar(int position)
        {
            this.SafeInvoke(() =>
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
            });
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            ButtonClickClear?.Invoke(this);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            ButtonClickSend?.Invoke(this);
        }
    }
}