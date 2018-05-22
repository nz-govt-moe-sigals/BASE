namespace App.Module01.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module01.Infrastructure.Initialization.Db;
    using App.Module01.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCourseInstructorOfficeAssignment : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<CourseInstructorOfficeAssignment>()
                 .HasKey(x => new
                 {
                     // x.TenantFK
                     x.CourseInstructorFK,
                     x.CourseInstructorOfficeFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<CourseInstructorOfficeAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<CourseInstructorOfficeAssignment>(ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<CourseInstructorOfficeAssignment>()
                .Property(x => x.CourseInstructorFK)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            modelBuilder.Entity<CourseInstructorOfficeAssignment>()
                    .Property(x => x.CourseInstructorOfficeFK)
                    .HasColumnOrder(order++)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<CourseInstructorOfficeAssignment>()
                .Property(x => x.Begin)
                .HasColumnOrder(order++)
                .IsOptional()
                ;
            modelBuilder.Entity<CourseInstructorOfficeAssignment>()
                .Property(x => x.End)
                .HasColumnOrder(order++)
                .IsOptional()
                ;
            modelBuilder.Entity<CourseInstructorOfficeAssignment>()
                .Property(x => x.Notes)
                .HasColumnOrder(order++)
                .IsMaxLength()
                .IsOptional()
                ;
            // --------------------------------------------------
            // Entity Navigtation Properties:

            //// Do not define these Entity Navigation Properties here, 
            //// as the Collection Navigation Properties
            //// are defined in the other objects.
            ////modelBuilder.Entity<CourseInstructorOfficeAssignment>()
            ////        .HasRequired(x => x.CourseInstructor)
            ////        .WithMany(x => x.OfficeAssignments)
            ////        .HasForeignKey(x => x.CourseInstructorFK);

            ////modelBuilder.Entity<CourseInstructorOfficeAssignment>()
            ////        .HasRequired(x => x.CourseInstructorOffice)
            ////        .WithMany(x => x.OfficeAssignments)
            ////        .HasForeignKey(x => x.CourseInstructorOfficeFK);

            // --------------------------------------------------
            // Naviation Navigtation Properties:

            // --------------------------------------------------
        }
    }


}