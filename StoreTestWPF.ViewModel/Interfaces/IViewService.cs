using StoreTestWPF.ViewModel.ViewModels;

namespace StoreTestWPF.ViewModel.Interfaces
{
    public interface IViewService
    {
        string OpenFileDialog();
        bool ShowWindow(ViewModelBase viewModel);
        bool ShowConfirmationMessage(string messageText);
        bool ShowErrorMessage(string messageText);
        void Accept();
        void Cancel();
    }
}
