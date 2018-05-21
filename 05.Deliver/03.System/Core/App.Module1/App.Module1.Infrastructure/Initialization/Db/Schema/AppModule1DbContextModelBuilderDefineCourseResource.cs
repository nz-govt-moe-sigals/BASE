namespace App.Module1.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module1.Infrastructure.Initialization.Db;
    using App.Module1.Shared.Models.Entities;

    public class AppModule1DbContextModelBuilderDefineCourseResource : IHasAppModule1DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CourseResource>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<CourseResource>()
                .HasRequired(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusFK)
                .WillCascadeOnDelete(false)
                ;

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<CourseResource>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<CourseResource>()
                .Property(x => x.Title)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<CourseResource>()
                .Property(x => x.Description)
                .HasColumnOrder(order++)
                .IsMaxLength()
                .IsOptional();

            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<CourseResource>()
                .HasRequired(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusFK)
                .WillCascadeOnDelete(false)
                ;

            modelBuilder.Entity<CourseResource>()
                .HasRequired(x => x.Type)
                .WithMany()
                .HasForeignKey(x => x.TypeFK);


            // --------------------------------------------------
            // Collection Navigation Properties:

            // Map to CourseEnrollment join table.
            // The other half of this is in the Resource table:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<CourseResource>()
                .HasMany(x => x.ResourceAssignments)
                .WithRequired(x => x.Resource)
                .HasForeignKey(x => x.ResourceFK)
                // When a join table record is deleted, you don't want it to delete an entry in this table:
                .WillCascadeOnDelete(false);
            // --------------------------------------------------
        }
    }


}