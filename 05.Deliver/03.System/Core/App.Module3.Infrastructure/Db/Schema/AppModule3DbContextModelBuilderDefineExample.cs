namespace App.Module3.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module3.Infrastructure.Initialization;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModule3DbContextModelBuilderDefineExample : IHasAppModule3DbContextModelBuilderInitializer
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