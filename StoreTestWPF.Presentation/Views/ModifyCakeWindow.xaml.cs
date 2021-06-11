using System.Windows;

namespace StoreTestWPF.Presentation
{
    /// <summary>
    /// Interaction logic for ModifyCakeWindow.xaml
    /// </summary>
    public partial class ModifyCakeWindow : Window
    {
        public ModifyCakeWindow()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
