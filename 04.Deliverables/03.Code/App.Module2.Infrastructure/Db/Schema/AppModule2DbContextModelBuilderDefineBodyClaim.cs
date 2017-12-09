namespace App.Module2.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineBodyClaim : IHasAppModule2DbContextModelBuilderInitializer
    {
        private readonly TenantFKEtcConvention _tenantFkEtcConvention;

        public AppModule2DbContextModelBuilderDefineBodyClaim(TenantFKEtcConvention tenantFkEtcConvention)
        {
            this._tenantFkEtcConvention = tenantFkEtcConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            _tenantFkEtcConvention.Define<BodyClaim>(modelBuilder, ref order);

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.Authority)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();
            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.Value)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X1024)
                .IsOptional();

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.AuthoritySignature)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X1024)
                .IsRequired();
        }
    }
}