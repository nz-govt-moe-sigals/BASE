using App.Module11.Infrastructure.Db.Schema.Conventions;

namespace App.Module11.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module11.Infrastructure.Initialization.Db;
    using App.Module11.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineMaoriElectorate : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention _modelBuilderConvention;

        public AppModuleDbContextModelBuilderDefineMaoriElectorate(TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<MaoriElectorate>(modelBuilder, ref order);
        }
    }
}