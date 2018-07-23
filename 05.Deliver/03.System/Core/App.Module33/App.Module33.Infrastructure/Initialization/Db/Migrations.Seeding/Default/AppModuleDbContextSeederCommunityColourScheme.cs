using System.Data.Entity.Migrations;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Module33.Infrastructure.Db.Context.Default;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Infrastructure.Initialization.Db.Migrations.Seeding.Default
{
    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    public class AppModuleDbContextSeederCommunityColourScheme : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederCommunityColourScheme(IHostSettingsService hostSettingsService)
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
                new CommunityColourScheme
                {
                    Id = 1.ToGuid(),
                    Enabled = true,
                    Title = "Violets",
                    Description = null,
                    DisplayOrderHint = 100,
                    DisplayStyleHint = "palette"
                },
                new CommunityColourScheme
                {
                    Id = 2.ToGuid(),
                    Enabled = true,
                    Title = "Blue and Green",
                    Description = null,
                    DisplayOrderHint = 200,
                    DisplayStyleHint = "palette"
                },
                new CommunityColourScheme
                {
                    Id = 3.ToGuid(),
                    Enabled = true,
                    Title = "Oranges",
                    Description = null,
                    DisplayOrderHint = 300,
                    DisplayStyleHint = "palette"
                },
                new CommunityColourScheme
                {
                    Id = 4.ToGuid(),
                    Enabled = true,
                    Title = "Purples",
                    Description = null,
                    DisplayOrderHint = 400,
                    DisplayStyleHint = "palette"
                }
            };

            var dbSet = context.Set<CommunityColourScheme>();

            dbSet.AddOrUpdate(p => p.Id,records);

            context.SaveChanges();
        }
    }
}

