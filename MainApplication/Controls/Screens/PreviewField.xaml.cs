using System.Windows.Controls;

namespace TextToScreen.Controls.Screens
{
    /// <summary>
    /// Interaction logic for PreviewField.xaml
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
