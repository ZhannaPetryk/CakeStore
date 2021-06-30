using Microsoft.Win32;
using StoreTestWPF.ViewModel.Enums;
using StoreTestWPF.ViewModel.Interfaces;
using StoreTestWPF.ViewModel.ViewModels;
using System;
using System.Windows;

namespace StoreTestWPF.Presentation.Services
{
    public sealed class ViewService : IViewService
    {
        private Window view;

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
            switch (viewModel)
            {
                case StoreViewModel _:
                    this.view = new MainWindow();
                    break;
                case ModifyCakeViewModel _:
                    this.view = new ModifyCakeWindow();
                    break;
                case MessageBoxCustomViewModel _:
                    this.view = new MessageBoxCustomWindow();
                    break;
            }
            if (this.view == null)
            { 
                return false; 
            }
            this.view.DataContext = viewModel;
            return this.view.ShowDialog() ?? false;
        }

        public void Accept()
        {
            if (this.view == null)
            {
                return;
            }
            this.view.DialogResult = true;
            this.view = null;
        }

        public void Cancel()
        {
            if (this.view == null)
            {
                return;
            }
            this.view.DialogResult = false;
            this.view = null;
        }

        public bool ShowMessage(string message)
        {
            return string.IsNullOrWhiteSpace(message) 
                ? false 
                : this.ShowWindow(new MessageBoxCustomViewModel(message, MessageType.Confirmation, MessageButtons.YesNo, this)); 
        }

        public bool ShowMessage(Exception exception)
        {
            return exception == null 
                ? false 
                : this.ShowWindow(new MessageBoxCustomViewModel(exception.Message, MessageType.Error, MessageButtons.Ok, this));
        }
    }
}
