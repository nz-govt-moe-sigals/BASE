namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
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
    public class AppCoreDbContextSeederAccountRoleAccountPermissionAssignment : IHasAppCoreDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederAccountRoleAccountPermissionAssignment(IHostSettingsService hostSettingsService)
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

