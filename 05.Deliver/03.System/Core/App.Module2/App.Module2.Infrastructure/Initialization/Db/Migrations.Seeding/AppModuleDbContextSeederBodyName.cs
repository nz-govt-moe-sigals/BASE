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

    public class AppModuleDbContextSeederBodyName : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederBodyName(IHostSettingsService hostSettingsService)
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
                //People:
                new BodyAlias
                {
                    Id = 6.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    DisplayOrderHint = 0,
                    Name = null,
                    GivenName = "Franky",
                    SurName = "Roberts",
                    OwnerFK = 5.ToGuid()
                },
                //Corps:
                new BodyAlias
                {
                    Id = 102.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    DisplayOrderHint = 0,
                    Name = "GS, Inc.",
                    OwnerFK = 101.ToGuid()
                }
            };
            context.Set<BodyAlias>().AddOrUpdate(p => p.Id, records);
        }
    }
}