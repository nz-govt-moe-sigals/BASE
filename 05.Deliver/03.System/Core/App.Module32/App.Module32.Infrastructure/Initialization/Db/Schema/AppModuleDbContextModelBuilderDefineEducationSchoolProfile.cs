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
    public class AppModuleDbContextModelBuilderDefineEducationSchoolProfile : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<EducationSchoolProfile>(modelBuilder, ref order);


            modelBuilder.Entity<EducationSchoolProfile>()
                .Property(x => x.SchoolId)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationSchoolProfile>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsRequired();

            modelBuilder.Entity<EducationSchoolProfile>()
                .Property(x => x.SourceModifiedDate)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationSchoolProfile>()
                .Property(t => t.SchoolId)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"IX_{typeof(EducationSchoolProfile).Name}_SchoolId") { IsUnique = false }));
        }
    }
}
