using StoreTestWPF.ViewModel.ViewModels;
using System;

namespace StoreTestWPF.ViewModel.Interfaces
{
    public interface IViewService
    {
        string OpenFileDialog();
        bool ShowWindow(ViewModelBase viewModel);
        bool ShowMessage(string message);
        bool ShowMessage(Exception exception);
        void Accept();
        void Cancel();
    }
}
