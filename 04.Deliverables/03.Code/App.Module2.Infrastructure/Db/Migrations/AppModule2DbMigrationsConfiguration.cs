namespace App.Module2.Infrastructure.Db.Migrations
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Module2.Infrastructure.Db.Context;
    using App.Module2.Infrastructure.Db.Migrations.Seeding;

    // Referenced by AppModule2DatabaseInitializer
    public sealed class AppModule2DbMigrationsConfiguration : DbMigrationsConfiguration<AppModule2DbContext>
    {
        public AppModule2DbMigrationsConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            //Where to save Migrations (keep schemas distinct in their own folder):
            this.MigrationsDirectory = @"Db\Migrations\Module2";
        }

        protected override void Seed(AppModule2DbContext context)
        {
            // Hand off to a specialized class for Seeding.
            var hostSettingsService = AppDependencyLocator.Current.GetInstance<IHostSettingsService>();
            new AppModule2DbContextSeedingOrchestrator(hostSettingsService).Initialize(context);
        }
    }
}