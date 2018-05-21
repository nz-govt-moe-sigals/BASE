// Unfortunately IDbContextFactory<> only becomes available within ASP.NET Core...

namespace App.Module11.Infrastructure.Db.Context
{
    using System.Data.Entity.Infrastructure;

    public class AppModule11DbContextFactory : IDbContextFactory<AppModule11DbContext>
    {
        public AppModule11DbContext Create()
        {
            return new AppModule11DbContext(
                @"Data Source=(localdb)\mssqllocaldb;Database=AppCoreDb;Integrated Security=True");
        }
    }
}