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
    public class AppCoreDbContextSeederSession : IHasAppCoreDbContextSeedInitializer
    {


        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederSession(IHostSettingsService hostSettingsService)
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
                new Session
                {
                    Id = 0.ToGuid(),
                    Enabled = false,
                    CreatedOnUtc = DateTime.UtcNow,
                    PrincipalFK = 0.ToGuid()
                },

                    new Session
                {
                    Id = 1.ToGuid(),
                    Enabled = false,
                    CreatedOnUtc = DateTime.UtcNow.AddDays(-3),
                    PrincipalFK = 1.ToGuid()
                },
                new Session
                {
                    Id = 2.ToGuid(),
                    Enabled = false,
                    CreatedOnUtc = DateTime.UtcNow.AddDays(-6),
                    PrincipalFK = 1.ToGuid()
                }
            };
            context.Set<Session>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }


    }
}