namespace StoreTestWPF.ViewModel.Interfaces
{
    public interface IViewService
    {
        string OpenFileDialog();
        bool? ShowWindow(object viewModel);
        bool? ShowConfirmationMessage(string messageText);
    }
}
