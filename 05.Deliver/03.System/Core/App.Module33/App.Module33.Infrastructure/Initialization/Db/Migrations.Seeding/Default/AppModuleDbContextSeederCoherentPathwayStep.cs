using System.Data.Entity.Migrations;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Module33.Infrastructure.Db.Context.Default;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Infrastructure.Initialization.Db.Migrations.Seeding.Default
{
    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    public class AppModuleDbContextSeederCoherentPathwayStep : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederCoherentPathwayStep(IHostSettingsService hostSettingsService)
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
                new CoherentPathwayStep
                {
                    Id = 1.ToGuid(),
                    CoherentPathwayFK = 1.ToGuid(),
                    Title = "Transition from ECE to School",
                    Description = null,
                    DisplayOrderHint = 100
                },
                new CoherentPathwayStep
                {
                    Id = 2.ToGuid(),
                    CoherentPathwayFK = 1.ToGuid(),
                    Title = "After Three Years at School",
                    Description = null,
                    DisplayOrderHint = 200
                },
                new CoherentPathwayStep
                {
                    Id = 3.ToGuid(),
                    CoherentPathwayFK = 1.ToGuid(),
                    Title = "At the end of Year 6",
                    Description = null,
                    DisplayOrderHint = 300
                },
                new CoherentPathwayStep
                {
                    Id = 4.ToGuid(),
                    CoherentPathwayFK = 1.ToGuid(),
                    Title = "At the end of Year 8",
                    Description = null,
                    DisplayOrderHint = 400
                },
                new CoherentPathwayStep
                {
                    Id = 5.ToGuid(),
                    CoherentPathwayFK = 1.ToGuid(),
                    Title = "At the end of Year 10",
                    Description = null,
                    DisplayOrderHint = 500
                },
                new CoherentPathwayStep
                {
                    Id = 6.ToGuid(),
                    CoherentPathwayFK = 1.ToGuid(),
                    Title = "Transition to Adult Citizenship, Work and Further Study",
                    Description = null,
                    DisplayOrderHint = 600
                },
                new CoherentPathwayStep
                {
                    Id = 7.ToGuid(),
                    CoherentPathwayFK = 2.ToGuid(),
                    Title = "Transition from ECE to School",
                    Description = null,
                    DisplayOrderHint = 100
                },
                new CoherentPathwayStep
                {
                    Id = 8.ToGuid(),
                    CoherentPathwayFK = 2.ToGuid(),
                    Title = "After Three Years at School",
                    Description = null,
                    DisplayOrderHint = 200
                },
                new CoherentPathwayStep
                {
                    Id = 9.ToGuid(),
                    CoherentPathwayFK = 2.ToGuid(),
                    Title = "At the end of Year 6",
                    Description = null,
                    DisplayOrderHint = 300
                },
                new CoherentPathwayStep
                {
                    Id = 10.ToGuid(),
                    CoherentPathwayFK = 2.ToGuid(),
                    Title = "At the end of Year 8",
                    Description = null,
                    DisplayOrderHint = 400
                },
                new CoherentPathwayStep
                {
                    Id = 11.ToGuid(),
                    CoherentPathwayFK = 2.ToGuid(),
                    Title = "At the end of Year 10",
                    Description = null,
                    DisplayOrderHint = 500
                },
                new CoherentPathwayStep
                {
                    Id = 12.ToGuid(),
                    CoherentPathwayFK = 2.ToGuid(),
                    Title = "Transition to Adult Citizenship, Work and Further Study",
                    Description = null,
                    DisplayOrderHint = 600
                }
            };

            var dbSet = context.Set<CoherentPathwayStep>();

            dbSet.AddOrUpdate(p => p.Id,records);

            context.SaveChanges();
        }
    }
}

