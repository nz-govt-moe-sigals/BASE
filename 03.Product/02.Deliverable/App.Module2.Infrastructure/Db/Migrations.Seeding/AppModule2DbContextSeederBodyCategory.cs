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

    public class AppModule2DbContextSeederBodyCategory : IHasAppModule2DbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModule2DbContextSeederBodyCategory(IHostSettingsService hostSettingsService)
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