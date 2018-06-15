﻿namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
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
    public class AppCoreDbContextSeederExceptionRecord : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederExceptionRecord(IHostSettingsService hostSettingsService)
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
            var records = new []{
                    new ExceptionRecord()
                    {
                        Id = 1.ToGuid(),
                        Level = TraceLevel.Warn,
                        Title="Demo Warning",
                        Stack = "blah...."
                    },
                new ExceptionRecord()
                {
                    Id = 2.ToGuid(),
                    Level = TraceLevel.Error,
                    Title="Demo Error",
                    Stack = "blah again...."
                },
            };

            context.Set<ExceptionRecord>().AddOrUpdate(p => p.Id,records);
            context.SaveChanges();
        }
    }
}