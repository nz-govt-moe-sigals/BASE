namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class AppCoreDbContextSeederPrincipalCategory : IHasAppCoreDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederPrincipalCategory(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppCoreDbContext context)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppCoreDbContext context)
        {
            var records = new[]
            {
                //People:
                new PrincipalCategory() {Id = 1.ToGuid(), Enabled = true,Text = "Default"},
                new PrincipalCategory() {Id = 2.ToGuid(), Enabled = true,Text = "System"},
            };
            context.Set<PrincipalCategory>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }

        protected void SeedDevOnlyEntries(AppCoreDbContext context)
        {
        }


    }
}