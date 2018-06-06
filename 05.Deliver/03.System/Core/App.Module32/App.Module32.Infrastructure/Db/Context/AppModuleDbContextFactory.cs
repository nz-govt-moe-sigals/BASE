// Unfortunately IDbContextFactory<> only becomes available within ASP.NET Core...

using App.Module32.Shared.Contracts;

namespace App.Module32.Infrastructure.Db.Context
{
    using System.Data.Entity.Infrastructure;

    public class AppModuleDbContextFactory : IDbContextFactory<AppModuleDbContext>, IHasModuleSpecificIdentifier
    {
        public AppModuleDbContext Create()
        {
            return new AppModuleDbContext(
                @"Data Source=(localdb)\mssqllocaldb;Database=AppCoreDb;Integrated Security=True");
        }
    }
}

