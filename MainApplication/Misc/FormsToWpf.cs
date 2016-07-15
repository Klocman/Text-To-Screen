using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace TextToScreen.Misc
{
    public static class FormsToWpf
    {

        public static System.Drawing.ContentAlignment ToContentAlignment(TextAlignment ta, VerticalAlignment va)
        {
            if (va == VerticalAlignment.Top && ta == TextAlignment.Left)
                return System.Drawing.ContentAlignment.TopLeft;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Center)
                return System.Drawing.ContentAlignment.TopCenter;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Right)
                return System.Drawing.ContentAlignment.TopRight;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Left)
                return System.Drawing.ContentAlignment.TopLeft;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Right)
                return System.Drawing.ContentAlignment.TopRight;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Center)
                return System.Drawing.ContentAlignment.TopCenter;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Left)
                return System.Drawing.ContentAlignment.MiddleLeft;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Center)
                return System.Drawing.ContentAlignment.MiddleCenter;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Right)
                return System.Drawing.ContentAlignment.MiddleRight;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Left)
                return System.Drawing.ContentAlignment.MiddleLeft;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Center)
                return System.Drawing.ContentAlignment.MiddleCenter;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Right)
                return System.Drawing.ContentAlignment.MiddleRight;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Center)
                return System.Drawing.ContentAlignment.BottomCenter;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Right)
                return System.Drawing.ContentAlignment.BottomRight;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Left)
                return System.Drawing.ContentAlignment.BottomLeft;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Center)
                return System.Drawing.ContentAlignment.BottomCenter;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Right)
                return System.Drawing.ContentAlignment.BottomRight;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Left)
                return System.Drawing.ContentAlignment.BottomLeft;

            throw new InvalidEnumArgumentException();
        }
        public static KeyValuePair<TextAlignment, VerticalAlignment> ToTextAlignment(System.Drawing.ContentAlignment alignment)
        {
            TextAlignment ta; VerticalAlignment va;

            switch (alignment)
            {
                case System.Drawing.ContentAlignment.TopLeft:
                case System.Drawing.ContentAlignment.TopCenter:
                case System.Drawing.ContentAlignment.TopRight:
                    va = VerticalAlignment.Top;
                    break;

                default:
                case System.Drawing.ContentAlignment.MiddleLeft:
                case System.Drawing.ContentAlignment.MiddleCenter:
                case System.Drawing.ContentAlignment.MiddleRight:
                    va = VerticalAlignment.Center;
                    break;

                case System.Drawing.ContentAlignment.BottomLeft:
                case System.Drawing.ContentAlignment.BottomCenter:
                case System.Drawing.ContentAlignment.BottomRight:
                    va = VerticalAlignment.Bottom;
                    break;
            }

            switch (alignment)
            {
                case System.Drawing.ContentAlignment.TopLeft:
                case System.Drawing.ContentAlignment.MiddleLeft:
                case System.Drawing.ContentAlignment.BottomLeft:
                    ta = TextAlignment.Left;
                    break;

                default:
                case System.Drawing.ContentAlignment.MiddleCenter:
                case System.Drawing.ContentAlignment.TopCenter:
                case System.Drawing.ContentAlignment.BottomCenter:
                    ta = TextAlignment.Center;
                    break;

                case System.Drawing.ContentAlignment.BottomRight:
                case System.Drawing.ContentAlignment.MiddleRight:
                case System.Drawing.ContentAlignment.TopRight:
                    ta = TextAlignment.Right;
                    break;
            }

            return new KeyValuePair<TextAlignment, VerticalAlignment>(ta, va);
        }
    }
}
