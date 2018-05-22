namespace App.Module02.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineExample : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
                
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Example>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:


            modelBuilder.Entity<Example>()
                .Property(x => x.Owner)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<Example>()
                .Property(x => x.PublicText)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<Example>()
                .Property(x => x.SensitiveText)
                .HasColumnOrder(order++)
                .IsOptional();
            modelBuilder.Entity<Example>()
                .Property(x => x.AppPrivateText)
                .HasColumnOrder(order++)
                .IsOptional();

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}

