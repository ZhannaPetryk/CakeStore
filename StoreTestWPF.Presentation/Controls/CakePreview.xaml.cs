using StoreTestWPF.DAL.Models;
using StoreTestWPF.ViewModel.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace StoreTestWPF.Presentation.Controls
{
    /// <summary>
    /// Interaction logic for CakePreview.xaml
    /// </summary>
    public partial class CakePreview : UserControl
    {
        public CakePreview()
        {
            InitializeComponent();
        }

        public CakeViewModel Cake
        {
            get { return (CakeViewModel)GetValue(CakeProperty); }
            set { SetValue(CakeProperty, value); }
        }

        public static readonly DependencyProperty CakeProperty =
            DependencyProperty.Register(
                nameof(Cake),
                typeof(CakeViewModel),
                typeof(CakePreview),
               new FrameworkPropertyMetadata(new CakeViewModel(new Cake())));
    }
}
