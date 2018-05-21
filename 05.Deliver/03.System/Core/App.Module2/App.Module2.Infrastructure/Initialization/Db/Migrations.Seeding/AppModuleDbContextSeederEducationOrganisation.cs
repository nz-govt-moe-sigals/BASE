namespace App.Module02.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Entities;
    using App.Module02.Infrastructure.Db.Context;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextSeederEducationOrganisation : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederEducationOrganisation(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }


        public void Seed(AppModuleDbContext context)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppModuleDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppModuleDbContext context)
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