using App.Module31.Infrastructure.Db.Schema.Conventions;

namespace App.Module31.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module31.Infrastructure.Initialization.Db;
    using App.Module31.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineCommunityBoard : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention _modelBuilderConvention;

        public AppModuleDbContextModelBuilderDefineCommunityBoard(TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<CommunityBoard>(modelBuilder, ref order);
        }
    }
}




