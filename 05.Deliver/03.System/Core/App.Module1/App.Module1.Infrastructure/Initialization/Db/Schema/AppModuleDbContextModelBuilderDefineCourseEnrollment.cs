namespace App.Module01.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module01.Infrastructure.Initialization.Db;
    using App.Module01.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCourseEnrollment : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            //NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseEnrollment>(modelBuilder, ref order....no...);

            // IMPORTANT:
            // This is a Join Map table between Course and CourseEnrollee, 
            // Adding a many to 1 at Grade.

            // IMPORTANT:
            // It works using x columns, where 2 are combined to be a composite key,
            // which is what the two endpoints reference as their FK.

            // --------------------------------------------------
            // Create Composite Key:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<CourseEnrollment>()
              .HasKey(x => new { x.EnrolleeFK, x.CourseFK });

            modelBuilder.Entity<CourseEnrollment>()
                .Property(x => x.EnrolleeFK)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
            modelBuilder.Entity<CourseEnrollment>()
                .Property(x => x.CourseFK)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
            // --------------------------------------------------
            // Standard Properties:
            // Re/Do the usual columns (notice we are not putting an Id):

            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<CourseEnrollment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<CourseEnrollment>(ref order);
            // --------------------------------------------------
            // FK  Properties:

            modelBuilder.Entity<CourseEnrollment>()
                .Property(x => x.StatusFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<CourseEnrollment>()
                .Property(x => x.CourseFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<CourseEnrollment>()
                .Property(x => x.EnrolleeFK)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<CourseEnrollment>()
                .Property(x => x.GradeFK)
                .HasColumnOrder(order++)
                .IsRequired();
            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<CourseEnrollment>()
                .Property(x => x.Notes)
                .HasColumnOrder(order++)
                .IsMaxLength()
                .IsOptional();
            modelBuilder.Entity<CourseEnrollment>()
                .Property(x => x.GradeComment)
                .HasColumnOrder(order++)
                .IsMaxLength()
                .IsOptional();
            modelBuilder.Entity<CourseEnrollment>()
                .Property(x => x.Notes)
                .HasColumnOrder(order++)
                .IsMaxLength()
                .IsOptional();
            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<CourseEnrollment>()
                .HasRequired(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusFK)
                .WillCascadeOnDelete(false)
                ;

            modelBuilder.Entity<CourseEnrollment>()
                .HasRequired(x => x.Grade)
                .WithMany()
                .HasForeignKey(x => x.GradeFK);
            // --------------------------------------------------
            // Collection Navigation Properties:

            //// Do not define these Entity Navigation Properties here, 
            //// as the Collection Navigation Properties
            //// are defined in the other objects.
            //modelBuilder.Entity<CourseEnrollment>()
            //        .HasRequired(x => x.Course)
            //        .WithMany(x => x.CourseEnrollments)
            //        .HasForeignKey(x => x.CourseFK);

            //modelBuilder.Entity<CourseEnrollment>()
            //        .HasRequired(x => x.CourseEnrollee)
            //        .WithMany(x => x.CourseEnrollments)
            //        .HasForeignKey(x => x.CourseEnrolleeFK);
            // --------------------------------------------------
        }
    }

}