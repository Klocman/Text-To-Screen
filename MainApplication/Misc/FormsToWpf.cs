using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows;

namespace TextToScreen.Misc
{
    public static class FormsToWpf
    {
        public static HorizontalAlignment ToHorizontalAlignment(TextAlignment ta)
        {
            switch (ta)
            {
                case TextAlignment.Left:
                    return HorizontalAlignment.Left;
                case TextAlignment.Right:
                    return HorizontalAlignment.Right;
                case TextAlignment.Justify:
                    return HorizontalAlignment.Stretch;
                default:
                    return HorizontalAlignment.Center;
            }
        }

        public static ContentAlignment ToContentAlignment(TextAlignment ta, VerticalAlignment va)
        {
            if (va == VerticalAlignment.Top && ta == TextAlignment.Left)
                return ContentAlignment.TopLeft;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Center)
                return ContentAlignment.TopCenter;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Right)
                return ContentAlignment.TopRight;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Left)
                return ContentAlignment.TopLeft;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Right)
                return ContentAlignment.TopRight;

            if (va == VerticalAlignment.Top && ta == TextAlignment.Center)
                return ContentAlignment.TopCenter;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Left)
                return ContentAlignment.MiddleLeft;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Center)
                return ContentAlignment.MiddleCenter;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Right)
                return ContentAlignment.MiddleRight;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Left)
                return ContentAlignment.MiddleLeft;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Center)
                return ContentAlignment.MiddleCenter;

            if (va == VerticalAlignment.Center && ta == TextAlignment.Right)
                return ContentAlignment.MiddleRight;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Center)
                return ContentAlignment.BottomCenter;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Right)
                return ContentAlignment.BottomRight;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Left)
                return ContentAlignment.BottomLeft;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Center)
                return ContentAlignment.BottomCenter;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Right)
                return ContentAlignment.BottomRight;

            if (va == VerticalAlignment.Bottom && ta == TextAlignment.Left)
                return ContentAlignment.BottomLeft;

            throw new InvalidEnumArgumentException();
        }

        public static KeyValuePair<TextAlignment, VerticalAlignment> ToTextAlignment(ContentAlignment alignment)
        {
            TextAlignment ta;
            VerticalAlignment va;

            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    va = VerticalAlignment.Top;
                    break;

                default:
                    va = VerticalAlignment.Center;
                    break;

                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    va = VerticalAlignment.Bottom;
                    break;
            }

            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    ta = TextAlignment.Left;
                    break;

                default:
                    ta = TextAlignment.Center;
                    break;

                case ContentAlignment.BottomRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.TopRight:
                    ta = TextAlignment.Right;
                    break;
            }

            return new KeyValuePair<TextAlignment, VerticalAlignment>(ta, va);
        }
    }
}