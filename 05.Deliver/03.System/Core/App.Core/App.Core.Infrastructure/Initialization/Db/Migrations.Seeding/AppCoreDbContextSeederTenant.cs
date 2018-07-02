namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
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
    public class AppCoreDbContextSeederTenant : IHasAppModuleDbContextSeedInitializer

    {



        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederTenant(IHostSettingsService hostSettingsService)
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
            
            context.SaveChanges();
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
            //TODO : Select to see if there is one with default first
            var records = new[]
            {
                App.Core.Infrastructure.Constants.Tenancy.Default.DefaultTenant
            };
            context.Set<Tenant>().AddOrUpdate(p => p.Id, records);
            
        }

        protected void SeedDevOnlyEntries(AppCoreDbContext context)
        {
            var records = new[]
            {
                new Tenant
                {
                    Id = Constants.Demo.Tenancies.A.Id,
                    IsDefault = null,
                    Enabled = true ,
                    Key = Constants.Demo.Tenancies.A.Key,
                    DisplayName = Constants.Demo.Tenancies.A.Name,
                    HostName = Constants.Demo.Tenancies.A.HostName
                },
                new Tenant
                {
                    Id = Constants.Demo.Tenancies.B.Id,
                    IsDefault = null,
                    Enabled = true,
                    Key = Constants.Demo.Tenancies.B.Key,
                    DisplayName = Constants.Demo.Tenancies.B.Name,
                    HostName = Constants.Demo.Tenancies.B.HostName 
                },

                //new Tenant {Id=3.ToGuid(),IsDefault = null, Enabled=true, Key="OrgC", HostName =".C.",DisplayName="Org C, Inc."},
            };
            context.Set<Tenant>().AddOrUpdate(p => p.Id, records);

        }
    }
}