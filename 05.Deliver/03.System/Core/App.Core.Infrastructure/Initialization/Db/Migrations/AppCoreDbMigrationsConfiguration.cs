namespace App.Core.Infrastructure.Db.Migrations
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Migrations.Seeding;
    using App.Core.Infrastructure.Services;

    // Referenced by AppCoreDatabaseInitializer
    public sealed class AppCoreDbMigrationsConfiguration : DbMigrationsConfiguration<AppCoreDbContext>
    {
        public AppCoreDbMigrationsConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            //Where to save Migrations (keep schemas distinct in their own folder):
            this.MigrationsDirectory = @"Initialization\Db\Migrations\" + Constants.Module.Names.ModuleKey;
        }

        protected override void Seed(AppCoreDbContext context)
        {
            // Hand off to a specialized class for Seeding.
            AppDependencyLocator.Current.GetInstance< AppCoreDbContextSeedingOrchestrator >().Initialize(context);
        }
    }
}