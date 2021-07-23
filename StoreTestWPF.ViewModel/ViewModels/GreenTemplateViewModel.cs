using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StoreTestWPF.ViewModel.ViewModels
{
    public class GreenTemplateViewModel : ViewModelBase, IDisposable
    {
        private StoreViewModel storeViewModel;
        public ObservableCollection<Tuple<string, string>> DetailsList
        {
            get
            {
                if (this.storeViewModel.SelectedCake != null)
                {
                    return new ObservableCollection<Tuple<string, string>>
                    {
                        new Tuple<string, string>(nameof(this.storeViewModel.SelectedCake.Manufacture), this.storeViewModel.SelectedCake.Manufacture),
                        new Tuple<string, string>(nameof(this.storeViewModel.SelectedCake.Title), this.storeViewModel.SelectedCake.Title),
                        new Tuple<string, string>(nameof(this.storeViewModel.SelectedCake.Description), this.storeViewModel.SelectedCake.Description),
                        new Tuple<string, string>(nameof(this.storeViewModel.SelectedCake.Price), this.storeViewModel.SelectedCake.Price.ToString())
                    };
                }
                else
                    return new ObservableCollection<Tuple<string, string>>();
            }
        }

        public GreenTemplateViewModel(StoreViewModel viewModel)
        {
            this.storeViewModel = viewModel;
            this.storeViewModel.PropertyChanged += GreenTemplateViewModel_PropertyChanged;
        }

        void GreenTemplateViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.storeViewModel.SelectedCake != null 
                &&(e.PropertyName == nameof(this.storeViewModel.SelectedCake)
                || e.PropertyName == nameof(this.storeViewModel.SelectedCake.Title)
                || e.PropertyName == nameof(this.storeViewModel.SelectedCake.Manufacture)
                || e.PropertyName == nameof(this.storeViewModel.SelectedCake.Description)
                || e.PropertyName == nameof(this.storeViewModel.SelectedCake.Price)
                ))
            {
                this.storeViewModel.SelectedCake.PropertyChanged += GreenTemplateViewModel_PropertyChanged;
                OnPropertyChanged(nameof(this.DetailsList));
            }
        }

        public void Dispose()
        {
            this.storeViewModel.PropertyChanged -= GreenTemplateViewModel_PropertyChanged;
            if(this.storeViewModel.SelectedCake !=null)
                this.storeViewModel.SelectedCake.PropertyChanged -= GreenTemplateViewModel_PropertyChanged;
        }
    }
}