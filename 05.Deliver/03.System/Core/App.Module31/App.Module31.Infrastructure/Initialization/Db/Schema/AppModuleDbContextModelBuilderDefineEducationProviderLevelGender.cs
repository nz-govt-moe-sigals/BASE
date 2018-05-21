using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using App.Core.Infrastructure.Constants.Db;

namespace App.Module31.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module31.Infrastructure.Initialization.Db;
    using App.Module31.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineEducationProviderLevelGender : IHasAppModuleDbContextModelBuilderInitializer
    {
        
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _modelBuilderConvention;

        public AppModuleDbContextModelBuilderDefineEducationProviderLevelGender(
            TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<EducationProviderLevelGender>(modelBuilder, ref order);

            // A school profile can have n SchoolLevelGender records.
            modelBuilder.Entity<EducationProviderLevelGender>()
                .Property(x => x.EducationProviderFK)
                .HasColumnOrder(order++)
                .IsRequired();

            // A SchoolLevelGender record  points to one of each of the following:
            modelBuilder.Entity<EducationProviderLevelGender>()
                .HasRequired(x => x.Level)
                .WithMany()
                .HasForeignKey(x => x.YearFK);

            modelBuilder.Entity<EducationProviderLevelGender>()
                .HasRequired(x => x.Gender)
                .WithMany()
                .HasForeignKey(x => x.GenderFK);

            modelBuilder.Entity<EducationProviderLevelGender>()
                .Property(x => x.SourceSystemKey)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X10)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(EducationProviderLevelGender).Name}_SourceSystemKey")
                    {
                        IsUnique = true
                    }))
                .IsRequired();

            modelBuilder.Entity<EducationProviderLevelGender>()
                .Property(x => x.SourceSystemName)
                .HasColumnOrder(order)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();
        }
    }
}




