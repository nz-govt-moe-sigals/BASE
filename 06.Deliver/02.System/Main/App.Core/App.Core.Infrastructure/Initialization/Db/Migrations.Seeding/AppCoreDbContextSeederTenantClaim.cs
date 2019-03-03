namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Context.Default;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class AppCoreDbContextSeederTenantClaim : IHasAppModuleDbContextSeedInitializer
    {



        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederTenantClaim(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppCoreDbContext context)
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
        protected void SeedImmutableEntries(AppCoreDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppCoreDbContext context)
        {

            var records = new[]
            {
                new TenantClaim
                {
                    Id = 1.ToGuid(),
                    TenantFK = Constants.Demo.Tenancies.A.Id,
                    Authority = "N/A",
                    AuthoritySignature = "A",
                    Key = "SomePropA",
                    Value = "SomeValueA1"
                },
                new TenantClaim
                {
                    Id = 2.ToGuid(),
                    TenantFK = Constants.Demo.Tenancies.A.Id,
                    Authority = "N/A",
                    AuthoritySignature = "A",
                    Key = "SomePropB",
                    Value = "SomeValueB1"
                },

                new TenantClaim
                {
                    Id = 3.ToGuid(),
                    TenantFK = Constants.Demo.Tenancies.B.Id,
                    Authority = "N/A",
                    AuthoritySignature = "A",
                    Key = "SomePropA",
                    Value = "SomeValueA1"
                },
                new TenantClaim
                {
                    Id = 4.ToGuid(),
                    TenantFK = Constants.Demo.Tenancies.B.Id,
                    Authority = "N/A",
                    AuthoritySignature = "A",
                    Key = "SomePropB",
                    Value = "SomeValueB1"
                }
            };
            context.Set<TenantClaim>().AddOrUpdate(p => p.Id, records);
        }
    }
}