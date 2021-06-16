using Microsoft.Win32;
using StoreTestWPF.ViewModel.Interfaces;
using StoreTestWPF.ViewModel.ViewModels;
using System;
using System.Windows;

namespace StoreTestWPF.Presentation.Services
{
    public sealed class ViewService : IViewService
    {
        public string OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;
            else return string.Empty;
        }

        public bool ShowWindow(ViewModelBase viewModel)
        {
            Window view = null;
            switch (viewModel)
            {
                case StoreViewModel _:
                    view = new MainWindow();
                    break;
                case ModifyCakeViewModel _:
                    view = new ModifyCakeWindow();
                    break;
            }
            if (view == null)
            { 
                return false; 
            }
            view.DataContext = viewModel;
            return view.ShowDialog() ?? false;
        }

        public bool ShowConfirmationMessage(string messageText)
        {
            return string.IsNullOrWhiteSpace(messageText) ? false : new MessageBoxCustom(messageText, MessageType.Confirmation, MessageButtons.YesNo).ShowDialog() ?? false;
        }

        public bool ShowErrorMessage(string messageText)
        {
            return string.IsNullOrWhiteSpace(messageText) ? false : new MessageBoxCustom(messageText, MessageType.Error, MessageButtons.Ok).ShowDialog() ?? false;
        }
    }
}
