namespace App.Module02.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Entities;
    using App.Module02.Infrastructure.Db.Context;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextSeederBody : IHasAppModuleDbContextSeedInitializer, IHasModuleSpecificIdentifier
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederBody(IHostSettingsService hostSettingsService)
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
            var records = new[]
            {
                //People:
                new Body
                {
                    Id = 1.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    Type = BodyType.Person,
                    CategoryFK = 1.ToGuid(),
                    Key = null,
                    GivenName = "Betty",
                    MiddleNames = "P.",
                    SurName = "Nelson"
                },
                new Body
                {
                    Id = 2.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    Type = BodyType.Person,
                    CategoryFK = 2.ToGuid(),
                    Key = null,
                    GivenName = "Craig",
                    SurName = "O'Neil"
                },
                new Body
                {
                    Id = 3.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    Type = BodyType.Person,
                    CategoryFK = 1.ToGuid(),
                    Key = null,
                    GivenName = "Daniella",
                    SurName = "Pearson",
                    Prefix = "Dr."
                },
                new Body
                {
                    Id = 4.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    Type = BodyType.Person,
                    CategoryFK = 2.ToGuid(),
                    Key = null,
                    GivenName = "Eric",
                    SurName = "Quail"
                },
                new Body
                {
                    Id = 5.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    Type = BodyType.Person,
                    CategoryFK = 3.ToGuid(),
                    Key = null,
                    GivenName = "Frank",
                    SurName = "Roberts"
                },
                //Corps:
                new Body
                {
                    Id = 101.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    RecordState = RecordPersistenceState.Active,
                    Type = BodyType.Organisation,
                    CategoryFK = 3.ToGuid(),
                    Key = "OrgXYZ",
                    Name = "GoodStuff, Inc."
                }
            };
            context.Set<Body>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }
    }
}