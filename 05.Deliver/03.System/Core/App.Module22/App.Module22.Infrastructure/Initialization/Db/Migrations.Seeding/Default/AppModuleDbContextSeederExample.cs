namespace App.Module22.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Module22.Infrastructure.Db.Context;
    using App.Module22.Infrastructure.Initialization;
    using App.Module22.Infrastructure.Initialization.Db;
    using App.Module22.Shared.Models.Entities;

    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    public class AppModuleDbContextSeederExample : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederExample(IHostSettingsService hostSettingsService)
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
            //var records = new[]
            //{
            //    new Course
            //    {
            //        Id = 1.ToGuid(),
            //        Owner = "jSmith",
            //        PublicText = "Some publicly viewable Text...",
            //        SensitiveText = "Some sensitive Data (eg: GovId:ABC1234)",
            //        AppPrivateText = "Some App-Private Text (you should *not* see it)..."
            //    }
            //};

            //var dbSet = context.Set<Course>();

            //dbSet.AddOrUpdate(p => p.Id,records);

            context.SaveChanges();
        }
    }
}

