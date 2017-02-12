/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System;
using System.Windows.Forms;
using TextToScreen.Misc;
using TextToScreen.Properties;
using TextToScreen.SongFile;

namespace TextToScreen.Windows
{
    public sealed partial class DodajPlik : Form
    {
        private SongFileEntry _target;

        public DodajPlik()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(IWin32Window owner, SongFileEntry targetEntry, bool creatingNew)
        {
            if (targetEntry == null || owner == null)
                throw new ArgumentNullException();

            Text = creatingNew ? Localisation.AddFileWindowTitle : Localisation.RenameFileWindowTitle;
            filePropertiesViewer1.Populate(targetEntry, true);
            _target = targetEntry;
            return ShowDialog(owner);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_target.CheckName(filePropertiesViewer1.NewName) != NameChangeResult.Ok)
                return;

            _target.Name = filePropertiesViewer1.NewName;
            _target.Comment = filePropertiesViewer1.NewComment;
            _target.Group = filePropertiesViewer1.NewGroup;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DodajPlik_FormClosing(object sender, FormClosingEventArgs e)
        {
            _target = null;
            filePropertiesViewer1.Clear();
        }

        // public int targetScreen = 0;
        private void DodajPlik_Shown(object sender, EventArgs e)
        {
            filePropertiesViewer1.Focus();

            //var mainPos = Screen.AllScreens[targetScreen].Bounds;
            // this.SetDesktopLocation(mainPos.X + 100, mainPos.Y + 100);
        }
    }
}