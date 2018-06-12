namespace App.Module02.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
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
    public class AppModuleDbContextSeederAccountRoleAccountPermissionAssignment : IHasAppModuleDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederAccountRoleAccountPermissionAssignment(IHostSettingsService hostSettingsService)
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
            var records = new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment[]
            {
// for Role 1:
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 1.ToGuid(),
                    PermissionFK = 1.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 1.ToGuid(),
                    PermissionFK = 2.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
// for Role 2:
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 2.ToGuid(),
                    PermissionFK = 3.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 2.ToGuid(),
                    PermissionFK = 4.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
// for Role 3:
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 3.ToGuid(),
                    PermissionFK = 5.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 3.ToGuid(),
                    PermissionFK = 6.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 3.ToGuid(),
                    PermissionFK = 7.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
            };

            var dbSet = context.Set<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>();

            dbSet.AddOrUpdate(x => new { x.RoleFK,x.PermissionFK}, records);

            context.SaveChanges();
        }
    }
}

