namespace App.Core.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    public class AppCoreDbContextModelBuilderDefineTenantMemberCategory : IHasAppModuleDbContextModelBuilderInitializer
    { 
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberCategory>(modelBuilder, ref order);

            // Note that this Schema uses an Enum as the Id:

            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);

        }
    }
}