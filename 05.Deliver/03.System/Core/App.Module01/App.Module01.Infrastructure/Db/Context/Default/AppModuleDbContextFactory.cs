// Unfortunately IDbContextFactory<> only becomes available within ASP.NET Core...

namespace App.Module01.Infrastructure.Db.Context.Default
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