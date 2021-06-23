using StoreTestWPF.DAL.Models;
using StoreTestWPF.ViewModel.Interfaces;
using StoreTestWPF.ViewModel.Utils;
using System;
using System.Windows.Input;

namespace StoreTestWPF.ViewModel.ViewModels
{
    public sealed class ModifyCakeViewModel : ViewModelBase
    {
        private CakeViewModel modifiedCake;
        private ICommand acceptCommand;
        private ICommand cancelCommand;
        private ICommand openFileCommand;
        private IViewService viewService;

        public string Title { get; set; }

        public ModifyCakeViewModel(IViewService viewService)
        {
            if (viewService == null)
            {
                throw new NullReferenceException();
            }
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
                    this.OnPropertyChanged(nameof(this.ModifiedCake));
                }
            }
        }

        public ICommand OpenFileCommand => this.openFileCommand ?? new RelayCommand(this.OpenFileExecuted);

        public ICommand AcceptCommand => this.acceptCommand ?? new RelayCommand(this.AcceptExecuted, this.AcceptCanExecute);

        public ICommand CancelCommand => this.cancelCommand ?? new RelayCommand(this.CancelExecuted);

        private void AcceptExecuted()
        {
            this.viewService.Accept();
        }

        private bool AcceptCanExecute() => !(string.IsNullOrWhiteSpace(this.ModifiedCake?.Manufacture)
            || string.IsNullOrWhiteSpace(this.ModifiedCake?.Title)
            || this.ModifiedCake?.Price == decimal.Zero
            || string.IsNullOrWhiteSpace(this.ModifiedCake?.ImagePath));

        private void CancelExecuted()
        {
            this.viewService.Cancel();
        }

        private void OpenFileExecuted()
        {
            if (this.ModifiedCake == null)
            {
                return;
            }
            this.ModifiedCake.ImagePath = viewService.OpenFileDialog();
        }
    }
}