namespace App.Module3.Infrastructure.Initialization.Db
{
    using App.Core.Infrastructure.Initialization;
    using App.Module3.Infrastructure.Db.Context;

    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasAppModule3DbContextSeedInitializer : IHasInitializer
    {
        void Seed(AppModule3DbContext context);
    }
}