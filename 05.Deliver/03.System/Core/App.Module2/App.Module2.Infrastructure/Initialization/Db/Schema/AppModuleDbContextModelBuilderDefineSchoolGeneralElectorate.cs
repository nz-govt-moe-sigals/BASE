namespace App.Module02.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineSchoolGeneralElectorate : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention _modelBuilderConvention;

        public AppModuleDbContextModelBuilderDefineSchoolGeneralElectorate(TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<SchoolGeneralElectorate>(modelBuilder, ref order);
        }
    }
}