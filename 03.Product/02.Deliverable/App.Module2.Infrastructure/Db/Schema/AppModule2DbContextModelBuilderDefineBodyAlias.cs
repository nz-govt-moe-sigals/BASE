namespace App.Module2.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineBodyAlias : IHasAppModule2DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKEtcConvention().Define<BodyAlias>(modelBuilder, ref order);

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
                .HasMaxLength(256)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.Prefix)
                .HasColumnOrder(order++)
                .HasMaxLength(50)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.GivenName)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.MiddleNames)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.SurName)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();

            modelBuilder.Entity<BodyAlias>()
                .Property(x => x.Suffix)
                .HasColumnOrder(order++)
                .HasMaxLength(50)
                .IsOptional();
        }
    }
}