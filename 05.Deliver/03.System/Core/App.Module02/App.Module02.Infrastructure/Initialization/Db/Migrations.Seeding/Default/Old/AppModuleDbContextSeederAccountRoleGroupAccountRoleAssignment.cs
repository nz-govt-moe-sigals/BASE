//namespace App.Module02.Infrastructure.Db.Migrations.Seeding
//{
//    using System.Data.Entity.Migrations;
//    using App.Core.Infrastructure.Services;
//    using App.Core.Shared.Models.Configuration;
//    using App.Core.Shared.Models.Configuration.AppHost;
//    using App.Core.Shared.Models.ConfigurationSettings;
//    using App.Module02.Infrastructure.Db.Context;
//    using App.Module02.Infrastructure.Initialization;
//    using App.Module02.Infrastructure.Initialization.Db;
//    using App.Module02.Shared.Models.Entities;

//    // A single DbContext Entity model seeder, 
//    // invoked via AppModuleModelBuilderOrchestrator
//    public class AppModuleDbContextSeederAccountAccountRoleAssignment : IHasAppModuleDbContextSeedInitializer
//    {
//        private readonly IHostSettingsService _hostSettingsService;

//        public AppModuleDbContextSeederAccountAccountRoleAssignment(IHostSettingsService hostSettingsService)
//        {
//            this._hostSettingsService = hostSettingsService;
//        }

//        public void Seed(AppModuleDbContext context)
//        {
//            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
//                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

//            SeedImmutableEntries(context);

//            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
//            {
//                SeedDevOnlyEntries(context);
//            }
//        }

//        protected void SeedImmutableEntries(AppModuleDbContext context)
//        {
//        }

//        protected void SeedDevOnlyEntries(AppModuleDbContext context)
//        {
//            var records = new AccountRoleGroupAccountRoleAssignment[]
//            {
//                new AccountRoleGroupAccountRoleAssignment
//                {
//                    TenantFK = App.Core.Infrastructure.Constants.Demo.DemoATenancyFK,
//                    AccountGroupFK = 1.ToGuid(),
//                    RoleFK = 1.ToGuid()
//                },
//                new AccountRoleGroupAccountRoleAssignment
//                {
//                    TenantFK = App.Core.Infrastructure.Constants.Demo.DemoATenancyFK,
//                    AccountGroupFK = 3.ToGuid(),
//                    RoleFK = 2.ToGuid()
//                },
//                new AccountRoleGroupAccountRoleAssignment
//                {
//                    TenantFK = App.Core.Infrastructure.Constants.Demo.DemoATenancyFK,
//                    AccountGroupFK = 5.ToGuid(),
//                    RoleFK = 3.ToGuid()
//                },
//            };

//            var dbSet = context.Set<AccountRoleGroupAccountRoleAssignment>();

//            dbSet.AddOrUpdate(p => new { p.AccountGroupFK, p.RoleFK }, records);

//            context.SaveChanges();
//        }
//    }
//}

