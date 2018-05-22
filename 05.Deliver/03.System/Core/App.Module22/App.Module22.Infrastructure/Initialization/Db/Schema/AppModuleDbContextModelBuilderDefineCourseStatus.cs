namespace App.Module22.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module22.Infrastructure.Initialization.Db;
    using App.Module22.Shared.Models.Entities;
    using App.Module22.Shared.Models.Entities.Enums;

    public class AppModuleDbContextModelBuilderDefineCourseStatus : IHasAppModuleDbContextModelBuilderInitializer
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

