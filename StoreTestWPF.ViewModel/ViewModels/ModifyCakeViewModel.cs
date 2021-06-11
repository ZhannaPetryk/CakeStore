using StoreTestWPF.DAL.Models;
using StoreTestWPF.ViewModel.Interfaces;
using StoreTestWPF.ViewModel.Utils;
using System.Windows.Input;

namespace StoreTestWPF.ViewModel.ViewModels
{
    public sealed class ModifyCakeViewModel : ViewModelBase
    {
        private CakeViewModel modifiedCake;
        private ICommand acceptCommand;
        private ICommand openFileCommand;
        private IViewService viewService;

        public string WindowName { get; set; }

        public ModifyCakeViewModel(IViewService viewService)
        {
            this.viewService = viewService;
        }

        public CakeViewModel ModifiedCake
        {
            get { return this.modifiedCake; }
            set
            {
                if (this.modifiedCake != value)
                {
                    this.modifiedCake = value;
                    OnPropertyChanged(nameof(this.ModifiedCake));
                }
            }
        }

        public ICommand OpenFileCommand
        {
            get
            {
                return this.openFileCommand ?? new RelayCommand(this.OpenFileExecuted);
            }
        }

        public ICommand AcceptCommand
        {
            get
            {
                return this.acceptCommand ?? new RelayCommand(this.AcceptExecuted, this.AcceptCanExecute);
            }
        }

        private void AcceptExecuted() { }

        private bool AcceptCanExecute()
        {
            return !(string.IsNullOrWhiteSpace(this.ModifiedCake.Manufacture)
                || string.IsNullOrWhiteSpace(this.ModifiedCake.Title)
                || this.ModifiedCake.PriceInCents == 0
                || string.IsNullOrWhiteSpace(this.ModifiedCake.ImagePath));
        }

        private void OpenFileExecuted()
        {
            this.ModifiedCake.ImagePath = viewService.OpenFileDialog();
            if (this.ModifiedCake != null && this.ModifiedCake.ImagePath == null)
            {
                this.ModifiedCake.ImagePath = string.Empty;
            }
        }
    }
}