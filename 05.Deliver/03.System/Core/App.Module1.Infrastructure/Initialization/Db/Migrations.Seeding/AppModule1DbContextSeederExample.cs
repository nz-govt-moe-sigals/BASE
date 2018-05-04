namespace App.Module1.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Module1.Infrastructure.Db.Context;
    using App.Module1.Infrastructure.Initialization;
    using App.Module1.Infrastructure.Initialization.Db;
    using App.Module1.Shared.Models.Entities;

    // A single DbContext Entity model seeder, 
    // invoked via AppModule1ModelBuilderOrchestrator
    public class AppModule1DbContextSeederExample : IHasAppModule1DbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModule1DbContextSeederExample(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppModule1DbContext context)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppModule1DbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppModule1DbContext context)
        {
            var records = new[]
            {
                new Example
                {
                    Id = 1.ToGuid(),
                    Owner = "jSmith",
                    PublicText = "Some publicly viewable Text...",
                    SensitiveText = "Some sensitive Data (eg: GovId:ABC1234)",
                    AppPrivateText = "Some App-Private Text (you should *not* see it)..."
                }
            };

            var dbSet = context.Set<Example>();

            dbSet.AddOrUpdate(p => p.Id,records);

            context.SaveChanges();
        }
    }
}