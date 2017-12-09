namespace App.Module2.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineBodyCategory : IHasAppModule2DbContextModelBuilderInitializer
    {
        private readonly TenantedReferenceDataConvention _tenantedReferenceDataConvention;

        public AppModule2DbContextModelBuilderDefineBodyCategory(TenantedReferenceDataConvention tenantedReferenceDataConvention)
        {
            this._tenantedReferenceDataConvention = tenantedReferenceDataConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            _tenantedReferenceDataConvention.Define<BodyCategory>(modelBuilder, ref order);


        }
    }
}