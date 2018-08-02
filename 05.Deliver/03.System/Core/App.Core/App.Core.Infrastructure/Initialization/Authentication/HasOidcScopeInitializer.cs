using App.Core.Infrastructure.Services;
using App.Core.Shared.Constants;

namespace App.Core.Infrastructure.Initialization.Authentication
{
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
