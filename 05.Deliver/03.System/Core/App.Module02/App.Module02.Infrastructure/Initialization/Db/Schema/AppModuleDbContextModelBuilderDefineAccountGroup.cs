namespace App.Module02.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Contracts;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineAccountGroup : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<AccountRoleGroup>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:


            modelBuilder.Entity<AccountRoleGroup>()
                .Property(x => x.ParentFK)
                .HasColumnOrder(order++)
                .IsOptional();



            modelBuilder.DefineTitleAndDescription<AccountRoleGroup>(ref order, true, false);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:
            modelBuilder.Entity<AccountRoleGroup>()
            .HasOptional(x => x.Parent)
            .WithMany(x => x.AccountGroups)
            .HasForeignKey(x => x.ParentFK)
            // When you delete this Property (Parent), 
            // you don't delete every child, so:
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountRoleGroup>()
                .HasMany(s => s.Roles)
                .WithMany()
                .Map(x =>
                {
                    x.ToTable(typeof(AccountRoleGroup).Name + "__" + typeof(AccountRole).Name);
                    x.MapLeftKey("AccountGroupFK");
                    x.MapRightKey("RoleFK");
                });
            // --------------------------------------------------

        }
    }
}

