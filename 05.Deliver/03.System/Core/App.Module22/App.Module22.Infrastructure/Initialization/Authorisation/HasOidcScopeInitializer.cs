namespace App.Module22.Infrastructure.Initialization.Authorisation
{
    using App.Core.Infrastructure.Initialization.Authentication;
    using App.Core.Infrastructure.Services;
    using App.Module22.Shared.Configuration.Models;

    public class HasOidcScopeInitializer : IHasOidcScopeInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public HasOidcScopeInitializer(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
            var apiConsumerConfiguration = hostSettingsService.GetObject<ApiPermissionConfig>("cookieAuth:");
            this.FullyQualifiedScopeDefinitions = new[]
            {
                apiConsumerConfiguration.FQExampleReadScope,
                apiConsumerConfiguration.FQExampleWriteScope
            };
        }


        public string[] FullyQualifiedScopeDefinitions { get; }
    }
}

