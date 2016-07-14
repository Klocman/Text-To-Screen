using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Klocman.Extensions;
using Klocman.Forms;
using TextToScreen.Controls;
using TextToScreen.Controls.Screens;
using TextToScreen.Properties;

namespace TextToScreen.Windows
{
    public sealed partial class SecondaryWindow : DraggableForm
    {
        private bool _isCursorHidden;
        public OutputCluster OutputCluster { get; }

        public SecondaryWindow()
        {
            InitializeComponent();

            OutputCluster = new OutputCluster();
            OutputCluster.Dock = DockStyle.Fill;
            Controls.Add(OutputCluster);
        }
        
        public bool IsAlwaysOnTop
        {
            get { return TopMost; }
            set
            {
                TopMost = value;
                Ustawienia.SelectedSettingSet.OknoDoceloweTop = value;
            }
        }

        public bool IsCursorHidden
        {
            get { return _isCursorHidden; }
            set
            {
                _isCursorHidden = value;
                Ustawienia.SelectedSettingSet.OknoDoceloweHideCursor = value;
            }
        }

        public bool IsFullScreen
        {
            get { return FormBorderStyle == FormBorderStyle.None; }
            set
            {
                if (value) //Going fullscreen now
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.SizableToolWindow;
                    WindowState = FormWindowState.Normal;
                }
                Ustawienia.SelectedSettingSet.OknoDoceloweFull = value;
            }
        }
       
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;

                var cp = base.CreateParams;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsAlwaysOnTop = !IsAlwaysOnTop;
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            fullScreenToolStripMenuItem.CheckState = IsFullScreen.ToCheckState();
            hideCursorToolStripMenuItem1.CheckState = IsCursorHidden.ToCheckState();
            alwaysOnTopToolStripMenuItem.CheckState = IsAlwaysOnTop.ToCheckState();
        }

        private void Form_MouseEnter(object sender, EventArgs e)
        {
            if (IsCursorHidden)
                Cursor.Hide();
        }

        private void Form_MouseLeave(object sender, EventArgs e)
        {
            if (IsCursorHidden)
                Cursor.Show();
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFullScreen = !IsFullScreen;
        }

        private void hideCursorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IsCursorHidden = !IsCursorHidden;
        }

        private void SecondaryWindow_DoubleClick(object sender, EventArgs e)
        {
            IsFullScreen = !IsFullScreen;
        }
    }
}