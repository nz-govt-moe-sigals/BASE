namespace App.Module2.Infrastructure.Db.Context
{
    using System.Data.Entity;
    using App.Module2.Infrastructure.Db.Migrations;

    public class AppModule2DatabaseInitializer : MigrateDatabaseToLatestVersion<AppModule2DbContext,
        AppModule2DbMigrationsConfiguration>
    {
        //MigrateDatabaseToLatestVersion is an implementation of IDatabaseInitializer
        // hence the name.
    }
}