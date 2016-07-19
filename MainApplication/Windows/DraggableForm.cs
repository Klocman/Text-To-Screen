using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Klocman.Forms
{
    public class DraggableForm : Form
    {
        #region Constructors

        public DraggableForm()
        {
            InitializeComponent();

            //Adding Mouse Event Handlers for the Form
            MouseDown += Form_MouseDown;
            MouseUp += Form_MouseUp;
            MouseMove += Form_MouseMove;
        }

        #endregion Constructors

        #region Fields

        // Required designer variable.
        private readonly IContainer components = null;

        private bool _drag;
        private string _excludeList = string.Empty;
        private Point _startPoint = new Point(0, 0);

        #endregion Fields

        #region Properties

        public bool Draggable { set; get; } = true;

        public string ExcludeList
        {
            set { _excludeList = value; }
            get { return _excludeList.Trim(); }
        }

        #endregion Properties

        #region Methods

        // Clean up any resources being used.
        // true if managed resources should be disposed; otherwise, false.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            //
            //Add Mouse Event Handlers for each control added into the form,
            //if Draggable property of the form is set to true and the control
            //name is not in the ExcludeList.Exclude list is the comma separated
            //list of the Controls for which you do not require the mouse handler
            //to be added. For Example a button.
            //
            if (Draggable && (ExcludeList.IndexOf(e.Control.Name, StringComparison.Ordinal) == -1))
            {
                e.Control.MouseDown += Form_MouseDown;
                e.Control.MouseUp += Form_MouseUp;
                e.Control.MouseMove += Form_MouseMove;
            }
            base.OnControlAdded(e);
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            //
            //On Mouse Down set the flag drag=true and
            //Store the clicked point to the start_point variable
            //
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
            //
            //If drag = true, drag the form
            //

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
            //
            //Set the drag flag = false;
            //
            _drag = false;
        }

        // Required method for Designer support - do not modify
        // the contents of this method with the code editor.
        private void InitializeComponent()
        {
            //
            // FormBase
            //
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(369, 182);
            const string t = "FormBase";
            Name = t;
            Text = t;
        }

        #endregion Methods
    }
}