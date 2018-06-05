using App.Module32.Shared.Contracts;

namespace App.Module32.Infrastructure.Initialization.Db
{
    using App.Core.Infrastructure.Initialization;
    using App.Module32.Infrastructure.Db.Context;

    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasAppModuleDbContextSeedInitializer : IHasInitializer, IHasModuleSpecificIdentifier
    {
        void Seed(AppModuleDbContext context);
    }
}

