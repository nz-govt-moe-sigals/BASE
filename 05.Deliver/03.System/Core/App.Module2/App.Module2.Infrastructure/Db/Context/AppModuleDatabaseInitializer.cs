namespace App.Module02.Infrastructure.Db.Context
{
    using System.Data.Entity;
    using App.Module02.Infrastructure.Db.Migrations;

    public class AppModuleDatabaseInitializer : MigrateDatabaseToLatestVersion<AppModuleDbContext,
        AppModuleDbMigrationsConfiguration>, IHasModuleSpecificIdentifier
    {
        //MigrateDatabaseToLatestVersion is an implementation of IDatabaseInitializer
        // hence the name.
    }
}