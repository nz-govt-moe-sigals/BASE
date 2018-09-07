using App.Core.Infrastructure.Db.Context.Base;

namespace App.Module22.Infrastructure.Db.Context.Default
{
    using System.Data.Entity;
    using App.Module22.Infrastructure.Db.Migrations;

    // Do NOT carelessly rename as this is referenced
    // via web.config, under the EF section.
    public class AppModuleDatabaseInitializer : BaseDatabaseInitializer<AppModuleDbContext,
        AppModuleDefaultDbMigrationsConfiguration>, IHasModuleSpecificIdentifier
    {
        //MigrateDatabaseToLatestVersion is an implementation of IDatabaseInitializer
        // hence the name.
    }
}

