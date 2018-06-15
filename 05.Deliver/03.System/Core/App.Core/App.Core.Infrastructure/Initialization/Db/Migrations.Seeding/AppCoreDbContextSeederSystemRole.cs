namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Constants.Roles;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Context.Default;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class AppCoreDbContextSeederSystemRole : IHasAppModuleDbContextSeedInitializer
    {


        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederSystemRole(IHostSettingsService hostSettingsService)
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
                //People:
                new SystemRole
                {
                    Id = 1.ToGuid(),
                    Enabled = false,
                    ModuleKey=Constants.Module.Names.ModuleKey,
                    Key =  Constants.Roles.RoleKeys.SystemUser,
                    DataClassificationFK = NZDataClassification.InConfidence,
                },
                new SystemRole
                {
                    Id = 2.ToGuid(),
                    Enabled = false,
                    ModuleKey=Constants.Module.Names.ModuleKey,
                    Key =  Constants.Roles.RoleKeys.SystemAdmin,
                    DataClassificationFK = NZDataClassification.InConfidence,
                },
                //People:
                new SystemRole
                {
                    Id = 3.ToGuid(),
                    Enabled = false,
                    ModuleKey=Constants.Module.Names.ModuleKey,
                    Key =  Constants.Roles.RoleKeys.TenantMember,
                    DataClassificationFK = NZDataClassification.InConfidence
                },
                new SystemRole
                {
                    Id = 4.ToGuid(),
                    Enabled = false,
                    ModuleKey=Constants.Module.Names.ModuleKey,
                    Key =  Constants.Roles.RoleKeys.TenantAdmin,
                    DataClassificationFK = NZDataClassification.InConfidence,
                }
            };
            context.Set<SystemRole>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }


    }
}