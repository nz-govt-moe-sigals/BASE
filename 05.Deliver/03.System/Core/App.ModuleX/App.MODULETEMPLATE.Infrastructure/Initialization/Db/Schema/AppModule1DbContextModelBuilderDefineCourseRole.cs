namespace App.MODULETEMPLATE.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.MODULETEMPLATE.Infrastructure.Initialization.Db;
    using App.MODULETEMPLATE.Shared.Models.Entities;

    public class AppModule1DbContextModelBuilderDefineCourseRole : IHasAppModule1DbContextModelBuilderInitializer
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














