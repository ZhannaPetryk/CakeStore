using StoreTestWPF.DAL.Models;
using System.Data.Entity;

namespace StoreTestWPF.DAL
{
    public class CakeStoreDbContext : DbContext
    {
        public DbSet<Cake> Cakes { get; set; }

        public CakeStoreDbContext() : base("DefaultConnection")
        {

        }
    }
}
