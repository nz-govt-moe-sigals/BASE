using App.Module01.Shared.Constants;

namespace App.Module01.Infrastructure.Initialization.Authorisation
{
    using App.Core.Infrastructure.Initialization.Authentication;
    using App.Core.Infrastructure.Services;

    public class HasOidcScopeInitializer : IHasOidcScopeInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public HasOidcScopeInitializer(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
            var apiConsumerConfiguration = hostSettingsService.GetObject<App.Core.Shared.Models.ConfigurationSettings.ApiPermissionConfiguration>();
            var serviceIdentifer = apiConsumerConfiguration.ServiceIdentifier;
            this.FullyQualifiedScopeDefinitions = new[]
            {
                serviceIdentifer + AppModuleApiScopes.ReadScope,
                serviceIdentifer + AppModuleApiScopes.WriteScope
            };
        }


        public string[] FullyQualifiedScopeDefinitions { get; }
    }
}