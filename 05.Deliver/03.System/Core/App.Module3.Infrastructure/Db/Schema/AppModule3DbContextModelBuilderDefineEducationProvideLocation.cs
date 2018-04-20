namespace App.Module3.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;

    public class AppModule3DbContextModelBuilderDefineEducationProvideLocation
        : IHasAppModule3DbContextModelBuilderInitializer
    {
        private readonly TenantFKEtcConvention _schemaDefinitionConvention;

        public AppModule3DbContextModelBuilderDefineEducationProvideLocation(TenantFKEtcConvention schemaDefinitionConvention)
        {
            this._schemaDefinitionConvention = schemaDefinitionConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._schemaDefinitionConvention.Define<EducationProviderLocation>(modelBuilder, ref order);

            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.EducationProviderFK)
                .HasColumnOrder(order++)
                .IsRequired();


            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.Longitude)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.Latitude)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<EducationProviderLocation>()
                .Property(x => x.Altitude)
                .HasColumnOrder(order++)
                .IsOptional();
        }
    }
}