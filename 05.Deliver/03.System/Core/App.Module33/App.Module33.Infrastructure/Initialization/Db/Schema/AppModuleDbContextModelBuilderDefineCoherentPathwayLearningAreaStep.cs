using System.Data.Entity;
using App.Core.Infrastructure.Db.Schema.Conventions;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Infrastructure.Initialization.Db.Schema
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineCoherentPathwayLearningAreaStep : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
                
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CoherentPathwayLearningAreaStep>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:


            modelBuilder.Entity<CoherentPathwayLearningAreaStep>()
                .Property(x => x.CurriculumArea)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<CoherentPathwayLearningAreaStep>()
                .HasMany(x => x.CoherentPathwayLearningAreaCapabilities)
                .WithRequired(x => x.CoherentPathwayLearningAreaStep)
                .HasForeignKey(x => x.CoherentPathwayLearningAreaStepFK);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}
