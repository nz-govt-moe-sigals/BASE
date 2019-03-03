namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
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
    using App.Core.Infrastructure.Db.Context.Default;

    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    public class AppModuleDbContextSeederAccountRoleGroup : IHasAppModuleDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederAccountRoleGroup(IHostSettingsService hostSettingsService)
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
            var r = context.Set<TenancySecurityProfileAccountRole>().Where(x => x.TenantFK == App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id).ToArray();


            var records = new TenancySecurityProfileRoleGroup[]
            {
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 1.ToGuid(),
                    Title = "GroupA",
                    Description = "...."
                },
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 2.ToGuid(),
                    Title = "GroupB"
                },
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 3.ToGuid(),
                    ParentFK = 2.ToGuid(),
                    Title = "GroupB.1",
                    Description = "A Group nested under GroupB"
                },
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 4.ToGuid(),
                    ParentFK = 2.ToGuid(),
                    Title = "GroupB.2",
                    Description = "A Group nested under GroupB"
                },
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 5.ToGuid(),
                    ParentFK = 4.ToGuid(),
                    Title = "GroupB.2.1",
                    Description = "A Group nested under GroupB.2",
                }
            };


            var dbSet = context.Set<TenancySecurityProfileRoleGroup>();
            dbSet.AddOrUpdate(p => p.Id, records);



            context.SaveChanges();
        }
    }
}

