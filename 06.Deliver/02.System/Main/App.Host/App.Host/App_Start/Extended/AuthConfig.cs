﻿using System.Collections.Generic;
using App.Core.Infrastructure.IDA.Models;
using App.Core.Infrastructure.IDA.Models.Enums;
using App.Core.Infrastructure.IDA.Models.Implementations;
using App.Core.Infrastructure.IDA.Owin;
using App.Core.Infrastructure.Initialization.Authentication;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Messages;
using Owin;

namespace App.Host.Extended
{
    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure
    /// the specified application builder.
    /// </summary>
    public class AuthConfig
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IAzureKeyVaultService _keyVaultService;
        private readonly IConfigurationStepService _configurationStepService;

        public AuthConfig(IDiagnosticsTracingService diagnosticsTracingService, IAzureKeyVaultService keyVaultService,
            IConfigurationStepService configurationStepService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._keyVaultService = keyVaultService;
            this._configurationStepService = configurationStepService;
        }
        /// <summary>
        /// Configures the specified application builder.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>
        /// </para>
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public void Configure(IAppBuilder appBuilder)
        {
            using (var elapsedTime = new ElapsedTime())
            {

                var scopes = ScanForAllModulesRequiredScopeDefinitions();

                var authorisationConfiguration = this._keyVaultService.GetObject<AuthorisationConfiguration>();
                var demoType = authorisationConfiguration.AuthorisationType;

                switch (demoType)
                {
                    case AuthorisationType.AadUsingOidcAndCookies:
                        AppDependencyLocator.Current.GetInstance<AadV2ForOidcCookiesConfiguration>()
                            .Configure(appBuilder);
                        break;
                    case AuthorisationType.B2CUsingOidcAndCookies:
                        AppDependencyLocator.Current.GetInstance<B2CAuthCookieBasedAuthenticationConfig>()
                            .Configure(appBuilder, scopes);
                        break;
                    case AuthorisationType.B2CUsingOidcAndBearerTokens:
                        AppDependencyLocator.Current.GetInstance<AuthBearerTokenAuthenticationConfiguration>()
                            .Configure(appBuilder);
                        break;
                    case AuthorisationType.B2CUsingOidcAndCookiesAndBearerTokens:
                        AppDependencyLocator.Current.GetInstance<AuthBearerTokenAuthenticationConfiguration>()
                            .Configure(appBuilder);
                        AppDependencyLocator.Current.GetInstance<B2CAuthCookieBasedAuthenticationConfig>()
                            .Configure(appBuilder, scopes);
                        break;
                }
                // 11.0836463 secs
                var color = ConfigurationStepStatus.Green;
                if (elapsedTime.Elapsed.TotalMilliseconds > 5000)
                {
                    color = ConfigurationStepStatus.Orange;
                }
                if (elapsedTime.Elapsed.TotalMilliseconds > 10000)
                {
                    color = ConfigurationStepStatus.Red;
                }

                _configurationStepService
                    .Register(
                        ConfigurationStepType.Performance,
                        color,
                        "Telemetry",
                        $"OIDC configuration. Took {elapsedTime.ElapsedText}.");
            }
        }

        private static string[] ScanForAllModulesRequiredScopeDefinitions()
        {
            var scopes = new string[] { };
            var t = new List<string>();
            AppDependencyLocator.Current.GetAllInstances<IHasOidcScopeInitializer>()
                .ForEach(x => t.AddRange(x.FullyQualifiedScopeDefinitions));
            scopes = t.ToArray();
            return scopes;
        }

        
    }
}