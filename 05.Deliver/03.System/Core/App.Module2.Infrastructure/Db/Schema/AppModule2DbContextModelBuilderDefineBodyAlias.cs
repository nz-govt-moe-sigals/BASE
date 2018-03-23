namespace App.Module2.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineBodyAlias : IHasAppModule2DbContextModelBuilderInitializer
    {
        private readonly TenantFKEtcConvention _tenantFkEtcConvention;

        public AppModule2DbContextModelBuilderDefineBodyAlias(TenantFKEtcConvention tenantFkEtcConvention)
        {
            this._tenantFkEtcConvention = tenantFkEtcConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            _tenantFkEtcConvention.Define<BodyAlias>(modelBuilder, ref order);

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.RecordState)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.Name)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.Prefix)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.GivenName)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.MiddleNames)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.SurName)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X256)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.Suffix)
                .HasColumnOrder(order++)
                .HasMaxLength(App.Core.Infrastructure.Constants.Db.TextFieldSizes.X64)
                .IsOptional();
        }
    }
}