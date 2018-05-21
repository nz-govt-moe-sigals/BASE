namespace App.MODULETEMPLATE.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.MODULETEMPLATE.Infrastructure.Initialization.Db;
    using App.MODULETEMPLATE.Shared.Models.Entities;
    using App.MODULETEMPLATE.Shared.Models.Entities.Enums;

    public class AppModule1DbContextModelBuilderDefineCourseStatus : IHasAppModule1DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Common Properties:

            
            new TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataConvention()
                .Define<CourseStatus, CourseStatusType>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<CourseStatus>()
            .Property(x => x.Description)
            .HasColumnOrder(order++)
            .IsMaxLength()
            .IsOptional();


            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection  Navigation Properties:

            // --------------------------------------------------
        }
    }

}














