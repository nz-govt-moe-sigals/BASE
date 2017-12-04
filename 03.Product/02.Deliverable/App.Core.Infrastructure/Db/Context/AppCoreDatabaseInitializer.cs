namespace App.Core.Infrastructure.Db.Context
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Migrations;

    // Do NOT carelessly rename as this is referenced
    // via web.config, under the EF section.
    public class AppCoreDatabaseInitializer : MigrateDatabaseToLatestVersion<AppCoreDbContext,
        AppCoreDbMigrationsConfiguration>
    {
    }
}