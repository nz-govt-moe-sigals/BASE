namespace App.Module3.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;


    public class AppModule3DbContextModelBuilderDefineRegion : IHasAppModule3DbContextModelBuilderInitializer
    {
        private readonly TenantedFIRSTSIFKeyedGuidIdReferenceDataConvention _schemaDefinitionConvention;

        public AppModule3DbContextModelBuilderDefineRegion(TenantedFIRSTSIFKeyedGuidIdReferenceDataConvention schemaDefinitionConvention)
        {
            this._schemaDefinitionConvention = schemaDefinitionConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._schemaDefinitionConvention.Define<Region>(modelBuilder, ref order);
        }
    }

}