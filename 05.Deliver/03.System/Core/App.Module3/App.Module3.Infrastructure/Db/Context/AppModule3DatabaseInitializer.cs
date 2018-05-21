namespace App.Module3.Infrastructure.Db.Context
{
    using System.Data.Entity;
    using App.Module3.Infrastructure.Db.Migrations;

    public class AppModule3DatabaseInitializer : MigrateDatabaseToLatestVersion<AppModule3DbContext,
        AppModule3DbMigrationsConfiguration>
    {
        //MigrateDatabaseToLatestVersion is an implementation of IDatabaseInitializer
        // hence the name.
    }
}