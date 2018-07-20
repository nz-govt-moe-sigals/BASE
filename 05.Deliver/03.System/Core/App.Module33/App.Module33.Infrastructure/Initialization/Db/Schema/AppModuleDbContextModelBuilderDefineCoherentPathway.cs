using System.Data.Entity;
using App.Core.Infrastructure.Db.Schema.Conventions;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Infrastructure.Initialization.Db.Schema
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineCoherentPathway : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
                
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CoherentPathway>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:


            modelBuilder.Entity<CoherentPathway>()
                .Property(x => x.Strategy)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<CoherentPathway>()
                .HasMany(x => x.CoherentPathwaySteps)
                .WithRequired(x => x.CoherentPathway)
                .HasForeignKey(x => x.CoherentPathwayFK);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}
