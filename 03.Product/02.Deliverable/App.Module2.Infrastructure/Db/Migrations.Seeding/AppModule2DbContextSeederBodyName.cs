namespace App.Module2.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Entities;
    using App.Module2.Infrastructure.Db.Context;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextSeederBodyName : IHasAppModule2DbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModule2DbContextSeederBodyName(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppModule2DbContext context)
        {
            CodeFirstMigrationConfiguration debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfiguration>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppModule2DbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppModule2DbContext context)
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