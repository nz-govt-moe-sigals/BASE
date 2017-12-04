namespace App.Core.Infrastructure.Initialization.Db
{
    using App.Core.Infrastructure.Db.Context;

    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasAppCoreDbContextSeedInitializer : IHasInitializer
    {
        void Seed(AppCoreDbContext context);
    }
}