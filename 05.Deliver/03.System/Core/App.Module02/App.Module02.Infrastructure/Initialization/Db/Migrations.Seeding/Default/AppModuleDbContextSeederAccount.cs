namespace App.Module02.Infrastructure.Db.Migrations.Seeding
{
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Module02.Infrastructure.Db.Context;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    [OrderBy(After = "Group,Role,Permission")]
    public class AppModuleDbContextSeederAccount : IHasAppModuleDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederAccount(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppModuleDbContext context)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppModuleDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var g = context.Set<TenancySecurityProfileRoleGroup>().Where(x => x.TenantFK == App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id).ToArray();
            var r = context.Set<TenancySecurityProfileAccountRole>().Where(x => x.TenantFK == App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id).ToArray();

            var records = new TenancySecurityProfile[]
            {
                new TenancySecurityProfile
                {
                    Id = 1.ToGuid(),
                    Key = "jsmith@whatever.com",
                },
                new TenancySecurityProfile
                {
                    Id = 2.ToGuid(),
                    Key = "bboop@okifnotsameastenancy.com",
                    Roles = new Collection<TenancySecurityProfileAccountRole>(){ r.Where(x => x.Id == 3.ToGuid()).SingleOrDefault() }
                }
            };

            var dbSet = context.Set<TenancySecurityProfile>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}

