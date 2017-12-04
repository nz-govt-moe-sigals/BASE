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
    public class AppCoreDbContextSeederTenant : IHasAppCoreDbContextSeedInitializer

    {



        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederTenant(IHostSettingsService hostSettingsService)
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
                //People:
                new Tenant
                {
                    Id = 1.ToGuid(),
                    IsDefault = true,
                    Enabled = true,
                    Key = "OrgA",
                    HostName = ".A.",
                    DisplayName = "Org A, Inc."
                },
                new Tenant
                {
                    Id = 2.ToGuid(),
                    IsDefault = null,
                    Enabled = false,
                    Key = "OrgB",
                    HostName = ".B.",
                    DisplayName = "Org B, Inc."
                }
                //new Tenant {Id=3.ToGuid(),IsDefault = null, Enabled=true, Key="OrgC", HostName =".C.",DisplayName="Org C, Inc."},
            };
            context.Set<Tenant>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }
    }
}