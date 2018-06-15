namespace App.Module02.Infrastructure.Initialization.Db
{
    using App.Core.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Db.Context;
    using App.Module02.Infrastructure.Db.Context.Default;

    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasAppModuleDbContextSeedInitializer : IHasInitializer, IHasModuleSpecificIdentifier
    {
        void Seed(AppModuleDbContext context);
    }
}

