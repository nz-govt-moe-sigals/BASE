namespace App.Module01.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module01.Infrastructure.Initialization.Db;
    using App.Module01.Shared.Models.Entities;
    using App.Module01.Shared.Models.Entities.Enums;

    public class AppModuleDbContextModelBuilderDefineCourseResourceType : IHasAppModuleDbContextModelBuilderInitializer
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