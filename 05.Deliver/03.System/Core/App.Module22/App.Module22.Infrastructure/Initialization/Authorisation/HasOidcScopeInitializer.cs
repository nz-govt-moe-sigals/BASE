﻿using App.Module22.Shared.Constants;
using App.Core.Infrastructure.Initialization.Authentication;
using App.Core.Infrastructure.Services;

namespace App.Module22.Infrastructure.Initialization.Authorisation
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

