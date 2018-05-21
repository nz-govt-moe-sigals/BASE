using App.Module11.Infrastructure.Db.Schema.Conventions;

namespace App.Module11.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module11.Infrastructure.Initialization.Db;
    using App.Module11.Shared.Models.Entities;

    public class AppModule11DbContextModelBuilderDefineRegionalCouncil : IHasAppModule11DbContextModelBuilderInitializer
    {
        private readonly TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention _modelBuilderConvention;

        public AppModule11DbContextModelBuilderDefineRegionalCouncil(TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<RegionalCouncil>(modelBuilder, ref order);
        }
    }

}