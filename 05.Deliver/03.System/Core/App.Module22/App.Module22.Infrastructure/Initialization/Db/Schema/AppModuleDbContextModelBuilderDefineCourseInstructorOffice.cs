﻿namespace App.Module22.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module22.Infrastructure.Initialization.Db;
    using App.Module22.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCourseInstructorOffice : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<CourseInstructorOffice>(modelBuilder, ref order);
            // --------------------------------------------------
            // FK Properties:
            //modelBuilder.Entity<CourseInstructorOffice>()
            //    .Property(x => xStatusFK)
            //    .HasColumnOrder(order++)
            //    .IsRequired();
            // --------------------------------------------------
            // Model Specific Propeties:
            modelBuilder.Entity<CourseInstructorOffice>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // Map to CourseEnrollment join table.
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<CourseInstructorOffice>()
                .HasMany(x => x.OfficeAssignments)
                .WithRequired(x => x.CourseInstructorOffice)
                .HasForeignKey(x => x.CourseInstructorOfficeFK)
                // When a join table record is deleted, you don't want it to delete an entry in this table:
                .WillCascadeOnDelete(false);

            // --------------------------------------------------
        }
    }


}

