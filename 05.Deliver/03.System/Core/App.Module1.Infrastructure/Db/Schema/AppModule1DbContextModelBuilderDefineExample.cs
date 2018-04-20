namespace App.Module2.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModule1DbContextModelBuilderDefineExample : IHasAppModule1DbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKEtcConvention().Define<Example>(modelBuilder, ref order);


            modelBuilder.Entity<Example>()
                .Property(x => x.Owner)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<Example>()
                .Property(x => x.PublicText)
                .HasColumnOrder(order++)
                .IsRequired();
            modelBuilder.Entity<Example>()
                .Property(x => x.SensitiveText)
                .HasColumnOrder(order++)
                .IsOptional();
            modelBuilder.Entity<Example>()
                .Property(x => x.AppPrivateText)
                .HasColumnOrder(order++)
                .IsOptional();
        }
    }
}