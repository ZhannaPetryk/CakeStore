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
        private ICommand addImageCommand;
        private ICommand deleteImageCommand;
        private readonly IViewService viewService;

        public string Title { get; set; }

        public ModifyCakeViewModel(IViewService viewService)
        {
            if (viewService == null)
            {
                throw new ArgumentNullException(nameof(viewService));
            }
            this.viewService = viewService;
        }

        public CakeViewModel ModifiedCake
        {
            get => this.modifiedCake;
            set
            {
                if (this.modifiedCake != value)
                {
                    this.modifiedCake = value;
                    this.OnPropertyChanged(nameof(this.ModifiedCake));
                }
            }
        }

        public ICommand AddImageCommand => this.addImageCommand ?? new RelayCommand(this.AddImageExecuted);

        public ICommand AcceptCommand => this.acceptCommand ?? new RelayCommand(this.AcceptExecuted, this.AcceptCanExecute);

        public ICommand CancelCommand => this.cancelCommand ?? new RelayCommand(this.CancelExecuted);

        public ICommand DeleteImageCommand => this.deleteImageCommand ?? new RelayCommandWithParameter<Image>(this.DeleteImageExecuted);

        private void AcceptExecuted()
        {
            this.viewService.Accept();
        }

        private bool AcceptCanExecute() => !(string.IsNullOrWhiteSpace(this.ModifiedCake?.Manufacture)
            || string.IsNullOrWhiteSpace(this.ModifiedCake?.Title)
            || this.ModifiedCake?.Price == decimal.Zero
            || this.ModifiedCake?.Images.Count == 0);

        private void CancelExecuted()
        {
            this.viewService.Cancel();
        }

        private void DeleteImageExecuted(Image imageToDelete)
        {
            imageToDelete.Cake = new Cake();
            this.ModifiedCake.Images.Remove(imageToDelete);
            this.ModifiedCake.OnPropertyChanged(nameof(this.ModifiedCake.Images));
        }

        private void AddImageExecuted()
        {
            if (this.ModifiedCake == null)
            {
                return;
            }
            this.ModifiedCake.Images.Add(new Image { Path = this.viewService.OpenFileDialog() });
            this.ModifiedCake.OnPropertyChanged(nameof(this.ModifiedCake.Images));
        }
    }
}