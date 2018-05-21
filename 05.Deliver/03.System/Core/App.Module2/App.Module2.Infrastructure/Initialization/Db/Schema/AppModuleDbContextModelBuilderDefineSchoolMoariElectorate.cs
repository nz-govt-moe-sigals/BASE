namespace App.Module02.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineSchoolMoariElectorate : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention _modelBuilderConvention;

        public AppModuleDbContextModelBuilderDefineSchoolMoariElectorate(TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<SchoolMaoriElectorate>(modelBuilder, ref order);
        }
    }
}