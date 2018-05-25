namespace App.Module02.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
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
    [OrderBy(After = "Group,Role")]
    public class AppModuleDbContextSeederAccountPermission : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederAccountPermission(IHostSettingsService hostSettingsService)
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
            var records = new AccountPermission[]
            {
// for Role 1:
                new AccountPermission
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 1.ToGuid(),
                    Title = "Permission 1"
                },
                new AccountPermission
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 2.ToGuid(),
                    Title = "Permission 2"
                },
// for Role 2:
                new AccountPermission
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 3.ToGuid(),
                    Title = "Permission 3"
                },
                new AccountPermission
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 4.ToGuid(),
                    Title = "Permission 4"
                },
// for Role 3:
                new AccountPermission
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 5.ToGuid(),
                    Title = "Permission 5"
                },
                new AccountPermission
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 6.ToGuid(),
                    Title = "Permission 6"
                },
                new AccountPermission
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 7.ToGuid(),
                    Title = "Permission 7"
                }
            };

            var dbSet = context.Set<AccountPermission>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}

