namespace App.Core.Infrastructure.Db.Migrations.Seeding
{
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Services;

    public class AppCoreDbContextSeederPrincipalClaim : IHasAppCoreDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppCoreDbContextSeederPrincipalClaim(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(AppCoreDbContext context)
        {

        }
    }
}