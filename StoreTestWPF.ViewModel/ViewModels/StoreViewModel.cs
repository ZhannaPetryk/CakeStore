using StoreTestWPF.DAL;
using StoreTestWPF.DAL.Models;
using StoreTestWPF.ViewModel.Interfaces;
using StoreTestWPF.ViewModel.Utils;
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
                    OnPropertyChanged(nameof(this.SelectedCake));
                    OnPropertyChanged(nameof(this.IsCakeSelected));
                }
            }
        }

        public bool IsCakeSelected
        {
            get
            {
                return !(this.selectedCake == null);
            }
            set
            {
                if (this.isCakeSelected != value)
                {
                    this.isCakeSelected = value;
                    OnPropertyChanged(nameof(this.IsCakeSelected));
                }
            }
        }

        public ICommand LoadCommand
        {
            get
            {
                return this.loadCommand ?? new RelayCommand(LoadExecuted, LoadCanExecute);
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return this.addCommand ?? new RelayCommand(AddExecuted);
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return this.editCommand ?? new RelayCommandWithSender<CakeViewModel>(EditExecuted, EditCanExecute);
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return this.deleteCommand ?? new RelayCommandWithSender<CakeViewModel>(DeleteExecuted, DeleteCanExecute);
            }
        }

        public StoreViewModel(IViewService viewService)
        {
            this.Cakes = new ObservableCollection<CakeViewModel>();
            this.dbContext = new CakeStoreDbContext();
            this.viewService = viewService;
        }

        private void AddExecuted()
        {
            ModifyCakeViewModel modifyViewModel = new ModifyCakeViewModel(this.viewService);
            modifyViewModel.ModifiedCake = new CakeViewModel(new Cake());
            modifyViewModel.WindowName = "Add cake";

            if (this.viewService.ShowWindow(modifyViewModel) == true)
            {
                this.SelectedCake = modifyViewModel.ModifiedCake;
                this.dbContext.Cakes.Add(SelectedCake.Cake);
                this.dbContext.SaveChanges();

                this.Cakes.Add(SelectedCake);
            }
        }

        private void EditExecuted(CakeViewModel cake)
        {
            ModifyCakeViewModel modifyViewModel = new ModifyCakeViewModel(this.viewService);
            modifyViewModel.ModifiedCake = cake;
            modifyViewModel.WindowName = "Edit cake";

            if (this.viewService.ShowWindow(modifyViewModel) == true)
            {
                this.dbContext.SaveChanges();

                this.SelectedCake = modifyViewModel.ModifiedCake;
            }
        }

        private bool EditCanExecute(CakeViewModel cake)
        {
            return cake != null && this.Cakes.Contains(cake);
        }

        private void DeleteExecuted(CakeViewModel cake)
        {
            if (this.viewService.ShowConfirmationMessage("Do you want to delete this cake permanently?") == true)
            {
                this.dbContext.Cakes.Remove(cake.Cake);
                this.dbContext.SaveChanges();

                this.Cakes.Remove(cake);
            }
        }

        private bool DeleteCanExecute(CakeViewModel cake)
        {
            return cake != null && this.Cakes.Contains(cake);
        }

        private void LoadExecuted()
        {
            this.dbContext.Cakes.Load();
            this.Cakes = new ObservableCollection<CakeViewModel>(dbContext.Cakes.Local.Select(cake => new CakeViewModel(cake)));
            OnPropertyChanged(nameof(this.Cakes));
        }

        private bool LoadCanExecute()
        {
            return !this.Cakes.Any();
        }

        //to fill database initially
        private void Init()
        {
            this.Cakes = new ObservableCollection<CakeViewModel>();
            this.Cakes.Add(new CakeViewModel(new Cake
            {
                Title = "Apple pie",
                Manufacture = "Baguette",
                Description = "Idealny jabłkowy paj, najsmaczniejszy, jaki jadłam :-). Z przepysznym kruchym ciastem (nowość na blogu!), które posiada strukturę i smak ciasta francuskiego, podobnie do niego się listkuje i smakuje (przypomina szybkie i ‚oszukane’ ciasto francuskie, jednak z mniejszą zawartością masła). Z dużą ilością jabłek doprawionych cynamonem i gałką muszkatołową, bez konieczności wcześniejszego podpiekania spodu. Kruche ciasto wymaga szczegółowego i dokładnego postępowania, ale jego smak po prostu zmiata z nóg ;-). Koniecznie wypróbujcie!",
                PriceInCents = 5500,
                ImagePath = "/Images/Apple_pie.jpg"
            }));
            this.Cakes.Add(new CakeViewModel(new Cake
            {
                Title = "Fraisier",
                Manufacture = "Jane's Bakery",
                Description = "Tort Fraisier (z francuskiego ‚fraise’ – truskawka) to francuska elegancja, szyk i delikatność. Delikatny torcik kremowy na puszystym biszkopcie. Moja wersja to biszkopt migdałowy – znany Wam już z tortu truskawkowo – migdałowego, krem bawarski (pierwszy raz na MW!), delikatne nasączenie likierem pomarańczowym (można pominąć i zastąpić sokiem z pomarańczy, jeśli tort ma być bezalkoholowy) i prosta polewa z przetartego dżemu truskawkowego. Brzmi pysznie, smakuje jeszcze lepiej niż wygląda 😉 a wykonanie jest proste i szybkie. Z nowości – krem bawarski jest to delikatny, puszysty krem przygotowany z kremu angielskiego wzmocnionego żelatyną i wymieszany z bitą śmietaną – pachnie i smakuje budyniowo lecz ma lekkość ptasiego mleczka. Może zechcecie go wykorzystać w innych deserach lub tortach? ",
                PriceInCents = 10000,
                ImagePath = "/Images/Fraisier.jpg"
            }));
            this.Cakes.Add(new CakeViewModel(new Cake
            {
                Title = "Chocolate cake \nwith pears",
                Manufacture = "Jane's Bakery",
                Description = "Na przywitanie jesieni – mokre ciasto czekoladowe z migdałami i gruszkami. Pachnące, w konsystencji wilgotne, pod wieloma względami podobne do brownies, ale nie tak zwarte. Gruszki podgotowujemy wcześniej w słodkim syropie z dodatkiem cynamonu, anyżu i cytryny. W cieście są mięciutkie i z łatwością ustępują pod naporem widelczyka. Ogonki i część gruszek wystają ponad ciasto, co dodaje mu  uroku :-). Z bardzo migdałową polewą czekoladową!",
                PriceInCents = 8000,
                ImagePath = "/Images/Ciasto_czekoladowo_migdałowe_z_gruszkami.jpg"
            }));
            this.Cakes.Add(new CakeViewModel(new Cake
            {
                Title = "Lviv cheesecake",
                Manufacture = "Mazurek",
                Description = "Pytacie, jakie wypieki będą u gościć u mnie na stole świętecznym. Będą nowości, z tych prezentowanych ostatnio na blogu, ale będzie też sernik królewski, bez którego (ja i moja siostra) nie wyobrażamy sobie Świąt. To sernik z naszego domu rodzinnego, tym razem upiekłam go w wersji lekko kokosowej i bez ubijania osobno białek. Jest przepyszny, jak zwykle, bez dwóch zdań ;-). Na święta musi być kawałek tego sernika, popijanego koniecznie colą (tak, niezdrowa i paskudna, ale to tylko tradycja świąteczna, inaczej nie smakuje ;-), w TV nieśmiertelny Kevin, i.. znowu jestem małą Dorotką ubierającą z Tatą choinkę.. A jakie wypieki muszą pojawić się u Was na święta?",
                PriceInCents = 5000,
                ImagePath = "/Images/Kokosowy_sernik_królewski.jpg"
            }));
            this.Cakes.Add(new CakeViewModel(new Cake
            {
                Title = "Rhubarb tart",
                Manufacture = "Mazurek",
                Description = "Fantastyczna wiosenna tarta z mascarpone, rabarbarem i truskawkami. Pyszne kruche ciasto, prosty krem z serka mascarpone i pieczony rabarbar z truskawkami w pomarańczowo-waniliowym sosie… Obłędne, kuszące połączenie!",
                PriceInCents = 6500,
                ImagePath = "/Images/Tarta_z_mascarpone_rabarbarem_i_truskawkami.jpg"
            }));
            this.dbContext.Cakes.RemoveRange(this.dbContext.Cakes);
            this.dbContext.Cakes.AddRange(this.Cakes.Select(cakeViewModel=>cakeViewModel.Cake));
            this.dbContext.SaveChanges();
        }
    }
}
