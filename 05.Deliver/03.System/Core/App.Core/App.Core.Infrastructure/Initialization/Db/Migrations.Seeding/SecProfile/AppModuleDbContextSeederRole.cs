namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    [OrderBy(After = "Group,Role")]
    public class AppModuleDbContextSeederAccountRole : IHasAppCoreDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederAccountRole(IHostSettingsService hostSettingsService)
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
        }

        protected void SeedDevOnlyEntries(AppCoreDbContext context)
        {
            var p = context.Set<TenancySecurityProfilePermission>().Where(x => x.TenantFK == App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id).ToArray();

            var records = new TenancySecurityProfileAccountRole[]
            {
                new TenancySecurityProfileAccountRole
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 1.ToGuid(),
                    Title="Role 1",
                    Permissions = new Collection<TenancySecurityProfilePermission>() {
                        p.Single(x=>x.Id == 1.ToGuid()),
                        p.Single(x=>x.Id == 2.ToGuid())
                    }
                },
                new TenancySecurityProfileAccountRole
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 2.ToGuid(),
                    Title="Role 2",
                    Permissions = new Collection<TenancySecurityProfilePermission>() {
                        p.Single(x=>x.Id == 3.ToGuid()),
                        p.Single(x=>x.Id == 4.ToGuid())
                    }
                },
                new TenancySecurityProfileAccountRole
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 3.ToGuid(),
                    Title="Role 3",
                    Permissions = new Collection<TenancySecurityProfilePermission>() {
                        p.Single(x=>x.Id == 5.ToGuid()),
                        p.Single(x=>x.Id == 6.ToGuid()),
                        p.Single(x=>x.Id == 7.ToGuid())
                    }
                }
            };

            var dbSet = context.Set<TenancySecurityProfileAccountRole>();

            dbSet.AddOrUpdate(x => x.Id, records);

            context.SaveChanges();
        }
    }
}

