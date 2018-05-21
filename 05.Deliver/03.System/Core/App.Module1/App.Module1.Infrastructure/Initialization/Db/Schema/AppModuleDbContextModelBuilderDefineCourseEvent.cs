namespace App.Module01.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module01.Infrastructure.Initialization.Db;
    using App.Module01.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCourseEvent : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CourseOccurance>(modelBuilder, ref order);



            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<CourseOccurance>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();
            
            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<CourseOccurance>()
            .Property(x => x.When)
            .HasColumnOrder(order++)
            .IsRequired();


            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------

        }
    }


}