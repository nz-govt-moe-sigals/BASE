using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Constants.Db;
using App.Core.Infrastructure.Db.Schema.Conventions;
using App.Module32.Shared.Models.Entities;

namespace App.Module32.Infrastructure.Initialization.Db.Schema
{
    public class AppModuleDbContextModelBuilderDefineEducationStudentProfile : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<EducationStudentProfile>(modelBuilder, ref order);

            modelBuilder.Entity<EducationStudentProfile>()
                .Property(x => x.FullName)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024) // ehhh could be excessive
                .IsRequired();

            modelBuilder.Entity<EducationStudentProfile>()
                .Property(x => x.NSN)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X32)
                .IsRequired();

            modelBuilder.Entity<EducationStudentProfile>()
                .Property(x => x.DateOfBirth)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationStudentProfile>()
                .Property(x => x.Gender)
                .HasColumnOrder(order++)
                .HasMaxLength(1)
                .IsRequired();

            modelBuilder.Entity<EducationStudentProfile>()
                .Property(x => x.SourceModifiedDate)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationStudentProfile>()
                .HasRequired(x => x.EducationSchoolProfile)
                .WithMany()
                .HasForeignKey(x => x.EducationSchoolProfileFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EducationStudentProfile>()
                .Property(t => t.NSN)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{typeof(EducationStudentProfile).Name}_NSN") { IsUnique = false }));
        }
    }
}
