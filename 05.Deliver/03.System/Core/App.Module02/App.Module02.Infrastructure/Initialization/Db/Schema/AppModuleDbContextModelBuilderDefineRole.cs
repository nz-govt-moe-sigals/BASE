namespace App.Module02.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineRole : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenancySecurityProfileAccountRole>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:
            // At present it is a sparse ReferenceData, with no enabled, no display information.
            modelBuilder.DefineTitleAndDescription<TenancySecurityProfileAccountRole>(ref order);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:
            modelBuilder.Entity<TenancySecurityProfileAccountRole>()
                .HasMany(s => s.Permissions)
                .WithMany()
                .Map(x =>
                {
                    x.ToTable(typeof(TenancySecurityProfileAccountRole).Name + "__" + typeof(TenancySecurityProfilePermission).Name);
                    x.MapLeftKey("RoleFK");
                    x.MapRightKey("PermissionFK");
                });
        }

    }
}

