namespace App.Module2.DbContextModelBuilder
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice : IHasAppModule2DbContextModelBuilderInitializer
    {
        private readonly TenantedReferenceDataConvention _tenantedReferenceDataConvention;

        public AppModule2DbContextModelBuilderDefineSchoolMinistryOfEducationLocalOffice(TenantedReferenceDataConvention tenantedReferenceDataConvention)
        {
            this._tenantedReferenceDataConvention = tenantedReferenceDataConvention;
        }
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;
            this._tenantedReferenceDataConvention.Define<SchoolMinistryOfEducationLocalOffice>(modelBuilder, ref order);
        }
    }
}