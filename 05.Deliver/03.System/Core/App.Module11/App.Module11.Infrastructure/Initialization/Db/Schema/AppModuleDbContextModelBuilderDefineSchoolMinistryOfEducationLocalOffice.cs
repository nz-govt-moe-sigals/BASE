namespace App.Module11.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module11.Infrastructure.Initialization.Db;
    using App.Module11.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice : IHasAppModuleDbContextModelBuilderInitializer
    {
                         
        private readonly TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention _modelBuilderConvention;
        
        public AppModuleDbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice(
            TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention 
            
            modelBuilderConvention)
        {
            this._modelBuilderConvention = modelBuilderConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._modelBuilderConvention.Define<SchoolMinistryOfEducationLocalOffice>(modelBuilder, ref order);
        }
    }
}





