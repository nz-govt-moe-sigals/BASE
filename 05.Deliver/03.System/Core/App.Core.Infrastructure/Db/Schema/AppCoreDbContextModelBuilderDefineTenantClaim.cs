namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppCoreDbContextModelBuilderDefineTenantClaim : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new NonTenantFKEtcConvention().Define<TenantClaim>(modelBuilder, ref order);


            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.Authority)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_TenantClaim_Authority") { IsUnique = false }))
                .IsRequired();
            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_TenantClaim_Key") { IsUnique = false }))
                .IsRequired();

            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.Value)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsOptional();

            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.AuthoritySignature)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired();
        }
    }
}