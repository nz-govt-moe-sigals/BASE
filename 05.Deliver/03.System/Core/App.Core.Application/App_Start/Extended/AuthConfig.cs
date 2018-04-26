namespace App.Core.Application.Extended
{
    using System.Collections.Generic;
    using App.Core.Infrastructure.IDA.Models;
    using App.Core.Infrastructure.IDA.Models.Enums;
    using App.Core.Infrastructure.IDA.Owin;
    using App.Core.Infrastructure.Initialization.Authentication;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;
    using Owin;

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
                var demoType = authorisationConfiguration.AuthorisationDemoType;

                switch (demoType)
                {
                    case AuthorisationDemoType.AADUsingOIDCAndCookies:
                        AppDependencyLocator.Current.GetInstance<AADV2ForOIDCCookiesConfiguration>()
                            .Configure(appBuilder);
                        break;
                    case AuthorisationDemoType.B2CUsingOIDCAndCookies:
                        AppDependencyLocator.Current.GetInstance<B2COAuthCookieBasedAuthenticationConfig>()
                            .Configure(appBuilder, scopes);
                        break;
                    case AuthorisationDemoType.B2CUsingOIDCAndBearerTokens:
                        AppDependencyLocator.Current.GetInstance<B2COAuthBearerTokenAuthenticationConfiguration>()
                            .Configure(appBuilder);
                        break;
                    case AuthorisationDemoType.B2CUsingOIDCAndCookiesAndBearerTokens:
                        AppDependencyLocator.Current.GetInstance<B2COAuthBearerTokenAuthenticationConfiguration>()
                            .Configure(appBuilder);
                        AppDependencyLocator.Current.GetInstance<B2COAuthCookieBasedAuthenticationConfig>()
                            .Configure(appBuilder, scopes);
                        break;
                }
                // 11.0836463 secs
                _configurationStepService
                    .Register(
                        ConfigurationStepType.Performance,
                        ConfigurationStepStatus.Green,
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