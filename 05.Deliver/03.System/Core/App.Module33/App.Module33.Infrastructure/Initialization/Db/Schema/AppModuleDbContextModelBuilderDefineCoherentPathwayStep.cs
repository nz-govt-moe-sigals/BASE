using System.Data.Entity;
using App.Core.Infrastructure.Db.Schema.Conventions;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Infrastructure.Initialization.Db.Schema
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineCoherentPathwayStep : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
                
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CoherentPathwayStep>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:


            modelBuilder.Entity<CoherentPathwayStep>()
                .HasMany(x => x.CoherentPathwayLearningAreaSteps)
                .WithRequired(x => x.CoherentPathwayStep)
                .HasForeignKey(x => x.CoherentPathwayStepFK);

            modelBuilder.Entity<CoherentPathwayStep>()
                .HasMany(x => x.CoherentPathwayOverarchingCapabilities)
                .WithRequired(x => x.CoherentPathwayStep)
                .HasForeignKey(x => x.CoherentPathwayStepFK);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}
