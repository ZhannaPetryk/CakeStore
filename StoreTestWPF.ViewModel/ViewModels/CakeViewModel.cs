using StoreTestWPF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace StoreTestWPF.ViewModel.ViewModels
{
    public class CakeViewModel : ViewModelBase
    {
        private readonly Cake cake;

        public CakeViewModel(Cake cake)
        {
            if (cake == null)
            {
                throw new ArgumentNullException(nameof(cake));
            }
            this.cake = cake;
            this.Images = new ObservableCollection<Image>(this.cake.Images);
            this.Images.CollectionChanged += OnCollectionChanged;
        }

        public Cake Cake => this.cake;

        public string Title
        {
            get => this.cake.Title;
            set
            {
                if (this.cake.Title != value)
                {
                    this.cake.Title = value;
                    this.OnPropertyChanged(nameof(this.Title));
                }
            }
        }

        public string Manufacture
        {
            get => this.cake.Manufacture;
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
            get => this.cake.Description;
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
            get => this.cake.Price;
            set
            {
                if (this.cake.Price != value)
                {
                    this.cake.Price = value;
                    this.OnPropertyChanged(nameof(this.Price));
                }
            }
        }

        public ObservableCollection<Image> Images { get; private set; }
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.cake.Images = this.Images.ToList();
        }
    }
}
