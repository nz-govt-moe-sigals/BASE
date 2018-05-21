namespace App.Module01.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module01.Infrastructure.Initialization.Db;
    using App.Module01.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCourseRole : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention().Define<CourseRole>(modelBuilder, ref order);
        }
    }


}