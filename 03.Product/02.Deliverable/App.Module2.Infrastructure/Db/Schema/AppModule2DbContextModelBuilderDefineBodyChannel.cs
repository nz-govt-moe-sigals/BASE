namespace App.Module2.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineBodyChannel : IHasAppModule2DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;


            new TenantFKEtcConvention().Define<BodyChannel>(modelBuilder, ref order);


            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.OwnerFK)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.Protocol)
                .HasColumnOrder(order++)
                //.HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.Title)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.Address)
                .HasColumnOrder(order++)
                .HasMaxLength(256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressStreetAndNumber)
                .HasColumnOrder(order++)
                .HasMaxLength(256)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressSuburb)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressCity)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressRegion)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressState)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressPostalCode)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressCountry)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();
            modelBuilder.Entity<BodyChannel>()
                .Property(x => x.AddressInstructions)
                .HasColumnOrder(order++)
                .HasMaxLength(100)
                .IsOptional();
        }
    }
}