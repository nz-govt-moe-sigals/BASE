// Unfortunately IDbContextFactory<> only becomes available within ASP.NET Core...

namespace App.Module3.Infrastructure.Db.Context
{
    using System.Data.Entity.Infrastructure;

    public class AppModule3DbContextFactory : IDbContextFactory<AppModule3DbContext>
    {
        public AppModule3DbContext Create()
        {
            return new AppModule3DbContext(
                @"Data Source=(localdb)\mssqllocaldb;Database=AppCoreDb;Integrated Security=True");
        }
    }
}