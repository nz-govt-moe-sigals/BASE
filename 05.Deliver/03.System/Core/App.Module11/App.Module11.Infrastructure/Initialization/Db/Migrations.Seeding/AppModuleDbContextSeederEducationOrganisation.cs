namespace App.Module11.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Entities;
    using App.Module11.Infrastructure.Db.Context;
    using App.Module11.Infrastructure.Initialization;
    using App.Module11.Infrastructure.Initialization.Db;
    using App.Module11.Shared.Models.Entities;

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

        /// <summary>
        /// Seed records that are part of this Module, no matter what (Immutable).
        /// <para>
        /// NOT the right place for demo entries, or data that will be updated
        /// by end users.
        /// </para>
        /// </summary>
        /// <param name="context"></param>
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





