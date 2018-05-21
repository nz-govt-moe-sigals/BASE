namespace App.Module11.Infrastructure.Initialization.Db
{
    using App.Core.Infrastructure.Initialization;
    using App.Module11.Infrastructure.Db.Context;

    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasAppModule11DbContextSeedInitializer : IHasInitializer, IHasModuleSpecificIdentifier
    {
        void Seed(AppModule11DbContext context);
    }
}