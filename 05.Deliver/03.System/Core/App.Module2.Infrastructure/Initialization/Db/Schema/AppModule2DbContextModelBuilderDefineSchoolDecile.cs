namespace App.Module2.DbContextModelBuilder
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineSchoolDecile : IHasAppModule2DbContextModelBuilderInitializer
    {
        private readonly TenantedReferenceDataConvention _tenantedReferenceDataConvention;

        public AppModule2DbContextModelBuilderDefineSchoolDecile(TenantedReferenceDataConvention tenantedReferenceDataConvention)
        {
            this._tenantedReferenceDataConvention = tenantedReferenceDataConvention;
        }

        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._tenantedReferenceDataConvention.Define<SchoolDecile>(modelBuilder, ref order);
        }
    }

}