using StoreTestWPF.DAL.Models;
using StoreTestWPF.ViewModel.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace StoreTestWPF.Presentation.Controls
{
    /// <summary>
    /// Interaction logic for CakeDetails.xaml
    /// </summary>
    public partial class CakeDetails : UserControl
    {
        public CakeDetails()
        {
            InitializeComponent();
        }

        public bool IsCakeSelected {
            get { return (bool)GetValue(IsCakeSelectedProperty); }
            set { SetValue(IsCakeSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsCakeSelectedProperty =
        DependencyProperty.Register(
            nameof(IsCakeSelected),
            typeof(bool),
            typeof(CakeDetails),
           new FrameworkPropertyMetadata(new bool()));

    public CakeViewModel SelectedCake
        {
            get { return (CakeViewModel) GetValue(CakeProperty); }
            set { SetValue(CakeProperty, value); }
        }

    public static readonly DependencyProperty CakeProperty =
        DependencyProperty.Register(
            nameof(SelectedCake),
            typeof(CakeViewModel),
            typeof(CakeDetails),
           new FrameworkPropertyMetadata(new CakeViewModel(new Cake())));
    }
}
