﻿namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Context.Default;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class AppCoreDbContextSeederPrincipalCategory : IHasAppModuleDbContextSeedInitializer
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
            var records = new[]
            {
                //People:
                GetDefaultPrincipalCategory(),
                GetSystemPrincipalCategory(),
            };
            context.Set<PrincipalCategory>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }

        public static PrincipalCategory GetDefaultPrincipalCategory()
        {
            return new PrincipalCategory() {Id = 1.ToGuid(), Enabled = true, Title = "Default"};
        }

        public static PrincipalCategory GetSystemPrincipalCategory()
        {
            return new PrincipalCategory() { Id = 2.ToGuid(), Enabled = true, Title = "System" };
        }

        protected void SeedDevOnlyEntries(AppCoreDbContext context)
        {
        }


    }
}