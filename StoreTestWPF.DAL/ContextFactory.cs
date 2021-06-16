namespace StoreTestWPF.DAL
{
    public static class ContextFactory
    {
        public static CakeStoreDbContext Create()
        {
            return new CakeStoreDbContext();
        }
    }
}
