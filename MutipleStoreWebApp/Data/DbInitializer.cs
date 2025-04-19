namespace MutipleStoreWebApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Stores.Any())
            {
                return;   // DB has been seeded
            }


        }
    }
}
