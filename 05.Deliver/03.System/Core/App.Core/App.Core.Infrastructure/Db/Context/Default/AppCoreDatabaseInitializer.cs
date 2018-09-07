using App.Core.Infrastructure.Db.Context.Base;

namespace App.Core.Infrastructure.Db.Context.Default
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Migrations;

    // IMPORTANT:
    // Do NOT carelessly rename as this is referenced
    // via web.config, under the EF section.
    public class AppCoreDatabaseInitializer : BaseDatabaseInitializer<AppCoreDbContext,
        AppCoreDbMigrationsConfiguration>
    {


    }
}