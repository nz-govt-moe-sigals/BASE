namespace App.Module11.Infrastructure.Db.Context
{
    using System.Data.Entity;
    using App.Module11.Infrastructure.Db.Migrations;

    public class AppModule11DatabaseInitializer : MigrateDatabaseToLatestVersion<AppModule11DbContext,
        AppModule11DbMigrationsConfiguration>
    {
        //MigrateDatabaseToLatestVersion is an implementation of IDatabaseInitializer
        // hence the name.
    }
}