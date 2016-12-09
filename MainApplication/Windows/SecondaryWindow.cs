using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using Klocman.Extensions;
using TextToScreen.Controls.Screens;
using TextToScreen.Properties;
using Cursor = System.Windows.Forms.Cursor;
using Cursors = System.Windows.Input.Cursors;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace TextToScreen.Windows
{
    public sealed partial class SecondaryWindow : DraggableForm
    {
        private bool _isCursorHidden;

        public SecondaryWindow()
        {
            InitializeComponent();
            OutputCluster = new OutputCluster {Dock = DockStyle.Fill};
            Controls.Add(OutputCluster);

            OutputCluster.FinalField.MouseDown += (sender, args) => OnMouseDown(ToFormsMouseArgs(args, args.ClickCount));
            OutputCluster.FinalField.MouseUp += (sender, args) => OnMouseUp(ToFormsMouseArgs(args, args.ClickCount));
            OutputCluster.FinalField.MouseMove += (sender, args) => OnMouseMove(ToFormsMouseArgs(args, 1));
            OutputCluster.FinalField.MouseDoubleClick +=
                (sender, args) =>
                {
                    if (args.LeftButton == MouseButtonState.Pressed) SecondaryWindow_DoubleClick(sender, args);
                };
        }

        public OutputCluster OutputCluster { get; }

        public bool IsAlwaysOnTop
        {
            get { return TopMost; }
            set
            {
                TopMost = value;
                Ustawienia.Default.OknoDoceloweTop = value;
            }
        }

        public bool IsCursorHidden
        {
            get { return _isCursorHidden; }
            set
            {
                _isCursorHidden = value;
                Ustawienia.Default.OknoDoceloweHideCursor = value;

                OutputCluster.FinalField.Cursor = value ? Cursors.None : Cursors.Arrow;
            }
        }

        public bool IsFullScreen
        {
            get { return FormBorderStyle == FormBorderStyle.None; }
            set
            {
                if (value)
                {
                    //Going fullscreen
                    SuspendLayout();
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    ResumeLayout();
                }
                else
                {
                    SuspendLayout();
                    FormBorderStyle = FormBorderStyle.SizableToolWindow;
                    WindowState = FormWindowState.Normal;
                    ResumeLayout();
                }
                Ustawienia.Default.OknoDoceloweFull = value;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle |= 0x200; // CS_NOCLOSE
                return cp;
            }
        }

        private static MouseEventArgs ToFormsMouseArgs(System.Windows.Input.MouseEventArgs args, int clicks)
        {
            var screenPoint = args.GetPosition(null);
            var clientPoint = new Point((int) screenPoint.X, (int) screenPoint.Y);
            return
                new MouseEventArgs(args.LeftButton == MouseButtonState.Pressed ? MouseButtons.Left : MouseButtons.None,
                    clicks, clientPoint.X, clientPoint.Y, 0);
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

        private void SecondaryWindow_Shown(object sender, EventArgs e)
        {
            // Refresh the output screen to final state
            OutputCluster.SendToPreviewField(Localisation.PreviewScreenInfo);
        }
    }
}