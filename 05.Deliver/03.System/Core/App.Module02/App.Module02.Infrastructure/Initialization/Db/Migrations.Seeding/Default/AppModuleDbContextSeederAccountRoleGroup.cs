namespace App.Module02.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using System.Linq;
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
    public class AppModuleDbContextSeederAccountRoleGroup : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederAccountRoleGroup(IHostSettingsService hostSettingsService)
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
            var r = context.Set<AccountRole>().Where(x => x.TenantFK == App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id).ToArray();


            var records = new AccountRoleGroup[]
            {
                new AccountRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 1.ToGuid(),
                    Title = "GroupA",
                    Description = "...."
                },
                new AccountRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 2.ToGuid(),
                    Title = "GroupB"
                },
                new AccountRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 3.ToGuid(),
                    ParentFK = 2.ToGuid(),
                    Title = "GroupB.1",
                    Description = "A Group nested under GroupB"
                },
                new AccountRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 4.ToGuid(),
                    ParentFK = 2.ToGuid(),
                    Title = "GroupB.2",
                    Description = "A Group nested under GroupB"
                },
                new AccountRoleGroup
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 5.ToGuid(),
                    ParentFK = 4.ToGuid(),
                    Title = "GroupB.2.1",
                    Description = "A Group nested under GroupB.2",
                }
            };


            var dbSet = context.Set<AccountRoleGroup>();
            dbSet.AddOrUpdate(p => p.Id, records);



            context.SaveChanges();
        }
    }
}

