namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
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
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        /// <summary>
        /// Seed records that are part of this Module, no matter what (Immutable).
        /// <para>
        /// NOT the right place for demo entries, or data that will be updated
        /// by end users.
        /// </para>
        /// </summary>
        /// <param name="context"></param>
        protected void SeedImmutableEntries(AppCoreDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppCoreDbContext context)
        {
            var records = new[]
            {
                new TenantProperty {Id = 1.ToGuid(), OwnerFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropA", Value = "SomeValueA1"},
                new TenantProperty {Id = 2.ToGuid(), OwnerFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropB", Value = "SomeValueB1"},
                new TenantProperty {Id = 3.ToGuid(), OwnerFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropC", Value = "SomeValueC1"},
                new TenantProperty {Id = 4.ToGuid(), OwnerFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropD", Value = "SomeValueD1"}
            };
            context.Set<TenantProperty>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }
    }
}