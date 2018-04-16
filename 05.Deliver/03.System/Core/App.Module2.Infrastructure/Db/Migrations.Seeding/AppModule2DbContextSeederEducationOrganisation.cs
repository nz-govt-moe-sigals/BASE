namespace App.Module2.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Entities;
    using App.Module2.Infrastructure.Db.Context;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextSeederEducationOrganisation : IHasAppModule2DbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModule2DbContextSeederEducationOrganisation(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }


        public void Seed(AppModule2DbContext context)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppModule2DbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppModule2DbContext context)
        {
            var records = new EducationOrganisation[]
            {
                //People:
                //new EducationOrganisation()
                //{
                //    Id = 1.ToGuid(),
                //    TenantFK = 1.ToGuid(),
                //    RecordState = RecordPersistenceState.Active,
                //    Type = SchoolEstablishmentType.School,

                //    CategoryFK = 1.ToGuid(),
                //    Key = null,
                //    GivenName = "Betty",
                //    MiddleNames = "P.",
                //    SurName = "Nelson"
            };
            context.Set<EducationOrganisation>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }
    }
}