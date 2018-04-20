namespace App.Module2.Infrastructure.Initialization.Db
{
    using App.Core.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Db.Context;

    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasAppModule1DbContextSeedInitializer : IHasInitializer
    {
        void Seed(AppModule1DbContext context);
    }
}