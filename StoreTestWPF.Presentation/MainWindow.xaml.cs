using StoreTestWPF.DAL;
using StoreTestWPF.Presentation.Services;
using StoreTestWPF.ViewModel.ViewModels;
using System.Windows;

namespace StoreTestWPF.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewService viewService = new ViewService();
            this.DataContext = new StoreViewModel(viewService);
        }
    }
}
