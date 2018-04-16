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
        public class AppCoreDbContextSeederPrincipal : IHasAppCoreDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederPrincipal(IHostSettingsService hostSettingsService)
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
                new Principal {Id = 0.ToGuid(), Enabled = true, CategoryFK = 1.ToGuid(), DisplayName = "Anon"},
                new Principal {Id = 1.ToGuid(), Enabled = true, CategoryFK = 2.ToGuid(), DisplayName = "SysDeamon"},
            };

            context.Set<Principal>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }

        protected void SeedDevOnlyEntries(AppCoreDbContext context)
        {
                var records = new[]
            {
                //People:
                new Principal {Id = 2.ToGuid(), Enabled = true, CategoryFK = 1.ToGuid(), DisplayName = "J Smith"},
                new Principal {Id = 3.ToGuid(), Enabled = true, CategoryFK = 1.ToGuid(), DisplayName = "P Smith"}
            };
            context.Set<Principal>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }


    }
}