using App.Module3.Infrastructure.Db.Schema.Conventions;

namespace App.Module3.Infrastructure.Db.Schema
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module3.Infrastructure.Initialization.Db;
    using App.Module3.Shared.Models.Entities;

    public class AppModule3DbContextModelBuilderDefineAuthorityType : IHasAppModule3DbContextModelBuilderInitializer
    {
        private readonly TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention _schemaDefinitionConvention;

        public AppModule3DbContextModelBuilderDefineAuthorityType(TenantedSIFSourceSystemKeyedGuidIdReferenceDataConvention schemaDefinitionConvention)
        {
            this._schemaDefinitionConvention = schemaDefinitionConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._schemaDefinitionConvention.Define<AuthorityType>(modelBuilder, ref order);
        }
    }
}