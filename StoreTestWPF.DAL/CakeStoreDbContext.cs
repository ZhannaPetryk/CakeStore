using StoreTestWPF.DAL.Models;
using System.Data.Entity;

namespace StoreTestWPF.DAL
{
    public class CakeStoreDbContext : DbContext
    {
        public DbSet<Cake> Cakes { get; set; }

        public CakeStoreDbContext() : base("DefaultConnection") { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Cake>().HasData(
        //        new Cake
        //        {
        //            Title = "Fraisier",
        //            Manufacture = "Jane's Bakery",
        //            Description = "Tort Fraisier (z francuskiego ‚fraise’ – truskawka) to francuska elegancja, szyk i delikatność. Delikatny torcik kremowy na puszystym biszkopcie. Moja wersja to biszkopt migdałowy – znany Wam już z tortu truskawkowo – migdałowego, krem bawarski (pierwszy raz na MW!), delikatne nasączenie likierem pomarańczowym (można pominąć i zastąpić sokiem z pomarańczy, jeśli tort ma być bezalkoholowy) i prosta polewa z przetartego dżemu truskawkowego. Brzmi pysznie, smakuje jeszcze lepiej niż wygląda 😉 a wykonanie jest proste i szybkie. Z nowości – krem bawarski jest to delikatny, puszysty krem przygotowany z kremu angielskiego wzmocnionego żelatyną i wymieszany z bitą śmietaną – pachnie i smakuje budyniowo lecz ma lekkość ptasiego mleczka. Może zechcecie go wykorzystać w innych deserach lub tortach? ",
        //            Price = 100,
        //            ImagePath = "/Resource/Images/Fraisier.jpg"
        //        },
        //        new Cake
        //        {
        //            Title = "Chocolate cake \nwith pears",
        //            Manufacture = "Jane's Bakery",
        //            Description = "Na przywitanie jesieni – mokre ciasto czekoladowe z migdałami i gruszkami. Pachnące, w konsystencji wilgotne, pod wieloma względami podobne do brownies, ale nie tak zwarte. Gruszki podgotowujemy wcześniej w słodkim syropie z dodatkiem cynamonu, anyżu i cytryny. W cieście są mięciutkie i z łatwością ustępują pod naporem widelczyka. Ogonki i część gruszek wystają ponad ciasto, co dodaje mu  uroku :-). Z bardzo migdałową polewą czekoladową!",
        //            Price = 79.99M,
        //            ImagePath = "/Resource/Images/Ciasto_czekoladowo_migdałowe_z_gruszkami.jpg"
        //        },
        //        new Cake
        //        {
        //            Title = "Lviv cheesecake",
        //            Manufacture = "Mazurek",
        //            Description = "Pytacie, jakie wypieki będą u gościć u mnie na stole świętecznym. Będą nowości, z tych prezentowanych ostatnio na blogu, ale będzie też sernik królewski, bez którego (ja i moja siostra) nie wyobrażamy sobie Świąt. To sernik z naszego domu rodzinnego, tym razem upiekłam go w wersji lekko kokosowej i bez ubijania osobno białek. Jest przepyszny, jak zwykle, bez dwóch zdań ;-). Na święta musi być kawałek tego sernika, popijanego koniecznie colą (tak, niezdrowa i paskudna, ale to tylko tradycja świąteczna, inaczej nie smakuje ;-), w TV nieśmiertelny Kevin, i.. znowu jestem małą Dorotką ubierającą z Tatą choinkę.. A jakie wypieki muszą pojawić się u Was na święta?",
        //            Price = 50,
        //            ImagePath = "/Resource/Images/Kokosowy_sernik_królewski.jpg"
        //        },
        //        new Cake
        //        {
        //            Title = "Rhubarb tart",
        //            Manufacture = "Mazurek",
        //            Description = "Fantastyczna wiosenna tarta z mascarpone, rabarbarem i truskawkami. Pyszne kruche ciasto, prosty krem z serka mascarpone i pieczony rabarbar z truskawkami w pomarańczowo-waniliowym sosie… Obłędne, kuszące połączenie!",
        //            Price = 65,
        //            ImagePath = "/Resource/Images/Tarta_z_mascarpone_rabarbarem_i_truskawkami.jpg"
        //        });
        //}
    }
}
