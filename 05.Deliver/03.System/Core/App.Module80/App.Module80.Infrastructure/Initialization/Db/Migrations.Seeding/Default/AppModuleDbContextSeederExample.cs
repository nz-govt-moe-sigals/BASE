using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Module80.Infrastructure.Db.Context.Default;
using App.Module80.Infrastructure.Initialization.Db.Migrations.Seeding.Implementations;

namespace App.Module80.Infrastructure.Initialization.Db.Migrations.Seeding.Default
{
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

        /// <summary>
        /// Seed records that are part of this Module, no matter what (Immutable).
        /// <para>
        /// NOT the right place for demo entries, or data that will be updated
        /// by end users.
        /// </para>
        /// </summary>
        /// <param name="context"></param>
        protected void SeedImmutableEntries(AppModuleDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            MigrationLitterItems.SeedDevOnlyEntries(context);
            MigrationLargeItems.SeedDevOnlyEntries(context);
        }
    }
}

