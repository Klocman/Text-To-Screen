/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System.Windows.Controls;

namespace TextToScreen.Controls.Screens
{
    /// <summary>
    ///     Interaction logic for PreviewField.xaml
    /// </summary>
    public partial class PreviewField : UserControl
    {
        public PreviewField()
        {
            InitializeComponent();
        }

        public void SetPreviewTarget(OutputField outputField)
        {
            DataContext = outputField;
        }
    }
}