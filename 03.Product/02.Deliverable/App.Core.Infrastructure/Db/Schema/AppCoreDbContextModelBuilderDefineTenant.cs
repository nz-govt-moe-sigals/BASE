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
    public class AppCoreDbContextModelBuilderDefineTenant : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new NonTenantFKEtcConvention().Define<Tenant>(modelBuilder, ref order);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.IsDefault)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_Tenant_IsDefault") {IsUnique = true}))
                .HasColumnOrder(order++)
                .IsOptional();

            modelBuilder.Entity<Tenant>()
                .Property(x => x.Enabled)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Tenant>()
                .HasOptional(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.Key)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_Tenant_Key") {IsUnique = true}))
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();
            modelBuilder.Entity<Tenant>()
                .Property(x => x.HostName)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_Tenant_HostName") {IsUnique = true}))
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<Tenant>()
                .Property(x => x.DisplayName)
                .HasColumnOrder(order++)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_Tenant_DisplayName") { IsUnique = false }))
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<Tenant>()
                .HasMany(x => x.Properties)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);

            modelBuilder.Entity<Tenant>()
                .HasMany(x => x.Claims)
                .WithOptional()
                .HasForeignKey(x => x.OwnerFK);
        }
    }
}