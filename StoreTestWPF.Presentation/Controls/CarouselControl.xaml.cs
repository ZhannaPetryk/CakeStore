using StoreTestWPF.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreTestWPF.Presentation.Controls
{
    /// <summary>
    /// Interaction logic for CarouselControl.xaml
    /// </summary>
    public partial class CarouselControl : UserControl
    {
        public CarouselControl()
        {
            InitializeComponent();
        }

        private void CarouseBtn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            AnimateCarousel();
        }

        private void CarouselItems_Updated(object sender, DataTransferEventArgs e)
        {
            AnimateCarousel(true);
        }

        private void AnimateCarousel(bool performImmediately = false)
        {
            Storyboard storyboard = this.Resources["CarouselStoryboard"] as Storyboard;
            DoubleAnimation animation = storyboard.Children.First() as DoubleAnimation;
            int currentElement = ((CakeImagesViewModel)this.DataContext).CurrentElement;
            animation.To = -this.Width * currentElement;
            
            if (performImmediately) 
                animation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 1));
            else
                animation.Duration = new Duration(new TimeSpan(0, 0, 0, 1));

            storyboard.Begin();
        }
    }
}
