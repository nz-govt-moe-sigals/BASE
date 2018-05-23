namespace App.Module22.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module22.Infrastructure.Initialization.Db;
    using App.Module22.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCourseDepartment : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CourseDepartment>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK  Properties:

            modelBuilder.Entity<CourseDepartment>()
                .Property(x => x.StatusFK)
                .HasColumnOrder(order++)
                .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<CourseDepartment>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<CourseDepartment>()
                .Property(x => x.Title)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<CourseDepartment>()
                .Property(x => x.Description)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X2048)
                .HasColumnOrder(order++)
                //.HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X2048)
                .IsMaxLength()
                .IsOptional();

            modelBuilder.Entity<CourseDepartment>()
                .Property(x => x.Budget)
                .HasColumnOrder(order++)
                .IsRequired();

            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<CourseDepartment>()
                .HasRequired(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusFK)
                .WillCascadeOnDelete(false)
                ;

            // --------------------------------------------------
            // Collection Navigation Properties:

            // Courses is defined in Course ModuleBuilder.
            // --------------------------------------------------

        }
    }


}

