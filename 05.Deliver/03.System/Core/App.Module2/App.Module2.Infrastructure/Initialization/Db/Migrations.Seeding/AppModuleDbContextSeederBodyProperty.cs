namespace App.Module02.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Module02.Infrastructure.Db.Context;
    using App.Module02.Infrastructure.Initialization;
    using App.Module02.Infrastructure.Initialization.Db;
    using App.Module02.Shared.Models.Entities;

    public class AppModuleDbContextSeederBodyProperty : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederBodyProperty(IHostSettingsService hostSettingsService)
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
                new BodyProperty
                {
                    Id = 1.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 1.ToGuid(),
                    Key = "SomePropA",
                    Value = "SomeValueA1"
                },
                new BodyProperty
                {
                    Id = 2.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 1.ToGuid(),
                    Key = "SomePropB",
                    Value = "SomeValueB1"
                },
                new BodyProperty
                {
                    Id = 3.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 1.ToGuid(),
                    Key = "SomePropC",
                    Value = "SomeValueC1"
                },
                new BodyProperty
                {
                    Id = 21.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 2.ToGuid(),
                    Key = "SomePropA",
                    Value = "SomeValueA2"
                },
                new BodyProperty
                {
                    Id = 22.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 2.ToGuid(),
                    Key = "SomePropB",
                    Value = "SomeValueB3"
                },
                new BodyProperty
                {
                    Id = 23.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 2.ToGuid(),
                    Key = "SomePropC",
                    Value = "SomeValueC4"
                },
                new BodyProperty
                {
                    Id = 31.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 3.ToGuid(),
                    Key = "SomePropA",
                    Value = "SomeValueA"
                },
                new BodyProperty
                {
                    Id = 41.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 4.ToGuid(),
                    Key = "SomePropA",
                    Value = "SomeValueA"
                },
                new BodyProperty
                {
                    Id = 51.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 5.ToGuid(),
                    Key = "SomePropA",
                    Value = "SomeValueA"
                },

                new BodyProperty
                {
                    Id = 101.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 101.ToGuid(),
                    Key = "SomePropA",
                    Value = "SomeValueA"
                }
            };
            context.Set<BodyProperty>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }
    }
}