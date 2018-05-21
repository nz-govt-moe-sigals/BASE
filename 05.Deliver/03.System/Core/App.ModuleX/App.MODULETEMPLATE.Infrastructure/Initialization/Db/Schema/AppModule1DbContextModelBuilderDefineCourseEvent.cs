namespace App.MODULETEMPLATE.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.MODULETEMPLATE.Infrastructure.Initialization.Db;
    using App.MODULETEMPLATE.Shared.Models.Entities;

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














