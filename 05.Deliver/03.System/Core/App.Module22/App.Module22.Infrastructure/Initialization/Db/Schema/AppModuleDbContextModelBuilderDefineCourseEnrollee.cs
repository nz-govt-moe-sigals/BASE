namespace App.Module22.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module22.Infrastructure.Initialization;
    using App.Module22.Infrastructure.Initialization.Db;
    using App.Module22.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineCourseEnrollee : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CourseEnrollee>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK  Properties:

            //modelBuilder.Entity<CourseEnrollee>()
            //    .Property(x => x.StatusFK)
            //    .HasColumnOrder(order++)
            //    .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:

            // The student Identifier. But would be more flexible
            // if it were developed as an Extension Method over a Property.
            modelBuilder.Entity<CourseEnrollee>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<CourseEnrollee>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsRequired();

            modelBuilder.Entity<CourseEnrollee>()
                .Property(x => x.Begin)
                .HasColumnOrder(order++)
                .IsOptional();

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<CourseEnrollee>()
                .HasMany(x => x.Enrollments)
                .WithRequired(x=> x.Enrollee)
                .HasForeignKey(x=> x.EnrolleeFK)
                .WillCascadeOnDelete(false)
            ;

            // --------------------------------------------------
        }
    }


}

