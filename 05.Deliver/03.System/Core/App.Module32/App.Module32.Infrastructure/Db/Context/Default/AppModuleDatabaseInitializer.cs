using App.Module32.Shared.Contracts;

namespace App.Module32.Infrastructure.Db.Context.Default
{
    using System.Data.Entity;
    using App.Module32.Infrastructure.Db.Migrations;

    // Do NOT carelessly rename as this is referenced
    // via web.config, under the EF section.
    public class AppModuleDatabaseInitializer : MigrateDatabaseToLatestVersion<AppModuleDbContext,
        AppModuleDefaultDbMigrationsConfiguration>, IHasModuleSpecificIdentifier
    {
        //MigrateDatabaseToLatestVersion is an implementation of IDatabaseInitializer
        // hence the name.
    }
}

