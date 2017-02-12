/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TextToScreen.Windows
{
    public class DraggableForm : Form
    {
        private readonly IContainer components = null;

        private bool _drag;
        private string _excludeList = string.Empty;
        private Point _startPoint = new Point(0, 0);

        public DraggableForm()
        {
            InitializeComponent();

            MouseDown += Form_MouseDown;
            MouseUp += Form_MouseUp;
            MouseMove += Form_MouseMove;
        }

        public bool Draggable { set; get; } = true;

        public string ExcludeList
        {
            set { _excludeList = value; }
            get { return _excludeList.Trim(); }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _drag = true;

            // Correct for the window border and titlebar
            var screenRectangle = RectangleToScreen(ClientRectangle);
            var borderHeight = screenRectangle.Top - Top;
            var borderWidth = screenRectangle.Left - Left;

            _startPoint = new Point(e.X + borderWidth, e.Y + borderHeight);
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
                _drag = false;
            else if (_drag)
            {
                var p1 = new Point(e.X, e.Y);
                var p2 = PointToScreen(p1);
                var p3 = new Point(p2.X - _startPoint.X,
                    p2.Y - _startPoint.Y);
                Location = p3;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            _drag = false;
        }

        private void InitializeComponent()
        {
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(369, 182);
            const string t = "FormBase";
            Name = t;
            Text = t;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (Draggable && (ExcludeList.IndexOf(e.Control.Name, StringComparison.Ordinal) == -1))
            {
                e.Control.MouseDown += Form_MouseDown;
                e.Control.MouseUp += Form_MouseUp;
                e.Control.MouseMove += Form_MouseMove;
            }
            base.OnControlAdded(e);
        }
    }
}