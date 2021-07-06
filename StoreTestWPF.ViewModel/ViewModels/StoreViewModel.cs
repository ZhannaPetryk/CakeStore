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
        private Template selectedTemplate;
        private ViewModelBase cakeDetailsViewModel;
        private ViewModelBase blackTemplateDetailsViewModel;
        private ViewModelBase greenTemplateDetailsViewModel;
        private ICommand loadCommand;
        private ICommand addCommand;
        private ICommand editCommand;
        private ICommand deleteCommand;
        private readonly IViewService viewService;
        private readonly CakeStoreDbContext dbContext;

        public ObservableCollection<CakeViewModel> Cakes { get; private set; }
        
        public Template SelectedTemplate 
        {
            get => this.selectedTemplate;
            set
            {
                if (this.selectedTemplate != value)
                {
                    this.selectedTemplate = value;
                    this.OnPropertyChanged(nameof(this.SelectedTemplate));
                    switch (value)
                    {
                        case Template.BlackTemplate:
                            this.cakeDetailsViewModel = blackTemplateDetailsViewModel;
                            break;
                        case Template.GreenTemplate:
                            this.cakeDetailsViewModel = greenTemplateDetailsViewModel;
                            break;
                    }
                    this.OnPropertyChanged(nameof(this.CakeDetailsViewModel));
                }
            }
        }

        public CakeViewModel SelectedCake
        {
            get => this.selectedCake;
            set
            {
                if (this.selectedCake != value)
                {
                    this.selectedCake = value;
                    this.OnPropertyChanged(nameof(this.SelectedCake));
                    this.OnPropertyChanged(nameof(this.IsCakeSelected));
                }
            }
        }

        public ViewModelBase CakeDetailsViewModel
        {
            get => this.cakeDetailsViewModel;
            set
            {
                if (this.cakeDetailsViewModel != value)
                {
                    this.cakeDetailsViewModel = value;
                    this.OnPropertyChanged(nameof(this.CakeDetailsViewModel));
                }
            }
        }

        public bool IsCakeSelected => this.SelectedCake != null;

        public ICommand LoadCommand => this.loadCommand ?? new RelayCommand(this.LoadExecuted, this.LoadCanExecute);

        public ICommand AddCommand => this.addCommand ?? new RelayCommand(this.AddExecuted);

        public ICommand EditCommand => this.editCommand ?? new RelayCommandWithParameter<CakeViewModel>(this.EditExecuted, this.EditCanExecute);

        public ICommand DeleteCommand => this.deleteCommand ?? new RelayCommandWithParameter<CakeViewModel>(this.DeleteExecuted, this.DeleteCanExecute);

        public StoreViewModel(IViewService viewService)
        {
            if (viewService == null)
            {
                throw new ArgumentNullException(nameof(viewService));
            }
            this.viewService = viewService;
            this.Cakes = new ObservableCollection<CakeViewModel>();
            this.SelectedTemplate = Template.BlackTemplate;
            this.blackTemplateDetailsViewModel = new BlackTemplateViewModel(this);
            this.greenTemplateDetailsViewModel = new GreenTemplateViewModel(this);
            this.cakeDetailsViewModel = this.blackTemplateDetailsViewModel;
            this.dbContext = CakeStoreDbContext.Create();
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
                this.dbContext.Cakes.Add(this.SelectedCake.Cake);
                this.dbContext.SaveChanges();

                this.Cakes.Add(this.SelectedCake);
            }
            catch (Exception exception)
            {
                this.viewService.ShowMessage(exception);
            }
        }

        private void EditExecuted(CakeViewModel cake)
        {
            try
            {
                var unmodifiedCake = new CakeViewModel(this.SelectedCake.Cake.Clone() as Cake);
                var modifyViewModel = new ModifyCakeViewModel(this.viewService);
                modifyViewModel.ModifiedCake = cake;

                WindowTitles Title = WindowTitles.Edit;
                modifyViewModel.Title = Title.GetDisplayAttributesFrom(typeof(WindowTitles)).Name;

                if (!this.viewService.ShowWindow(modifyViewModel))
                {
                    if(this.Cakes.Contains(cake))
                    {
                        this.Cakes[this.Cakes.IndexOf(cake)] = unmodifiedCake;
                        this.SelectedCake = unmodifiedCake;
                    }
                    return;
                }

                this.dbContext.SaveChanges();

                this.SelectedCake = modifyViewModel.ModifiedCake;

            }
            catch (Exception exception)
            {
                this.viewService.ShowMessage(exception);
            }
        }

        private bool EditCanExecute(CakeViewModel cake) => cake != null && this.Cakes.Contains(cake);

        private void DeleteExecuted(CakeViewModel cake)
        {
            if (!this.viewService.ShowMessage("Do you want to delete this cake permanently?"))
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
                this.Cakes = new ObservableCollection<CakeViewModel>(this.dbContext.Cakes.Local.Select(cake => new CakeViewModel(cake)));
                this.OnPropertyChanged(nameof(this.Cakes));
            }
            catch (Exception exception)
            {
                this.viewService.ShowMessage(exception);
            }
        }

        private bool LoadCanExecute() => !this.Cakes.Any();
    }
}
