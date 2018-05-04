namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppCoreDbContextModelBuilderDefinePrincipalCategory : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;


            new NonTenantFKEtcConvention().Define<PrincipalCategory>(modelBuilder, ref order);

            modelBuilder.Entity<PrincipalCategory>()
                .Property(x => x.Enabled)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<PrincipalCategory>()
                .Property(x => x.Text)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<PrincipalCategory>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<PrincipalCategory>()
                .Property(x => x.DisplayStyleHint)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsOptional();

        }
    }
}