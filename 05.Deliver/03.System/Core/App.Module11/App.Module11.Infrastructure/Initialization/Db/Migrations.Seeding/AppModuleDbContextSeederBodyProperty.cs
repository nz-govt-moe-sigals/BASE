namespace App.Module11.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Module11.Infrastructure.Db.Context;
    using App.Module11.Infrastructure.Initialization;
    using App.Module11.Infrastructure.Initialization.Db;
    using App.Module11.Shared.Models.Entities;

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





