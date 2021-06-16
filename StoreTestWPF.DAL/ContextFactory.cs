namespace StoreTestWPF.DAL
{
    public class ContextFactory : IContextFactory<CakeStoreDbContext>
    {
        public CakeStoreDbContext Create()
        {
            return new CakeStoreDbContext();
        }
    }
}
