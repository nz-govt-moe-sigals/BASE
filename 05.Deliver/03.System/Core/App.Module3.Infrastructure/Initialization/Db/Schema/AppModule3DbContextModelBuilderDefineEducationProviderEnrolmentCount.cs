
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using App.Core.Infrastructure.Constants.Db;

namespace App.Module3.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;

    public class AppModule3DbContextModelBuilderDefineEducationProviderEnrolmentCount : IHasAppModule3DbContextModelBuilderInitializer
    {
        
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _modelBuilderConvention;
        
        public AppModule3DbContextModelBuilderDefineEducationProviderEnrolmentCount(TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<EducationProviderEnrolmentCount>(modelBuilder, ref order);



            // An Enrol Record is one of x child records of a school profile.
            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.EducationProviderFK)
                .HasColumnOrder(order++)
                .IsRequired();
            // ...taken on a specific date
            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.Date)
                .HasColumnOrder(order++)
                .IsRequired();

            // Having the following numbers:
            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.TotalRoll)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.International)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.European)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.Maori)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.Pasifika)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.Asian)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.MELAA)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.Other)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.SourceSystemKey)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X10)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(EducationProviderEnrolmentCount).Name}_SourceSystemKey")
                    {
                        IsUnique = true
                    }))
                .IsRequired();

            modelBuilder.Entity<EducationProviderEnrolmentCount>()
                .Property(x => x.SourceSystemName)
                .HasColumnOrder(order)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();
        }

    }
}