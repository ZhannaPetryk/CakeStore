namespace StoreTestWPF.ViewModel.ViewModels
{
    public class BlackTemplateViewModel : ViewModelBase
    {
        public StoreViewModel StoreViewModel { get; set; }

        public BlackTemplateViewModel(StoreViewModel viewModel)
        {
            this.StoreViewModel = viewModel;
        }
    }
}
