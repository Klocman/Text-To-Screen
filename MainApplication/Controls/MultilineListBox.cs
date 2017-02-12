/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0

    This class contains free-to-use code written by Nishant S [nishforever@vsnl.com]
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextToScreen.Controls
{
    public sealed class MultilineListBox : ListBox
    {
        private const TextFormatFlags DrawTextFlags =
            TextFormatFlags.Left | TextFormatFlags.PreserveGraphicsClipping | 
            TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;

        public MultilineListBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            ScrollAlwaysVisible = true;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            BackColor = Enabled ? SystemColors.Window : SystemColors.Control;
            base.OnEnabledChanged(e);
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
                    TextRenderer.DrawText(e.Graphics, s, Font, GetTextBounds(e.Bounds), SystemColors.WindowText, DrawTextFlags);
                    //e.Graphics.DrawString(s, Font, new SolidBrush(SystemColors.WindowText), e.bounds);
                    e.Graphics.DrawRectangle(new Pen(SystemColors.ControlDarkDark), GetItemBounds(e.Bounds));
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), GetItemBounds(e.Bounds));
                    TextRenderer.DrawText(e.Graphics, s, Font, GetTextBounds(e.Bounds), SystemColors.HighlightText, DrawTextFlags);
                    //e.Graphics.DrawString(s, Font, new SolidBrush(SystemColors.HighlightText), e.bounds);
                }
            }
        }

        private static Rectangle GetItemBounds(Rectangle bounds)
        {
            return new Rectangle(bounds.X, bounds.Y, bounds.Width - 3, bounds.Height);
        }

        private static Rectangle GetTextBounds(Rectangle bounds)
        {
            return new Rectangle(bounds.X + 3, bounds.Y + 5, bounds.Width - 6, bounds.Height - 2);
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (Site != null)
                return;
            if (e.Index > -1)
            {
                var itemText = Items[e.Index].ToString();
                var sf = TextRenderer.MeasureText(e.Graphics, itemText, Font, new Size(Width - 20, 0), DrawTextFlags);
                //var sf = e.Graphics.MeasureString(itemText, Font, Width);
                var htex = e.Index == 0 ? 15 : 10;
                e.ItemHeight = sf.Height + htex;
                e.ItemWidth = Width;
            }
        }
    }
}