using App.Module33.Infrastructure.Initialization.Db.Migrations;

namespace App.Module33.Infrastructure.Db.Context.Default
{
    using System.Data.Entity;

    // Do NOT carelessly rename as this is referenced
    // via web.config, under the EF section.
    public class AppModuleDatabaseInitializer : MigrateDatabaseToLatestVersion<AppModuleDbContext,
        AppModuleDefaultDbMigrationsConfiguration>, IHasModuleSpecificIdentifier
    {
        //MigrateDatabaseToLatestVersion is an implementation of IDatabaseInitializer
        // hence the name.
    }
}

