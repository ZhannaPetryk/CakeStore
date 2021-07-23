using StoreTestWPF.ViewModel.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StoreTestWPF.ViewModel.ViewModels
{
    public class CakeImagesViewModel : ViewModelBase
    {
        public int currentElement = 0;
        private ICommand leftCommand;
        private ICommand rightCommand;

        public int CurrentElement
        {
            get => this.currentElement;
            set
            {
                if (this.currentElement != value)
                {
                    this.currentElement = value;
                    this.OnPropertyChanged(nameof(this.CurrentElement));
                }
            }
        }

        public StoreViewModel StoreViewModel { get; set; }

        public ICommand LeftCommand => this.leftCommand ?? new RelayCommand(this.LeftExecuted);
        public ICommand RightCommand => this.rightCommand ?? new RelayCommand(this.RightExecuted);

        public CakeImagesViewModel(StoreViewModel viewModel)
        {
            this.StoreViewModel = viewModel;
        }

        public void RaiseCurrentElementChanged()
        {
            this.CurrentElement = 0;
            this.OnPropertyChanged(nameof(this.CurrentElement));
        }

        private void LeftExecuted()
        {
            if (this.currentElement > 0)
            {
                this.currentElement--;
            }
        }

        private void RightExecuted()
        {
            if (this.currentElement < (this.StoreViewModel.SelectedCake?.Images.Count - 1))
            {
                this.currentElement++;
            }
        }
    }
}
