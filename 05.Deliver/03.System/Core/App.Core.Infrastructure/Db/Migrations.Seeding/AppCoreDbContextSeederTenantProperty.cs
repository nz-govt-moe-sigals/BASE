namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class AppCoreDbContextSeederTenantProperty : IHasAppCoreDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederTenantProperty(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppCoreDbContext context)
        {
            CodeFirstMigrationConfiguration debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfiguration>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppCoreDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppCoreDbContext context)
        {
            var records = new[]
            {
                new TenantProperty {Id = 1.ToGuid(), OwnerFK = 1.ToGuid(), Key = "SomePropA", Value = "SomeValueA1"},
                new TenantProperty {Id = 2.ToGuid(), OwnerFK = 1.ToGuid(), Key = "SomePropB", Value = "SomeValueB1"}
            };
            context.Set<TenantProperty>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }
    }
}