namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.TenancySpecific;

    public class AppModuleDbContextModelBuilderDefinePrincipalProfile : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:


            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<PrincipalProfile>()
                .Property(x => x.Enabled)
                .IsRequired();

            modelBuilder.Entity<PrincipalProfile>()
                .Property(x => x.EnabledBeginningUtc)
                .IsOptional();

            modelBuilder.Entity<PrincipalProfile>()
                .Property(x => x.EnabledEndingUtc)
                .IsOptional();

            modelBuilder.Entity<PrincipalProfile>()
                .HasOptional(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<PrincipalProfile>()
               .HasRequired(x => x.Category)
               .WithMany()
               .HasForeignKey(x => x.CategoryFK);

            modelBuilder.Entity<PrincipalProfile>()
                .HasMany(x => x.Properties)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);

            modelBuilder.Entity<PrincipalProfile>()
                .HasMany(x => x.Claims)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);
            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------

        }
    }
}