namespace App.Module2.Infrastructure.Db.Migrations.Seeding
{
    using System.Data.Entity.Migrations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Module2.Infrastructure.Db.Context;
    using App.Module2.Infrastructure.Initialization;
    using App.Module2.Infrastructure.Initialization.Db;
    using App.Module2.Shared.Models.Entities;

    public class AppModule2DbContextSeederBodyClaim : IHasAppModule2DbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModule2DbContextSeederBodyClaim(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppModule2DbContext context)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        protected void SeedImmutableEntries(AppModule2DbContext context)
        {
        }

        protected void SeedDevOnlyEntries(AppModule2DbContext context)
        {
            var records = new[]
            {
                //Bodies:
                new BodyChannel
                {
                    Id = 11.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 1.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Landline,
                    Title = "Home Phone",
                    Address = "+64 (19) 123 4567"
                },
                new BodyChannel
                {
                    Id = 12.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 1.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Landline,
                    Title = "Work Phone",
                    Address = "+64 (19) 234 5678"
                },
                new BodyChannel
                {
                    Id = 13.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 1.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Email,
                    Title = "Work Email",
                    Address = "betty@corp.demo"
                },

                new BodyChannel
                {
                    Id = 21.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 2.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Twitter,
                    Title = "Mobile",
                    Address = "+64 (21) 987 6543"
                },
                new BodyChannel
                {
                    Id = 22.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 2.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Twitter,
                    Title = "Personal Twitter",
                    Address = "@reallyhatetweets"
                },
                new BodyChannel
                {
                    Id = 23.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 2.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Email,
                    Title = "Email",
                    Address = "craig@corp.demo"
                },

                new BodyChannel
                {
                    Id = 31.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 3.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Landline,
                    Title = "Personal",
                    Address = "+64 (21) 987 6543"
                },
                new BodyChannel
                {
                    Id = 32.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 3.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Postal,
                    Title = "Work",
                    AddressStreetAndNumber = "123 Goodluck Road",
                    AddressCity = "Wellington",
                    AddressState = "XR",
                    AddressCountry = "New Estonia"
                },
                new BodyChannel
                {
                    Id = 33.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 3.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Email,
                    Title = "Email",
                    Address = "daniella@corp.demo"
                },

                new BodyChannel
                {
                    Id = 41.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 4.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Postal,
                    Title = "Home",
                    Address = "@demo1",
                    AddressStreetAndNumber = "123 Goodluck Road",
                    AddressCity = "Wellington",
                    AddressState = "XR",
                    AddressCountry = "New Estonia"
                },
                new BodyChannel
                {
                    Id = 42.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 4.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Email,
                    Title = "Email",
                    Address = "eric@corp.demo"
                },

                new BodyChannel
                {
                    Id = 51.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 5.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Twitter,
                    Title = "Mobile",
                    Address = "+64 (21) 987 6547"
                },
                new BodyChannel
                {
                    Id = 52.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 5.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Email,
                    Title = "Work Email",
                    Address = "frankiiiiie@corp.demo"
                },

                //Corps:
                new BodyChannel
                {
                    Id = 101.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 101.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Email,
                    Title = "Work Email",
                    Address = "info@goodstuff.demo"
                },
                new BodyChannel
                {
                    Id = 102.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 101.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Landline,
                    Title = "Work Phone",
                    Address = "+64 (19) 233 5678"
                },
                new BodyChannel
                {
                    Id = 103.ToGuid(),
                    TenantFK = 1.ToGuid(),
                    OwnerFK = 101.ToGuid(),
                    DisplayOrderHint = 0,
                    Protocol = BodyChannelType.Email,
                    Title = "Work Email",
                    Address = "ccccccc@corp.demo"
                }
            };
            context.Set<BodyChannel>().AddOrUpdate(p => p.Id, records);
            context.SaveChanges();
        }
    }
}