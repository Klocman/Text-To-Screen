/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0

    This class contains free-to-use code written by Nishant S [nishforever@vsnl.com]
*/

using System.Drawing;
using System.Windows.Forms;

namespace TextToScreen.Controls
{
    public sealed class MultilineListBox : ListBox
    {
        public MultilineListBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            ScrollAlwaysVisible = true;
            //tbox.Hide();
            //tbox.mllb = this;
            //Controls.Add(tbox);
            EnabledChanged += (x, y) => BackColor = Enabled ? SystemColors.Window : SystemColors.Control;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Site != null)
                return;
            if (e.Index > -1)
            {
                var s = Items[e.Index].ToString();

                if ((e.State & DrawItemState.Focus) == 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
                    e.Graphics.DrawString(s, Font, new SolidBrush(SystemColors.WindowText), e.Bounds);
                    e.Graphics.DrawRectangle(new Pen(SystemColors.Highlight), e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), e.Bounds);
                    e.Graphics.DrawString(s, Font, new SolidBrush(SystemColors.HighlightText), e.Bounds);
                }
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (Site != null)
                return;
            if (e.Index > -1)
            {
                var itemText = Items[e.Index].ToString();
                var sf = e.Graphics.MeasureString(itemText, Font, Width);
                var htex = e.Index == 0 ? 15 : 10;
                e.ItemHeight = (int) sf.Height + htex;
                e.ItemWidth = Width;
            }
        }
    }
}