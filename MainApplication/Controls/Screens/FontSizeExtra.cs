/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

namespace TextToScreen.Controls.Screens
{
    public class FontSizeExtra
    {
        public FontSizeExtra(double size, bool flexible)
        {
            Size = size;
            Flexible = flexible;
        }

        public double Size { get; set; }
        public bool Flexible { get; set; }
    }
}