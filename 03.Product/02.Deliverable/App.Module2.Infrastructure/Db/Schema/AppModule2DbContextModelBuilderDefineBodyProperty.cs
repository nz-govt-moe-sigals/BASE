namespace App.Module2.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineBodyProperty : IHasAppModule2DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKEtcConvention().Define<BodyProperty>(modelBuilder, ref order);


            modelBuilder.Entity<BodyProperty>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyProperty>()
                .Property(x => x.Key)
                .HasColumnOrder(order++)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<BodyProperty>()
                .Property(x => x.Value)
                .HasColumnOrder(order++)
                .HasMaxLength(1024)
                .IsOptional();
        }
    }
}