namespace StoreTestWPF.ViewModel.ViewModels
{
    public class GreenTemplateViewModel : ViewModelBase
    {
        public StoreViewModel StoreViewModel { get; set; }

        public GreenTemplateViewModel(StoreViewModel viewModel)
        {
            this.StoreViewModel = viewModel;
        }
    }
}
