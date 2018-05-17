namespace App.Module1.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module1.Infrastructure.Initialization.Db;
    using App.Module1.Shared.Models.Entities;
    using App.Module1.Shared.Models.Entities.Enums;

    public class AppModule1DbContextModelBuilderDefineCourseResourceType : IHasAppModule1DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Common Properties:

            new TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataConvention()
                .Define<CourseResourceType, CourseResourceEnumType>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }

}