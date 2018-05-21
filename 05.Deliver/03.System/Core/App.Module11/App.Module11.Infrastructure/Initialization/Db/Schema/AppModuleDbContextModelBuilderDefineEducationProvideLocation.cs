using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using App.Core.Infrastructure.Constants.Db;

namespace App.Module11.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module11.Infrastructure.Initialization.Db;
    using App.Module11.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineEducationProvideLocation
        : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention _modelBuilderConvention;

        public AppModuleDbContextModelBuilderDefineEducationProvideLocation(TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<EducationProviderLocation>(modelBuilder, ref order);

            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.EducationProviderFK)
                .HasColumnOrder(order++)
                .IsRequired();


            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.Longitude)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.Latitude)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.Altitude)
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.SourceSystemKey)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X10)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(EducationProviderLocation).Name}_SourceSystemKey")
                    {
                        IsUnique = true
                    }))
                .IsRequired();

            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.SourceSystemName)
                .HasColumnOrder(order)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();
        }
    }
}