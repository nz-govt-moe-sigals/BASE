namespace App.MODULETEMPLATE.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.MODULETEMPLATE.Infrastructure.Initialization.Db;
    using App.MODULETEMPLATE.Shared.Models.Entities;


    public class AppModule1DbContextModelBuilderDefineCourseGrade : IHasAppModule1DbContextModelBuilderInitializer
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














