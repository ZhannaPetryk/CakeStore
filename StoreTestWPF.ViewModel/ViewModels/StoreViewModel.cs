using StoreTestWPF.DAL;
using StoreTestWPF.DAL.Models;
using StoreTestWPF.ViewModel.Enums;
using StoreTestWPF.ViewModel.Interfaces;
using StoreTestWPF.ViewModel.Utils;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace StoreTestWPF.ViewModel.ViewModels
{
    public sealed class StoreViewModel : ViewModelBase
    {
        private CakeViewModel selectedCake;
        private bool isCakeSelected;
        private ICommand loadCommand;
        private ICommand addCommand;
        private ICommand editCommand;
        private ICommand deleteCommand;
        private IViewService viewService;
        private CakeStoreDbContext dbContext;

        public ObservableCollection<CakeViewModel> Cakes { get; private set; }

        public CakeViewModel SelectedCake
        {
            get { return this.selectedCake; }
            set
            {
                if (this.selectedCake != value)
                {
                    this.selectedCake = value;
                    this.OnPropertyChanged(nameof(this.SelectedCake));

                    this.isCakeSelected = !(value == null);
                    this.OnPropertyChanged(nameof(this.IsCakeSelected));
                }
            }
        }

        public bool IsCakeSelected
        {
            get
            {
                return isCakeSelected;
            }
            set
            {
                if (this.isCakeSelected != value)
                {
                    this.isCakeSelected = value;
                    this.OnPropertyChanged(nameof(this.IsCakeSelected));
                }
            }
        }

        public ICommand LoadCommand => this.loadCommand ?? new RelayCommand(LoadExecuted, LoadCanExecute);

        public ICommand AddCommand => this.addCommand ?? new RelayCommand(AddExecuted);

        public ICommand EditCommand => this.editCommand ?? new RelayCommandWithParameter<CakeViewModel>(EditExecuted, EditCanExecute);

        public ICommand DeleteCommand => this.deleteCommand ?? new RelayCommandWithParameter<CakeViewModel>(DeleteExecuted, DeleteCanExecute);

        public StoreViewModel(IViewService viewService)
        {
            this.Cakes = new ObservableCollection<CakeViewModel>();
            this.dbContext = ContextFactory.Create();
            this.viewService = viewService;
        }

        private void AddExecuted()
        {
            try
            {
                var modifyViewModel = new ModifyCakeViewModel(this.viewService);
                modifyViewModel.ModifiedCake = new CakeViewModel(new Cake());
                WindowTitles Title = WindowTitles.Add;
                modifyViewModel.Title = Title.GetDisplayAttributesFrom(typeof(WindowTitles)).Name;

                if (!this.viewService.ShowWindow(modifyViewModel))
                {
                    return;
                }
                this.SelectedCake = modifyViewModel.ModifiedCake;
                this.dbContext.Cakes.Add(SelectedCake.Cake);
                this.dbContext.SaveChanges();

                this.Cakes.Add(SelectedCake);
            }
            catch (Exception exception)
            {
                viewService.ShowErrorMessage(exception.Message);
            }
            
        }

        private void EditExecuted(CakeViewModel cake)
        {
            try
            {
                var modifyViewModel = new ModifyCakeViewModel(this.viewService);
                modifyViewModel.ModifiedCake = cake;

                WindowTitles Title = WindowTitles.Edit;
                modifyViewModel.Title = Title.GetDisplayAttributesFrom(typeof(WindowTitles)).Name;

                if (!this.viewService.ShowWindow(modifyViewModel))
                {
                    return;
                }

                this.dbContext.SaveChanges();

                this.SelectedCake = modifyViewModel.ModifiedCake;
            }
            catch (Exception exception)
            {
                viewService.ShowErrorMessage(exception.Message);
            }
        }

        private bool EditCanExecute(CakeViewModel cake) => cake != null && this.Cakes.Contains(cake);

        private void DeleteExecuted(CakeViewModel cake)
        {
            if (!this.viewService.ShowConfirmationMessage("Do you want to delete this cake permanently?"))
            {
                return;
            }
            this.dbContext.Cakes.Remove(cake.Cake);
            this.dbContext.SaveChanges();

            this.Cakes.Remove(cake);
        }

        private bool DeleteCanExecute(CakeViewModel cake) => cake != null && this.Cakes.Contains(cake);

        private void LoadExecuted()
        {
            try
            {
                this.dbContext.Cakes.Load();
                this.Cakes = new ObservableCollection<CakeViewModel>(dbContext.Cakes.Local.Select(cake => new CakeViewModel(cake)));
                this.OnPropertyChanged(nameof(this.Cakes));
            }
            catch (Exception exception)
            {
                viewService.ShowErrorMessage(exception.Message);
            }
        }

        private bool LoadCanExecute() => !this.Cakes.Any();
    }
}
