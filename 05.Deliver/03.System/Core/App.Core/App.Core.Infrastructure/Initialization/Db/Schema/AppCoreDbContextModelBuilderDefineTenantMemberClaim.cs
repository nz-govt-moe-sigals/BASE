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
    public class AppCoreDbContextModelBuilderDefineTenantMemberClaim : IHasAppCoreDbContextModelBuilderInitializer
    { 
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;


            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberClaim>(modelBuilder, ref order);

            modelBuilder.Entity<TenantMemberClaim>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<TenantMemberClaim>()
                .Property(x => x.Authority)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(TenantMemberClaim).Name}_Authority") { IsUnique = false }))
                .IsRequired();

            modelBuilder.Entity<TenantMemberClaim>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(TenantMemberClaim).Name}_Key") { IsUnique = false }))
                .IsRequired();

            modelBuilder.Entity<TenantMemberClaim>()
                .Property(x => x.Value)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsOptional();
            modelBuilder.Entity<TenantMemberClaim>()
                .Property(x => x.AuthoritySignature)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired();
        }
    }
}