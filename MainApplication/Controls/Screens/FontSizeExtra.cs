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