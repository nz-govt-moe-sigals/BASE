namespace App.Module02.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;
     
    public class AppModuleDbContextModelBuilderDefineSchoolType : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention _modelBuilderConvention;

        public AppModuleDbContextModelBuilderDefineSchoolType(TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<SchoolType>(modelBuilder, ref order);
        }
    }
}