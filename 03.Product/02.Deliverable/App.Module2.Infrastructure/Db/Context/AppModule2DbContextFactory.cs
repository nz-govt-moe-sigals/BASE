// Unfortunately IDbContextFactory<> only becomes available within ASP.NET Core...

namespace App.Module2.Infrastructure.Db.Context
{
    using System.Data.Entity.Infrastructure;

    public class AppModule2DbContextFactory : IDbContextFactory<AppModule2DbContext>
    {
        public AppModule2DbContext Create()
        {
            return new AppModule2DbContext(
                @"Data Source=(localdb)\mssqllocaldb;Database=AppCoreDb;Integrated Security=True");
        }
    }
}