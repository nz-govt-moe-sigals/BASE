namespace App.Module2.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineBodyClaim : IHasAppModule2DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKEtcConvention().Define<BodyClaim>(modelBuilder, ref order);

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.Authority)
                .HasColumnOrder(order++)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.Value)
                .HasColumnOrder(order++)
                .HasMaxLength(1024)
                .IsOptional();

            modelBuilder.Entity<BodyClaim>()
                .Property(x => x.AuthoritySignature)
                .HasColumnOrder(order++)
                .HasMaxLength(1024)
                .IsRequired();
        }
    }
}