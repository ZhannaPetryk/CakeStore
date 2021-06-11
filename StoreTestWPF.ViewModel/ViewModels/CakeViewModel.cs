using StoreTestWPF.DAL.Models;

namespace StoreTestWPF.ViewModel.ViewModels
{
    public class CakeViewModel : ViewModelBase
    {
        private Cake cake;

        public CakeViewModel(Cake cake)
        {
            this.cake = cake;
        }

        public Cake Cake { get { return this.cake; }}

        public string Title
        {
            get { return this.cake.Title; }
            set
            {
                this.cake.Title = value;
                OnPropertyChanged(nameof(this.Title));
            }
        }

        public string Manufacture
        {
            get { return this.cake.Manufacture; }
            set
            {
                this.cake.Manufacture = value;
                OnPropertyChanged(nameof(this.Manufacture));
            }
        }

        public string Description
        {
            get { return this.cake.Description; }
            set
            {
                this.cake.Description = value;
                OnPropertyChanged(nameof(this.Description));
            }
        }

        public int PriceInCents
        {
            get { return this.cake.PriceInCents; }
            set
            {
                this.cake.PriceInCents = value;
                OnPropertyChanged(nameof(this.PriceInCents));
            }
        }

        public string ImagePath
        {
            get { return this.cake.ImagePath; }
            set
            {
                this.cake.ImagePath = value;
                OnPropertyChanged(nameof(this.ImagePath));
            }
        }
    }
}
