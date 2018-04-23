using App.Module3.Infrastructure.Db.Schema.Conventions;

namespace App.Module3.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;

    public class AppModule3DbContextModelBuilderDefineAreaUnit : IHasAppModule3DbContextModelBuilderInitializer
    {
        private readonly TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention _schemaDefinitionDataConvetion;

        public AppModule3DbContextModelBuilderDefineAreaUnit(TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention schemaDefinitionDataConvetion)
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