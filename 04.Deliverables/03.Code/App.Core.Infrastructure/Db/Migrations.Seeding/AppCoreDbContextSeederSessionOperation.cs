namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class AppCoreDbContextSeederSessionOperation : IHasAppCoreDbContextSeedInitializer
    {


        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederSessionOperation(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppCoreDbContext context)
        {
            CodeFirstMigrationConfiguration debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfiguration>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }


        protected void SeedImmutableEntries(AppCoreDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppCoreDbContext context)
        {
                var records = new[]
            {
                //People:
                new SessionOperation
                {
                    Id = 1.ToGuid(),
                    OwnerFK = 1.ToGuid(),
                    ClientIp = "12.34.56.78",
                    Url = "https://localhost:123/TenantA/Foo/Bar/12",
                    ResourceTenantKey="TenantA",
                    ControllerName = "FooController",
                    ActionName = "BarAction",
                    ActionArguments = "12",
                    Duration = TimeSpan.FromMilliseconds(112),
                    ResponseCode = "200"
    },
            };
            context.Set<SessionOperation>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }


    }
}