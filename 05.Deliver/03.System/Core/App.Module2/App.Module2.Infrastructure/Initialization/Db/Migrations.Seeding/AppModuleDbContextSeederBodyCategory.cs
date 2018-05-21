namespace App.Module02.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Entities;
    using App.Module02.Infrastructure.Db.Context;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextSeederBodyCategory : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederBodyCategory(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppModuleDbContext context)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppModuleDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var records = new[]
            {
                new BodyCategory
                {
                    Id = 1.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    Text = "Cat1"
                },
                new BodyCategory
                {
                    Id = 2.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    Text = "Cat2"
                },
                new BodyCategory
                {
                    Id = 3.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    Text = "Cat3"
                }
            };
            context.Set<BodyCategory>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }
    }
}