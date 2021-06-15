using StoreTestWPF.DAL.Models;
using System;

namespace StoreTestWPF.ViewModel.ViewModels
{
    public class CakeViewModel : ViewModelBase
    {
        private Cake cake;

        public CakeViewModel()
        {
        }

        public CakeViewModel(Cake cake)
        {
            if (cake == null)
            {
                throw new NullReferenceException();
            }
            this.cake = cake;
        }

        public Cake Cake => this.cake;

        public string Title
        {
            get { return this.cake.Title; }
            set
            {
                if(this.cake.Title != value)
                {
                    this.cake.Title = value;
                    this.OnPropertyChanged(nameof(this.Title));
                }
            }
        }

        public string Manufacture
        {
            get { return this.cake.Manufacture; }
            set
            {
                if (this.cake.Manufacture != value)
                {
                    this.cake.Manufacture = value;
                    this.OnPropertyChanged(nameof(this.Manufacture));
                }
            }
        }

        public string Description
        {
            get { return this.cake.Description; }
            set
            {
                if (this.cake.Description != value)
                {
                    this.cake.Description = value;
                    this.OnPropertyChanged(nameof(this.Description));
                }
            }
        }

        public decimal Price
        {
            get { return this.cake.Price; }
            set
            {
                if (this.cake.Price != value)
                {
                    this.cake.Price = value;
                    this.OnPropertyChanged(nameof(this.Price));
                }
            }
        }

        public string ImagePath
        {
            get { return this.cake.ImagePath; }
            set
            {
                if (this.cake.ImagePath != value)
                {
                    this.cake.ImagePath = value;
                    this.OnPropertyChanged(nameof(this.ImagePath));
                }
            }
        }
    }
}
