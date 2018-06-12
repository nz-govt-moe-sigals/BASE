namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppCoreDbContextModelBuilderDefineTenantMember : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMember>(modelBuilder, ref order);

            modelBuilder.Entity<TenantMember>()
                .Property(x => x.Enabled)
                .IsRequired();

            modelBuilder.Entity<TenantMember>()
                .Property(x => x.EnabledBeginningUtc)
                .IsOptional();

            modelBuilder.Entity<TenantMember>()
                .Property(x => x.EnabledEndingUtc)
                .IsOptional();

            modelBuilder.Entity<TenantMember>()
                .HasOptional(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<TenantMember>()
               .HasRequired(x => x.Category)
               .WithMany()
               .HasForeignKey(x => x.CategoryFK);

            modelBuilder.Entity<TenantMember>()
                .HasMany(x => x.Properties)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);

            modelBuilder.Entity<TenantMember>()
                .HasMany(x => x.Claims)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);

        }
    }
}