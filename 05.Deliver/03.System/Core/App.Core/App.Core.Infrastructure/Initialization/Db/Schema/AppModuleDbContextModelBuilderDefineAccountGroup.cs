namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineAccountGroup : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenancySecurityProfileRoleGroup>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:


            modelBuilder.Entity<TenancySecurityProfileRoleGroup>()
                .Property(x => x.ParentFK)
                .HasColumnOrder(order++)
                .IsOptional();



            modelBuilder.DefineTitleAndDescription<TenancySecurityProfileRoleGroup>(ref order, TextFieldSizes.X64, true, false);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:
            modelBuilder.Entity<TenancySecurityProfileRoleGroup>()
            .HasOptional(x => x.Parent)
            .WithMany(x => x.AccountGroups)
            .HasForeignKey(x => x.ParentFK)
            // When you delete this Property (Parent), 
            // you don't delete every child, so:
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<TenancySecurityProfileRoleGroup>()
                .HasMany(s => s.Roles)
                .WithMany()
                .Map(x =>
                {
                    x.ToTable(typeof(TenancySecurityProfileRoleGroup).Name + "__" + typeof(TenancySecurityProfileAccountRole).Name);
                    x.MapLeftKey("AccountGroupFK");
                    x.MapRightKey("RoleFK");
                });
            // --------------------------------------------------

        }
    }
}

