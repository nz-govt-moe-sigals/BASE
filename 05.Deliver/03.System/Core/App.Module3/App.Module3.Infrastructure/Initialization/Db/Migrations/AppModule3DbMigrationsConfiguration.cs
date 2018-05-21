using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Module3.Infrastructure.Db.Migrations
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Module3.Infrastructure.Db.Context;
    using App.Module3.Infrastructure.Db.Migrations.Seeding;

    // Referenced by AppModule3DatabaseInitializer
    public sealed class AppModule3DbMigrationsConfiguration : DbMigrationsConfiguration<AppModule3DbContext>
    {
        public AppModule3DbMigrationsConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            //Where to save Migrations (keep schemas distinct in their own folder):
            this.MigrationsDirectory = @"Initialization\Db\Migrations\" + Constants.Module.Names.ModuleKey;
        }

        protected override void Seed(AppModule3DbContext context)
        {
            // Hand off to a specialized class for Seeding.
            var hostSettingsService = AppDependencyLocator.Current.GetInstance<IHostSettingsService>();
            new AppModule3DbContextSeedingOrchestrator(hostSettingsService).Initialize(context);
        }
    }
}