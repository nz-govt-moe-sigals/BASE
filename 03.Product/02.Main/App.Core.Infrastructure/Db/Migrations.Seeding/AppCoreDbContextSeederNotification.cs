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
    public class AppCoreDbContextSeederNotification : IHasAppCoreDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederNotification(IHostSettingsService hostSettingsService)
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
            var records = new []{
                    new Notification
                    {
                        Id = 1.ToGuid(),
                        TenantFK = 1.ToGuid(),
                        Type = NotificationType.Notification,
                        Level = TraceLevel.Info,
                        From = "System",
                        Class = "xyz",
                        ImageUrl = "...",
                        Text = "Some Message about Foo.",
                        DateTimeCreatedUtc = DateTime.UtcNow
                    },
                    new Notification
                    {
                        Id = 2.ToGuid(),
                        TenantFK = 1.ToGuid(),
                        Type = NotificationType.Message,
                        Level = TraceLevel.Warn,
                        From = "System",
                        Class = "xyz",
                        ImageUrl = "...",
                        Text = "Another Message for you.",
                        DateTimeCreatedUtc = DateTime.UtcNow
                    },
                    new Notification
                    {
                        Id = 3.ToGuid(),
                        TenantFK = 1.ToGuid(),
                        Type = NotificationType.Task,
                        Level = TraceLevel.Info,
                        From = "System",
                        Class = "xyz",
                        ImageUrl = "...",
                        Text = "A Message you've read.",
                        DateTimeCreatedUtc = DateTime.UtcNow,
                        DateTimeReadUtc = DateTime.UtcNow
                    }
            };

            context.Set<Notification>().AddOrUpdate(p => p.Id,records);
            context.SaveChanges();
        }
    }
}