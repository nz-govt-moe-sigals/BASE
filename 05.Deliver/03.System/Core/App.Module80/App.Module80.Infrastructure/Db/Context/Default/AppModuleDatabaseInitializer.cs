using App.Module80.Infrastructure.Initialization.Db.Migrations;
using App.Module80.Shared.Contracts;

namespace App.Module80.Infrastructure.Db.Context.Default
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

