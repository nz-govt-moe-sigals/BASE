namespace App.Module22.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module22.Infrastructure.Initialization.Db;
    using App.Module22.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCourseResourceAssignment : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<CourseResourceAssignment>()
                  .HasKey(x => new
                  {
                      //Not needed as both other keys are unique Guids: x.TenantFK,
                      x.CourseFK,
                      x.ResourceFK
                  });

            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<CourseResourceAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<CourseResourceAssignment>(ref order);
            // --------------------------------------------------
            // FK Properties:

            modelBuilder.Entity<CourseResourceAssignment>()
                        .Property(x => x.CourseFK)
                        .HasColumnOrder(order++)
                        // Note (as they are Keys):
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                        .IsRequired();

            modelBuilder.Entity<CourseResourceAssignment>()
                        .Property(x => x.ResourceFK)
                        .HasColumnOrder(order++)
                        // Note (as they are Keys):
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                        .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<CourseResourceAssignment>()
                        .Property(x => x.Notes)
                        .HasColumnOrder(order++)
                        // Note (as they are Keys):
                        .IsMaxLength()
                        .IsOptional();

            // --------------------------------------------------
            // Entity Navigtation Properties:

            //// Do not define these Entity Navigation Properties here, 
            //// as the Collection Navigation Properties
            //// are defined in the other objects.
            //modelBuilder.Entity<CourseResourceAssignment>()
            //        .HasRequired(x => x.Course)
            //        .WithMany(x => x.ResourceAssignments)
            //        .HasForeignKey(x => x.CourseFK);

            //modelBuilder.Entity<CourseResourceAssignment>()
            //        .HasRequired(x => x.Resource)
            //        .WithMany(x => x.ResourceAssignments)
            //        .HasForeignKey(x => x.ResourceFK);

            // --------------------------------------------------
            // Collection Navigtation Properties:

            // --------------------------------------------------
        }
    }






}

