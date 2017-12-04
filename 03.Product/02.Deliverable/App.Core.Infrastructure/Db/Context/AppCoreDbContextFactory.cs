// Unfortunately IDbContextFactory<> only becomes available within ASP.NET Core...

namespace App.Core.Infrastructure.Db.Context
{
    using System.Data.Entity.Infrastructure;

    public class AppCoreDbContextFactory : IDbContextFactory<AppCoreDbContext>
    {
        public AppCoreDbContext Create()
        {
            return new AppCoreDbContext(
                @"Data Source=(localdb)\mssqllocaldb;Database=AppCoreDb;Integrated Security=True");
        }
    }
}