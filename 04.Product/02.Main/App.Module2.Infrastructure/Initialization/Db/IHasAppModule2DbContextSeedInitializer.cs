namespace App.Module2.Infrastructure.Initialization.Db
{
    using App.Core.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Db.Context;

    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasAppModule2DbContextSeedInitializer : IHasInitializer
    {
        void Seed(AppModule2DbContext context);
    }
}