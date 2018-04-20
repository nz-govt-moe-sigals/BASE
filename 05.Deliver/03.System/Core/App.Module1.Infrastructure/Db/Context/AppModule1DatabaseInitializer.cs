namespace App.Module2.Infrastructure.Db.Context
{
    using System.Data.Entity;
    using App.Module2.Infrastructure.Db.Migrations;

    public class AppModule1DatabaseInitializer : MigrateDatabaseToLatestVersion<AppModule1DbContext,
        AppModule1DbMigrationsConfiguration>
    {
        //MigrateDatabaseToLatestVersion is an implementation of IDatabaseInitializer
        // hence the name.
    }
}