namespace App.Module31.Infrastructure.Initialization.Db
{
    using App.Core.Infrastructure.Initialization;
    using App.Module31.Infrastructure.Db.Context;
    using App.Module31.Infrastructure.Db.Context.Default;

    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasAppModuleDbContextSeedInitializer : IHasInitializer, IHasModuleSpecificIdentifier
    {
        void Seed(AppModuleDbContext context);
    }
}




