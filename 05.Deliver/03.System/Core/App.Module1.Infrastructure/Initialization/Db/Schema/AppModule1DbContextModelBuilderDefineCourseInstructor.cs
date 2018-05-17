namespace App.Module1.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module1.Infrastructure.Initialization.Db;
    using App.Module1.Shared.Models.Entities;



    public class AppModule1DbContextModelBuilderDefineCourseInstructor : IHasAppModule1DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Stadard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CourseInstructor>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<CourseInstructor> ()
                .Property(x => x.StatusFK)
                .HasColumnOrder(order++)
                .IsRequired()
                ;

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<CourseInstructor>()
                        .Property(x => x.Name)
                        .HasColumnOrder(order++)
                        .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                        .IsRequired();
            modelBuilder.Entity<CourseInstructor>()
                        .Property(x => x.Description)
                        .HasColumnOrder(order++)
                        .IsMaxLength()
                        .IsOptional();
            modelBuilder.Entity<CourseInstructor>()
                        .Property(x => x.Begin)
                        .HasColumnOrder(order++)
                        .IsOptional();

            // --------------------------------------------------
            // Entity Navgigation Properties:

            modelBuilder.Entity<CourseInstructor>()
                .HasRequired(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusFK)
                .WillCascadeOnDelete(false)
                ;



            // --------------------------------------------------
            // Collection Navigation Properties:

            // Map to CourseInstructor join table.
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<CourseInstructor>()
                .HasMany(x => x.CourseRoles)
                .WithRequired(x => x.CourseInstructor)
                .HasForeignKey(x => x.CourseInstructorFK)
                // When a join table record is deleted, you don't want it to delete an entry in this table:
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseInstructor>()
                .HasMany(x => x.OfficeAssignments)
                .WithRequired(x => x.CourseInstructor)
                .HasForeignKey(x => x.CourseInstructorFK)
                // When a join table record is deleted, you don't want it to delete an entry in this table:
                .WillCascadeOnDelete(false);


            // --------------------------------------------------
        }
    }


}