using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module11.Infrastructure.Db.Migrations
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Module11.Infrastructure.Db.Context;
    using App.Module11.Infrastructure.Db.Migrations.Seeding;
    using App.Module11.Shared;

    // Referenced by AppModule11DatabaseInitializer
    public sealed class AppModule11DbMigrationsConfiguration : DbMigrationsConfiguration<AppModule11DbContext>, IHasModuleSpecificIdentifier
    {
        public AppModule11DbMigrationsConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            //Where to save Migrations (keep schemas distinct in their own folder):
            this.MigrationsDirectory = @"Initialization\Db\Migrations\" + Constants.Module.Names.ModuleKey;
        }

        protected override void Seed(AppModule11DbContext context)
        {
            // Hand off to a specialized class for Seeding.
            var hostSettingsService = AppDependencyLocator.Current.GetInstance<IHostSettingsService>();
            new AppModule11DbContextSeedingOrchestrator(hostSettingsService).Initialize(context);
        }
    }
}