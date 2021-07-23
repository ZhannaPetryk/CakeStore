using StoreTestWPF.DAL.Models;
using System.Data.Entity;

namespace StoreTestWPF.DAL
{
    public class CakeStoreDbContext : DbContext
    {
        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Image> Images { get; set; }

        public CakeStoreDbContext() : base("DefaultConnection") 
        {
            Database.SetInitializer(new CakeDBInitializer());
        }

        public static CakeStoreDbContext Create()
        {
            return new CakeStoreDbContext();
        }
    }
}
