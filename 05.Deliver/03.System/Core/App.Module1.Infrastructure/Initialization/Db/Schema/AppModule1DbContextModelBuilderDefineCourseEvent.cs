namespace App.Module1.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module1.Infrastructure.Initialization.Db;
    using App.Module1.Shared.Models.Entities;

    public class AppModule1DbContextModelBuilderDefineCourseEvent : IHasAppModule1DbContextModelBuilderInitializer
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