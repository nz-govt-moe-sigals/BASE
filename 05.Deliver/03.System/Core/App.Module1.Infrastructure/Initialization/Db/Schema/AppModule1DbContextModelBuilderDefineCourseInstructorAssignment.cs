namespace App.Module1.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module1.Infrastructure.Initialization.Db;
    using App.Module1.Shared.Models.Entities;

    public class AppModule1DbContextModelBuilderDefineCourseInstructorAssignment : IHasAppModule1DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<CourseInstructorAssignment>()
                 .HasKey(x => new
                 {
                     // x.TenantFK
                     x.CourseFK,
                     x.CourseInstructorFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<CourseInstructorAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<CourseInstructorAssignment>(ref order);
            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<CourseInstructorAssignment>()
                .Property(x => x.CourseFK)
                .HasColumnOrder(order++)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            modelBuilder.Entity<CourseInstructorAssignment>()
                    .Property(x => x.CourseInstructorFK)
                    .HasColumnOrder(order++)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    .IsRequired();

            // --------------------------------------------------
            // Entity Navigtation Properties:

            modelBuilder.Entity<CourseInstructorAssignment>()
                    .HasRequired(x => x.Role)
                    .WithMany()
                    .HasForeignKey(x => x.RoleFK);

            //// Do not define these Entity Navigation Properties here, 
            //// as the Collection Navigation Properties
            //// are defined in the other objects.
            //modelBuilder.Entity<CourseInstructorAssignment>()
            //        .HasRequired(x => x.Course)
            //        .WithMany(x => x.InstructorRoles)
            //        .HasForeignKey(x => x.CourseFK);

            //modelBuilder.Entity<CourseInstructorAssignment>()
            //        .HasRequired(x => x.CourseInstructor)
            //        .WithMany(x => x.CourseRoles)
            //        .HasForeignKey(x => x.CourseInstructorFK);

            // --------------------------------------------------
            // Collection Navigtation Properties:

            // --------------------------------------------------
        }
    }


}