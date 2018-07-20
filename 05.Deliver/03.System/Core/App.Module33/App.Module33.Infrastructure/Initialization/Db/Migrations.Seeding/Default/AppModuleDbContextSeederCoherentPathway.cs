using System.Data.Entity.Migrations;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Module33.Infrastructure.Db.Context.Default;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Infrastructure.Initialization.Db.Migrations.Seeding.Default
{
    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    public class AppModuleDbContextSeederCoherentPathway : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederCoherentPathway(IHostSettingsService hostSettingsService)
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
            var records = new[]
            {
                new CoherentPathway
                {
                    Id = 1.ToGuid(),
                    CommunityFK = 1.ToGuid(),
                    Strategy = "This is a Coherent Pathway strategy statement."
                },
                new CoherentPathway
                {
                    Id = 2.ToGuid(),
                    CommunityFK = 2.ToGuid(),
                    Strategy = "This is a Coherent Pathway strategy statement."
                }
            };

            var dbSet = context.Set<CoherentPathway>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}

