using System.Data.Entity;

namespace StoreTestWPF.DAL
{
    public interface IContextFactory<out TContext> where TContext : DbContext
    {
        TContext Create();
    }
}
