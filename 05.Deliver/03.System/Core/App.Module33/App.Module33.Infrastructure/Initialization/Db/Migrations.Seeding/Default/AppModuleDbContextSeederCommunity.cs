using System.Data.Entity.Migrations;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Module33.Infrastructure.Db.Context.Default;
using App.Module33.Shared.Models.Entities;

namespace App.Module33.Infrastructure.Initialization.Db.Migrations.Seeding.Default
{
    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    public class AppModuleDbContextSeederCommunity : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederCommunity(IHostSettingsService hostSettingsService)
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
                new Community
                {
                    Id = 1.ToGuid(),
                    Owner = "jSmith",
                    PublicText = "Some publicly viewable Text...",
                    SensitiveText = "Some sensitive Data (eg: GovId:ABC1234)",
                    AppPrivateText = "Some App-Private Text (you should *not* see it)...",
                    Name = "Common Thinking Community",
                    Description = "A community for like minded thinkers.",
                    ColourSchemeFK = 1.ToGuid(),
                    Strategy = "Our strategy is to follow the status quo."
                },
                new Community
                {
                    Id = 2.ToGuid(),
                    Owner = "jSmith",
                    PublicText = "Some publicly viewable Text...",
                    SensitiveText = "Some sensitive Data (eg: GovId:ABC1234)",
                    AppPrivateText = "Some App-Private Text (you should *not* see it)...",
                    Name = "Alternative Thinking Community",
                    Description = "A community for alternative thinkers.",
                    ColourSchemeFK = 2.ToGuid(),
                    Strategy = "Our strategy is to do things differently to others."
                }
            };

            var dbSet = context.Set<Community>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}

