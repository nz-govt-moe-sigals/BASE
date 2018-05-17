using App.Module3.Infrastructure.Db.Schema.Conventions;

namespace App.Module3.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;

    public class AppModule3DbContextModelBuilderDefineOrganisationType : IHasAppModule3DbContextModelBuilderInitializer
    {
        private readonly TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention _modelBuilderConvention;

        public AppModule3DbContextModelBuilderDefineOrganisationType(TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<EducationProviderType>(modelBuilder, ref order);
        }
    }
}