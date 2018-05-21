using App.Module11.Infrastructure.Db.Schema.Conventions;

namespace App.Module11.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module11.Infrastructure.Initialization.Db;
    using App.Module11.Shared.Models.Entities;

    public class AppModuleDbContextModelBuilderDefineAreaUnit : IHasAppModuleDbContextModelBuilderInitializer
    {
        private readonly TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention _schemaDefinitionDataConvetion;

        public AppModuleDbContextModelBuilderDefineAreaUnit(TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention schemaDefinitionDataConvetion)
        {
            this._schemaDefinitionDataConvetion = schemaDefinitionDataConvetion;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            this._schemaDefinitionDataConvetion.Define<AreaUnit>(modelBuilder, ref order);
        }
    }
}