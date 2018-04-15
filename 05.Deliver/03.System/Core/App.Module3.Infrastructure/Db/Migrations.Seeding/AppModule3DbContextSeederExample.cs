namespace App.Module3.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Module3.Infrastructure.Db.Context;
    using App.Module3.Infrastructure.Initialization;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;

    // A single DbContext Entity model seeder, 
    // invoked via AppModule3ModelBuilderOrchestrator
    public class AppModule3DbContextSeederExample : IHasAppModule3DbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModule3DbContextSeederExample(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppModule3DbContext context)
        {
            CodeFirstMigrationConfiguration debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfiguration>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppModule3DbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppModule3DbContext context)
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