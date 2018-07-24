using System.Data.Entity.Migrations;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Module33.Infrastructure.Db.Context.Default;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Infrastructure.Initialization.Db.Migrations.Seeding.Default
{
    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    public class AppModuleDbContextSeederCoherentPathwayLearningAreaStep : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederCoherentPathwayLearningAreaStep(IHostSettingsService hostSettingsService)
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
                new CoherentPathwayLearningAreaStep
                {
                    Id = 1.ToGuid(),
                    CoherentPathwayStepFK = 2.ToGuid(),
                    Title = "English",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 100
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 2.ToGuid(),
                    CoherentPathwayStepFK = 3.ToGuid(),
                    Title = "English",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 200
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 3.ToGuid(),
                    CoherentPathwayStepFK = 4.ToGuid(),
                    Title = "English",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 100
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 4.ToGuid(),
                    CoherentPathwayStepFK = 5.ToGuid(),
                    Title = "English",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 200
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 5.ToGuid(),
                    CoherentPathwayStepFK = 2.ToGuid(),
                    Title = "The Arts",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 100
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 6.ToGuid(),
                    CoherentPathwayStepFK = 3.ToGuid(),
                    Title = "The Arts",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 200
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 7.ToGuid(),
                    CoherentPathwayStepFK = 4.ToGuid(),
                    Title = "The Arts",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 100
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 8.ToGuid(),
                    CoherentPathwayStepFK = 5.ToGuid(),
                    Title = "The Arts",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 200
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 9.ToGuid(),
                    CoherentPathwayStepFK = 2.ToGuid(),
                    Title = "Health and Physical Education",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 100
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 10.ToGuid(),
                    CoherentPathwayStepFK = 3.ToGuid(),
                    Title = "Health and Physical Education",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 200
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 11.ToGuid(),
                    CoherentPathwayStepFK = 4.ToGuid(),
                    Title = "Health and Physical Education",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 300
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 12.ToGuid(),
                    CoherentPathwayStepFK = 5.ToGuid(),
                    Title = "Health and Physical Education",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 400
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 13.ToGuid(),
                    CoherentPathwayStepFK = 2.ToGuid(),
                    Title = "Te Reo Māori",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 100
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 14.ToGuid(),
                    CoherentPathwayStepFK = 3.ToGuid(),
                    Title = "Te Reo Māori",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 200
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 15.ToGuid(),
                    CoherentPathwayStepFK = 4.ToGuid(),
                    Title = "Te Reo Māori",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 300
                },
                new CoherentPathwayLearningAreaStep
                {
                    Id = 16.ToGuid(),
                    CoherentPathwayStepFK = 5.ToGuid(),
                    Title = "Te Reo Māori",
                    Description = null,
                    CurriculumArea = true,
                    DisplayOrderHint = 400
                }
            };

            var dbSet = context.Set<CoherentPathwayLearningAreaStep>();

            dbSet.AddOrUpdate(p => p.Id,records);

            context.SaveChanges();
        }
    }
}

