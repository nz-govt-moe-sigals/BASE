namespace App.Module01.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module01.Infrastructure.Initialization.Db;
    using App.Module01.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCourseOccurance : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CourseOccurance>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:
            //modelBuilder.Entity<CourseOccurance>()
            //   .Property(x => x.StatusFK)
            //   .HasColumnOrder(order++)
            //   .Cascade(false)
            //   .IsRequired();

            modelBuilder.Entity<CourseOccurance>()
               .Property(x => x.OwnerFK)
               .HasColumnOrder(order++)
               .IsRequired();


            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<CourseOccurance>()
            .Property(x => x.When)
            .HasColumnOrder(order++)
            .IsRequired();

            modelBuilder.Entity<CourseOccurance>()
            .Property(x => x.Duration)
            .HasColumnOrder(order++)
            .IsRequired();

            modelBuilder.Entity<CourseOccurance>()
            .Property(x => x.Notes)
            .HasColumnOrder(order++)
            .IsMaxLength()
            .IsOptional();





            // --------------------------------------------------
            // Entity Navigation Properties:
            //modelBuilder.Entity<Course>()
            //    .HasRequired(x => x.Status)
            //    .WithMany()
            //    .HasForeignKey(x => x.StatusFK)
            //    .WillCascadeOnDelete(false)
            //    ;

            // The Course Navigation is defined in Course ModelBuilder

            // --------------------------------------------------
            // Collection Navigation Properties:

        }
    }
}