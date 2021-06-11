using Microsoft.Win32;
using StoreTestWPF.ViewModel.Interfaces;
using StoreTestWPF.ViewModel.ViewModels;
using System;

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
            else return "";
        }

        public bool? ShowWindow(object viewModel)
        {
            switch (viewModel)
            {
                case StoreViewModel storeViewModel:
                    return new MainWindow { DataContext = storeViewModel }.ShowDialog();
                case ModifyCakeViewModel modifyCakeViewModel:
                    return new ModifyCakeWindow { DataContext = modifyCakeViewModel }.ShowDialog();
            }
            return null;
        }

        public bool? ShowConfirmationMessage(string messageText)
        {
            return new MessageBoxCustom(messageText, MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
        }
    }
}
