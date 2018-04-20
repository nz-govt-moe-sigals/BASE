// Unfortunately IDbContextFactory<> only becomes available within ASP.NET Core...

namespace App.Module2.Infrastructure.Db.Context
{
    using System.Data.Entity.Infrastructure;

    public class AppModule1DbContextFactory : IDbContextFactory<AppModule1DbContext>
    {
        public AppModule1DbContext Create()
        {
            return new AppModule1DbContext(
                @"Data Source=(localdb)\mssqllocaldb;Database=AppCoreDb;Integrated Security=True");
        }
    }
}