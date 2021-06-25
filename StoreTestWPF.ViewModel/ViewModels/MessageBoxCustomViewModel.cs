using StoreTestWPF.ViewModel.Enums;
using StoreTestWPF.ViewModel.Interfaces;
using StoreTestWPF.ViewModel.Utils;
using System;
using System.Windows.Input;

namespace StoreTestWPF.ViewModel.ViewModels
{
    public class MessageBoxCustomViewModel : ViewModelBase
    {
        private ICommand acceptCommand;
        private ICommand cancelCommand;
        private readonly IViewService viewService;

        public string Text { get; }
        public string Title { get; }
        public bool YesNoButtonsVisible { get; set; }
        public bool OkButtonVisible { get; set; }
        public bool CancelButtonVisible { get; set; }

        public MessageBoxCustomViewModel(string message, MessageType type, MessageButtons buttons, IViewService viewService)
        {
            if (viewService == null)
            {
                throw new ArgumentNullException(nameof(viewService));
            }
            this.viewService = viewService;

            this.Text = message;
            this.Title = type.ToString();
            this.SetButtonsVisibility(buttons);
        }

        public ICommand AcceptCommand => this.acceptCommand ?? new RelayCommand(this.AcceptExecuted);

        public ICommand CancelCommand => this.cancelCommand ?? new RelayCommand(this.CancelExecuted);

        private void AcceptExecuted()
        {
            this.viewService.Accept();
        }

        private void CancelExecuted()
        {
            this.viewService.Cancel();
        }

        private void SetButtonsVisibility(MessageButtons buttons)
        {
            switch (buttons)
            {
                case MessageButtons.OkCancel:
                    this.OkButtonVisible = true;
                    this.CancelButtonVisible = true;
                    break;
                case MessageButtons.YesNo:
                    this.YesNoButtonsVisible = true;
                    break;
                case MessageButtons.Ok:
                    this.OkButtonVisible = true;
                    break;
            }
        }
    }
}
