namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppCoreDbContextModelBuilderDefinePrincipalTag : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;


            new NonTenantFKEtcConvention().Define<PrincipalTag>(modelBuilder, ref order);

            modelBuilder.Entity<PrincipalTag>()
                .Property(x => x.Enabled)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<PrincipalTag>()
                .Property(x => x.Text)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_PrincipalTag_Text") { IsUnique = false }))
                .IsRequired();

            modelBuilder.Entity<PrincipalTag>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<PrincipalTag>()
                .Property(x => x.DisplayStyleHint)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();
        }
    }
}