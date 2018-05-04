namespace App.Module1.Infrastructure.Db.Migrations
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Module1.Infrastructure.Db.Context;
    using App.Module1.Infrastructure.Db.Migrations.Seeding;

    // Referenced by AppModule1DatabaseInitializer
    public sealed class AppModule1DbMigrationsConfiguration : DbMigrationsConfiguration<AppModule1DbContext>
    {
        public AppModule1DbMigrationsConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            //Where to save Migrations (keep schemas distinct in their own folder):
            this.MigrationsDirectory = @"Initialization\Db\Migrations\" + Constants.Module.Names.ModuleKey;
        }

        protected override void Seed(AppModule1DbContext context)
        {
            // Hand off to a specialized class for Seeding.
            var hostSettingsService = AppDependencyLocator.Current.GetInstance<IHostSettingsService>();
            new AppModule1DbContextSeedingOrchestrator(hostSettingsService).Initialize(context);
        }
    }
}