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
//    public class AppModuleDbContextSeederAccountAccountGroupAssignment : IHasAppModuleDbContextSeedInitializer
//    {
//        private readonly IHostSettingsService _hostSettingsService;

//        public AppModuleDbContextSeederAccountAccountGroupAssignment(IHostSettingsService hostSettingsService)
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
//            var records = new Acc AccountAccountGroupAssignment[]
//            {
//                new AccountAccountGroupAssignment
//                {
//                    Id = 1.ToGuid(),
//                    Key = "jsmith@whatever.com"
//                },
//                new AccountAccountGroupAssignment
//                {
//                    Id = .ToGuid(),
//                    Key = "bboop@okifnotsameastenancy.com"
//                }
//            };

//            var dbSet = context.Set<AccountAccountGroupAssignment>();

//            dbSet.AddOrUpdate(p => p.Id, records);

//            context.SaveChanges();
//        }
//    }
//}

