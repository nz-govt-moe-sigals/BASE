namespace App.MODULETEMPLATE.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.MODULETEMPLATE.Infrastructure.Initialization;
    using App.MODULETEMPLATE.Infrastructure.Initialization.Db;
    using App.MODULETEMPLATE.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModule1DbContextModelBuilderDefineExample : IHasAppModule1DbContextModelBuilderInitializer
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














