using App.Module31.Shared.Models.Configuration;

namespace App.Module31.Infrastructure.Initialization.Authorisation
{
    using App.Core.Infrastructure.Initialization.Authentication;
    using App.Core.Infrastructure.Services;

    public class HasOidcScopeInitializer : IHasOidcScopeInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public HasOidcScopeInitializer(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
            var apiConsumerConfiguration = hostSettingsService.GetObject<ExampleApiConfiguration>("cookieAuth:");
            this.FullyQualifiedScopeDefinitions = new[]
            {
                "https://BaseCommonTest.onmicrosoft.com/BaseTest/module31_read",
                apiConsumerConfiguration.FQExampleReadScope,
                apiConsumerConfiguration.FQExampleWriteScope
            };
        }


        public string[] FullyQualifiedScopeDefinitions { get; }
    }
}




