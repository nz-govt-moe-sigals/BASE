namespace App.Module01.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module01.Infrastructure.Initialization.Db;
    using App.Module01.Shared.Models.Entities;


    public class AppModuleDbContextModelBuilderDefineCourseGrade : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention().Define<CourseGrade>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:
            //Underlying model adds Text column



            modelBuilder.Entity<CourseGrade>()
                .Property(x => x.Description)
                .HasColumnOrder(order++)
                .IsMaxLength()
                .IsOptional();
            // --------------------------------------------------
            // Entity  Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }


}